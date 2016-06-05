using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PAT.Common;
using PAT.Common.Classes.ModuleInterface;

namespace PAT.Console
{
    class ModelCheckingInstance : ISpecificationWorker
    {
        private SpecificationWorker mSpecWorker;

        public ModelCheckingInstance(string Name, SpecificationBase spec, PNExtendInfo extendInfo)
        {
            mSpecWorker = new SpecificationWorker(spec, this, this);
            mExtendInfo = extendInfo;
            initLogic();
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
    }
}
