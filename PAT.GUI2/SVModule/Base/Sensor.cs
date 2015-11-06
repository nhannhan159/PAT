using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAT.Module.KWSN;

namespace PAT.GUI.SVModule.Base
{
    class Sensor
    {
        private int id;
        private double sX;
        private double sY;
        private double sWidth;
        private int groupId;
        private int stype;
        //private int sending_rate;
        //private int processing_rate;
        private int maxSendingRate;
        //private int minSendingRate;
        private int maxProcessingRate;
        //private int minProcessingRate;
        private int maxBufferSize;
        private int maxQueueSize;
        public static int NOISE = -1;
        public static int UNCLASSIFIED = 0;
        private double labelX;
        private double labelY;

        public Sensor(int id)
        {
            this.id = id;
        }
        public Sensor(int id, double sX, double sY, int stype)//của Minh khai báo
        {
            this.id = id;
            this.sX = sX;
            this.sY = sY;
            this.stype = stype;
            this.sWidth = 10;
            this.groupId = UNCLASSIFIED;
        }

        public Sensor(int id, double sX, double sY, int stype, int maxSendingRate, int maxProcessingRate, double labelX, double labelY)//của Minh khai báo
        {
            this.id = id;
            this.sX = sX;
            this.sY = sY;
            this.stype = stype;
            this.maxSendingRate = maxSendingRate;
            //this.minSendingRate = minSendingRate;
            this.maxProcessingRate = maxProcessingRate;
            //this.minProcessingRate = minProcessingRate;
            //this.maxBufferSize = maxBufferSize;
            //this.maxQueueSize = maxQueueSize;
            this.sWidth = 10;
            this.groupId = UNCLASSIFIED;
            this.labelX = labelX;
            this.labelY = labelY;
        }

        public Sensor(int id, double sX, double sY)
        {
            this.id = id;
            this.sX = sX;
            this.sY = sY;
            this.sWidth = 10;
            this.groupId = UNCLASSIFIED;
        }
        public Sensor(int id, double sX, double sY, List<Sensor> destination)
        {
            this.id = id;
            this.sX = sX;
            this.sY = sY;
            this.sWidth = 10;
        }

        public int getprocessing_rate()
        {
            return maxProcessingRate;
        }

        public int getsending_rate()
        {
            return maxSendingRate;
        }

        public int getstype()
        {
            return stype;
        }

        public double getX()
        {
            return sX;
        }

        public double getY()
        {
            return sY;
        }

        public double getXLabel()
        {
            return labelX;
        }

        public double getYLabel()
        {
            return labelY;
        }

        public int getId()
        {
            return id;
        }

        public double getWidth()
        {
            return this.sWidth;
        }
        public int SType
        {
            get
            {
                return stype;
            }
            set
            {
                stype = value;
            }
            
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int setId
        {
            set { id = value; }
        }

        public double SX
        {
            get
            {
                return sX;
            }
        }

        public double SY
        {
            get
            {
                return sY;
            }
        }

        public double SWidth
        {
            get
            {
                return sWidth;
            }
        }

        public int SendingRate
        {
            get { return maxSendingRate; }
            set { maxSendingRate = value; }
        }
        public int ProcessingRate
        {
            get { return maxProcessingRate; }
            set { maxProcessingRate = value; }
        }

        public int GroupId
        {
            get
            {
                return groupId;
            }
            set
            {
                groupId = value;
            }
        }

        public static double Distance(Sensor p1, Sensor p2)
        {
            double diffX = p2.SX - p1.SX;
            double diffY = p2.SY - p1.SY;
            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", sX, sY);
        }
    }
}
