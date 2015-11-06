using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.SemanticModels.LTS.Assertion;
using PAT.Common.ModelCommon.PNCommon;
using System.Diagnostics;


namespace PAT.Common.GUI.ModelChecker
{
    public partial class ModelCheckingForm : Form, ResourceFormInterface, ISpecificationWorker
    {
        public static ModelCheckingForm ModelCheckingFormInstance = null;
        private const string mystring = "(*)";
        private const string ValidString = "VALID";
        private const string NotValidString = "NOT valid";

        private const int CORRECT_ICON = 0;
        private const int WRONG_ICON = 1;
        private const int UNKNOWN_ICON = 2;
        private const int CORRECT_ICON_PRPB = 3;

        //localized string for the button text display
        private System.ComponentModel.ComponentResourceManager resources;
        private string STOP;
        private string VERIFY;

        private PNExtendInfo mExtendInfo;

        // CPU usage and RAM available analytics
        protected PerformanceCounter mRAMCounter;
        protected PerformanceCounter mCPUCounter;

        private LatexWorker mLatexWorker;
        private SpecificationWorker mSpecWorker;

        private static Font fnt = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
        private static Font fntBold = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point);


        public ModelCheckingForm()
        {
            InitializeComponent();
            initPerformanceAnalytics();
        }

        public ModelCheckingForm(string Name, SpecificationBase spec, PNExtendInfo extendInfo)
        {
            mSpecWorker = new SpecificationWorker(spec, this, this);
            mExtendInfo = extendInfo;

            InitializeComponent();
            initPerformanceAnalytics();
            initLogic();
            mLatexWorker = new LatexWorker(extendInfo, Name);

            if (Name != "")
            {
#if DEBUG
                Text = Text + " (Debug Model) - " + Name;
#else
            this.Text = this.Text + " - " + Name; 
#endif
            }
        }

        private void initPerformanceAnalytics()
        {
            mCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            mRAMCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            perfomanceTimer.Start();
        }

        protected void initLogic()
        {
            ModelCheckingFormInstance = this;
            InitializeResourceText();

            int Index = 1;
            ListView_Assertions.Items.Clear();
            foreach (KeyValuePair<string, AssertionBase> entry in mSpecWorker.mSpec.AssertionDatabase)
            {
                ListViewItem item = new ListViewItem(new string[] { "", Index.ToString(), entry.Key });

                // If the assertion is LTL, the button of the view BA should be enabled.
                if (entry.Value is AssertionLTL)
                    item.Tag = "LTL";                             

                // Set the question mark image
                item.ImageIndex = 2;

                this.ListView_Assertions.Items.Add(item);
                Index++;
            }

            this.StatusLabel_Text.Text = Resources.Select_an_assertion_to_start_with;
        }

