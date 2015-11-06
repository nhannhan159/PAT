using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using Tools.Diagrams;

using PAT.Common.GUI.Drawing;
using PAT.Common.GUI.LTSModule;
using PAT.Common.Utility;
using System.Diagnostics;
using System.Globalization;
using PAT.Module.KWSN;
using PAT.GUI.ModuleGUI.KWSNDrawing;
using PAT.GUI.ModuleGUI;
using PAT.KWSN.Model;
using PAT.Common.ModelCommon.WSNCommon;

namespace PAT.GUI.KWSNDrawing
{
    public class WSNTabItem : KLTSTabItem, IConfigurationForm
    {
        private const string TAG = "WSNTabItem";

        // Base file name
        private const string PNXmlRes = "wsn-pn-based.xml";
        public WSNExtendInfo mExtendInfo = new WSNExtendInfo();
        private IConvertPN mConverter;
       
        #region GUI controls
        private ToolStripMenuItem mnuItemConvert2PNModel;
        private ToolStripMenuItem mnuItemSetType;
        #endregion


        public WSNTabItem(string name, string shortName, IConvertPN iconvertor)
            : base(name)
        {
            _docPNRes = LoadPNRes(shortName);
            mConverter = iconvertor;
            initGUI();
        }

        #region PN XML resource
        private XmlDocument _docPNRes = null;
        public virtual XmlDocument PNRes
        {
            get { return _docPNRes; }
        }

        public static XmlDocument LoadPNRes(string moduleName)
        {
            XmlDocument doc = null;
            string path = @"XML/" + PNXmlRes;

            try
            {
                doc = new XmlDocument();
                doc.Load(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load PN resource xml\n\n" + "* Path: " + path + "\n\n,* Error: " + ex.Message,
                    "Load resource failed", MessageBoxButtons.OKCancel);
            }

            return doc;
        }
        #endregion

        #region GUI handler
        private void initGUI()
        {
            // Add context menu to convert data to PN Model
            mnuItemSetType = new ToolStripMenuItem("Set Type");

            ToolStripMenuItem mnuSetTypeSource = new ToolStripMenuItem("Source");
            ToolStripMenuItem mnuSetTypeSink = new ToolStripMenuItem("Sink");
            ToolStripMenuItem mnuSetTypeIntermediate = new ToolStripMenuItem("Intermediate");
            
            mnuSetTypeSource.Click += mnuSetTypeSource_Click;
            mnuSetTypeIntermediate.Click += mnuSetTypeIntermediate_Normal_Click;
            mnuSetTypeSink.Click += mnuSetTypeSink_Click;

            mnuItemSetType.DropDownItems.Add(mnuSetTypeSource);
            mnuItemSetType.DropDownItems.Add(mnuSetTypeIntermediate);
            mnuItemSetType.DropDownItems.Add(mnuSetTypeSink);


            // EXPORT OPTIONS
            mnuItemConvert2PNModel = new ToolStripMenuItem("Export to Petri Nets Model");
            mnuItemConvert2PNModel.Name = "mnuItemConvert2PNModel";

            ToolStripMenuItem exportAll = new ToolStripMenuItem("Non Abstraction");
            ToolStripMenuItem exportSensorsOnly = new ToolStripMenuItem("Channel Abstraction");
            ToolStripMenuItem exportChanelsOnly = new ToolStripMenuItem("Sensor Abstraction");

            exportAll.Click += mConverter.convertNonAbstract;
            exportSensorsOnly.Click += mConverter.convertAbstractChannel;
            exportChanelsOnly.Click += mConverter.convertAbstractSensor;

            mnuItemConvert2PNModel.DropDownItems.Add(exportAll);
            mnuItemConvert2PNModel.DropDownItems.Add(exportSensorsOnly);
            mnuItemConvert2PNModel.DropDownItems.Add(exportChanelsOnly);

            this.contextMenuStrip1.Items.Add(mnuItemSetType);
            this.contextMenuStrip1.Items.Add(mnuItemConvert2PNModel);
        }

