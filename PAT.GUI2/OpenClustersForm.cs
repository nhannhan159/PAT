using PAT.Common.Ultility;
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

        private List<string> listPathDirectory = new List<string>();
        //private List<String> listBeforeClusters = new List<String>();
        //private List<String> listAfterClusters = new List<String>();
        //private int flag_check_state=0;
        public OpenClustersForm(List<String> listBefore, List<String> listAfter, List<string> listPath)
        {
            InitializeComponent();
            //listViewBefore.Items.Clear();
            //listViewAfter.Items.Clear();
            //flag_check_state = flag;
            //Log.d(TAG, "" + flag_check_state);
            for (int i = 0; i < listBefore.Count; i++)
            {
                listViewBefore.Items.Add(listBefore[i]);
                //resultGridView.Rows.Add(listClusters[i],"null");
            }
            for (int i = 0; i < listAfter.Count; i++)
            {
                listViewAfter.Items.Add(listAfter[i]);
                //resultGridView.Rows.Add(listClusters[i],"null");
            }
            openClusterBtn.Enabled = false;
            listPathDirectory.AddRange(listPath);

            //Log.d(TAG, "After add: ");
            //for (int i = 0; i < listViewBefore.Items.Count; i++)
            //{
            //    Log.d(TAG, "" + listViewBefore.Items[i].Text + " count: " + listViewBefore.Items.Count);
            //}
            //Log.d(TAG, "============END============");
            foreach (string s in listPathDirectory)
            {
                Log.d(TAG, "" + s);
            }
        }

        public object Open
        {
            get;
            set;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            if (Open is FormMain)
            {
                FormMain frmMain = Open as FormMain;
                frmMain.openClusters.Enabled = true;
            }

        }

        private void openClusterBtn_Click(object sender, EventArgs e)
        {
            if (listViewBefore.SelectedItems.Count == 1)
            {
                string tmpName = "";
                //Log.d(TAG, "Before: " + tmpName);
                tmpName += listPathDirectory[0].ToString();
                tmpName += @"\" + listViewBefore.SelectedItems[0].Text + ".kwsn";
                //Log.d(TAG, "Before: " + tmpName);
                if (Open is FormMain)
                {
                    FormMain frmMain = Open as FormMain;
                    frmMain.OpenFile(tmpName, true);
                }
            }
            if (listViewAfter.SelectedItems.Count == 1)
            {
                string tmpName = "";
                //Log.d(TAG, "After: " + tmpName);
                tmpName += listPathDirectory[1].ToString();
                tmpName += @"\" + listViewAfter.SelectedItems[0].Text + ".kwsn";
                //Log.d(TAG, "After: " + tmpName);
                if (Open is FormMain)
                {
                    FormMain frmMain = Open as FormMain;
                    frmMain.OpenFile(tmpName, true);
                }
            }
        }

        private void listViewBefore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBefore.SelectedItems.Count == 1)
            {
                openClusterBtn.Enabled = true;
                //MessageBox.Show(""+listViewBefore.SelectedItems[0].Text, "msg");
            }
            else
            {
                openClusterBtn.Enabled = false;
            }
        }

        private void listViewAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAfter.SelectedItems.Count == 1)
            {
                openClusterBtn.Enabled = true;
                //MessageBox.Show(""+listViewBefore.SelectedItems[0].Text, "msg");
            }
            else
            {
                openClusterBtn.Enabled = false;
            }
        }

        private void OpenClustersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Open is FormMain)
            {
                FormMain frmMain = Open as FormMain;
                frmMain.openClusters.Enabled = true;
            }
        }

    }
}
