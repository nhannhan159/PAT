using PAT.Common.GUI.Drawing;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.Utility;
using PAT.GUI.Docking;
using PAT.GUI.Helper;
using PAT.GUI.KWSNDrawing;
using PAT.GUI.ModuleGUI;
using PAT.GUI.Utility;
using PAT.KWSN.Model;
using PAT.Module.KWSN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Tools.Diagrams;


namespace PAT.GUI
{
    /// <summary>
    /// Used for generate PN files
    /// </summary>
    public class PNGenerationHelper : GenerationHelper
    {
        private const string TAG = "PnGenerationHelper";
        private const string PNBaseFileName = "wsn-pn-based.xml";
        private const int XPOSITION_SHIFT = 1;
        private const int YPOSITION_SHIFT = 1;

        private WSNExtendInfo mExtendInfo = null;
        private XmlDocument mDocOut = null; // Document generate
        private XmlElement mXRoot = null;
        private XmlElement mDeclaration = null;
        private XmlDocument mDocPNRes;

        private IList<WSNCanvas> mCanvas;
        private float mMinX = 0;
        private float mMinY = 0;

        public PNGenerationHelper(string name, EditorTabItem tabItem) : base(name, tabItem)
        {
            try
            {
                WSNTabItem wsnTabItem = (WSNTabItem)tabItem;
                mCanvas = wsnTabItem.getAllCanvas();
                mDocPNRes = wsnTabItem.PNRes;

                // Get extend information
                mExtendInfo = wsnTabItem.mExtendInfo;

                initXML();
                mLoaded = true;
            }
            catch (Exception ex)
            {
                DevLog.d(TAG, "Can not read wsn document");
            }
        }

        private void initXML()
        {
            mDocOut = new XmlDocument();
            mXRoot = mDocOut.CreateElement(XmlTag.TAG_PN);
            mDeclaration = mDocOut.CreateElement((XmlTag.TAG_DECLARATION));
            mXRoot.AppendChild(mDeclaration);
            mDocOut.AppendChild(mXRoot);
        }

