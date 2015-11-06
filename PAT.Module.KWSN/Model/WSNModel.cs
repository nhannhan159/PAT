using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using PAT.Common.GUI.LTSModule;
using PAT.Common.GUI.Drawing;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.KWSN.Model;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.PNCommon;

namespace PAT.Module.KWSN
{

    #region PN Model define

    public class WSNPNData
    {
        public XmlElement places = null;
        public XmlElement transitions = null;
        public XmlElement arcs = null;

        public NodeInfo inNode;
        public NodeInfo outNode;

        public string nodeId = null;

        public void clear()
        {
            places = null;
            transitions = null;
            arcs = null;

            inNode = new NodeInfo();
            outNode = new NodeInfo();

            nodeId = null;
        }
    }

    public class Position
    {
        public float x = -1;
        public float y = -1;

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", x, y);
        }
    }

    public class NodeInfo
    {
        public string name;
        public Position pos;
    }

    public enum CGNLevel 
    {
        Low,
        Medium,
        Heigh
    }
    #endregion

    /// <summary>
    /// Wireless Sensor Network model
    /// </summary>
    public class WSNModel : LTSModel
    {
        public WSNExtendInfo mExtendInfo = new WSNExtendInfo();

        public WSNModel() : base() { }

        public WSNModel(String declare, List<LTSCanvas> canvas) : base(declare, canvas) { }

        public WSNModel(WSNExtendInfo extendInfo, String declare, List<LTSCanvas> canvas)
            : base(declare, canvas)
        {
            if (extendInfo != null)
                mExtendInfo = extendInfo;
        }

        /// <summary>
        /// Load model from XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="PNDocRes"></param>
        /// <returns></returns>
        public static WSNModel LoadModelFromXML(string xml, XmlDocument PNDocRes)
        {
            WSNModel model = new WSNModel();

            do
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.LoadXml(xml);
                }
                catch { }

                XmlNodeList nodes = null;
                do
                {
                    nodes = doc.GetElementsByTagName(XmlTag.TAG_DECLARATION);
                    if (nodes == null || nodes.Count != 1)
                        break;

                    model.Declaration = nodes.Item(0).InnerText;
                } while (false);

                do
                {
                    nodes = doc.GetElementsByTagName(XmlTag.TAG_NETWORK);
                    if (nodes == null)
                        break;

                    // mlqvu -- load attributes for network tag
                    XmlNode firstNetworkNode = nodes[0];
                    if (firstNetworkNode == null)
                        break;

                    if (model.mExtendInfo == null)
                        model.mExtendInfo = new WSNExtendInfo();

                    try
                    {
                        String noID = firstNetworkNode.Attributes[XmlTag.ATTR_mID].Value;
                        model.mExtendInfo.mID = long.Parse(noID);

                        String noPacket = firstNetworkNode.Attributes[XmlTag.ATTR_NUMOFPACKETS].Value;
                        model.mExtendInfo.mNumberPacket = Int32.Parse(noPacket);

                        String noSensor = firstNetworkNode.Attributes[XmlTag.ATTR_NUMOFSENSORS].Value;
                        model.mExtendInfo.mNumberSensor = Int32.Parse(noSensor);

                        String maxSensorBufferSize = firstNetworkNode.Attributes[XmlTag.ATTR_SENSOR_MAX_BUFFER_SIZE].Value;
                        model.mExtendInfo.mSensorMaxBufferSize = Int32.Parse(maxSensorBufferSize);

                        String maxSensorQueueSize = firstNetworkNode.Attributes[XmlTag.ATTR_SENSOR_MAX_QUEUE_SIZE].Value;
                        model.mExtendInfo.mSensorMaxQueueSize = Int32.Parse(maxSensorQueueSize);

                        String maxChannelBufferSize = firstNetworkNode.Attributes[XmlTag.ATTR_CHANNEL_MAX_BUFFER_SIZE].Value;
                        model.mExtendInfo.mChannelMaxBufferSize = Int32.Parse(maxChannelBufferSize);
                    }
                    catch (Exception e) { }

                    LTSCanvas canvas = null;
                    foreach (XmlElement node in nodes[0].ChildNodes)
                    {
                        canvas = new WSNCanvas(node.GetAttribute(XmlTag.ATTR_NAME));
                        canvas.LoadFromXml(node);
                        model.Processes.Add(canvas);
                    }
                } while (false);
            } while (false);

            return model;
        }

        /// <summary>
        /// Generate the XML data
        /// </summary>
        /// <returns></returns>
        public override XmlDocument GenerateXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element = null;

            XmlElement root = doc.CreateElement(XmlTag.TAG_WSN);
            doc.AppendChild(root);

            element = doc.CreateElement(XmlTag.TAG_DECLARATION);
            element.InnerText = Declaration;
            root.AppendChild(element);

            element = doc.CreateElement(XmlTag.TAG_NETWORK);

            // mlqvu -- set attributes for network tag
            try
            {
                element.SetAttribute(XmlTag.ATTR_mID, mExtendInfo.mID.ToString());
                element.SetAttribute(XmlTag.ATTR_NUMOFSENSORS, mExtendInfo.mNumberSensor.ToString());
                element.SetAttribute(XmlTag.ATTR_NUMOFPACKETS, mExtendInfo.mNumberPacket.ToString());
                element.SetAttribute(XmlTag.ATTR_SENSOR_MAX_BUFFER_SIZE, mExtendInfo.mSensorMaxBufferSize.ToString());
                element.SetAttribute(XmlTag.ATTR_SENSOR_MAX_QUEUE_SIZE, mExtendInfo.mSensorMaxQueueSize.ToString());
                element.SetAttribute(XmlTag.ATTR_CHANNEL_MAX_BUFFER_SIZE, mExtendInfo.mChannelMaxBufferSize.ToString());
            }
            catch (Exception e) { }

            foreach (LTSCanvas canvas in Processes)
                element.AppendChild(canvas.WriteToXml(doc));

            root.AppendChild(element);

            return doc;
        }
    }
}
