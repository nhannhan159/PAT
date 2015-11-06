using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

using PAT.Common.Utility;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon;

namespace PAT.Module.KWSN
{
    public interface IWSNBase
    {
        WSNPNData GeneratePNXml(XmlDocument doc, string id, bool isCollapsed, float xShift, float yShift);
    }

    public class WSNUtil
    {
        public static int PN_FULL = 0;
        public static int PN_ONLY_SENSOR = 1;
        public static int PN_ONLY_CHANNEL = 2;
        public static int PN_COLLAPSE_ALL = 3;

        private const string TAG = "WSNUtil";

        protected const string TAG_PNTRANS_GUARDS = "PNTrProp";

        /// <summary>
        /// Get the PN xml data
        /// </summary>
        /// <param name="PNRes">PN XML resource document</param>
        /// <param name="pnId">Id (Name) of the PN model</param>
        /// <param name="itemId">Sensor/Channel item Id</param>
        /// <param name="xShift"></param>
        /// <param name="yShift"></param>
        /// <returns></returns>
        public static WSNPNData GetPNXml(XmlDocument PNRes, string id, string pnId, string itemId, float xShift, float yShift)
        {
            WSNPNData data = null;
            string tmp;

            do
            {
                if (PNRes == null)
                    break;

                if (pnId == null || pnId.Length == 0)
                    break;
                
                // find the sensor PN model
                string query = string.Format("//{0}[@{1}='{2}']", XmlTag.TAG_MODEL, XmlTag.ATTR_NAME, pnId);

                XmlElement pnModel = null;
                try
                {
                    pnModel = (XmlElement)PNRes.SelectSingleNode(query).CloneNode(true);
                }
                catch
                {
                    DevLog.d(TAG, "Can not find the sensor model node in resource!");
                    break;
                }
                XmlNodeList nodeList = null;


                #region Update node name
                // update the name of these nodes
                if (itemId == null || itemId.Length == 0)
                {
                    DevLog.d(TAG, "Sensor ID is invalid: " + itemId);
                    break;
                }

                // node Place, Transition
                {
                    string[] nodes = new []
                    {
                        XmlTag.TAG_PLACE,
                        XmlTag.TAG_TRANSITION,
                    };
                    foreach (string node in nodes)
                    {
                        nodeList = pnModel.GetElementsByTagName(node);
                        if (nodeList == null || nodeList.Count == 0)
                            continue;

                        foreach (XmlElement xml in nodeList)
                        {
                            tmp = xml.GetAttribute(XmlTag.ATTR_NAME);
                            xml.SetAttribute(XmlTag.ATTR_NAME, tmp + itemId);
                            xml.SetAttribute(XmlTag.TAG_REFERENCE_ID, id);
                        }
                    }
                }

                // node Arc
                {
                    nodeList = pnModel.GetElementsByTagName(XmlTag.TAG_ARC);
                    foreach (XmlElement xml in nodeList)
                    {
                        tmp = xml.GetAttribute(XmlTag.TAG_ARC_PRO_FROM);
                        xml.SetAttribute(XmlTag.TAG_ARC_PRO_FROM, tmp + itemId);

                        tmp = xml.GetAttribute(XmlTag.TAG_ARC_PRO_TO);
                        xml.SetAttribute(XmlTag.TAG_ARC_PRO_TO, tmp + itemId);
                    }
                }
                #endregion

                #region Combine the returned data
                data = new WSNPNData();
                data.nodeId = itemId;
                data.places = (XmlElement)pnModel.GetElementsByTagName(XmlTag.TAG_PLACES)[0];
                data.transitions = (XmlElement)pnModel.GetElementsByTagName(XmlTag.TAG_TRANSITIONS)[0];
                data.arcs = (XmlElement)pnModel.GetElementsByTagName(XmlTag.TAG_ARCS)[0];
                #endregion

                #region Update node position
                do
                {
                    if (xShift <= 0 && yShift <= 0)
                        break;

                    XmlElement[] elements = new XmlElement[]
                    {
                        data.places,
                        data.transitions,
                        data.arcs,
                    };

                    query = string.Format("//{0}", XmlTag.TAG_POSITION);

                    float xPos;
                    float yPos;
                    foreach (XmlElement node in elements)
                    {
                        nodeList = node.SelectNodes(query);

                        foreach (XmlElement ele in nodeList)
                        {
                            xPos = -1;
                            yPos = -1;
                            try
                            {
                                xPos = float.Parse(ele.GetAttribute(XmlTag.ATTR_POSITION_X));
                            }
                            catch { }
                            try
                            {
                                yPos = float.Parse(ele.GetAttribute(XmlTag.ATTR_POSITION_Y));
                            }
                            catch { }
                            if (xPos < 0 && yPos < 0)
                                continue;

                            xPos += xShift;
                            yPos += yShift;

                            ele.SetAttribute(XmlTag.ATTR_POSITION_X, xPos.ToString());
                            ele.SetAttribute(XmlTag.ATTR_POSITION_Y, yPos.ToString());
                        }
                    }
                } while (false);
                #endregion

                #region Save the position
                XmlElement xNode;

                data.inNode = new NodeInfo();

                string inName = pnModel.GetAttribute(XmlTag.TAG_MODEL_PRO_IN);
                string outName = pnModel.GetAttribute(XmlTag.TAG_MODEL_PRO_OUT);

                if (inName == null || inName.Length == 0)
                    inName = "Input";
                query = string.Format("//*[@{0}='{1}{2}']/{3}", XmlTag.ATTR_NAME, inName, itemId, XmlTag.TAG_POSITION);
                xNode = (XmlElement)pnModel.SelectSingleNode(query);
                if (xNode != null)
                {
                    data.inNode.name = inName;
                    data.inNode.pos = new Position();
                    try
                    {
                        data.inNode.pos.x = float.Parse(xNode.GetAttribute(XmlTag.ATTR_POSITION_X));
                        data.inNode.pos.y = float.Parse(xNode.GetAttribute(XmlTag.ATTR_POSITION_Y));
                    }
                    catch { }
                }

                data.outNode = new NodeInfo();
                if (outName == null || outName.Length == 0)
                    outName = "Output";
                query = string.Format("//*[@{0}='{1}{2}']/{3}", XmlTag.ATTR_NAME, outName, itemId, XmlTag.TAG_POSITION);
                xNode = (XmlElement)pnModel.SelectSingleNode(query);
                if (xNode != null)
                {
                    data.outNode.name = outName;
                    data.outNode.pos = new Position();
                    try
                    {
                        data.outNode.pos.x = float.Parse(xNode.GetAttribute(XmlTag.ATTR_POSITION_X));
                        data.outNode.pos.y = float.Parse(xNode.GetAttribute(XmlTag.ATTR_POSITION_Y));
                    }
                    catch { }
                }
                #endregion
            } while (false);

            return data;
        }
    }
}