        private void mnuSetTypeSink_Click(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                PAT.Common.GUI.Drawing.LTSCanvas.CanvasItemData SelectedItem = this.SelectedItems[0];
                if (SelectedItem.Item is WSNSensor)
                {
                    // Enable multi sink
                    // Disabled sink before
                    //foreach (CanvasItem state in Canvas.itemsData.Keys)
                    //{
                    //    if (state is WSNSensor && state != null)
                    //        if ((state as WSNSensor).NodeType == SensorType.Sink)
                    //            (state as WSNSensor).NodeType = SensorType.Intermediate;
                    //}

                    (SelectedItem.Item as WSNSensor).NodeType = SensorType.Sink;
                    Canvas.Refresh();
                    SetDirty();
                }
            }
        }

        private void mnuSetTypeIntermediate_Normal_Click(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                PAT.Common.GUI.Drawing.LTSCanvas.CanvasItemData SelectedItem = this.SelectedItems[0];
                if (SelectedItem.Item is WSNSensor)
                {
                    (SelectedItem.Item as WSNSensor).NodeType = SensorType.Intermediate;
                    Canvas.Refresh();
                    SetDirty();
                }
            }
        }

        private void mnuSetTypeSource_Click(object sender, EventArgs e)
        {
            if (this.SelectedItems.Count > 0)
            {
                PAT.Common.GUI.Drawing.LTSCanvas.CanvasItemData SelectedItem = this.SelectedItems[0];
                if (SelectedItem.Item is WSNSensor)
                {
                    // Enable multi source
                    // Disabled source before
                    //foreach (CanvasItem state in Canvas.itemsData.Keys)
                    //{
                    //    if (state is WSNSensor && state != null)
                    //        if ((state as WSNSensor).NodeType == SensorType.Source)
                    //            (state as WSNSensor).NodeType = SensorType.Intermediate;
                    //}

                    (SelectedItem.Item as WSNSensor).NodeType = SensorType.Source;
                    Canvas.Refresh();
                    SetDirty();
                }
            }
        }

        protected override void Button_NetMode_Click(object sender, EventArgs e)
        {
            string currentMode = Build.mMode.ToString();

            if (currentMode.StartsWith(NetMode.UNICAST.ToString().ToUpper()))
            {
                Build.mMode = NetMode.BROADCAST;
                Button_NetMode.Image = PAT.GUI.Properties.Resources.broadcast_mode;
            }

            else if (currentMode.StartsWith(NetMode.BROADCAST.ToString().ToUpper()))
            {
                Build.mMode = NetMode.MULTICAST;
                Button_NetMode.Image = PAT.GUI.Properties.Resources.multicast_mode;
            }
            else if (currentMode.StartsWith(NetMode.MULTICAST.ToString().ToUpper()))
            {
                Build.mMode = NetMode.UNICAST;
                Button_NetMode.Image = PAT.GUI.Properties.Resources.unicast_mode;
            }
        }

        #endregion

        protected override LTSModel LoadModel(string text)
        {
            WSNModel model = WSNModel.LoadModelFromXML(text, _docPNRes);
            mExtendInfo = model.mExtendInfo;
            return model;
            
        }

        protected override LTSModel CreateModel(string declare, List<LTSCanvas> canvas)
        {
            WSNModel model = new WSNModel(mExtendInfo, declare, canvas);
            return model;
        }

        protected override StateItem CreateItem()
        {
            return new WSNSensor(Canvas.StateCounter);
        }

        protected override Form CreateItemEditForm(StateItem item)
        {
            return new SensorEditForm(item);
        }

        protected override Form CreateTransitionEditForm(Route route)
        {
            return new ChannelEditForm(route, Canvas, Build.mMode);
        }

        protected override Route CreateRoute(IRectangle from, IRectangle to)
        {
            return new WSNChannel(from, to);
        }

        protected override void Button_Configuration_Click(object sender, EventArgs e)
        {
            
            (new WSNConfigForm(this, Canvas, mExtendInfo)).ShowDialog();
        }
        
        public void Save(WSNExtendInfo info)
        {
            do
            {
                if (String.IsNullOrEmpty(FileName))
                {
                    MessageBox.Show("Please save this file before perform action!");
                    break;
                }

                mExtendInfo = info;
                Save(FileName);
            } while (false);
        }


    }

    /// <summary>
    /// Interface comunication for this from and sensorconfigfrom
    /// </summary>
    public interface IConfigurationForm
    {
        void Save(WSNExtendInfo info);
    }

    public interface IConvertPN
    {
        void convertNonAbstract(object sender, EventArgs e);
        void convertAbstractSensor(object sender, EventArgs e);
        void convertAbstractChannel(object sender, EventArgs e);
    }
}



