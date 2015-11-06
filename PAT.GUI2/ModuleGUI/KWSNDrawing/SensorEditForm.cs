using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PAT.Common.GUI.Drawing;
using PAT.Common.Classes.SemanticModels.LTS.BDD;
using Tools.Diagrams;
using PAT.Module.KWSN;

namespace PAT.GUI.ModuleGUI.KWSNDrawing
{
    public partial class SensorEditForm : Form
    {
        private WSNSensor mItem;

        public SensorEditForm(StateItem item)
        {
            InitializeComponent();
            
            mItem = item as WSNSensor;
            txtSensorName.Text = mItem.Name;

            foreach (SensorType type in Enum.GetValues(typeof(SensorType)))
            {
                cmbSensorType.Items.Add(type.ToString());
                if (type == mItem.NodeType)
                    this.cmbSensorType.SelectedItem = type.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mItem.Name = txtSensorName.Text;
            mItem.NodeType = (SensorType)this.cmbSensorType.SelectedIndex;
            mItem.IsInitialState = (mItem.NodeType == SensorType.Source);
        }
    }
}
