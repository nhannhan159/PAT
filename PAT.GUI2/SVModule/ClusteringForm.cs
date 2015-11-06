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
    public partial class ClusteringForm : Form
    {
        public event EventHandler ButtonTestFormClick;

        public ClusteringForm()
        {
            InitializeComponent();
        }

        private void ClusteringFormOk_Click(object sender, EventArgs e)
        {
            if (ButtonTestFormClick != null)
            {
                ButtonTestFormClick(sender, e);
            }
        }

        private void ClusteringFormCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void methodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClusteringFormOk.Enabled = true;
        }

        public ComboBox ComboBoxValue
        {
            get
            {
                return methodBox;
            }
        }

        /*
        public TextBox TextBoxValue
        {
            get
            {
                return TestFormTextBox;
            }
        }
        */
    }
}
