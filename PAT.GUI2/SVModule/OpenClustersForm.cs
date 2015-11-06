using PAT.Common.Utility;
using PAT.GUI.SVModule.Clustering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAT.GUI
{
    public partial class OpenClustersForm : Form
    {
        private const string TAG = "OpenClustersForm";

        private ICluster mListener;

        public OpenClustersForm(List<String> listBefore, List<String> listAfter, ICluster listener)
        {
            InitializeComponent();

            foreach (string item in listBefore)
                listViewBefore.Items.Add(item);
            
            foreach (string item in listAfter)
                listViewAfter.Items.Add(item);

            // mlqvu-20151026-listen for event open file
            mListener = listener;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openClusterBtn_Click(object sender, EventArgs e)
        {
            do
            {
                string kwsnName = null;
                if (listViewBefore.SelectedItems.Count > 0)
                {
                    kwsnName = listViewBefore.SelectedItems[0].Text + ".kwsn";
                    mListener.onOpenFile(ClusterHelper.CURRENT_PATH + ClusterHelper.BEFORE_FOLDER + "\\" + kwsnName);
                    break;
                }

                if (listViewAfter.SelectedItems.Count > 0)
                {
                    kwsnName = listViewAfter.SelectedItems[0].Text + ".kwsn";
                    mListener.onOpenFile(ClusterHelper.CURRENT_PATH + ClusterHelper.AFTER_FOLDER + "\\" + kwsnName);
                    break;
                }

                DevLog.e(TAG, "Not item selected");
            } while (false);

            // mlqvu-20151026- force close after open kwsn file
            Close();
        }

        private void listViewBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            openClusterBtn.Enabled = (listViewBefore.SelectedItems.Count == 1);
        }

        private void listViewAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            openClusterBtn.Enabled = (listViewAfter.SelectedItems.Count == 1);
        }
    }
}
