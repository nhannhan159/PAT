using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.WSNCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.KWSN.Model
{
    public class WSNExtendInfo: ExtendInfo
    {
        public WSNExtendInfo() { 
            mNumberSensor = 0;
            mNumberPacket = 10;
            mSensorMaxBufferSize = 50;
            mSensorMaxQueueSize = 50;
            mChannelMaxBufferSize = 50;
            mID = DateTime.Now.Ticks;
        }
    }
}
