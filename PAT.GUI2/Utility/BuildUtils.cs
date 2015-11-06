using PAT.Common.GUI.Drawing;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.GUI.ModuleGUI;
using PAT.Module.KWSN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using Tools.Diagrams;

namespace PAT.GUI.Utility
{
    public class BuildUtils
    {
        // Source 
        private const string GBK_SENSOR_SOURCE_SEND = "pkg > 0";

        // Sink
        private const string PBK_SENSOR_SINK_RECEIVE = "q{0} = q{0} + b{0};\nb{0} = 0;";

        // Intermediate
        // {0} - sensor ID
        private const string PBK_SENSOR_INTERFULL_RECEIVE =
            "var sub = util.getMin(b{0}, sbr{0});"
            + "\nif (testMode == 0)"
            + "\n\tsub = util.getRandInt(1, sub);"
            + "\nq{0} = q{0} + sub;"
            + "\nb{0} = b{0} - sub;"
            + "\n\nif (b{0} > 0)\n\tInput{0} = 1;";

        // {0} - sensor ID
        private const string GBK_SENSOR_INTERFULL_RECEIVE = "b{0} > 0 && b{0} < S_MAX_BUFFER";

        // {0} - sensor ID
        private const string GBK_SENSOR_INTERFULL_CONGESTION = "b{0} >= S_MAX_BUFFER";

        // Broadcast - Send
        // {0} - channel ID/ {1} - to sensor ID
        private const string PBK_CHANNEL_SEND =
            "var sub = util.getMin(b{0}, r{0});"
            + "\nif (testMode == 0)"
            + "\n\tsub = util.getRandInt(1, sub);"
            + "\nb{1} = b{1} + sub;"
            + "\nb{0} = b{0} - sub;"
            + "\nif (b{0} > 0)\n\tMain{0} = 1;";

        // Broadcast/Multicast
        // {0} - channel ID
        private const string GBK_CHANNEL_SEND = "b{0} > 0 && b{0} <= C_MAX_BUFFER";

        // Broadcast/Multicast/Unicast - Congestion
        // {0} - channel ID
        private const string GBK_CHANNEL_CONGESTION = "b{0} > C_MAX_BUFFER";

        // Broadcast - Broadcasting - Source
        private const string GBK_SENSOR_SOURCE_TRANSITION_BROADCASTING = "pkg > 0";

        // Broadcast - Broadcasting - Intermediate
        // {0} - sensor ID
        private const string GBK_SENSOR_INTER_TRANSITION_BROADCASTING = "b{0} > 0";

        // Multicast/Unicast -Receive
        // {0} - sensor ID
        private const string GBK_CHANNEL_INTER_RECEIVE = "b{0} > 0";

        // Broadcast/Multicast channel abstraction 
        // {0} - from sensor ID/ {1} channel ID
        private const string PBK_CHANNEL_TRANSITION_ASTRACTION = "\nb{0} = b{0} + b{1};\nb{1} = 0;";

        // Unicast - receive
        private const string GBK_CHANNEL_SOURCE_RECEIVE = "pkg > 0";

        // {0} - from sensor ID/ {1} - channel ID
        private const string PBK_CHANNEL_SOURCE_RECEIVE =
            "var sub;"
            + "\nif (pkg > 0) {{"
            + "\n\tsub = util.getMin(sqr{0}, pkg);"
            + "\n\tb{1} = sub;"
            + "\n\tif (testMode == 0)"
            + "\n\t\tb{1} = util.getRandInt(1, sub);"
            + "\n\tpkg = pkg - sub;"
            + "\n}}";

        // {0} - from sensor ID/ {1} - channel ID
        private const string PBK_CHANNEL_INTER_RECEIVE = "b{1} = b{1} + b{0};\nb{0} = 0;";

        // {0} - channel ID/ {1} - to sensor ID
        private const string PBK_CHANNEL_MULTI_SEND =
            "\n\nsub = util.getMin(b{0}, r{0});"
            + "\nif (sub > 0) {{"
            + "\n\tif (testMode == 0)"
            + "\n\t\tsub = util.getRandInt(1, sub);"
            + "\n\tb{1} = b{1} + sub;"
            + "\n\tb{0} = b{0} - sub;"
            + "\n}}";


        /// <summary>
        /// Get transition by Name and ID
        /// </summary>
        /// <param name="wsnData">Root xml content transision</param>
        /// <param name="name">Name of transition</param>
        /// <param name="id">ID of transition</param>
        /// <returns></returns>
        private static XmlNode getTransition(WSNPNData wsnData, string name, string id)
        {
            return wsnData.transitions.SelectSingleNode(
                String.Format("./Transition[@Name='{0}{1}']", name, id));
        }

