using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

using PAT.Common.Utility;
using PAT.Common.GUI.Drawing;
using PAT.KWSN.Model;
using PAT.KWSN.Properties;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.WSNCommon;

namespace PAT.Module.KWSN
{
    public enum SensorType
    {
        None = 0,

        Source,
        Sink,
        Intermediate,
    }

    public class WSNSensor : StateItem, IWSNBase, ICloneable
    {
        private const String TAG = "WSNSensor";

        public float locateX;
        public float locateY;
        
        #region Property define
        

        public override bool IsInitialState
        {
            get { return initialState; }
            set
            {
                initialState = value;

                if (initialState == true)
                    NodeType = SensorType.Source;
            }
        }

        public SensorType NodeType { get; set; }
        public virtual int ID { get; set; }
        public int ProcessingRate { get; set; }
        public int SendingRate { get; set; }
        public CGNLevel CongestionLevel { get; set; }
        #endregion

        public WSNSensor(int id)
            : base(false, "Sensor " + id)
        {
            ID = id;
            SendingRate = 10;
            ProcessingRate = 10;
            NodeType = SensorType.Intermediate;
            CongestionLevel = CGNLevel.Low;
        }

        public WSNSensor Clone()
        {
            return (WSNSensor) this.MemberwiseClone();
        }

        public override void HandleMouseUp(PointF pos)
        {
            base.HandleMouseUp(pos);
            labelItems.MoveFast(AbsoluteX - 10, AbsoluteY + 25);
        }

        #region Model Save/Load
        public override void LoadFromXml(XmlElement element)
        {
            // Base load first
            base.LoadFromXml(element);
            try
            {
                NodeType = (SensorType)Int32.Parse(element.GetAttribute(XmlTag.ATTR_SENSOR_TYPE));
                if (NodeType == SensorType.Source)
                    initialState = true;

                ID = int.Parse(element.GetAttribute(XmlTag.ATTR_ID));

                SendingRate = Int32.Parse(element.GetAttribute(XmlTag.ATTR_MAX_SENDING_RATE));
                ProcessingRate = Int32.Parse(element.GetAttribute(XmlTag.ATTR_MAX_PROCESSING_RATE));
                
                string cngLevel = element.GetAttribute(XmlTag.ATTR_CONGESTION_LEVEL);
                CongestionLevel = (CGNLevel)Enum.Parse(typeof(CGNLevel), cngLevel);
            }
            catch (Exception ex)
            {
                DevLog.d(TAG, ex.ToString());
            }
        }

        protected override XmlElement CreateXmlElement(XmlDocument doc)
        {
            return doc.CreateElement(XmlTag.TAG_SENSOR);
        }

        protected override void FillXmlElement(XmlElement element, XmlDocument document)
        {
            base.FillXmlElement(element, document);

            element.SetAttribute(XmlTag.ATTR_SENSOR_TYPE, ((int)NodeType).ToString());
            if (ID > 0)
                element.SetAttribute(XmlTag.ATTR_ID, ID.ToString());

            element.SetAttribute(XmlTag.ATTR_MAX_SENDING_RATE, SendingRate.ToString());
            element.SetAttribute(XmlTag.ATTR_MAX_PROCESSING_RATE, ProcessingRate.ToString());
            element.SetAttribute(XmlTag.ATTR_CONGESTION_LEVEL, ((int)CongestionLevel).ToString());
        }
        #endregion

        /// <summary>
        /// Custom icon for WSN module
        /// </summary>
        /// <param name="graphics"></param>
        protected override void customIcon(Graphics graphics) 
        {

            Image imgIcon = Resources.ic_intermediate;

            switch (NodeType) 
            { 
                case SensorType.Source:
                    imgIcon = Resources.ic_source;
                    break;

                case SensorType.Sink:
                    imgIcon = Resources.ic_sink;
                    break;

                default:
                    break;
            }


            graphics.DrawImage(imgIcon, AbsoluteX - 5, AbsoluteY - 5, 30, 30);
        }

        #region PN Exported
        /// <summary>
        /// Generate the PN model of this sensor
        /// </summary>
        /// <param name="PNRes">PN model resource reference document</param>
        /// <param name="xShift"></param>
        /// <param name="yShift"></param>
        /// <returns></returns>
        public virtual WSNPNData GeneratePNXml(XmlDocument doc, string id, bool isCollapsed, float xShift, float yShift)
        {
            WSNPNData data = null;
            do
            {
                if (ID < 0)
                    break;

                string pnName = NodeType.ToString();
                if (isCollapsed)
                    pnName = "Collapsed" + NodeType.ToString();
                data = WSNUtil.GetPNXml(doc, id, pnName, ID.ToString(), xShift, yShift);
            } while (false);

            return data;
        }

        #endregion

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
