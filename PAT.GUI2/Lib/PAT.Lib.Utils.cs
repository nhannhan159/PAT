using PAT.Common.Classes.Expressions.ExpressionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.Lib
{
    public class PATUtils : ExpressionValue
    {
        private Random mRand;

        public PATUtils() {
            mRand = new Random(DateTime.Now.Millisecond);
        }
    
        public int getRandInt(int from, int to) 
        {
            return mRand.Next(from, to + 1);
        }

        public double getRandDouble(double from, double to)
        {
            return (to - from) * mRand.NextDouble() + from;
        }

        public int getMax(int a, int b) {
            return a > b ? a : b;
        }

        public int getMin(int a, int b) {
            return a > b ? b : a;
        }

        public override ExpressionValue GetClone()
        {
            return this;
        }

        public override string ExpressionID
        {
            get
            {
                return base.ExpressionID;
            }
        }

    }
}