        /// <summary>
        /// Get transition by Name and ID
        /// </summary>
        /// <param name="wsnData">Root xml content transision</param>
        /// <param name="name">Name of transition</param>
        /// <param name="id">ID of transition</param>
        /// <returns></returns>
        private static XmlNode getTransition(WSNPNData wsnData, string name, int id)
        {
            return getTransition(wsnData, name, id.ToString());
        }

        /// <summary>
        /// Set inner text for xmlNode
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="name">Name of node</param>
        /// <param name="text">Text value</param>
        private static void setXmlNodeData(XmlNode xmlNode, string name, string text)
        {
            XmlNode node = xmlNode.SelectSingleNode("./" + name);
            node.InnerText = text;
        }

        /// <summary>
        /// Embed code to sensor
        /// </summary>
        /// <param name="data">Sensor data</param>
        /// <param name="sensor">Sensor object</param>
        /// <param name="channels">Channel Object list</param>
        /// <param name="sensorAbstract">Flag sensor has abstracted</param>
        public static void embedCodeToSensor(WSNPNData data, WSNSensor sensor, IList<WSNChannel> channels, bool sensorAbstract)
        {
            XmlNode transition;
            switch (sensor.NodeType)
            {
                case SensorType.Source:
                    if (sensorAbstract && Build.mMode == NetMode.BROADCAST)
                        break;

                    transition = getTransition(data, "Send", sensor.ID);
                    setXmlNodeData(transition, "Guard", GBK_SENSOR_SOURCE_SEND);
                    setXmlNodeData(transition, "Program", initSensorSource(channels, sensor.ID));
                    break;

                case SensorType.Intermediate:
                    if (sensorAbstract)
                        break;

                    // Receive transition
                    transition = getTransition(data, "Receive", sensor.ID);
                    setXmlNodeData(transition, "Program", String.Format(PBK_SENSOR_INTERFULL_RECEIVE, sensor.ID));
                    setXmlNodeData(transition, "Guard", String.Format(GBK_SENSOR_INTERFULL_RECEIVE, sensor.ID));

                    // Send transition
                    transition = getTransition(data, "Send", sensor.ID);
                    setXmlNodeData(transition, "Program", initSensorSend(channels, sensor.ID));

                    // Congestion transition
                    transition = getTransition(data, "Congestion", sensor.ID);
                    setXmlNodeData(transition, "Guard", String.Format(GBK_SENSOR_INTERFULL_CONGESTION, sensor.ID));
                    break;

                case SensorType.Sink:
                    transition = getTransition(data, "Receive", sensor.ID);
                    setXmlNodeData(transition, "Program", String.Format(PBK_SENSOR_SINK_RECEIVE, sensor.ID));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Initialize source code for Sensor source in network
        /// </summary>
        /// <param name="channels">Channel list</param>
        /// <param name="sensorId">Sensor ID</param>
        /// <returns>Program's code of transistion source</returns>
        private static string initSensorSource(IList<WSNChannel> channels, int sensorId)
        {
            StringBuilder ret = new StringBuilder();

            ret.Append("var sub;");
            foreach (WSNChannel channel in channels)
            {
                if (channel == null || channel.From == null)
                    continue;

                if (((WSNSensor)channel.From).ID != sensorId)
                    continue;

                ret.Append("\n\nif (pkg > 0) {");
                ret.AppendFormat("\n\tsub = util.getMin(sqr{0}, pkg);", sensorId);
                ret.AppendFormat("\n\tb{0} = b{0} + sub;", channel.ID);
                ret.Append("\n\tif (testMode == 0)");
                ret.AppendFormat("\n\t\tb{0} = b{0} + util.getRandInt(1, sub);", channel.ID);
                ret.Append("\n\tpkg = pkg - sub;\n}");
            }

            return ret.ToString();
        }

        /// <summary>
        /// Initialize code for sensor in multicast mode
        /// </summary>
        /// <param name="channel">Channel object</param>
        /// <returns>Program's code of transition source</returns>
        private static string initSensorSendMulti(WSNChannel channel)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("var sub;");
            ret.AppendFormat(PBK_CHANNEL_MULTI_SEND, channel.ID, ((WSNSensor)channel.To).ID);

            foreach (int sensorID in channel.SubIdList)
                ret.AppendFormat(PBK_CHANNEL_MULTI_SEND, channel.ID, sensorID);

            ret.AppendFormat("\n\nif (b{0} > 0)\n\tMain{0} = 1;", channel.ID);
            return ret.ToString();
        }

        /// <summary>
        /// Build program for send data from sensor
        /// </summary>
        /// <param name="channels">Channel list</param>
        /// <param name="sensorId">Sensor ID</param>
        /// <param name="fromBuffer">Send data from buffer. Skip processing</param>
        /// <returns></returns>
        private static string initSensorSend(IList<WSNChannel> channels, int sensorId)
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("var sub;");

            foreach (WSNChannel channel in channels)
            {
                if (channel == null || channel.From == null || channel.To == null)
                    continue;

                if (((WSNSensor)channel.From).ID != sensorId)
                    continue;

                ret.AppendFormat("\n\nsub = util.getMin(q{0}, sqr{0});", sensorId);
                ret.Append("\nif (sub > 0) {");
                ret.Append("\n\tif (testMode == 0)");
                ret.AppendFormat("\n\t\tsub = util.getRandInt(1, sub);");
                ret.AppendFormat("\n\tb{0} = b{0} + sub;", channel.ID);
                ret.AppendFormat("\n\tq{0} = q{0} - sub;", sensorId);
                ret.Append("\n}");
            }

            ret.AppendFormat("\n\nif (q{0} > 0)\n\tMain{0} = 1;", sensorId);
            return ret.ToString();
        }