        /// <summary>
        /// Generate PN xml file from KWSN model
        /// </summary>
        /// <param name="abstractSensor">if Sensors are abstracted</param>
        /// <param name="abstractChannel">if Channel are abstracted</param>
        /// <returns>PN xml</returns>
        public override XmlDocument GenerateXML(params bool[] values)
        {
            do
            {
                if (values == null || values.Count() != 2)
                {
                    DevLog.e(TAG, "Incorrect input params");
                    break;
                }

                bool abstractSensor = values[0];
                bool abstractChannel = values[1];

                bool blError = false;
                XmlElement models = mDocOut.CreateElement(XmlTag.TAG_MODELS);
                mXRoot.AppendChild(models);

                foreach (WSNCanvas canvas in mCanvas)
                {
                    List<WSNSensor> sensors = new List<WSNSensor>(); // sensors list from canvas
                    List<WSNChannel> channels = new List<WSNChannel>();  // channel list from canvas
                    StringBuilder ltlSensorCongestion = new StringBuilder(); // LTL for check on sensor
                    StringBuilder ltlChannelCongestion = new StringBuilder(); // LTL for check on channel
                    int maxSensorId = 0;
                    List<Int32> sensorCheckIds = new List<Int32>();

                    foreach (LTSCanvas.CanvasItemData item in canvas.itemsList) // get the sensors list
                    {
                        if (item.Item is WSNSensor)
                        {
                            WSNSensor add = (WSNSensor)item.Item;
                            add.locateX = item.Item.X / 120;
                            add.locateY = item.Item.Y / 120;

                            if (mMinX == 0 || add.locateX < mMinX)
                                mMinX = add.locateX;
                            if (mMinY == 0 || add.locateY < mMinY)
                                mMinY = add.locateY;

                            sensors.Add(add.Clone());
                            if (add.ID > maxSensorId)
                                maxSensorId = add.ID;

                            // Append LTL for sensor congestion
                            if (abstractSensor || add.NodeType != SensorType.Intermediate)
                                continue;
                            sensorCheckIds.Add(add.ID);
                        }
                    }

                    // Add LTL check congestion on sensor
                    int interCnt = sensorCheckIds.Count;
                    if (interCnt > 0)
                    {
                        ltlSensorCongestion.Append("#assert System |= []!(");
                        for (int i = 0; i < interCnt - 1; i++)
                            ltlSensorCongestion.Append(String.Format("Congestion{0} || ", sensorCheckIds[i]));
                        ltlSensorCongestion.Append(String.Format("Congestion{0});", sensorCheckIds[interCnt - 1]));
                    }

                    // Get the channels list
                    foreach (Route route in canvas.diagramRouter.routes)
                    {
                        if (route is WSNChannel)
                        {
                            WSNChannel channel = (WSNChannel)route;
                            channel.Type = getChannelType(Build.mMode);
                            channels.Add(channel.Clone());
                        }
                    }

                    XmlElement topology = mDocOut.CreateElement(XmlTag.TAG_TOPOLOGY);
                    topology.SetAttribute(XmlTag.ATTR_mID, mExtendInfo.mID.ToString());
                    topology.SetAttribute(XmlTag.ATTR_NUMOFSENSORS, mExtendInfo.mNumberSensor.ToString());
                    topology.SetAttribute(XmlTag.ATTR_NUMOFPACKETS, mExtendInfo.mNumberPacket.ToString());
                    topology.SetAttribute(XmlTag.ATTR_AVGBUFFER, mExtendInfo.mSensorMaxBufferSize.ToString());
                    topology.SetAttribute(XmlTag.TAG_MODE, Build.mMode.ToString());
                    topology.SetAttribute(XmlTag.TAG_ABSTRACTEDLEVEL, (abstractSensor ? "0" : "1") + (abstractChannel ? "0" : "1"));

                    foreach (WSNSensor sensor in sensors) // append sensor to topology
                        topology.AppendChild(sensor.WriteToXml(mDocOut));

                    foreach (WSNChannel channel in channels) // append channel to topology
                        topology.AppendChild(channel.WriteToXml(mDocOut));

                    XmlElement model = mDocOut.CreateElement(XmlTag.TAG_MODEL);
                    XmlElement places = mDocOut.CreateElement(XmlTag.TAG_PLACES);
                    XmlElement transitions = mDocOut.CreateElement(XmlTag.TAG_TRANSITIONS);
                    XmlElement arcs = mDocOut.CreateElement(XmlTag.TAG_ARCS);

                    models.AppendChild(model);
                    model.AppendChild(topology);
                    model.AppendChild(places);
                    model.AppendChild(transitions);
                    model.AppendChild(arcs);

                    do
                    {
                        WSNPNData data = null;
                        float xStartPos = 0;
                        float yStartPos = 0;

                        Hashtable mapData = new Hashtable();
                        bool localSensorAbstract;
                        foreach (WSNSensor sensor in sensors)
                        {
                            // Force keep source sensor in case unicast or multicast
                            localSensorAbstract = abstractSensor;
                            if (sensor.NodeType == SensorType.Source
                                && abstractSensor && (Build.mMode == NetMode.UNICAST || Build.mMode == NetMode.MULTICAST))
                                localSensorAbstract = false;

                            data = sensor.GeneratePNXml(mDocPNRes, sensor.ID.ToString(), localSensorAbstract, sensor.locateX - mMinX, sensor.locateY - mMinY);
                            if (data == null)
                            {
                                DevLog.e(TAG, "Failed to generate the sensor PN xml nodes");
                                blError = true;
                                break;
                            }

                            mapData[sensor.ID] = data;
                            xStartPos += XPOSITION_SHIFT;

                            // Embed code for sensor
                            BuildUtils.embedCodeToSensor(data, sensor, channels, abstractSensor);
                            addPNData(data, ref places, ref transitions, ref arcs);

                            // Then find the channel connected with this sensor
                            foreach (WSNChannel channel in channels)
                            {
                                WSNSensor sensorFrom = (WSNSensor)channel.From;
                                if (sensorFrom.ID != sensor.ID)
                                    continue;

                                // compute positon for channel
                                xStartPos = (channel.From.AbsoluteX + channel.To.AbsoluteX) / 240;
                                yStartPos = (channel.From.AbsoluteY + channel.To.AbsoluteY) / 240;

                                data = channel.GeneratePNXml(mDocPNRes, channel.ID, abstractChannel, xStartPos - mMinX, yStartPos - mMinY);
                                if (data == null)
                                {
                                    DevLog.d(TAG, "Failed to generate the sensor PN xml nodes");
                                    blError = true;
                                    break;
                                }

                                mapData[channel.ID] = data;
                                xStartPos += XPOSITION_SHIFT; // Shift x position
                                yStartPos += YPOSITION_SHIFT; // Shift y position

                                BuildUtils.embedCodeToChannel(data, channel, abstractChannel, abstractSensor);
                                addPNData(data, ref places, ref transitions, ref arcs);
                            } // foreach

                            if (blError == true)
                                break;
                        } // foreach

                        if (blError == true)
                            break;

                        switch (Build.mMode)  // build connector by mode
                        {
                            case NetMode.BROADCAST:
                                if (abstractChannel)
                                {
                                    BuildUtils.buildConnectorBroadcast1(mDocOut, arcs, mapData, channels);
                                    break;
                                }
                                
                                BuildUtils.buildConnectorBroadcast2(mDocOut, transitions, canvas, places, arcs, mapData, sensors, channels, abstractSensor, abstractChannel);
                                break;

                            case NetMode.UNICAST:
                                BuildUtils.buildConnectorUnicast(mDocOut, arcs, mapData, channels, abstractSensor);
                                break;

                            case NetMode.MULTICAST:
                                BuildUtils.buildConnectorMulticast(mDocOut, arcs, mapData, channels, abstractSensor);
                                break;

                            default:
                                break;
                        }

                        #region Update model properties
                        // update the property
                        model.SetAttribute(XmlTag.ATTR_NAME, canvas.ProcessName);
                        model.SetAttribute(XmlTag.ATTR_PRO_PARAM, "");
                        model.SetAttribute(XmlTag.ATTR_ZOOM, "1");
                        model.SetAttribute(XmlTag.TAG_MODEL_PRO_PCOUNTER, "0");
                        model.SetAttribute(XmlTag.TAG_MODEL_PRO_TCOUNTER, "0");
                        #endregion

                        mDocOut.Save(mFileName); // save document
                    } while (false);

                    // Add LTL check congestion on channel
                    if (abstractChannel == false && channels.Count > 0)
                    {
                        ltlChannelCongestion.Append("#assert System |= []!(");
                        for (int i = 0; i < channels.Count - 1; i++)
                            ltlChannelCongestion.AppendFormat("Congestion{0} || ", channels[i].ID);
                        ltlChannelCongestion.AppendFormat("Congestion{0});", channels[channels.Count - 1].ID);
                    }

                    // add declaration
                    mDeclaration.InnerXml = String.Format(mDocPNRes.GetElementsByTagName(
                        XmlTag.TAG_DECLARATION)[0].InnerXml,
                        BuildUtils.buildDeclaration(mExtendInfo, sensors, channels),
                        ltlSensorCongestion.ToString(), // LTL for check on sensor
                        ltlChannelCongestion.ToString()); // LTL for check on channel
                }
            } while (false);

            return mDocOut;
        }

