using PAT.Common;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.GUI;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.Utility;
using PAT.GUI.Docking;
using PAT.GUI.KWSNDrawing;
using PAT.GUI.PNDrawing;
using PAT.GUI.Properties;
using PAT.GUI.SVModule.Clustering;
using PAT.GUI.Utility;
using PAT.PN.Assertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PAT.GUI
{

    public interface IVerifyFinish
    {
       void finished();
    }

    public partial class VerifyAllClusters : Form, IVerifyFinish //, ResourceFormInterface
    {
        private const string TAG = "VerifyAllClusters";

        private List<string> listPathDirectory = new List<string>();
        int test;
        protected AssertionBase Assertion;
        private PNExtendInfo mExtendInfo;
        private int VerificationIndex = -1;
        protected SpecificationBase Spec;
        private ModuleFacadeBase mModule;
        private ICluster mListener;
        public VerifyAllClusters(List<String> listClusters, List<String> listPath, ICluster listener)
        {
            do
            {
                InitializeComponent();
                listPathDirectory.AddRange(listPath);
                mListener = listener;
                if (listClusters.Count == 0)
                {
                    Verify_Btn.Enabled = false;
                    VerifyAll_Btn.Enabled = false;
                    break;
                }

                //add items listview resultVerify
                for (int i = 0; i < listClusters.Count; i++)
                {
                    resultVerifyGridView.Rows.Add(listClusters[i], null, null);
                    //resultVerify.Items[i].SubItems.Add("null");
                    //resultGridView.Rows.Add(listClusters[i],"null");
                }
                Verify_Btn.Enabled = true;
                VerifyAll_Btn.Enabled = true;
            } while (false);
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void autoVerification()
        //{
        //    try
        //    {
        //        if (ParseSpecification(true) != null)
        //        {
        //            if (GUIUltility.AUTO_SAVE)
        //                Save();

        //            // mlqvu -- edit here
        //            PNTabItem cPNTabItem = CurrentEditorTabItem as PNTabItem;
        //            PNExtendInfo extendInfo = null;
        //            if (cPNTabItem != null)
        //                extendInfo = cPNTabItem.mExtendInfo;

        //            CurrentModule.ShowModelCheckingWindow(CurrentEditorTabItem.TabText.TrimEnd('*'), extendInfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Ultility.LogException(ex, null);
        //    }
        //}


        private void VerifyAll_Btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Verify_Btn_Click(object sender, EventArgs e)
        {
            //---Minh---Edit all
            if (Verify_Btn.Text == "STOP")
            {
                Verify_Btn.Text = "Verify";
                Close_Btn.Enabled = true;
                VerifyAll_Btn.Enabled = true;
                resultVerifyGridView.Enabled = true;
            }
            else
            {
                if (resultVerifyGridView.SelectedCells[0].Value == null)
                {
                    MessageBox.Show("Please choose one cluster to verify", "Error");
                }
                else
                {
                    bool isOpened = false;//flag check a Document has been opened
                    Verify_Btn.Text = "STOP";
                    Close_Btn.Enabled = false;
                    VerifyAll_Btn.Enabled = false;
                    resultVerifyGridView.Enabled = false;
                    int N = mListener.onDockContainer().Documents.Length;
                    DevLog.d(TAG, "Number Documents: " + N);
                    string tmpName = "";
                    //FormMain frmMain = autoVerify as FormMain;
                    tmpName += ClusterHelper.CURRENT_PATH + ClusterHelper.BEFORE_FOLDER;
                    tmpName += @"\" + resultVerifyGridView.SelectedCells[0].Value + ".kwsn";
                    DevLog.d(TAG, "" + tmpName);

                    for (int i = 0; i < N; i++)
                    {
                        EditorTabItem item = mListener.onDockContainer().Documents[i] as EditorTabItem;
                        if (item.FileName == tmpName)
                        {
                            isOpened = true;//this Document has been opened
                            break;
                            //Log.d(TAG, "File is opened: " + item.FileName);
                        }
                    }
                    if (isOpened == true)
                    {
                        //OutputTxtBox.AppendText("Please wait............\n");
                        OutputTxtBox.AppendText(resultVerifyGridView.SelectedCells[0].Value + ".kwsn" + " has been opened......\n");
                        //OutputTxtBox.AppendText("Open " + resultVerifyGridView.SelectedCells[0].Value + ".kwsn" + " successful\n");
                        //Log.d(TAG, "CurrentActiveTab: " + curretActiveTab);
                        //EditorTabItem currentWSNItem = frmMain.DockContainer.Documents[frmMain.DockContainer.Documents.Length - 1] as EditorTabItem;
                        //Log.d(TAG, "CurrentEditorTabItem: " + frmMain.CurrentEditorTabItem.FileName);
                        int N2 = mListener.onDockContainer().Documents.Length;
                        DevLog.d(TAG, "Number Documents: " + N2);

                        //convert to PN underground
                        int rowSelected = resultVerifyGridView.SelectedCells[0].RowIndex;
                        //resultVerifyGridView.Rows[rowSelected].Cells[0].Value="ma";
                        //resultVerifyGridView.Rows[rowSelected].Cells[1].Value = "tao";
                        resultVerifyGridView.Rows[rowSelected].Cells[2].Value = "";

                        DevLog.d(TAG, "row: " + rowSelected);
                        //Verify_Btn.Text = "STOP";

                        mListener.onConvertToPNAfterCluster(false, true, resultVerifyGridView.SelectedCells[0].Value.ToString());//only channel
                        EditorTabItem currentPNItem = mListener.onDockContainer().Documents[N2 - 1] as EditorTabItem;
                        //frmMain.Save();
                        //currentWSNItem.Close();//Close WSNTabItem convert to PNTabItem
                        //Log.d(TAG, "Number Documents After: " + N);
                        currentPNItem.Close();//Close PNTabItem
                        //OutputTxtBox.AppendText("Done....\n");
                        //for(int m=0;m<N;m++)
                        //{
                        //    Log.d(TAG, "Document["+(m+1)+"]:" + frmMain.DockContainer.Documents[m]);
                        //}
                        OutputTxtBox.AppendText("Verifying " + resultVerifyGridView.SelectedCells[0].Value + "......\n");
                        OutputTxtBox.AppendText("Please wait....\n");
                        try
                        {
                            if (mListener.onParseSpecificationAfterCluster(currentPNItem) != null)
                            {
                                if (GUIUtility.AUTO_SAVE)
                                    mListener.onSave();


                                PNTabItem cPNTabItem = currentPNItem as PNTabItem;
                                PNExtendInfo extendInfo = null;
                                if (cPNTabItem != null)
                                    extendInfo = cPNTabItem.mExtendInfo;

                                mListener.onShowModelCheckingWindow(currentPNItem.TabText.TrimEnd('*'), extendInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can't open model checking form", "Error");
                        }
                    }
                    else
                    {
                        mListener.onOpenFile(tmpName);
                        OutputTxtBox.AppendText("Please wait............\n");
                        OutputTxtBox.AppendText("Opening " + resultVerifyGridView.SelectedCells[0].Value + "......\n");
                        OutputTxtBox.AppendText("Open " + resultVerifyGridView.SelectedCells[0].Value + ".kwsn" + " successful\n");
                        //Log.d(TAG, "CurrentActiveTab: " + curretActiveTab);
                        EditorTabItem currentWSNItem = mListener.onDockContainer().Documents[mListener.onDockContainer().Documents.Length - 1] as EditorTabItem;
                        //Log.d(TAG, "CurrentEditorTabItem: " + frmMain.CurrentEditorTabItem.FileName);
                        int N2 = mListener.onDockContainer().Documents.Length;
                        DevLog.d(TAG, "Number Documents: " + N2);

                        //convert to PN underground
                        int rowSelected = resultVerifyGridView.SelectedCells[0].RowIndex;
                        //resultVerifyGridView.Rows[rowSelected].Cells[0].Value="ma";
                        //resultVerifyGridView.Rows[rowSelected].Cells[1].Value = "tao";
                        resultVerifyGridView.Rows[rowSelected].Cells[2].Value = "la";

                        DevLog.d(TAG, "row: " + rowSelected);

                        //Close_Btn.Enabled = false;
                        //VerifyAll_Btn.Enabled = false;
                        //resultVerifyGridView.Enabled = false;
                        mListener.onConvertToPNAfterCluster(false, true, resultVerifyGridView.SelectedCells[0].Value.ToString());//only channel
                        EditorTabItem currentPNItem = mListener.onDockContainer().Documents[mListener.onDockContainer().Documents.Length - 1] as EditorTabItem;
                        mListener.onSave();
                        currentWSNItem.Close();//Close WSNTabItem convert to PNTabItem
                        //Log.d(TAG, "Number Documents After: " + N);
                        currentPNItem.Close();//Close PNTabItem
                        //OutputTxtBox.AppendText("Done....\n");
                        //for(int m=0;m<N;m++)
                        //{
                        //    Log.d(TAG, "Document["+(m+1)+"]:" + frmMain.DockContainer.Documents[m]);
                        //}
                        OutputTxtBox.AppendText("Verifying " + resultVerifyGridView.SelectedCells[0].Value + "......\n");
                        OutputTxtBox.AppendText("Please wait....\n");


                        try
                        {
                            if (mListener.onParseSpecificationAfterCluster(currentPNItem) != null)
                            {
                                if (GUIUtility.AUTO_SAVE)
                                    mListener.onSave();


                                PNTabItem cPNTabItem = currentPNItem as PNTabItem;
                                PNExtendInfo extendInfo = null;
                                if (cPNTabItem != null)
                                    extendInfo = cPNTabItem.mExtendInfo;

                                mListener.onShowModelCheckingWindow(currentPNItem.TabText.TrimEnd('*'), extendInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            //GUIUtility.LogException(ex, null);
                            MessageBox.Show("Can't open model checking form", "Error");
                        }
                    }


                    //verify completed, enable all
                    //Verify_Btn.Text = "Verify";
                    //Close_Btn.Enabled = true;
                    //VerifyAll_Btn.Enabled = true;
                    //resultVerifyGridView.Enabled = true;
                    //VerificationIndex = 0;
                    //StartVerification(ListView_Assertions.SelectedItems[VerificationIndex]);

                    //var ram = new PerformanceCounter("Memory", "Available MBytes");
                    //float cur = ram.NextValue(); // lấy dung lượng RAM free thời điểm hiện tại
                    //ulong max = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;// lấy dung lượng tổng cộng của các thanh RAM
                    //Log.d(TAG, "Ram: " + max);
                }
                //Log.d(TAG, "");
                OutputTxtBox.AppendText("Done....\n");
                OutputTxtBox.AppendText("======================\n");
            }
            
        }

        private bool createModule()
        {
            bool ret = false;
            do
            {
                string moduleName = "KWSN Model";
                if (mModule != null && mModule.ModuleName == moduleName)
                    break;

                string facadeClass = "PAT." + moduleName + ".ModuleFacade";
                string file = Path.Combine(Path.Combine(Utilities.ModuleFolderPath, moduleName), "PAT.Module." + moduleName + ".dll");

                Assembly assembly = Assembly.LoadFrom(file);
                mModule = (ModuleFacadeBase)assembly.CreateInstance(
                                                       facadeClass,
                                                       true,
                                                       BindingFlags.CreateInstance,
                                                       null, null,
                                                       null, null);

                if (mModule.GetType().Namespace != "PAT." + moduleName)
                {
                    mModule = null;
                    break;
                }

                // mModule.ShowModel += new ShowModelHandler(ShowModel);
                // mModule.ExampleMenualToolbarInitialize(this.MenuButton_Examples);
                mModule.ReadConfiguration();
                ret = true;
            } while (false);

            return ret;
        }

        private void convertToPN(string kwsnFileName)
        {
            do
            {
                WSNTabItem wsnTabItem = new WSNTabItem("KWSN Model", "KWSN", null);
                wsnTabItem.Open(kwsnFileName);

                string pnName = DateTime.Now.Millisecond.ToString() + ".pn"; // 13486468456456.pn
                PNGenerationHelper helper = new PNGenerationHelper(pnName, wsnTabItem);
                helper.GenerateXML(false, false);

                bool cne = createModule();
                if (cne == false)
                    break;



            } while (false);

        }

        //private void StartVerification(ListViewItem item)
        //{


        //    if (!ModuleSpecificCheckPassed())
        //    {
        //        return;
        //    }

        //    if (!Spec.GrabSharedDataLock())
        //    {
        //        MessageBox.Show("Please_wait_for_the_simulation_or_parsing_finished_before_verification", Common.Ultility.Ultility.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    DisableAllControls();


        //    try
        //    {
        //        Spec.LockSharedData(false);

        //        StatusLabel_Text.Text = Resources.ModelCheckingForm_StartVerification_Verification_Starts;



        //        item.ImageIndex = UNKNOWN_ICON;

        //        Assertion = Spec.AssertionDatabase[item.SubItems[2].Text];
        //        Assertion.UIInitialize(this, ComboBox_AdmissibleBehavior.SelectedIndex == -1 ? 0 : ComboBox_AdmissibleBehavior.SelectedIndex,
        //            //ComboBox_VerificationEngine.SelectedIndex == -1 ? 0 : ComboBox_VerificationEngine.SelectedIndex);

        //        //Assertion.VerificationOutput.GenerateCounterExample = CheckBox_GenerateWitnessTrace.Checked;

        //       // Assertion.Action += OnAction;
        //        //Assertion.ReturnResult += VerificationFinished;
        //        //Assertion.Cancelled += Verification_Cancelled;
        //        //Assertion.Failed += MC_Failed;

        //        //seconds = 1;
        //        //ProgressBar.Value = 0;
        //        //MCTimer.Start();
        //        //Assertion.Start();
        //    }
        //    catch (RuntimeException e)
        //    {
        //        Spec.UnLockSharedData();
        //        Common.Ultility.Ultility.LogRuntimeException(e);
        //        Button_Verify.Text = VERIFY;
        //        this.Close();
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        Spec.UnLockSharedData();
        //        Common.Ultility.Ultility.LogException(ex, Spec);
        //        Button_Verify.Text = VERIFY;
        //        this.Close();
        //        return;
        //    }
        //}

        //public void InitializeResourceText()
        //{
        //    throw new NotImplementedException();
        //}
    
        public void finished()
        {

 	        // throw new NotImplementedException();
        }
}
}