        private static string initSensorAbstractSend(IList<WSNChannel> channels, int sensorId)
        {
            StringBuilder ret = new StringBuilder();
            int c = 0;

            foreach (WSNChannel channel in channels)
            {
                if (channel == null || channel.From == null || channel.To == null)
                    continue;

                if (((WSNSensor)channel.From).ID != sensorId)
                    continue;

                c++;
            }

            ret.AppendFormat("var sub = b{0}/{1};", sensorId, c);
            int recomC = c;
            foreach (WSNChannel channel in channels)
            {
                if (channel == null || channel.From == null || channel.To == null)
                    continue;

                if (((WSNSensor)channel.From).ID != sensorId)
                    continue;

                if (c == 1)
                {
                    ret.AppendFormat("\nb{0} = b{0} + b{1} - sub*{2};", channel.ID, sensorId, recomC - 1);
                    ret.AppendFormat("\nb{0} = 0;", sensorId);
                    break;
                }

                c--;
                ret.AppendFormat("\nb{0} = b{0} + sub;", channel.ID, channel.ID);
            }

            return ret.ToString();
        }


        //******************************************************************
        //*********************** CHANNEL BUILD UTIL **********************

        /// <summary>
        /// Compute center XY of between fromData and toData
        /// </summary>
        /// <param name="fromData"></param>
        /// <param name="toData"></param>
        /// <returns>Float point</returns>
        private static PointF computeCenterXY(WSNPNData fromData, WSNPNData toData) {
            PointF p = new PointF();
            float outX = fromData.outNode.pos.x;
            float outY = fromData.outNode.pos.y;
            float inX = toData.inNode.pos.x;
            float inY = toData.inNode.pos.y;

            p.X = Math.Min(outX, inX) + Math.Abs(outX - inX) / 2;
            p.Y = Math.Min(outY, inY) + Math.Abs(outY - inY) / 2;
            return p;
        }

        /// <summary>
        /// Build connector for unicast mode
        /// </summary>
        /// <param name="_docOut">Xmldocument output</param>
        /// <param name="transitions">trans contain channels instance</param>
        /// <param name="arcs">arcs xmlelement</param>
        /// <param name="mapData">map id to data</param>
        /// <param name="_sensors">sensor list</param>
        /// <param name="channels">channel list</param>
        public static void buildConnectorBroadcast1(XmlDocument _docOut, XmlElement arcs, Hashtable mapData, List<WSNChannel> channels)
        {
            int fromId, toId;
            WSNPNData fromData, toData;

            foreach (WSNChannel channel in channels)
            {
                if (channel.Neighbor)
                    continue;

                fromId = ((WSNSensor)channel.From).ID;
                toId = ((WSNSensor)channel.To).ID;

                fromData = (WSNPNData)mapData[fromId];
                toData = (WSNPNData)mapData[channel.ID];

                // first arc
                arcs.AppendChild(buildArc(_docOut,
                    fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));

                fromData = (WSNPNData)mapData[channel.ID];
                toData = (WSNPNData)mapData[toId];

                // second arc
                arcs.AppendChild(buildArc(_docOut,
                    fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));
            }
        }

