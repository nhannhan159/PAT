using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.Utility;
using PAT.GUI.SVModule.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PAT.GUI.SVModule
{
    class GraphXML
    {
        private const string TAG = "GraphXML";

        private List<Sensor> listSensors; //contains sensor
        private List<Link> listLinks; // contains string (id link)
        private List<String> stringSensors;
        private List<String> stringLinks;
        private List<String> Pathfull;

        public GraphXML()
        {
            listSensors = new List<Sensor>();
            listLinks = new List<Link>();
            stringSensors = new List<String>();
            stringLinks = new List<String>();

        }

        #region //Test
        public void createXML1(XmlTextWriter writer, List<Sensor> listSensors, List<Link> listLinks)
        {
            writer.WriteStartElement("WSN");

            writer.WriteStartElement("Declaration");
            writer.WriteEndElement();

            writer.WriteStartElement("Network");

            writer.WriteStartElement("Process");
            writer.WriteAttributeString("Name", "Network_1");
            writer.WriteAttributeString("Parameter", "");
            writer.WriteAttributeString("Zoom", "1");
            writer.WriteAttributeString("StateCounter", "9");

            //Create sensors
            writer.WriteStartElement("Sensors");

            foreach (Sensor s in listSensors)
            {
                createSensor1(s.Id.ToString(), s.SX.ToString(), s.SY.ToString(), s.SWidth.ToString(), s.SendingRate.ToString(), writer);
            }
            writer.WriteEndElement(); //End sensors

            //Create links
            writer.WriteStartElement("Links");

            Random r = new Random();
            foreach (Link s in listLinks)
            {
                createLink1(s.getSource().Id.ToString(), s.getDest().Id.ToString(),
                            r.Next(10).ToString(), r.Next().ToString(), r.Next().ToString(), writer);
            }

            writer.WriteEndElement(); //End <Links>


            writer.WriteEndElement(); //End <Process>

            writer.WriteEndElement(); //End <Network>

            writer.WriteEndElement(); //End <WSN>
        }
        private void createSensor1(string sID, string sX, string sY, string sWidth, string rate, XmlTextWriter writer)
        {
            //Start Sensor
            writer.WriteStartElement("Sensor");
            writer.WriteAttributeString("Name", "Sensor " + sID);
            writer.WriteAttributeString("Init", "False");
            writer.WriteAttributeString("SType", "2");
            writer.WriteAttributeString("SMode", "1");
            writer.WriteAttributeString("id", sID);

            //Postion
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("X", sX);
            writer.WriteAttributeString("Y", sY);
            writer.WriteAttributeString("Width", sWidth);
            writer.WriteEndElement();

            //Label
            writer.WriteStartElement("Label");
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("X", sX);
            writer.WriteAttributeString("Y", sY);
            writer.WriteAttributeString("Width", sWidth);
            writer.WriteEndElement();
            writer.WriteEndElement();

            //For DBSCAN with sending rate
            writer.WriteStartElement("Rate");
            writer.WriteString(rate.ToString());
            writer.WriteEndElement();

            //End </Sensor>
            writer.WriteEndElement();
        }

        private void createLink1(string lFrom, string lTo, string lX, string lY, string lWidth, XmlTextWriter writer)
        {
            //Start Link
            writer.WriteStartElement("Link");
            writer.WriteAttributeString("CType", "0");
            writer.WriteAttributeString("CMode", "0");
            writer.WriteAttributeString("id", lFrom + "_" + lTo);

            //From
            writer.WriteStartElement("From");
            writer.WriteString("Sensor " + lFrom);
            writer.WriteEndElement();

            //To
            writer.WriteStartElement("To");
            writer.WriteString("Sensor " + lTo);
            writer.WriteEndElement();

            //Select
            writer.WriteStartElement("Select");
            writer.WriteEndElement();

            //Event    
            writer.WriteStartElement("Event");
            writer.WriteEndElement();

            //ClockGuard
            writer.WriteStartElement("ClockGuard");
            writer.WriteEndElement();

            //Guard
            writer.WriteStartElement("Guard");
            writer.WriteEndElement();

            //Program
            writer.WriteStartElement("Program");
            writer.WriteEndElement();

            //ClockReset
            writer.WriteStartElement("ClockReset");
            writer.WriteEndElement();

            //Label
            writer.WriteStartElement("Label");
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("X", lX);
            writer.WriteAttributeString("Y", lY);
            writer.WriteAttributeString("Width", lWidth);
            writer.WriteEndElement();
            writer.WriteEndElement();

            //End </Link>
            writer.WriteEndElement();
        }
        #endregion

        public void createXML(XmlTextWriter writer, List<Sensor> listSensors, List<Link> listLinks, List<String> Pathfull, List<String> Parameters)
        {
            writer.WriteStartElement(XmlTag.TAG_WSN);
            writer.WriteStartElement(XmlTag.TAG_DECLARATION);
            writer.WriteEndElement();
            writer.WriteStartElement(XmlTag.TAG_NETWORK);

            writer.WriteAttributeString(XmlTag.ATTR_NUMOFSENSORS, Parameters[0]);
            writer.WriteAttributeString(XmlTag.ATTR_NUMOFPACKETS, Parameters[1]);
            writer.WriteAttributeString(XmlTag.ATTR_SENSOR_MAX_BUFFER_SIZE, Parameters[2]);
            writer.WriteAttributeString(XmlTag.ATTR_SENSOR_MAX_QUEUE_SIZE, Parameters[3]);
            writer.WriteAttributeString(XmlTag.ATTR_CHANNEL_MAX_BUFFER_SIZE, Parameters[4]);

            writer.WriteStartElement(XmlTag.TAG_PROCESS);
            writer.WriteAttributeString(XmlTag.ATTR_NAME, "Network_1");
            writer.WriteAttributeString(XmlTag.ATTR_PRO_PARAM, "");
            writer.WriteAttributeString(XmlTag.ATTR_ZOOM, "1");
            writer.WriteAttributeString("StateCounter", "8");

            //Create sensors
            writer.WriteStartElement(XmlTag.TAG_SENSORS);
            foreach (Sensor test in listSensors)
                createSensor(test.getId().ToString(), test.getX().ToString(), test.getY().ToString(), test.getWidth().ToString(), writer, test.getstype().ToString(), test.getsending_rate().ToString(), test.getprocessing_rate().ToString(), test.getXLabel().ToString(), test.getYLabel().ToString());
            writer.WriteEndElement(); //End sensors

            //Create links
            writer.WriteStartElement(XmlTag.TAG_CHANNELS);
            Random r = new Random();
            foreach (Link testLink in listLinks)
                createLink(Pathfull, testLink.getLType(), testLink.getSource().getId().ToString(), testLink.getDest().getId().ToString(), r.Next(10).ToString(), r.Next().ToString(), r.Next().ToString(), writer, testLink.getTranfer_rate().ToString());

            writer.WriteEndElement(); //End <Links>

            writer.WriteEndElement(); //End <Process>

            writer.WriteEndElement(); //End <Network>

            writer.WriteEndElement(); //End <WSN>
        }

        public void createRandomXML(XmlTextWriter writer, int NUM_SENSOR, int NUM_LINK)
        {

            writer.WriteStartElement(XmlTag.TAG_WSN);

            writer.WriteStartElement(XmlTag.TAG_DECLARATION);
            writer.WriteEndElement();

            writer.WriteStartElement(XmlTag.TAG_NETWORK);

            writer.WriteStartElement(XmlTag.TAG_PROCESS);
            writer.WriteAttributeString(XmlTag.ATTR_NAME, "Network_1");
            writer.WriteAttributeString(XmlTag.ATTR_PRO_PARAM, "");
            writer.WriteAttributeString(XmlTag.ATTR_ZOOM, "1");
            writer.WriteAttributeString("StateCounter", "9");

            //Create sensors
            writer.WriteStartElement(XmlTag.TAG_SENSORS);

            randomSensors(NUM_SENSOR, writer);
            writer.WriteEndElement(); //End sensors

            //Create links
            writer.WriteStartElement(XmlTag.TAG_CHANNELS);
            randomLinks(NUM_LINK, NUM_SENSOR, writer);
            writer.WriteEndElement(); //End <Links>


            writer.WriteEndElement(); //End <Process>
            writer.WriteEndElement(); //End <Network>
            writer.WriteEndElement(); //End <WSN>
        }

        private void createSensor(string sID, string sX, string sY, string sWidth, XmlTextWriter writer, string sType, string smaxSendingRate, string smaxProcessingRate, string xLabel, string yLabel)
        {
            //Start Sensor
            //1 là source; 2 là sink; 3 là trung gian;
            writer.WriteStartElement(XmlTag.TAG_SENSOR);
            writer.WriteAttributeString(XmlTag.ATTR_NAME, "Sensor " + sID);
            writer.WriteAttributeString("Init", "False");
            writer.WriteAttributeString(XmlTag.ATTR_SENSOR_TYPE, sType.ToString());
            writer.WriteAttributeString(XmlTag.ATTR_ID, sID);
            writer.WriteAttributeString(XmlTag.ATTR_MAX_SENDING_RATE, smaxSendingRate);
            writer.WriteAttributeString(XmlTag.ATTR_MAX_PROCESSING_RATE, smaxProcessingRate);
            writer.WriteAttributeString(XmlTag.ATTR_CONGESTION_LEVEL, "0");

            //Postion
            writer.WriteStartElement(XmlTag.TAG_POSITION);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_X, sX);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_Y, sY);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_WIDTH, sWidth);
            writer.WriteEndElement();

            //Label
            writer.WriteStartElement(XmlTag.TAG_LABEL);
            writer.WriteStartElement(XmlTag.TAG_POSITION);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_X, sX);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_Y, sY);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_WIDTH, sWidth);
            writer.WriteEndElement();
            writer.WriteEndElement();

            //End </Sensor>
            writer.WriteEndElement();
        }

        private void createLink(List<String> Pathfull, string lType, string lFrom, string lTo, string lX, string lY, string lWidth, XmlTextWriter writer, string lSendingRate)
        {
            //Start Link
            writer.WriteStartElement(XmlTag.TAG_CHANNEL);
            writer.WriteAttributeString(XmlTag.ATTR_CHANNEL_KIND, lType);
            writer.WriteAttributeString(XmlTag.ATTR_LINK_TYPE, "0");
            writer.WriteAttributeString(XmlTag.ATTR_MAX_SENDING_RATE, lSendingRate);
            writer.WriteAttributeString(XmlTag.ATTR_ID, lFrom + "_" + lTo);
            writer.WriteAttributeString(XmlTag.ATTR_CONGESTION_LEVEL, "0");

            //From
            writer.WriteStartElement(XmlTag.TAG_CHANNEL_FROM);
            writer.WriteString("Sensor " + lFrom);
            writer.WriteEndElement();

            //To
            writer.WriteStartElement(XmlTag.TAG_CHANNEL_TO);
            writer.WriteString("Sensor " + lTo);
            writer.WriteEndElement();

            //Path
            if (lType == "Virtual")
            {
                DevLog.d(TAG, "=============Export XML===============");
                DevLog.d(TAG, "From: " + lFrom + " to: " + lTo);
                writer.WriteStartElement(XmlTag.TAG_PATH);
                for (int i = 0; i < Pathfull.Count; i++)
                {
                    string temp = "";
                    string path = "";
                    path += Pathfull[i].ToString();
                    char[] d = new char[] { ';' };
                    string[] s1 = Pathfull[i].Split(d, StringSplitOptions.RemoveEmptyEntries);
                    for (int p = 0; p < s1.Length; p++)
                    {
                        temp += s1[p];
                        char[] c = new char[] { '-' };
                        string[] s2 = temp.Split(c, StringSplitOptions.RemoveEmptyEntries);
                        if ((s2[0].ToString() == lFrom) && (s2[s2.Length - 1].ToString() == lTo))
                        {
                            DevLog.d(TAG, "" + path);
                            writer.WriteString(path);
                            break;
                        }
                    }
                }
                writer.WriteEndElement();
            }

            //Select
            writer.WriteStartElement("Select");
            writer.WriteEndElement();

            //Event    
            writer.WriteStartElement("Event");
            writer.WriteEndElement();

            //ClockGuard
            writer.WriteStartElement("ClockGuard");
            writer.WriteEndElement();

            //Guard
            writer.WriteStartElement(XmlTag.TAG_GUARD);
            writer.WriteEndElement();

            //Program
            writer.WriteStartElement(XmlTag.TAG_PROGRAM);
            writer.WriteEndElement();

            //ClockReset
            writer.WriteStartElement("ClockReset");
            writer.WriteEndElement();

            //Label
            writer.WriteStartElement(XmlTag.TAG_LABEL);
            writer.WriteStartElement(XmlTag.TAG_POSITION);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_X, lX);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_Y, lY);
            writer.WriteAttributeString(XmlTag.ATTR_POSITION_WIDTH, lWidth);
            writer.WriteEndElement();
            writer.WriteEndElement();

            //End </Link>
            writer.WriteEndElement();
        }


        private void randomSensors(int numS, XmlTextWriter writer)
        {
            //random x, y 
            //so sanh trong array
            Random r = new Random();
            int maxRandom = 6;
            //int maxRandom = numS / 20;

            //if (maxRandom < 15) maxRandom = 15;

            for (int i = 1; i <= numS; i++)
            {
                string id = i.ToString();
                string w = (r.Next(maxRandom) + r.NextDouble()).ToString();
                string x = "";
                string y = "";

                string pos;
                do
                {
                    x = (r.Next(maxRandom) + r.NextDouble()).ToString("0.0");
                    y = (r.Next(maxRandom) + r.NextDouble()).ToString("0.0");
                    pos = x + "-" + y;
                    if (!stringSensors.Contains(pos))
                    {
                        stringSensors.Add(pos);
                        break;
                    }
                }
                while (stringSensors.Contains(pos));

                // if (i == 1)
                // {
                //    //createSensor(id, x, y, w, writer, "1", r.Next(2, 10).ToString(), r.Next(2, 10).ToString());
                // }
                // else if (i == numS)
                // {
                //    //createSensor(id, x, y, w, writer, "2", r.Next(2, 10).ToString(), r.Next(2, 10).ToString());
                // }
                // else
                // {
                //    //createSensor(id, x, y, w, writer, "3", r.Next(2, 10).ToString(), r.Next(2, 10).ToString());
                // }
            }
        }



        private void randomLinks(int numL, int numS, XmlTextWriter writer)
        {
            //random x, y 
            //so sanh trong array
            Random r = new Random();
            string id = "";
            string from = "";
            string to = "";


            Console.WriteLine(r.NextDouble().ToString("0.0"));

            int tempfrom = 0;
            int tempto = 0;
            for (int i = 1; i <= numL; i++)
            {
                do                          //NUM_SENSOR là link, 1 là source   (V)
                {
                    if (i < numS)
                    {
                        from = i.ToString();
                    }
                    else
                    {
                        tempfrom = (r.Next(1, numS + 1));
                        if (tempfrom == numS)
                        {
                            continue;
                        }
                        else
                        {
                            from = tempfrom.ToString();
                        }
                    }

                    if (i == numS)
                    {
                        to = i.ToString();
                    }
                    else
                    {
                        tempto = (r.Next(1, numS + 1));
                        if (tempto == 1)
                        {
                            continue;
                        }
                        else
                        {
                            to = tempto.ToString();
                        }
                    }

                    if (from == "1" && to == numS.ToString())
                    {
                        continue;
                    }
                    id = from + "_" + to;
                    string id2 = to + "_" + from;
                    if ((!stringLinks.Contains(id)) && (!stringLinks.Contains(id2)) && (!from.Equals(to)))
                    {

                        stringLinks.Add(id);
                        break;
                    }
                }
                while (stringLinks.Contains(id) || from.Equals(to));       //của V
                //while (stringLinks.Contains(id) && !from.Equals(to)) ;        //của Sỹ
                //stringSensors.Add(id);
                //createLink(listSensors, Pathfull, "Real", from, to, r.Next().ToString(), r.Next().ToString(), r.Next().ToString(), writer);

            }
        }
    }
}
