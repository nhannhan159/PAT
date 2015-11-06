using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PAT.Common.GUI.Drawing;
using PAT.Common;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.WSNCommon;

namespace PAT.Module.PN.Model
{
    public class PNModel
    {
        // Save the assertion
        public string Declaration { get; set; }
        public List<PNCanvas> Canvases { get; set; }
        public PNExtendInfo mExtendInfo = new PNExtendInfo();


        public PNModel(string declaration, List<PNCanvas> canvases)
        {
            Declaration = declaration;
            Canvases = canvases;
        }

        /// <summary>
        /// Generate XML from model
        /// </summary>
        /// <returns></returns>
        public XmlDocument GenerateXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement PN = doc.CreateElement(XmlTag.TAG_PN);
            doc.AppendChild(PN);

            XmlElement decl = doc.CreateElement(XmlTag.TAG_DECLARATION);
            decl.InnerText = Declaration;
            PN.AppendChild(decl);

            XmlElement model = doc.CreateElement(XmlTag.TAG_MODELS);
            foreach (PNCanvas canvas in Canvases)
                model.AppendChild(canvas.WriteToXml(doc));

            generateExtendInfo(model);
            PN.AppendChild(model);
            return doc;
        }

        /// <summary>
        /// Parse and load LTS from Xml
        /// </summary>
        /// <param name="text">Xml pure text</param>
        /// <returns></returns>
        public static PNModel LoadLTSFromXML(string text)
        {
            string assertion = string.Empty;
            List<PNCanvas> canvases = new List<PNCanvas>();
            PNExtendInfo extendInfo = null;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);

            XmlNodeList sitesNodes = doc.GetElementsByTagName(XmlTag.TAG_DECLARATION);

            //TODO? What is this for?
            foreach (XmlElement component in sitesNodes)
                assertion = component.InnerText;

            sitesNodes = doc.GetElementsByTagName(XmlTag.TAG_MODELS);

            if (sitesNodes.Count > 0)
            {
                foreach (XmlElement component in sitesNodes[0].ChildNodes)
                {
                    // mlqvu -- set value for extend info
                    // load topology from xml
                    if (component.ChildNodes.Count == 4)
                    {
                        XmlElement topologyElement = (XmlElement)component.ChildNodes[0];
                        extendInfo = loadExtendInfo(topologyElement);
                    }

                    PNCanvas canvas = new PNCanvas();
                    canvas.LoadFromXml(component);
                    canvases.Add(canvas);
                }
            }

            PNModel model = new PNModel(assertion, canvases);
            model.mExtendInfo = extendInfo;

            return model;
        }

        /// <summary>
        /// Generate extend information from model
        /// </summary>
        /// <param name="model"></param>
        private void generateExtendInfo(XmlElement model)
        {
            do
            {
                XmlElement topoElem = (XmlElement)model.GetElementsByTagName(XmlTag.TAG_TOPOLOGY)[0];
                if (topoElem == null)
                    break;

                if (mExtendInfo == null)
                    mExtendInfo = new PNExtendInfo();
                topoElem.SetAttribute(XmlTag.ATTR_mID, mExtendInfo.mID.ToString());
                topoElem.SetAttribute(XmlTag.ATTR_NUMOFSENSORS, mExtendInfo.mNumberSensor.ToString());
                topoElem.SetAttribute(XmlTag.ATTR_NUMOFPACKETS, mExtendInfo.mNumberPacket.ToString());
                topoElem.SetAttribute(XmlTag.ATTR_AVGBUFFER, mExtendInfo.mSensorMaxBufferSize.ToString());
                topoElem.SetAttribute(XmlTag.TAG_MODE, mExtendInfo.mMode.ToString());
                topoElem.SetAttribute(XmlTag.TAG_ABSTRACTEDLEVEL, mExtendInfo.mAbsLevel);
            } while (false);
        }

        /// <summary>
        /// Load extend information from Xml
        /// </summary>
        /// <param name="topoElement"></param>
        /// <returns></returns>
        private static PNExtendInfo loadExtendInfo(XmlElement topoElement)
        {
            PNExtendInfo extendInfo = null;

            do
            {
                extendInfo = new PNExtendInfo();
                String mID=topoElement.Attributes[XmlTag.ATTR_mID].Value;
                String numOfSensor = topoElement.Attributes[XmlTag.ATTR_NUMOFSENSORS].Value;
                String numOfPacket = topoElement.Attributes[XmlTag.ATTR_NUMOFPACKETS].Value;
                String avgBuffer = topoElement.Attributes[XmlTag.ATTR_AVGBUFFER].Value;
                String mode = topoElement.Attributes[XmlTag.TAG_MODE].Value;
                String absLevel = topoElement.Attributes[XmlTag.TAG_ABSTRACTEDLEVEL].Value;

                extendInfo.mID = long.Parse(mID);
                extendInfo.mNumberSensor = Int32.Parse(numOfSensor);
                extendInfo.mNumberPacket = Int32.Parse(numOfPacket);
                extendInfo.mSensorMaxBufferSize = Int32.Parse(avgBuffer);
                extendInfo.mMode = (NetMode)Enum.Parse(typeof(NetMode), mode);
                extendInfo.mAbsLevel = absLevel;
            } while (false);

            return extendInfo;
        }

        public string ToSpecificationString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (PNCanvas canvas in Canvases)
                sb.AppendLine(canvas.GetDeclare());

            sb.AppendLine(Declaration);
            string file = "";
            foreach (string[] eraCanvase in ParsingException.FileOffset.Values)
                file = eraCanvase[0];

            ParsingException.FileOffset.Clear();
            ParsingException.FileOffset.Add(ParsingException.CountLinesInFile(sb.ToString()), new string[] { file, "Declaration" });
            foreach (PNCanvas canvas in Canvases)
            {
                sb.AppendLine(canvas.ToSpecificationString());
                ParsingException.FileOffset.Add(ParsingException.CountLinesInFile(sb.ToString()), new string[] { file, canvas.Node.Text });
            }

            return sb.ToString();
        }
    }
}