        public static void buildConnectorUnicast(XmlDocument docOut, XmlElement arcs, Hashtable mapData, List<WSNChannel> channels, bool abstractSensor)
        {
            PointF pos;
            int fromId, toId;
            WSNPNData fromData, toData;

            foreach (WSNChannel channel in channels)
            {
                if (channel.Neighbor)
                    continue;

                fromId = ((WSNSensor)channel.From).ID;
                toId = ((WSNSensor)channel.To).ID;

                // arc from
                fromData = (WSNPNData)mapData[fromId];
                toData = (WSNPNData)mapData[channel.ID];
                
                pos = computeCenterXY(fromData, toData);

                // first arc
                arcs.AppendChild(buildArc(docOut, fromData.outNode.name + fromData.nodeId, 
                    toData.inNode.name + toData.nodeId, pos));

                // Bidirect for abstract sensor
                //if (abstractSensor && ((WSNSensor)channel.From).NodeType == SensorType.Source)
                //    arcs.AppendChild(buildArc(docOut, toData.inNode.name + toData.nodeId,
                //        fromData.outNode.name + fromData.nodeId, pos));

                fromData = (WSNPNData)mapData[channel.ID];
                toData = (WSNPNData)mapData[toId];

                // second arc
                arcs.AppendChild(buildArc(docOut,
                    fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));
            }
        }

        /// <summary>
        /// Build connector for multicast mode
        /// </summary>
        /// <param name="docOut">Xmldocument output</param>
        /// <param name="transitions">trans contain channels instance</param>
        /// <param name="arcs">arcs xmlelement</param>
        /// <param name="mapData">map id to data</param>
        /// <param name="_sensors">sensor list</param>
        /// <param name="channels">channel list</param>
        public static void buildConnectorMulticast(XmlDocument docOut, XmlElement arcs, Hashtable mapData, List<WSNChannel> channels, bool abstractSensor)
        {
            PointF pos;
            int fromId, toId;
            WSNPNData fromData, toData;

            foreach (WSNChannel channel in channels)
            {
                if (channel.Neighbor)
                    continue;

                fromId = ((WSNSensor)channel.From).ID;
                toId = ((WSNSensor)channel.To).ID;

                // arc from
                fromData = (WSNPNData)mapData[fromId];
                toData = (WSNPNData)mapData[channel.ID];

                pos = computeCenterXY(fromData, toData);

                // first arc
                arcs.AppendChild(buildArc(docOut, fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, pos));

                //// Bidirect for abstract sensor
                //if (abstractSensor && ((WSNSensor)channel.From).NodeType == SensorType.Source)
                //    arcs.AppendChild(buildArc(docOut, toData.inNode.name + toData.nodeId,
                //        fromData.outNode.name + fromData.nodeId, pos));

                fromData = (WSNPNData)mapData[channel.ID];
                toData = (WSNPNData)mapData[toId];

                // second arc
                arcs.AppendChild(buildArc(docOut,
                    fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));

                foreach (int item in channel.SubIdList)
                {
                    toData = (WSNPNData)mapData[item];
                    if (item == fromId || toData == null)
                        continue;

                    arcs.AppendChild(buildArc(docOut,
                        fromData.outNode.name + fromData.nodeId,
                        toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));
                }
            }
        }

        /// <summary>
        /// Combine code for connector on broadcast mode
        /// </summary>
        /// <param name="transition">trans contain channels instance</param>
        /// <param name="ws">sensor item</param>
        /// <param name="_channels">channel list</param>
        public static void buildCodeBroadcastConnector(XmlElement transition, WSNSensor ws, List<WSNChannel> _channels)
        {
            do
            {
                XmlNode xmlGuard = transition.SelectSingleNode("./Guard");
                XmlNode xmlProgram = transition.SelectSingleNode("./Program");

                // full sensor
                StringBuilder guardBuild = new StringBuilder();
                StringBuilder progBuild = new StringBuilder();
                guardBuild.Append("false");
                String subPartternGuard = "(!net.isFullChannel({0}, {1}) &amp;&amp; net.getChannelBS({0}, {1}) > 0)";

                foreach (WSNChannel wc in _channels)
                {
                    if (((WSNSensor)wc.From).ID == ws.ID)
                    {
                        guardBuild.Append(" || ");
                        guardBuild.Append(String.Format(subPartternGuard, ws.ID, ((WSNSensor)wc.To).ID));
                        progBuild.Append(String.Format("Main{0} = 1;\n", wc.ID));
                    }
                }

                xmlGuard.InnerText = "";
            } while (false);
        }

