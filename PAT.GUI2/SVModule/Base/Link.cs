using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.GUI.SVModule.Base
{
    class Link
    {
        private Sensor source;
        private Sensor dest;
        private string Ltype="Real";//Link type=0 là link giả, 1 là link thật
        private int maxSendingRate;
        //private int minSendingRate;
        private int maxBufferSize;
        private double transfer_rate;
        public Link(Sensor source, Sensor dest, string Ltype)
        {
            this.source= source;
            this.dest= dest;
            this.Ltype = Ltype;
        }

        public Link(Sensor source, Sensor dest, string Ltype, int maxSendingRate)
        {
            this.source = source;
            this.dest = dest;
            this.Ltype = Ltype;
            this.maxSendingRate = maxSendingRate;
            //this.minSendingRate = minSendingRate;
            //this.maxBufferSize = maxBufferSize;
        }

        public Link(Sensor source, Sensor dest, string Ltype, double transfer_rate)
        {
            this.source = source;
            this.dest = dest;
            this.Ltype = Ltype;
            this.transfer_rate = transfer_rate;
        }

        public Sensor getSource()
        {
            return source;
        }

        public Sensor getDest()
        {
            return dest;
        }

        public string getLType()
        {
            return Ltype;
        }

        public int getTranfer_rate()
        {
            return maxSendingRate;
        }

        public bool isSame(Link other)
        {
            return source.getId() == other.getSource().getId() &&
                dest.getId() == other.getDest().getId();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Link l = obj as Link;
            if ((System.Object)l == null)
            {
                return false;
            }
            return source.getId() == ((Link)obj).getSource().getId() &&
                dest.getId() == ((Link)obj).getDest().getId();
        }
    }
}
