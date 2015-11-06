using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.Common.ModelCommon
{
    public static class XmlTag
    {
        // Common Tag
        public const string TAG_DECLARATION = "Declaration";
        public const string TAG_MODELS = "Models";
        public const string TAG_MODEL = "Model";
        public const string ATTR_NAME = "Name";

        public const string ATTR_PRO_PARAM = "Parameter";
        public const string ATTR_ZOOM = "Zoom";
        public const string TAG_MODEL_PRO_PCOUNTER = "PlaceCounter";
        public const string TAG_MODEL_PRO_TCOUNTER = "TransitionCounter";

        public const string TAG_PLACES = "Places";
        public const string TAG_PLACE = "Place";

        public const string TAG_TRANSITIONS = "Transitions";
        public const string TAG_TRANSITION = "Transition";

        public const string TAG_ARCS = "Arcs";
        public const string TAG_ARC = "Arc";
        public const string TAG_ARC_PRO_FROM = "From";
        public const string TAG_ARC_PRO_TO = "To";
        public const string TAG_ARC_PRO_WEIGHT = "Weight";

        public const string TAG_POSITION = "Position";
        public const string ATTR_POSITION_X = "X";
        public const string ATTR_POSITION_Y = "Y";
        public const string ATTR_POSITION_WIDTH = "Width";

        public const string TAG_LABEL = "Label";

        public const string TAG_GUARD = "Guard";
        public const string TAG_PROGRAM = "Program";


        public const string TAG_ABSTRACTEDLEVEL = "AbstractedLevel";
        public const string TAG_TOPOLOGY = "Topology";
        public const string TAG_REFERENCE_ID = "id";
        public const string TAG_SENSOR = "Sensor"; 
        public const string TAG_SENSORS = "Sensors";
        public const string TAG_CHANNEL = "Link";

        public const string ATTR_CHANNEL_KIND = "LType";
        public const string ATTR_ID = "id";

        public const string ATTR_MAX_SENDING_RATE = "MaxSendingRate";
        public const string ATTR_MAX_PROCESSING_RATE = "MaxProcessingRate";
        public const string ATTR_NUMOFSENSORS = "NumberOfSensors";
        public const string ATTR_NUMOFPACKETS = "NumberOfPackets";
        public const string ATTR_AVGBUFFER = "AvgBufferSensor";
        public const string TAG_MODE = "Mode";
        public const string ATTR_mID = "ID";

        public const string ATTR_SENSOR_MAX_BUFFER_SIZE = "SensorMaxBufferSize";
        public const string ATTR_SENSOR_MAX_QUEUE_SIZE = "SensorMaxQueueSize";
        public const string ATTR_CHANNEL_MAX_BUFFER_SIZE = "ChannelMaxBufferSize";

        public const string ATTR_SENSOR_TYPE = "SType";
        public const string ATTR_LINK_TYPE = "CType";
        public const string ATTR_CONGESTION_LEVEL = "CGNLevel";

        // For PN Tag
        public const string TAG_PN = "PN";


        // For WSN Tag
        public const string TAG_MODEL_PRO_IN = "In"; // Input node name
        public const string TAG_MODEL_PRO_OUT = "Out"; // Output node name
        public const string TAG_WSN = "WSN";
        public const string TAG_CHANNEL_FROM = "From";
        public const string TAG_CHANNEL_TO = "To";
        public const string TAG_CHANNELS = "Links";
        public const string TAG_NETWORK = "Network";
        public const string TAG_PROCESS = "Process";
        public const string TAG_PATH = "Path";
    }
}
