using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PAT.Common.ModelCommon.WSNCommon
{
    public class WSNSensorIndie
    {
        #region XML attribute define
        protected const string TAG_PRO_NODE_SIZEOFBUFFER = "SizeOfBuffer";
        protected const string TAG_PRO_NODE_NAME = "Name";
        protected const string TAG_PRO_NODE_ID = "id";
        #endregion

        public WSNSensorIndie() { }

        #region Properties
        private XmlElement originalElem;

        public string Name
        {
            get { return originalElem.GetAttribute(TAG_PRO_NODE_NAME); }
        }

        public string ID
        {
            get { return originalElem.GetAttribute(TAG_PRO_NODE_ID); }
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
                _bufferSize = int.Parse(xmlElement.GetAttribute(TAG_PRO_NODE_SIZEOFBUFFER));
            }
            catch { }
        }

        public XmlNode WriteToXml(XmlDocument doc)
        {
            originalElem.SetAttribute(TAG_PRO_NODE_SIZEOFBUFFER, _bufferSize.ToString(System.Globalization.CultureInfo.InvariantCulture));
            XmlNode _node = originalElem.CloneNode(true);
            XmlNode node = doc.ImportNode(_node, true);
            return node;
        }
        #endregion
    }
}