        /// <summary>
        /// Combine code for receive place on abstract sensor
        /// </summary>
        /// <param name="canvas">Canvas contain sensor/channel item</param>
        /// <param name="places">places list</param>
        /// <param name="channels">channel list</param>
        /// <param name="sensors">sensor list</param>
        /// <param name="ws">sensor item</param>
        /// <param name="transition">trans contain channels instance</param>
        /// <param name="isSensorAbstract">mark sensor abstract</param>
        /// <param name="isChannelAbstract">mark channel abstract</param>
        public static void embedReceiveAbstractSensor(WSNCanvas canvas, IList<WSNChannel> channels, WSNSensor ws, XmlElement transition)
        {
            switch (ws.NodeType)
            { 
                case SensorType.Source:
                    setXmlNodeData(transition, "Guard", GBK_SENSOR_SOURCE_TRANSITION_BROADCASTING);
                    setXmlNodeData(transition, "Program", initSensorSource(channels, ws.ID));
                    break;

                case SensorType.Intermediate:
                    setXmlNodeData(transition, "Guard", String.Format(GBK_SENSOR_INTER_TRANSITION_BROADCASTING, ws.ID));
                    setXmlNodeData(transition, "Program", initSensorAbstractSend(channels, ws.ID));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Build connector base
        /// </summary>
        /// <param name="_docOut">Xmldocument output</param>
        /// <param name="transName">trans contain channels intance</param>
        /// <param name="xPos">x position</param>
        /// <param name="yPos">y position</param>
        /// <returns></returns>
        private static XmlElement buildTransistion(XmlDocument _docOut, String transName, float xPos, float yPos)
        {
            XmlElement label;
            XmlElement position;
            XmlElement position2;
            XmlElement tran;
            XmlElement prog;

            tran = _docOut.CreateElement(XmlTag.TAG_TRANSITION);
            tran.SetAttribute(XmlTag.ATTR_NAME, transName);
            label = _docOut.CreateElement(XmlTag.TAG_LABEL);
            position = _docOut.CreateElement(XmlTag.TAG_POSITION);
            position2 = _docOut.CreateElement(XmlTag.TAG_POSITION);

            position.SetAttribute(XmlTag.ATTR_POSITION_X, xPos.ToString());
            position2.SetAttribute(XmlTag.ATTR_POSITION_X, (xPos - 0.1).ToString());

            position.SetAttribute(XmlTag.ATTR_POSITION_Y, yPos.ToString());
            position2.SetAttribute(XmlTag.ATTR_POSITION_Y, (yPos + 0.22).ToString());

            position.SetAttribute(XmlTag.ATTR_POSITION_WIDTH, "0.25");
            label.AppendChild(position2);
            tran.AppendChild(position);
            tran.AppendChild(label);
            tran.AppendChild(_docOut.CreateElement(XmlTag.TAG_GUARD));

            prog = _docOut.CreateElement(XmlTag.TAG_PROGRAM);
            prog.InnerText = "";
            tran.AppendChild(prog);

            return tran;
        }

        private static XmlElement buildPlace(XmlDocument _docOut, String placeName, float x, float y)
        {
            XmlElement label;
            XmlElement position;
            XmlElement position2;
            XmlElement place;

            place = _docOut.CreateElement(XmlTag.TAG_PLACE);
            place.SetAttribute(XmlTag.ATTR_NAME, placeName);
            label = _docOut.CreateElement(XmlTag.TAG_LABEL);
            position = _docOut.CreateElement(XmlTag.TAG_POSITION);
            position2 = _docOut.CreateElement(XmlTag.TAG_POSITION);

            position.SetAttribute(XmlTag.ATTR_POSITION_X, x.ToString());
            position2.SetAttribute(XmlTag.ATTR_POSITION_X, (x - 0.1).ToString());

            position.SetAttribute(XmlTag.ATTR_POSITION_Y, y.ToString());
            position2.SetAttribute(XmlTag.ATTR_POSITION_Y, (y + 0.22).ToString());

            position.SetAttribute(XmlTag.ATTR_POSITION_WIDTH, "0.25");
            label.AppendChild(position2);
            place.AppendChild(position);
            place.AppendChild(label);
            place.AppendChild(_docOut.CreateElement(XmlTag.TAG_GUARD));

            return place;
        }

        /// <summary>
        /// Build connector for broadcast mode
        /// </summary>
        /// <param name="docOut">Xmldocument output</param>
        /// <param name="transitions">trans contain channels instance</param>
        /// <param name="canvas"></param>
        /// <param name="places"></param>
        /// <param name="arcs"></param>
        /// <param name="mapData"></param>
        /// <param name="_sensors"></param>
        /// <param name="channels"></param>
        /// <param name="abstractSensor"></param>
        /// <param name="abstractChannel"></param>
        public static void buildConnectorBroadcast2(XmlDocument docOut, XmlElement transitions, WSNCanvas canvas, XmlElement places, XmlElement arcs, Hashtable mapData, List<WSNSensor> _sensors, List<WSNChannel> channels, bool abstractSensor, bool abstractChannel)
        {
            // connect the model
            float xPos, yPos, fTmp;
            int fromId, toId;
            WSNPNData fromData, toData;

            foreach (WSNChannel channel in channels)
            {
                if (channel.Neighbor)
                    continue;

                fromId = ((WSNSensor)channel.From).ID;
                toId = ((WSNSensor)channel.To).ID;

                fromData = (WSNPNData)mapData[channel.ID];
                toData = (WSNPNData)mapData[toId];

                // second arc
                arcs.AppendChild(buildArc(docOut, fromData.outNode.name + fromData.nodeId,
                    toData.inNode.name + toData.nodeId, computeCenterXY(fromData, toData)));
            }

            foreach (WSNSensor ws in _sensors)
            {
                if (ws.NodeType == SensorType.Sink)
                    continue;

                int wsId = ws.ID;
                List<WSNChannel> channelList = new List<WSNChannel>();
                foreach (WSNChannel wc in channels)
                {
                    if (((WSNSensor)wc.From).ID == wsId)
                        channelList.Add(wc);
                }

                WSNPNData fData = (WSNPNData)mapData[ws.ID];
                WSNPNData tData;

                float xChannel = 0f;
                float yChannel = 0f;
                int iCount = 0;

                foreach (WSNChannel wc in channels)
                {
                    if (((WSNSensor)wc.From).ID != ws.ID)
                        continue;

                    iCount++;
                    tData = (WSNPNData)mapData[wc.ID];
                    xChannel += tData.inNode.pos.x;
                    yChannel += tData.inNode.pos.y;
                }

                xChannel = xChannel / iCount;
                yChannel = yChannel / iCount;

                fTmp = Math.Abs(fData.outNode.pos.x - xChannel) / 2;
                xPos = Math.Min(fData.outNode.pos.x, xChannel) + fTmp;

                fTmp = Math.Abs(fData.outNode.pos.y - yChannel) / 2;
                yPos = Math.Min(fData.outNode.pos.y, yChannel) + fTmp;

                String tranName = "BroadCasting_" + wsId;
                XmlElement tran = buildTransistion(docOut, tranName, xPos, yPos);

                // Check abstract and build code 
                if (abstractSensor)
                    embedReceiveAbstractSensor(canvas, channels, ws, tran);

                transitions.AppendChild(tran);
                WSNPNData wsFrom = (WSNPNData)mapData[wsId];

                if (abstractChannel)
                {
                    do
                    {
                        if (channelList.Count == 1)
                        {
                            transitions.RemoveChild(tran);
                            WSNChannel wc = channelList[0];
                            WSNPNData wsDataTo = (WSNPNData)mapData[wc.ID];
                            arcs.AppendChild(buildArc(docOut, wsFrom.outNode.name + wsId, wsDataTo.inNode.name + wc.ID));
                            break;
                        }

                        float xtmp, ytmp, x, y;
                        foreach (WSNChannel c in channelList)
                        {
                            String placeConnName = "BroadCasted" + c.ID;
                            WSNPNData placeData = (WSNPNData)mapData[c.ID];

                            xtmp = Math.Abs(placeData.outNode.pos.x - xPos) / 2;
                            ytmp = Math.Abs(placeData.outNode.pos.y - yPos) / 2;

                            x = Math.Min(placeData.outNode.pos.x, xPos) + xtmp;
                            y = Math.Min(placeData.outNode.pos.y, yPos) + ytmp;

                            XmlElement placeConn = buildPlace(docOut, placeConnName, x, y);
                            places.AppendChild(placeConn);

                            arcs.AppendChild(buildArc(docOut, tranName, placeConnName));
                            arcs.AppendChild(buildArc(docOut, placeConnName, placeData.inNode.name + c.ID));
                        }
                        arcs.AppendChild(buildArc(docOut, wsFrom.outNode.name + wsId, tranName));
                    } while (false);
                }
                else
                { // Full channel
                    arcs.AppendChild(buildArc(docOut, wsFrom.outNode.name + wsId, tranName));
                    if (ws.NodeType == SensorType.Source && abstractSensor)
                        arcs.AppendChild(buildArc(docOut, tranName, wsFrom.outNode.name + wsId));

                    foreach (WSNChannel wc in channelList)
                    {
                        WSNPNData wsDataTo = (WSNPNData)mapData[wc.ID];
                        arcs.AppendChild(buildArc(docOut, tranName, wsDataTo.inNode.name + wc.ID));
                    }
                }
            }
        }

        /// <summary>
        /// Combine code for channel 
        /// </summary>
        /// <param name="data">Channel data</param>
        /// <param name="channel">Channel item</param>
        /// <param name="channelAbstract"></param>
        /// <param name="sensorAbstract"></param>
        public static void embedCodeToChannel(WSNPNData data, WSNChannel channel, bool channelAbstract, bool sensorAbstract)
        {
            do
            {
                XmlNode transition; // get xml node to transition then edit content
                XmlNode progNode = null; // get program xml node

                String stringOfSensorConnected = getStringOfNodesConnectedChannel(channel);

                if (channelAbstract)
                {
                    switch (Build.mMode)
                    {
                        case NetMode.BROADCAST:
                        case NetMode.UNICAST:
                            transition = getTransition(data, "Channel", channel.ID);
                            setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_TRANSITION_ASTRACTION, ((WSNSensor)channel.To).ID, channel.ID));
                            break;

                        case NetMode.MULTICAST:
                            StringBuilder prgBuilder = new StringBuilder();
                            prgBuilder.AppendFormat("while (b{0} > 0) {{", channel.ID);
                            prgBuilder.AppendFormat(PBK_CHANNEL_TRANSITION_ASTRACTION, ((WSNSensor)channel.To).ID, channel.ID);

                            foreach (int sensorID in channel.SubIdList)
                            {
                                prgBuilder.Append("\n");
                                prgBuilder.AppendFormat(PBK_CHANNEL_TRANSITION_ASTRACTION, sensorID, channel.ID);
                            }
                            prgBuilder.Append("\n}");

                            transition = getTransition(data, "Channel", channel.ID);
                            setXmlNodeData(transition, "Program", prgBuilder.ToString());
                            break;

                        default:
                            break;
                    }
                    break;
                }

                switch (channel.Type)
                {
                    case ChannelType.Unicast:
                        if (sensorAbstract)
                            embedReceiveUnicast(ref data, channel);

                        // Embed code for transition's send
                        transition = getTransition(data, "Send", channel.ID);
                        setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_SEND, channel.ID, ((WSNSensor)channel.To).ID));
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_SEND, channel.ID));

