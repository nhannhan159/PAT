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
    public partial class ConfirmForm : Form
    {
        public event EventHandler ButtonTestFormClick;
        public ConfirmForm()
        {
            InitializeComponent();
        }

        private void ConfirmFormNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmFormYes_Click(object sender, EventArgs e)
        {
            if (ButtonTestFormClick != null)
            {
                ButtonTestFormClick(sender, e);
            }
        }
    }
}
