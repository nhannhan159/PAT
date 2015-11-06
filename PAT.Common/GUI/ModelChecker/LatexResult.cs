using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.Common.GUI.ModelChecker
{

    public enum AssertType 
    {
        NONE,

        CONGESTION_SENSOR,
        CONGESTION_CHANNEL,
        DEADLOCK_FREE
    }

    public class LatexResult
    {
        //0: deadlockfree, 1:ChannelCongestion, 2: SensorCongestion
        public AssertType mType; // assertion type
        public float mMemo; // memory using
        public long mTransition;
        public long mState;
        public double mTime;
        public string mRes;

        //public float[] mem_data = new float[3];
        //public long[] tr_data = new long[3];
        //public long[] st_data = new long[3];
        //public double[] time_data = new double[3];
        //public string[] res_data = new string[3];
        //public string[] assert_data = new string[3];
    }
}
