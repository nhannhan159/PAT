using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.IO;
using PAT.Common.GUI.Drawing;
using System.Windows.Forms;
using Tools.Diagrams;
using PAT.Module.KWSN;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.ModelCommon.PNCommon;
using PAT.GUI.Helper;
using PAT.GUI.Docking;
using PAT.Common.Utility;
using PAT.Common.ModelCommon;


namespace PAT.GUI
{
    public class KWSNGenerationHelper : GenerationHelper
    {
        private const string TAG = "KWSNExportHelper";

        private XmlElement mXRoot = null;
        private XmlElement mDeclaration = null;
        private XmlDocument mPNDoc;

       
        public string GetGeneratedFileName()
        {
            return mFileName;
        }

        /// <summary>
        /// The function used to convert from PN to KWSN
        /// </summary>
        /// <param name="topology">input PN file</param>
        /// 
        public KWSNGenerationHelper(string name, EditorTabItem tabItem) : base(name, tabItem)
        {
            mPNDoc = new XmlDocument();
            try
            {
                mPNDoc.Load(tabItem.FileName);
                mLoaded = true;
            }
            catch
            {
                DevLog.e(TAG, String.Format("Error when load PN file ({0})", name));
                MessageBox.Show("Error when reading PN file!");
            }
        }

        private XmlElement GenerateCanvasXml(XmlDocument docOut, String name, List<WSNSensorIndie> sensors, List<WSNChannelIndie> channels)
        {
            XmlElement process = docOut.CreateElement(LTSCanvas.PROCESS_NODE_NAME);
            process.SetAttribute(LTSCanvas.NAME_PROCESS_NODE_NAME, name);
            process.SetAttribute(LTSCanvas.PARAMETER_NODE_NAME, "");
            process.SetAttribute(LTSCanvas.ZOOM_PROCESS_NODE_NAME, "1");
            process.SetAttribute(LTSCanvas.STATE_COUNTER, (sensors.Count + 1).ToString(System.Globalization.CultureInfo.InvariantCulture)); 

            //Sensors
            XmlElement sensorElems = docOut.CreateElement(LTSCanvas.STATES_NODE_NAME);
            process.AppendChild(sensorElems);
            foreach (WSNSensorIndie sensor in sensors)
                sensorElems.AppendChild(sensor.WriteToXml(docOut));

            //Channels
            XmlElement channelElems = docOut.CreateElement(LTSCanvas.LINKS_NODE_NAME);
            process.AppendChild(channelElems);
            foreach (WSNChannelIndie channel in channels)
                channelElems.AppendChild(channel.WriteToXml(docOut));

            return process;
        }


        public override XmlDocument GenerateXML(params bool[] values)
        {
            XmlDocument docOut = null;
            do
            {
                if (mLoaded == false)
                    break;
                docOut = new XmlDocument();

                // WSN
                #region generate kwsn xml file
                mXRoot = docOut.CreateElement(XmlTag.TAG_WSN);
                docOut.AppendChild(mXRoot);

                // Network
                XmlElement network = docOut.CreateElement(XmlTag.TAG_NETWORK);
                mXRoot.AppendChild(network);

                //Declaration
                mDeclaration = docOut.CreateElement(XmlTag.TAG_DECLARATION);
                mDeclaration.InnerText = "";
                mXRoot.AppendChild(mDeclaration);

                #region get kwsn components from the extended pn file

                XmlElement models = (mPNDoc.ChildNodes[0] as XmlElement).GetElementsByTagName(XmlTag.TAG_MODELS)[0] as XmlElement;

                foreach (XmlElement model in models.ChildNodes)
                {
                    String modelName = model.GetAttribute(XmlTag.ATTR_NAME);

                    List<WSNSensorIndie> _sensors = new List<WSNSensorIndie>();
                    List<WSNChannelIndie> _channels = new List<WSNChannelIndie>();

                    XmlElement topology = model.GetElementsByTagName(XmlTag.TAG_TOPOLOGY)[0] as XmlElement;

                    //Load base attribute
                    String _abstractedLevel = topology.GetAttribute(XmlTag.TAG_ABSTRACTEDLEVEL, "");

                    //Load sensors list
                    XmlNodeList sensorNodes = topology.GetElementsByTagName(XmlTag.TAG_SENSOR);
                    foreach (XmlElement element in sensorNodes)
                    {
                        WSNSensorIndie sensor = new WSNSensorIndie();
                        sensor.LoadFromXML(element);
                        _sensors.Add(sensor);
                    }

                    //Load channels list
                    XmlNodeList channelNodes = topology.GetElementsByTagName(XmlTag.TAG_CHANNEL);
                    foreach (XmlElement element in channelNodes)
                    {
                        WSNChannelIndie channel = new WSNChannelIndie();
                        channel.LoadFromXML(element);
                        _channels.Add(channel);
                    }

                    network.AppendChild(GenerateCanvasXml(docOut, modelName, _sensors, _channels));
                #endregion

                }
                #endregion
            } while (false);

            return docOut;
        }

        public override bool canExport()
        {
            return true;
        }
    }
}