                        // Embed code for transition's congestion
                        transition = getTransition(data, "Congestion", channel.ID);
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_CONGESTION, channel.ID));
                        break;

                    case ChannelType.Multicast:
                        if (sensorAbstract)
                            compileReceiveMulticast(ref data, channel, stringOfSensorConnected, sensorAbstract, channelAbstract);

                        // Embed code for transition's send
                        transition = getTransition(data, "Send", channel.ID);
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_SEND, channel.ID));
                        setXmlNodeData(transition, "Program", initSensorSendMulti(channel));

                        // Embed cpde for transition's congestion
                        transition = getTransition(data, "Congestion", channel.ID);
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_CONGESTION, channel.ID));
                        break;

                    case ChannelType.Broadcast:
                        // Embed code for transition's send
                        transition = getTransition(data, "Send", channel.ID);
                        setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_SEND, channel.ID, ((WSNSensor)channel.To).ID));
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_SEND, channel.ID));

                        // Embed code for transition's congestion
                        transition = getTransition(data, "Congestion", channel.ID);
                        setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_CONGESTION, channel.ID));
                        break;

                    default:
                        break;
                }
            } while (false);
        }

        /// <summary>
        /// Get [x,y,z...] for nodes connected to channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        private static String getStringOfNodesConnectedChannel(WSNChannel channel)
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.Append("[");
            sbuilder.Append(((WSNSensor)channel.To).ID);

            if (Build.mMode.Equals(NetMode.BROADCAST))
                foreach (int item in channel.SubIdList)
                    sbuilder.Append("," + item);

            sbuilder.Append("]");
            return sbuilder.ToString();
        }

        /// <summary>
        /// Embed code for receive place on unicast mode
        /// </summary>
        /// <param name="data">data mode</param>
        /// <param name="channel">channel item</param>
        /// <param name="stringOfSensorConnected">String [...] sensor id connected</param>
        /// <param name="isSensorAbstract">mark sensor abstract</param>
        /// <param name="isChannelAbstract">mark channel abstract</param>
        private static void embedReceiveUnicast(ref WSNPNData data, WSNChannel channel)
        {
            WSNSensor fromSensor = (WSNSensor)channel.From;
            XmlNode transition = getTransition(data, "Receive", channel.ID);

            switch (fromSensor.NodeType)
            {
                //case SensorType.Source:
                //    setXmlNodeData(transition, "Guard", GBK_CHANNEL_SOURCE_RECEIVE);
                //    setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_SOURCE_RECEIVE, fromSensor.ID, channel.ID));
                //    break;

                case SensorType.Intermediate:
                    setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_INTER_RECEIVE, fromSensor.ID));
                    setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_INTER_RECEIVE, fromSensor.ID, channel.ID));
                    break;

                default:
                    break;
            }
        }

        private static void compileReceiveMulticast(ref WSNPNData data, WSNChannel channel, string stringOfSensorConnected, bool isSensorAbstract, bool isChannelAbstract)
        {
            WSNSensor fromSensor = (WSNSensor)channel.From;
            SensorType type = fromSensor.NodeType;
            XmlNode transition = getTransition(data, "Receive", channel.ID);

            switch (type)
            {
                //case SensorType.Source:
                //    setXmlNodeData(transition, "Guard", GBK_CHANNEL_SOURCE_RECEIVE);
                //    setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_SOURCE_RECEIVE, fromSensor.ID, channel.ID));
                //    break;

                case SensorType.Intermediate:
                    setXmlNodeData(transition, "Guard", String.Format(GBK_CHANNEL_INTER_RECEIVE, fromSensor.ID));
                    setXmlNodeData(transition, "Program", String.Format(PBK_CHANNEL_INTER_RECEIVE, fromSensor.ID, channel.ID));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Build arc base
        /// </summary>
        /// <param name="docOut">Xmldocument output</param>
        /// <param name="fromName">from place name</param>
        /// <param name="toName">to place name</param>
        /// <param name="xPos">x position</param>
        /// <param name="yPos">y position</param>
        /// <returns></returns>
        private static XmlElement buildArc(XmlDocument docOut, string fromName, string toName, PointF pos)
        {
            XmlElement arc;
            XmlElement label;
            XmlElement position;

            if (pos == null)
                pos = new PointF(0f, 0f);

            arc = docOut.CreateElement(XmlTag.TAG_ARC);
            arc.SetAttribute(XmlTag.TAG_ARC_PRO_FROM, fromName);
            arc.SetAttribute(XmlTag.TAG_ARC_PRO_TO, toName);
            arc.SetAttribute(XmlTag.TAG_ARC_PRO_WEIGHT, "1");

            label = docOut.CreateElement(XmlTag.TAG_LABEL);
            position = docOut.CreateElement(XmlTag.TAG_POSITION);
            position.SetAttribute(XmlTag.ATTR_POSITION_X, pos.X.ToString());
            position.SetAttribute(XmlTag.ATTR_POSITION_Y, pos.Y.ToString());
            position.SetAttribute(XmlTag.ATTR_POSITION_WIDTH, "0.25");
            label.AppendChild(position);
            arc.AppendChild(label);
            return arc;
        }

        private static XmlElement buildArc(XmlDocument docOut, string nameFrom, string nameTo) {
            return buildArc(docOut, nameFrom, nameTo, new PointF(0f, 0f));
        }

        public static string buildDeclaration(KWSN.Model.WSNExtendInfo mExtendInfo, List<WSNSensor> sensors, List<WSNChannel> channels)
        {
            StringBuilder decBuild = new StringBuilder();
            CGNLevel level;

            decBuild.AppendFormat("\n#define S_MAX_BUFFER  {0};", mExtendInfo.mSensorMaxBufferSize);
            decBuild.AppendFormat("\n#define S_MAX_QUEUE  {0};", mExtendInfo.mSensorMaxQueueSize);
            decBuild.AppendFormat("\n#define C_MAX_BUFFER  {0};", mExtendInfo.mChannelMaxBufferSize);
            decBuild.Append("\nvar util = new PATUtils();");
            decBuild.AppendFormat("\nvar pkg = {0};", mExtendInfo.mNumberPacket);
            decBuild.Append("\n\n// For debug testing");
            decBuild.Append("\nvar testMode = 1;");

            foreach (WSNSensor sensor in sensors)
            {
                decBuild.AppendFormat("\n\n//Configure for sensor {0}", sensor.ID);

                level = sensor.CongestionLevel;
                decBuild.AppendFormat("\nvar b{0} = {1};", sensor.ID, computeSize(level, mExtendInfo.mSensorMaxBufferSize));
                decBuild.AppendFormat("\nvar q{0} = {1};", sensor.ID, computeSize(level, mExtendInfo.mSensorMaxQueueSize));
                decBuild.AppendFormat("\nvar sbr{0} = {1};", sensor.ID, sensor.ProcessingRate);
                decBuild.AppendFormat("\nvar sqr{0} = {1};", sensor.ID, sensor.SendingRate);
            }

            foreach (WSNChannel channel in channels)
            {
                decBuild.AppendFormat("\n\n//Configure for channel {0}", channel.ID);
                decBuild.AppendFormat("\nvar b{0} = {1};", channel.ID, computeSize(channel.CongestionLevel, mExtendInfo.mChannelMaxBufferSize));
                decBuild.AppendFormat("\nvar r{0} = {1};", channel.ID, channel.SendingRate);
            }

            return decBuild.ToString();
        }

        private static int computeSize(CGNLevel level, int msize) {
            int ret = 0;
            switch (level)
            { 
                case CGNLevel.Low:
                    break;

                case CGNLevel.Medium:
                    ret = (int) (msize * 0.9f);
                    break;

                case CGNLevel.Heigh:
                    ret = (int)(msize * 1.1f);
                    break;

                default:
                    break;
            }

            return ret;
        }
    }
}