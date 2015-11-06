using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PAT.GUI.Helper
{
    public class Utils
    {
        public static bool IsAbstractSensor(XmlDocument pnDoc)
        {
            return true;// ((((pnDoc.ChildNodes[0] as XmlElement).GetElementsByTagName(ExtPN.TAG_MODELS)[0] as XmlElement).GetElementsByTagName(ExtPN.TAG_MODEL)[0] as XmlDocument).GetElementsByTagName(ExtPN.TAG_TOPOLOGY)[0] as XmlElement).GetAttribute(ExtPN.TAG_ABSTRACTEDLEVEL).ToArray().ElementAt(0).Equals("1");
        }
        public static bool IsAbstractChannel(XmlDocument pnDoc)
        {
            return true;// ((((pnDoc.ChildNodes[0] as XmlElement).GetElementsByTagName(ExtPN.TAG_MODELS)[0] as XmlElement).GetElementsByTagName(ExtPN.TAG_MODEL)[0] as XmlDocument).GetElementsByTagName(ExtPN.TAG_TOPOLOGY)[0] as XmlElement).GetAttribute(ExtPN.TAG_ABSTRACTEDLEVEL).ToArray().ElementAt(1).Equals("1");
        }

        public static String getCurrentDate() {
            DateTime now = DateTime.Now;
            StringBuilder b = new StringBuilder();
            b.Append(now.Year);
            b.Append(now.Month);
            b.Append(now.Day);

            return b.ToString();
        }

        public static String getCurrentTime() {
            DateTime now = DateTime.Now;
            StringBuilder b = new StringBuilder();
            b.Append(now.Hour);
            b.Append(now.Minute);
            b.Append(now.Second);

            return b.ToString();
        }
    }
}
