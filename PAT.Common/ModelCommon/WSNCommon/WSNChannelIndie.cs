using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PAT.Common.ModelCommon.WSNCommon
{
    public class WSNChannelIndie
    {
        #region XML attribute define
        protected const string TAG_PRO_CHANNEL_SIZEOFBUFFER = "SizeOfBuffer";
        protected const string TAG_PRO_CHANNEL_FROM = "From";
        protected const string TAG_PRO_CHANNEL_TO = "To";
        protected const string TAG_PRO_CHANNEL_ID = "id";
        #endregion

        public WSNChannelIndie() { }

        #region Properties
        private XmlElement originalElem;

        public string From
        {
            get { return originalElem.ChildNodes[0].InnerText; }
        }

        public string To
        {
            get { return originalElem.ChildNodes[1].InnerText; }
        }

        public string ID
        {
            get { return originalElem.GetAttribute(TAG_PRO_CHANNEL_ID); }
        }

        private int _bufferSize;
        public int BufferSize
        {
            get { return _bufferSize; }
            set { _bufferSize = value; }
        }
        #endregion

        #region Data saving/loading
        public void LoadFromXML(XmlElement xmlElement)
        {
            originalElem = xmlElement;
            _bufferSize = 9999;
            try
            {
                _bufferSize = int.Parse(xmlElement.GetAttribute(TAG_PRO_CHANNEL_SIZEOFBUFFER));
            }
            catch { }
        }

        public XmlNode WriteToXml(XmlDocument doc)
        {
            originalElem.SetAttribute(TAG_PRO_CHANNEL_SIZEOFBUFFER, _bufferSize.ToString(System.Globalization.CultureInfo.InvariantCulture));
            XmlNode _node = originalElem.CloneNode(true);
            XmlNode node = doc.ImportNode(_node, true);
            return node;
        }
        #endregion
    }
}