        /// <summary>
        /// Convert Netmode to Channel type
        /// </summary>
        /// <param name="_mode">Netmode instance</param>
        /// <returns>Channel type</returns>
        private ChannelType getChannelType(NetMode _mode)
        {
            ChannelType channelType = ChannelType.Unicast;
            if (_mode == NetMode.BROADCAST)
                channelType = ChannelType.Broadcast;
            else if (_mode == NetMode.MULTICAST)
                channelType = ChannelType.Multicast;

            return channelType;
        }

        /// <summary>
        /// Update the PN data to the final output file
        /// </summary>
        /// <param name="data">The input PN data of current item</param>
        /// <param name="places">Places node parent</param>
        /// <param name="transitions">Transitions node parent</param>
        /// <param name="arcs">Arcs node parent</param>
        private void addPNData(WSNPNData data, ref XmlElement places, ref XmlElement transitions, ref XmlElement arcs)
        {
            XmlElement[,] map = new XmlElement[,]
            {
                { data.places, places },
                { data.transitions, transitions },
                { data.arcs, arcs },
            };
            XmlDocumentFragment xFrag = null;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                foreach (XmlElement xml in map[i, 0].ChildNodes)
                {
                    xFrag = mDocOut.CreateDocumentFragment();
                    xFrag.InnerXml = xml.OuterXml;
                    map[i, 1].AppendChild(xFrag);
                }
            }
        }

        /// <summary>
        /// Verify source/sink before export
        /// </summary>
        /// <returns>true if verify Ok</returns>
        public override bool canExport()
        {
            bool ret = true;
            foreach (WSNCanvas canvas in mCanvas)
            {
                int sink = 0;
                int source = 0;
                
                // Get sensor list
                foreach (LTSCanvas.CanvasItemData item in canvas.itemsList)
                { 
                    if (item.Item is WSNSensor) {
                        if (((WSNSensor) item.Item).NodeType == SensorType.Source) 
                        {
                            source++;
                            continue;
                        }

                        if (((WSNSensor) item.Item).NodeType == SensorType.Sink) 
                        {
                            sink++;
                            continue;
                        }
                    }
                }

                if (sink == 0 || source == 0) 
                {
                    ret = false;
                    break;
                } 
            }

            return ret;
        }
    }
}