        public void InitializeResourceText()
        {
            resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelCheckingForm));
            STOP = resources.GetString("Button_Verify_Stop") ?? "Stop";
            VERIFY = resources.GetString("Button_Verify.Text") ?? "Verify";

        }

        #region UI Operations

        private void TextBox_Output_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.ContextMenu.Show(this.TextBox_Output, e.Location);
            }
        }

        private void MenuItem_Copy_Click(object sender, EventArgs e)
        {
            this.TextBox_Output.Copy();
        }

        private void MenuItem_SelectAll_Click(object sender, EventArgs e)
        {
            this.TextBox_Output.SelectedText = this.TextBox_Output.Text;
        }

        private void MenuItem_Clear_Click(object sender, EventArgs e)
        {
            this.TextBox_Output.Text = "";
        }

        private void MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Title = "Save Output File";
            svd.Filter = "Text Files|*.txt|All files|*.*";

            if (svd.ShowDialog() == DialogResult.OK)
            {
                TextWriter tr = new StreamWriter(svd.FileName);
                tr.WriteLine(this.TextBox_Output.Text);
                tr.Flush();
                tr.Close();
            }
        }

        private void Button_BAGraph_Click(object sender, EventArgs e)
        {
            do
            {
                if (ListView_Assertions.SelectedItems.Count == 0)
                {
                    MessageBox.Show(Resources.Please_select_an_assertion_first, Common.Utility.Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                try
                {
                    if (this.ListView_Assertions.SelectedItems.Count == 1)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Graph g = mSpecWorker.mSpec.GenerateBAGraph(this.ListView_Assertions.SelectedItems[0].SubItems[2].Text);
                        this.Cursor = Cursors.Default;

                        if (g != null)
                        {
                            LTL2AutoamataConverter v = new LTL2AutoamataConverter(g.UserData.ToString(), "");
                            v.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    Common.Utility.Utilities.LogException(ex, mSpecWorker.mSpec);
                }
            } while (false);
        }

        #endregion

        private void ListView_Assertions_DoubleClick(object sender, EventArgs e)
        {
            do
            {
                if (ListView_Assertions.SelectedItems.Count == 0)
                {
                    MessageBox.Show(Resources.Please_select_an_assertion_first, Common.Utility.Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                VerificationIndex = 0;
                mSpecWorker.startVerification(ListView_Assertions.SelectedItems[VerificationIndex].SubItems[2].Text, NumericUpDown_TimeOut.Value);
            } while (false);
        }

        private int VerificationIndex = -1;
        private void Button_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Button_Verify.Text == STOP)
                {
                    if (mSpecWorker.mAssertion != null)
                    {
                        Button_Verify.Enabled = false;
                        mSpecWorker.mAssertion.Cancel();
                    }
                }
                else
                {
                    if (ListView_Assertions.SelectedItems.Count == 0)
                    {
                        MessageBox.Show(Resources.Please_select_an_assertion_first, Common.Utility.Utilities.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    VerificationIndex = 0;
                    mSpecWorker.startVerification(
                        ListView_Assertions.SelectedItems[VerificationIndex].SubItems[2].Text,
                        NumericUpDown_TimeOut.Value);
                }
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpecWorker.mSpec);
            }
        }

        private void ColorText(int start)
        {
            int index = int.MaxValue;
            int indexCase = 0;
            int index1 = TextBox_Output.Find(mystring, start, -1, RichTextBoxFinds.WholeWord);

            if (index1 > 0 && index1 < index)
            {
                index = index1;
                indexCase = 0;
            }

            index1 = TextBox_Output.Find("-> (", start, -1, RichTextBoxFinds.None);
            if (index1 > 0 && index1 < index)
            {
                index = index1;
                indexCase = 1;
            }

            index1 = TextBox_Output.Find(ValidString, start, -1, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
            if (index1 > 0 && index1 < index)
            {
                index = index1;
                indexCase = 2;
            }

            index1 = TextBox_Output.Find(NotValidString, start, -1, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
            if (index1 > 0 && index1 < index)
            {
                index = index1;
                indexCase = 3;
            }

            index1 = TextBox_Output.Find(Common.Classes.Ultility.Constants.VERFICATION_RESULT_STRING, start, -1, RichTextBoxFinds.WholeWord | RichTextBoxFinds.MatchCase);
            if (index1 >= 0 && index1 < index)
            {
                index = index1;
                indexCase = 4;
            }

            if (index != int.MaxValue)
            {
                switch (indexCase)
                {
                    case 0:
                        TextBox_Output.SelectionStart = index;
                        TextBox_Output.SelectionLength = mystring.Length;
                        TextBox_Output.SelectionFont = fnt;
                        TextBox_Output.SelectionColor = System.Drawing.Color.Red;
                        TextBox_Output.SelectionBackColor = System.Drawing.Color.Yellow;
                        ColorText(index + mystring.Length);
                        return;

                    case 1:
                        int endIndex = TextBox_Output.Find(")*", start, -1, RichTextBoxFinds.None);
                        if (endIndex > 0)
                        {
                            index = index + 3;
                            if (endIndex - index + 2 > 0)
                            {
                                TextBox_Output.SelectionStart = index;

                                TextBox_Output.SelectionLength = endIndex - index + 2;
                                TextBox_Output.SelectionFont = fnt;
                                TextBox_Output.SelectionColor = System.Drawing.Color.Red;
                                TextBox_Output.SelectionBackColor = System.Drawing.Color.Yellow;
                            }
                            ColorText(endIndex + 2);
                        }
                        return;

                    case 2:
                        TextBox_Output.SelectionStart = index;
                        TextBox_Output.SelectionLength = ValidString.Length;
                        TextBox_Output.SelectionFont = fntBold;
                        TextBox_Output.SelectionColor = System.Drawing.Color.Green;
                        ColorText(index + 2);
                        return;

                    case 3:
                        TextBox_Output.SelectionStart = index;
                        TextBox_Output.SelectionLength = NotValidString.Length;
                        TextBox_Output.SelectionFont = fntBold;
                        TextBox_Output.SelectionColor = System.Drawing.Color.Red;
                        ColorText(index + 2);
                        return;

                    case 4:
                        TextBox_Output.SelectionStart = index;
                        TextBox_Output.SelectionLength = Common.Classes.Ultility.Constants.VERFICATION_RESULT_STRING.Length;
                        TextBox_Output.SelectionFont = fntBold;
                        TextBox_Output.SelectionColor = System.Drawing.Color.Blue;
                        ColorText(index + Common.Classes.Ultility.Constants.VERFICATION_RESULT_STRING.Length);
                        return;
                }
            }
        }

        private void OnAction(string action)
        {
            TextBox_Output.Text = action + TextBox_Output.Text;
        }

        private void Button_SimulateCounterExample_Click(object sender, EventArgs e)
        {
            try
            {
                PAT.Common.GUI.SimulationForm form = new PAT.Common.GUI.SimulationForm();
                form.SetSpec(this.Button_SimulateWitnessTrace.Tag.ToString(),
                    this.Button_SimulateWitnessTrace.Tag.ToString(),
                    mSpecWorker.mSpec, mSpecWorker.mAssertion);
                form.Show();
                //form.Refresh();
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpecWorker.mSpec);
                //MessageBox.Show("Exception happened: " + ex.Message + "\r\n" + ex.StackTrace,"PAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView_Assertions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (ListView_Assertions.SelectedItems.Count != 1)
                {
                    mSpecWorker.mAssertion = null;

                    if (ListView_Assertions.SelectedItems.Count == 0)
                    {
                        //set text
                        Label_SelectedAssertion.Text = "";
                        Button_BAGraph.Enabled = false;
                        Button_SimulateWitnessTrace.Enabled = false;

                        Button_Verify.Enabled = false;
                        this.StatusLabel_Text.Text = Resources.Select_an_assertion_to_start_with;

                        ComboBox_AdmissibleBehavior.Items.Clear();
                        ComboBox_VerificationEngine.Items.Clear();
                        ComboBox_AdmissibleBehavior.Enabled = false;
                        ComboBox_VerificationEngine.Enabled = false;
                    }
                    else
                    {
                        ResetUIOptions(null, true);
                        Button_Verify.Enabled = true;
                        this.StatusLabel_Text.Text = Resources.Ready;
                    }
                }
                else
                {
                    //only check the selected item
                    //if (e.IsSelected)
                    {
                        ResetUIOptions(ListView_Assertions.SelectedItems[0], true);
                        this.StatusLabel_Text.Text = Resources.Ready;
                    }
                }
            }
            catch (RuntimeException ex)
            {
                mSpecWorker.mSpec.UnLockSharedData();
                Common.Utility.Utilities.LogRuntimeException(ex);
                this.Close();
            }
            catch (Exception ex)
            {
                mSpecWorker.mSpec.UnLockSharedData();
                Common.Utility.Utilities.LogException(ex, mSpecWorker.mSpec);
                this.Close();
            }
        }

        protected virtual void ResetUIOptions(ListViewItem item, bool resetUIvalues)
        {
            if (item == null)
            {
                ComboBox_AdmissibleBehavior.Items.Clear();
                ComboBox_AdmissibleBehavior.Enabled = false;

                ComboBox_VerificationEngine.Items.Clear();
                ComboBox_VerificationEngine.Enabled = false;

                Button_BAGraph.Enabled = false;


                Button_SimulateWitnessTrace.Enabled = false;

                Button_Verify.Enabled = true;

                Label_SelectedAssertion.Text = "";
                return;
            }

            //set text
            Label_SelectedAssertion.Text = item.SubItems[2].Text;
            mSpecWorker.mAssertion = mSpecWorker.mSpec.AssertionDatabase[Label_SelectedAssertion.Text];

            if ((string)item.Tag == "LTL")
            {
                Button_BAGraph.Enabled = true;
            }
            else
            {
                Button_BAGraph.Enabled = false;
            }

            ComboBox_AdmissibleBehavior.Enabled = true;
            ComboBox_VerificationEngine.Enabled = true;

            Button_Verify.Enabled = true;


            if (resetUIvalues)
            {
                //System.Diagnostics.Debug.Assert(Assertion.ModelCheckingOptions.AddimissibleBehaviorsNames.Count > 0);
                ComboBox_AdmissibleBehavior.Items.Clear();

                if (mSpecWorker.mAssertion.ModelCheckingOptions.AddimissibleBehaviorsNames.Count > 0)
                {
                    ComboBox_AdmissibleBehavior.Items.AddRange(mSpecWorker.mAssertion.ModelCheckingOptions.AddimissibleBehaviorsNames.ToArray());
                    ComboBox_AdmissibleBehavior.SelectedIndex = 0;
                }
                else
                {
                    Button_Verify.Enabled = false;
                }
            }

            //ComboBox_VerificationEngine.Items.AddRange(Assertion.ModelCheckingOptions.AddimissibleBehaviors[0].VerificationEngines.ToArray());
            //ComboBox_VerificationEngine.SelectedIndex = 0;

            //verification result handling.                
            if (mSpecWorker.mAssertion.VerificationOutput != null 
                && mSpecWorker.mAssertion.VerificationOutput.CounterExampleTrace != null
                && mSpecWorker.mAssertion.VerificationOutput.CounterExampleTrace.Count > 0)
            {
                Button_SimulateWitnessTrace.Enabled = true;
                Button_SimulateWitnessTrace.Tag = mSpecWorker.mAssertion.StartingProcess.ToString().Replace("()", "");
            }
            else
            {
                Button_SimulateWitnessTrace.Enabled = false;
            }
        }

        private void ComboBox_AddmissibleBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mSpecWorker.mAssertion != null)
            {
                //System.Diagnostics.Debug.Assert(Assertion.ModelCheckingOptions.AddimissibleBehaviors[ComboBox_AdmissibleBehavior.SelectedIndex].VerificationEngines.Count > 0);
                ComboBox_VerificationEngine.Items.Clear();
                if (mSpecWorker.mAssertion.ModelCheckingOptions.AddimissibleBehaviors[ComboBox_AdmissibleBehavior.SelectedIndex].VerificationEngines.Count > 0)
                {
                    ComboBox_VerificationEngine.Items.AddRange(mSpecWorker.mAssertion.ModelCheckingOptions.AddimissibleBehaviors[ComboBox_AdmissibleBehavior.SelectedIndex].
                            VerificationEngines.ToArray());
                    ComboBox_VerificationEngine.SelectedIndex = 0;
                    Button_Verify.Enabled = true;
                }
                else
                {
                    Button_Verify.Enabled = false;
                }
            }
        }

        private void ModelCheckingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //may the exception dialog want to force the application to close, in this case, we should not give up.
            if (Button_Verify.Text == STOP && !ExceptionDialog.ForceExit)
            {
                mSpecWorker.cancelAssertion();
                e.Cancel = true;
                MessageBox.Show(Resources.Please_wait_for_the_verification_to_stop_first__Otherwise_it_may_cause_exceptional_behaviors, Common.Utility.Utilities.APPLICATION_NAME, MessageBoxButtons.OK);
            }

            // Handle Latex export when close form
            handleResult();
        }

        private void ModelCheckingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ModelCheckingFormInstance = null;
            GC.Collect();
        }

        // I can remove it
        private void btn_transfer_Click(object sender, EventArgs e)
        {
            
            //StatusLabel_Text.Text = "Transfer Completed !";
            //btn_transfer.Enabled = false;
        }

        public void handleResult()
        {
            DialogResult dr = MessageBox.Show("Do you want to replace current tex file with this result ?", "Message", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                mLatexWorker.exportLatex();
        }

        protected virtual void perfomanceTimer_Tick(object sender, EventArgs e) { }


        public bool moduleSpecificCheckPassed()
        {
            return true;
        }

        public void disableAllControls()
        {
            this.Cursor = Cursors.WaitCursor;
            this.TextBox_Output.Cursor = Cursors.WaitCursor;
            ListView_Assertions.Enabled = false;
            ComboBox_AdmissibleBehavior.Enabled = false;
            ComboBox_VerificationEngine.Enabled = false;
            this.CheckBox_GenerateWitnessTrace.Enabled = false;
            NumericUpDown_TimeOut.Enabled = false;

            ComboBox_AdmissibleBehavior.Enabled = false;


            Button_BAGraph.Enabled = false;
            Button_Verify.Text = STOP;
            this.ToolTip.SetToolTip(Button_Verify, STOP);

            ProgressBar.Value = 0;
            ProgressBar.Visible = false;

            Button_SimulateWitnessTrace.Enabled = false;
        }

        public void enableAllControls()
        {
            ListView_Assertions.Enabled = true;
            ComboBox_AdmissibleBehavior.Enabled = true;
            ComboBox_VerificationEngine.Enabled = true;
            this.CheckBox_GenerateWitnessTrace.Enabled = true;
            NumericUpDown_TimeOut.Enabled = true;

            Button_Verify.Text = VERIFY;
            ToolTip.SetToolTip(Button_Verify, VERIFY);
            ProgressBar.Value = 0;
            ProgressBar.Visible = false;
            Cursor = Cursors.Default;
            TextBox_Output.Cursor = Cursors.Default;

            if (ListView_Assertions.SelectedItems.Count == 1)
            {
                ResetUIOptions(ListView_Assertions.SelectedItems[0], false);
            }
            else
            {
                ResetUIOptions(null, false);
            }

            mSpecWorker.unlockShareData();
            Common.Utility.Utilities.FlashWindowEx(this);
        }

        public void updateResStartVerify()
        {
            StatusLabel_Text.Text = Resources.ModelCheckingForm_StartVerification_Verification_Starts;
            ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = UNKNOWN_ICON;
        }

        public void updateResFinishedVerify()
        {
            ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = UNKNOWN_ICON;
            TextBox_Output.Text =
                String.Format(
                    "You are running an evaluation version of PAT. The number of searched states are limited to {0}.\r\nPurchase the full version to unlock the full functions of PAT.\r\n\r\n",
                    Common.Utility.Utilities.LicenseBoundedStateNumber) + TextBox_Output.Text;
        }

        public void onResult(VerificationResultType type)
        {
            if (type == VerificationResultType.UNKNOWN)
            {
                ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = UNKNOWN_ICON;
            }
            else if (type == VerificationResultType.VALID)
            {
                ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = CORRECT_ICON;
            }
            else if (type == VerificationResultType.WITHPROBABILITY)
            {
                ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = CORRECT_ICON_PRPB;
            }
            else
            {
                ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = WRONG_ICON;
            }
        }

        public void updateVerifyBtnLabel(string label)
        {
            Button_Verify.Text = label;
        }

        public void updateStatusLabel(string status)
        {
            StatusLabel_Text.Text = status;
        }

        public int getCmbAdmissibleIndex()
        {
            int index = ComboBox_AdmissibleBehavior.SelectedIndex;
            return index == -1 ? 0 : index;
        }

        public int getCmbVerificationEngineIndex()
        {
            int index = ComboBox_VerificationEngine.SelectedIndex;
            return index == -1 ? 0 : index;
        }

        public bool generateCounterExample()
        {
            return CheckBox_GenerateWitnessTrace.Checked;
        }

        public void closeForm()
        {
            Close();
        }

        public void onAction(string action)
        {
            TextBox_Output.Text = action + TextBox_Output.Text + "\n\n";
        }

        public void RnderingOutputTextbox()
        {
            TextBox_Output.SelectAll();
            TextBox_Output.SelectionFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            TextBox_Output.SelectionColor = System.Drawing.Color.Black;

            TextBox_Output.SelectionStart = 0;
            TextBox_Output.SelectionLength = 0;

            ColorText(0);

            TextBox_Output.Select(0, 0);
            TextBox_Output.ScrollToCaret();
        }

        public bool isVerifyBtnEnabled()
        {
            return Button_Verify.Enabled;
        }

        public void eventResult()
        {
            VerificationIndex++;
            if (VerificationIndex < this.ListView_Assertions.SelectedItems.Count)
            {
                mSpecWorker.startVerification(ListView_Assertions.SelectedItems[VerificationIndex].SubItems[2].Text, 
                    NumericUpDown_TimeOut.Value);
            }
        }

        public void eventCancel()
        {
            ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = UNKNOWN_ICON;
        }

        public void performVerifyBtn()
        {
            Button_Verify.PerformClick();
        }


        public void updateLatexResult(AssertionBase assertion)
        {
            // Update latex result
            mLatexWorker.addAssertResult(assertion);
        }
    }
}