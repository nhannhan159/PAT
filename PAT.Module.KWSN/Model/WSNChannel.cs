using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

using Tools.Diagrams;

using PAT.Common.GUI.Drawing;
using PAT.KWSN.Model;
using PAT.Common.Utility;
using System.Drawing;
using System.Drawing.Drawing2D;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.ModelCommon;

namespace PAT.Module.KWSN
{
    public enum ChannelType
    {
        None = 0,

        Unicast,
        Broadcast,
        Multicast,
    }

    public enum ChannelKind
    {
        Virtual = 0,
        Real,
    }

    public class WSNChannel : Route, IWSNBase, ICloneable
    {
        private static String TAG = "WSNChannel";

        public WSNChannel(IRectangle from, IRectangle to)
            : base(from, to)
        {
            if (from != null && to != null)
                ID = getPureId();

            // Default value
            Kind = ChannelKind.Real;
            SendingRate = 10;
            Type = ChannelType.Broadcast;
            SubIdList = new List<int>();
            Neighbor = false;
            CongestionLevel = CGNLevel.Low;
        }

        public string ID { get; set; }
        public virtual ChannelKind Kind { get; set; }
        public virtual ChannelType Type { get; set; }
        public List<int> SubIdList { get; set; }
        public CGNLevel CongestionLevel { get; set; }

        private string _broadcastId = null;
        public string BroadcastId
        {
            get
            {
                if (_broadcastId != null)
                    return _broadcastId;

                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append(getPureId());
                foreach (int item in SubIdList)
                    sbuilder.Append("_" + item);
                return sbuilder.ToString();
            }

            set { _broadcastId = value; }
        }

        public Boolean Neighbor { get; set; }
        public int SendingRate { get; set; }

        public String FromSensorName
        {
            get
            {
                return (From as WSNSensor).Name;
            }
        }

        public String ToSensorName
        {
            get
            {
                return (To as WSNSensor).Name;
            }
        }

        private string getPureId()
        {
            string ret = "";
            int srcID = -1;
            int dstID = -1;

            try
            {
                srcID = ((WSNSensor)from).ID;
                dstID = ((WSNSensor)to).ID;
            }
            catch 
            {
                DevLog.e(TAG, "Parse ID error");    
            }

            if (srcID > 0 && dstID > 0)
                ret = srcID + "_" + dstID;

            return ret;
        }

        public WSNChannel Clone()
        {
            return (WSNChannel)this.MemberwiseClone();
        }

        #region Data saving/loading
        public override void LoadFromXML(XmlElement xmlElement, LTSCanvas canvas)
        {
            base.LoadFromXML(xmlElement, canvas);
            try
            {
                Kind = (ChannelKind)Enum.Parse(typeof(ChannelKind), xmlElement.GetAttribute(XmlTag.ATTR_CHANNEL_KIND), true);
                Type = (ChannelType)int.Parse(xmlElement.GetAttribute(XmlTag.ATTR_LINK_TYPE));
                SendingRate = int.Parse(xmlElement.GetAttribute(XmlTag.ATTR_MAX_SENDING_RATE));

                string cgnLevel = xmlElement.GetAttribute(XmlTag.ATTR_CONGESTION_LEVEL);
                CongestionLevel = (CGNLevel)Enum.Parse(typeof(CGNLevel), cgnLevel); 

                ID = xmlElement.GetAttribute(XmlTag.ATTR_ID);
                if (ID != null && ID.Length == 0)
                    ID = null;
            }
            catch (Exception ex)
            {
                DevLog.d(TAG, ex.ToString());
            }
        }

        public override XmlElement WriteToXml(XmlDocument doc)
        {
            XmlElement node = base.WriteToXml(doc);
            node.SetAttribute(XmlTag.ATTR_CHANNEL_KIND, Kind.ToString());
            node.SetAttribute(XmlTag.ATTR_LINK_TYPE, ((int)Type).ToString());
            node.SetAttribute(XmlTag.ATTR_MAX_SENDING_RATE, SendingRate.ToString());
            node.SetAttribute(XmlTag.ATTR_CONGESTION_LEVEL, ((int)CongestionLevel).ToString());

            if (ID != null && ID.Length > 0)
            {
                string[] subId = ID.Split('_');
                string id = ID;
                if (subId.Length > 1)
                    id = subId[0] + "_" + subId[1];

                node.SetAttribute(XmlTag.ATTR_ID, id);
            }

            return node;
        }
        #endregion

        public virtual WSNPNData GeneratePNXml(XmlDocument doc, string id, bool isAbstract, float xShift, float yShift)
        {
            string modelName = Type.ToString();
            if (isAbstract)
                modelName = "CollapsedChannel";

            return WSNUtil.GetPNXml(doc, id, modelName, ID, xShift, yShift);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        protected override void setLinkKind(Pen pen)
        {
            if (Kind == ChannelKind.Virtual)
                pen.DashStyle = DashStyle.Dash;
        }
    }

}
