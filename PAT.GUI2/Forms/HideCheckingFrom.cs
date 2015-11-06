using PAT.Common;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.GUI.ModelChecker;
using PAT.Common.Utility;
using PAT.GUI.PNDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PAT.GUI.Forms
{
    public partial class HideCheckingFrom : ModelCheckingForm
    {
        private const string TAG = "HideCheckingFrom";
        private const string MODULE_NAME = "PN Model";

        private string mPNName;
        private PNTabItem mTabItem;
        private ModuleFacadeBase mModule;
        private AssertionBase mAssert;
        private SpecificationBase mSpec;

        public HideCheckingFrom()
            : base()
        {
            InitializeComponent();
        }

        private void initParseSpecifinication(string fName)
        {
            if (mTabItem == null)
                mTabItem = new PNTabItem(MODULE_NAME);

            mTabItem.Open(fName);
        }

        private bool LoadModule(string moduleName)
        {
            bool ret = false;
            do
            {
                try
                {
                    if (Common.Utility.Utilities.ModuleDictionary.ContainsKey(moduleName))
                    {
                        if (mModule == null || moduleName != mModule.ModuleName)
                            mModule = Common.Utility.Utilities.ModuleDictionary[moduleName];
                        ret = true;
                        break;
                    }

                    string facadeClass = "PAT." + moduleName + ".ModuleFacade";
                    string file = Path.Combine(Path.Combine(Common.Utility.Utilities.ModuleFolderPath, moduleName), "PAT.Module." + moduleName + ".dll");

                    Assembly assembly = Assembly.LoadFrom(file);
                    mModule = (ModuleFacadeBase)assembly.CreateInstance(facadeClass, true, BindingFlags.CreateInstance, null, null, null, null);

                    if (mModule.GetType().Namespace != "PAT." + moduleName)
                    {
                        mModule = null;
                        break;
                    }

                    //CurrentModule.ShowModel += new ShowModelHandler(ShowModel);
                    //CurrentModule.ExampleMenualToolbarInitialize(this.MenuButton_Examples);
                    mModule.ReadConfiguration();
                    ret = true;
                }
                catch { }
            } while (false);

            return ret;
        }

        //private string GetOption()
        //{
        //    string option = "";
        //    option += MenuButton_EnableSimplificationOfTheFormula.Checked ? "" : "l";
        //    option += MenuButton_EnableOntheflyAutomataSimplification.Checked ? "" : "o";
        //    option += MenuButton_EnableAPosterioriAutomataSimplification.Checked ? "" : "p";
        //    option += MenuButton_EnableStronglyConnectedComponentsSimplification.Checked ? "" : "c";
        //    option += MenuButton_EnableTrickingInAcceptingConditions.Checked ? "" : "a";
        //    return option;
        //}

        private SpecificationBase parseSpecification()
        {
            SpecificationBase spec = null;
            do
            {
                if (mTabItem == null || mTabItem.Text.Trim() == "")
                {
                    DevLog.e(TAG, "mTabItem is null");
                    break;
                }

                // DisableAllControls();
                try
                {
                    string moduleName = mTabItem.ModuleName;
                    if (LoadModule(moduleName))
                    {
                        //string option = GetOption();
                        Stopwatch t = new Stopwatch();
                        // DisableAllControls();
                        disableAllControls();
                        t.Start();
                        spec = mModule.ParseSpecification(mTabItem.Text, "", mTabItem.FileName);
                        t.Stop();

                        if (spec != null)
                        {
                            mTabItem.Specification = spec;
                            if (spec.Errors.Count > 0)
                            {
                                string key = "";
                                foreach (KeyValuePair<string, ParsingException> pair in spec.Errors)
                                {
                                    key = pair.Key;
                                    break;
                                }

                                ParsingException parsingException = spec.Errors[key];
                                spec.Errors.Remove(key);
                                throw parsingException;
                            }
                        }

                        // Spec = spec;
                        initLogic();
                        enableAllControls();
                        // EnableAllControls();
                    }
                }
                catch (ParsingException ex) { }
                catch (Exception ex) { }
            } while (false);

            return spec;
        }

        private void btnBrowser_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                mPNName = openFileDialog.FileName;
                lblPath.Text = mPNName;

                initParseSpecifinication(mPNName);
                parseSpecification();
            }
        }

        protected override void perfomanceTimer_Tick(object sender, EventArgs e)
        {
            base.perfomanceTimer_Tick(sender, e);
            lblCPU.Text = ((int) mCPUCounter.NextValue()).ToString() + "%";
            lblRAM.Text = (mRAMCounter.NextValue()/1024f).ToString("0.00") + "Gb";
        }
    }
}
