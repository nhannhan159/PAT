using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.Common
{
    interface IValueRecord
    {
        void Save(float[] mem_data, long[] tr_st_data, double[] time_data, string[] res_assert);
    }
}
