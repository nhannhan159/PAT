using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Tools.Diagrams;

using PAT.Common.GUI.Drawing;
using System.Windows.Forms;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.ModelCommon;

namespace PAT.Module.KWSN
{

    // useless

    /// <summary>
    /// Wireless Sensor Network canvas
    /// </summary>
    public class WSNCanvas : LTSCanvas
    {
        public WSNCanvas(String Name)
            : base()
        {
            this.ProcessName = Name;
        }

        //public WSNCanvas(XmlDocument PNRes)
        //    : base()
        //{
        //    this.PNDocResource = PNRes;
        //}

        public String ProcessName { get; set; }

        public WSNCanvas Duplicate()
        {
            WSNCanvas duplicate = new WSNCanvas();
            duplicate.LoadFromXml(this.Clone());
            duplicate.Node.Text = this.Node.Text + "-Copy";

            bool nameExist = true;
            while (nameExist)
            {
                nameExist = false;
                foreach (TreeNode node in this.Node.Parent.Nodes)
                {
                    if (node.Text.Equals(duplicate.Node.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        duplicate.Node.Text = duplicate.Node.Text + "-Copy";
                        nameExist = true;
                        break;
                    }
                }
            }

            return duplicate;
        }

        public WSNCanvas() : base() { }

        #region Model Save/Load
        #region Model Loading
        protected override void LoadStates(XmlElement procNode)
        {
            XmlElement sensors = (XmlElement)procNode.ChildNodes[0];
            WSNSensor canvasSensor = null;
            foreach (XmlElement xmlSen in sensors.ChildNodes)
            {
                canvasSensor = new WSNSensor(StateCounter);
                canvasSensor.LoadFromXml(xmlSen);
                AddSingleCanvasItem(canvasSensor);
                AddSingleCanvasItem(canvasSensor.labelItems);
            }
        }

        protected override Route LoadRoute(XmlElement element)
        {
            WSNChannel route = new WSNChannel(null, null);
            route.LoadFromXML(element, this);

            return route;
        }
        #endregion

        #region Model Saving
        protected override void WriteStates(XmlDocument doc, XmlElement canvasElement)
        {
            XmlElement sensors = doc.CreateElement(XmlTag.TAG_SENSORS);
            canvasElement.AppendChild(sensors);

            foreach (CanvasItemData item in itemsList)
            {
                if (item.Item is StateItem)
                    sensors.AppendChild(item.Item.WriteToXml(doc));
            }
        }
        #endregion
        #endregion

        #region PN Export
        protected XmlDocument _docRes = null;
        public virtual XmlDocument PNDocResource
        {
            get { return _docRes; }
            set { _docRes = value; }
        }
        #endregion
    }
}
