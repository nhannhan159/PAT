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
    public partial class KMeansClusteringForm : Form
    {
        public event EventHandler ButtonFirstFormClicked;

        public KMeansClusteringForm()
        {
            InitializeComponent();
        }

        private void KMeanClusteringFormCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public TextBox TextBoxKvalue
        {
            get
            {
                return textBoxKvalue;
            }
        }

        private void KMeanClusteringFormOk_Click(object sender, EventArgs e)
        {
            if (ButtonFirstFormClicked != null)
                ButtonFirstFormClicked(sender, e);
        }
    }
}
