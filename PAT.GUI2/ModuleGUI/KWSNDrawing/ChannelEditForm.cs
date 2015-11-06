using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tools.Diagrams;
using PAT.Common.GUI.Drawing;
using PAT.Common.Utility;
using PAT.Module.KWSN;
using PAT.Common.ModelCommon.WSNCommon;

namespace PAT.GUI.ModuleGUI.KWSNDrawing
{
    public partial class ChannelEditForm : Form
    {
        private WSNChannel mChannel = null;
        private NetMode mMode;
        private string TAG = "SensorChannelEditForm";
        private LTSCanvas mCanvas;

        public ChannelEditForm(Route route, LTSCanvas canvas, NetMode mode)
        {
            do
            {
                InitializeComponent();

                mChannel = (WSNChannel)route;
                mMode = mode;
                mCanvas = canvas;

                List<LTSCanvas.CanvasItemData> canvasItems = canvas.itemsList;
                foreach (LTSCanvas.CanvasItemData itemData in canvasItems)
                {
                    if (itemData.Item is StateItem)
                    {
                        this.cmbSource.Items.Add(itemData.Item);
                        this.cmbDest.Items.Add(itemData.Item);

                        if (itemData.Item.Equals(route.From))
                            this.cmbSource.SelectedItem = itemData.Item;

                        if (itemData.Item.Equals(route.To))
                            this.cmbDest.SelectedItem = itemData.Item;
                    }
                }

                if (!mMode.Equals(NetMode.MULTICAST))
                {
                    txtSensorsConn.Visible = false;
                    lblSensorsConn.Visible = false;
                    break;
                }
                
                StringBuilder subConn = new StringBuilder();
                subConn.Append(((WSNSensor)mChannel.To).ID.ToString());

                foreach (int item in mChannel.SubIdList)
                    subConn.Append("," + item);

                txtSensorsConn.Text = subConn.ToString();
            } while (false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            do
            {
                // not multicast mode
                if (!mMode.Equals(NetMode.MULTICAST))
                    break;

                string[] sConn = txtSensorsConn.Text.Trim().Split(',');
                
                if (sConn.Length < 2)
                    break;

                string toId = ((WSNSensor)mChannel.To).ID.ToString();
                mChannel.SubIdList.Clear();

                foreach (string item in sConn)
                {
                    if (toId.Equals(item))
                        continue;

                    try
                    {
                        mChannel.SubIdList.Add(Int32.Parse(item));
                    }
                    catch (Exception ex) {
                        DevLog.d(TAG, "Error: " + ex.ToString());
                    }
                }
                
            } while (false);
        }       
    }
}
