using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAT.GUI.SVModule
{
    public partial class DBScanForm : Form
    {

        public DBScanForm()
        {
            InitializeComponent();

        }

        private void DBScanFormCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DBScanFormOk_Click(object sender, EventArgs e)
        {
            if(EpsBox.Text == "")
            {
                MessageBox.Show("Please input value Esp", "Esp not valid");
                EpsBox.Focus();
            }
            if(PtsBox.Text=="")
            {
                MessageBox.Show("Please input value esp", "Esp not valid");
                PtsBox.Focus();
            }
            if ((EpsBox.Text != "") && (PtsBox.Text != ""))
            {
                this.Close();
            }
                
        }

        private void PtsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (EpsBox.Text == "")
                {
                    MessageBox.Show("Please input value Esp", "Esp not valid");
                    EpsBox.Focus();
                }
                if (PtsBox.Text == "")
                {
                    MessageBox.Show("Please input value Minpts", "Minpts not valid");
                    PtsBox.Focus();
                }
                if ((EpsBox.Text != "") && (PtsBox.Text != ""))
                {
                    this.Close();
                }
            }
        }

        private void EpsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (EpsBox.Text == "")
                {
                    MessageBox.Show("Please input value Esp", "Esp not valid");
                    EpsBox.Focus();
                }
                if (PtsBox.Text == "")
                {
                    MessageBox.Show("Please input value Minpts", "Minpts not valid");
                    PtsBox.Focus();
                }
                if((EpsBox.Text != "")&&(PtsBox.Text != ""))
                {
                    this.Close();
                }
            }
        }
    }
}
