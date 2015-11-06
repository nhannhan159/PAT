using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;

//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{

// utilities
    public class RandomUtil {
        // random utility
        private static readonly Random mRand = new Random();
        private static readonly object mSynClock = new object();

        public static int GetRandomNumber(int min, int max)
        {
            lock (mSynClock)
            {
                return mRand.Next(min, max + 1);
            }
        }
    }

// PACKET BASE ------------------------------------------------
    public class PacketBase {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int FinalDest { get; set; }

        // simple data with just number
        public int Data { get; set; }

        public PacketBase(int fromId, int toId, int finalDest, int data) 
        {
            FromId = fromId;
            ToId = toId;
            FinalDest = finalDest;
            Data = data;
        }
    }
// ------------------------------------------------------------

    public class NetPacket : PacketBase {
        public NetPacket(int fromId, int toId, int finalDest, int data)
            : base(fromId, toId, finalDest, data) 
        { }
    }

    public class Sensor
    {
        public int Id { get; set; }
        public int BufferMaxSize { get; set; }
        public int NumOfReceive { get; set; }

        public int MinThreadSending { get; set; }
        public int MaxThreadSending { get; set; }

        public int MinThreadProcessing { get; set; }
        public int MaxThreadProcessing { get; set; }

        public bool DroppedState { get; set; }

        // maker for data reveice
        //public int[] DataReceive { get; set; }
        public int SizeReceive;

        // data pre-process
        public Queue<NetPacket> PBuffer { get; set; }

        // data after process and ready to send
        public Queue<NetPacket> SBuffer { get; set; }


        public Sensor(int id, int bufferMaxSize)
        {
            Id = id;
            PBuffer = new Queue<NetPacket>();
            SBuffer = new Queue<NetPacket>();
            NumOfReceive = 0;
            BufferMaxSize = bufferMaxSize;
            
            MinThreadSending = 1;
            MinThreadSending = 1;

            MinThreadProcessing = 1;
            MaxThreadProcessing = 1;

            DroppedState = false;
        }

        public void reset() {
            PBuffer.Clear();
            SBuffer.Clear();
            NumOfReceive = 0;
        }

        public void setThreadSending(int min, int max) {
            MinThreadSending = min;
            MaxThreadSending = max;
        }

        public void setThreadProcessing(int min, int max)
        {
            MinThreadProcessing = min;
            MaxThreadProcessing = max;
        }

        public int getSendingRate() { 
            return RandomUtil.GetRandomNumber(MinThreadSending, MaxThreadSending);
        }

        public int getProcessingRate()
        {
            return RandomUtil.GetRandomNumber(MinThreadProcessing, MaxThreadProcessing);
        }

        //public void dataReceiveInit(int size) {
        //    this.SizeReceive = size;

        //    DataReceive = new int[size + 1];
        //    for (int i = 1; i <= size; ++i)
        //        DataReceive[i] = 0;
        //}

        //public bool isReceiveComplete() {
        //    bool f = true;
        //    for (int i = 1; i <= SizeReceive; ++i)
        //        if (DataReceive[i] == 0) {
        //            f = false;
        //            break;
        //        }
        //    return f;
        //}

        public override string ToString()
        {
            string rstr = "------Sensor node: " + Id + "\nNumOfReceive: " + NumOfReceive
            + "\nPre-Buffer: (P="
            + PBuffer.Count()
            + ", Q="
            + SBuffer.Count()
            +") [";

            int c = PBuffer.Count;
            NetPacket k;
            while (c > 0)
            {
                k = PBuffer.Dequeue();
                rstr += " [" + k.FromId + "#" + k.ToId + "#" + k.Data + "]";
                PBuffer.Enqueue(k);
                c--;
            }
            rstr += "]";


            rstr += "\nPost-Buffer: [";

            c = SBuffer.Count;
            while (c > 0)
            {
                k = SBuffer.Dequeue();
                rstr += " [" + k.FromId + "#" + k.ToId + "#" + k.Data + "]";
                SBuffer.Enqueue(k);
                c--;
            }
            rstr += "]";

            return rstr;
        }

    }

    public class Channel
    {
        public int BufferMaxSize { get; set; }
		public int ChannelSize { get; set; }
        public Queue<NetPacket> SBuffer { get; set; }
        public int MinThread { get; set; }
        public int MaxThread { get; set; }


     
        public Channel(int bufferMaxSize)
        {
            SBuffer = new Queue<NetPacket>();
            BufferMaxSize = bufferMaxSize;
            MinThread = 1;
            MaxThread = 1;
        }

        public void reset() {
            SBuffer.Clear();
        }

        public void setRate(int min, int max) 
        {
            MinThread = min;
            MaxThread = max;
        }

        public int getRate() 
        {
            return RandomUtil.GetRandomNumber(MinThread, MaxThread);
        }
    }

    public class Network : ExpressionValue
    {
    	public int MAX_SENSOR_BUFFER = 100;
        public int MAX_CHANNEL_BUFFER = 100;
        
    	private int size;
        private Sensor[] sensors;
        private Channel[,] channels;
        public int packetNo;
        private int pkgDiv = 0;

        public Network(int size, int packetNo)
        {
            this.size = size;
            this.packetNo = packetNo;
            this.sensors = new Sensor[size + 1];
            this.channels = new Channel[size + 1, size + 1];

            for (int i = 1; i <= size; i++)
            {
                sensors[i] = new Sensor(i, MAX_SENSOR_BUFFER);
                //sensors[i].dataReceiveInit(packetNo);
            }

            for (int i = 1; i <= size; i++)
                for (int j = 1; j <= size; j++)
                    channels[i, j] = new Channel(MAX_CHANNEL_BUFFER);
        }

        public void reset() 
        {
            for (int i = 1; i <= size; ++i)
                sensors[i].reset();

            for (int i = 1; i <= size; i++)
                for (int j = 1; j <= size; j++)
                    channels[i, j].reset();
        }

        public void setDroppedState(int id, bool value)
        {
            sensors[id].DroppedState = value;
        }

        public bool getDroppedState(int id) 
        {
            return sensors[id].DroppedState;
        }

        public int getNoRecv(int id)
        {
            return sensors[id].NumOfReceive;
        }

        public void initRoute(int fsrc, int finalDest, int[] fdest)
        {
            pkgDiv = packetNo/fdest.Length + 1;

            for (int i = 0; i < fdest.Length; ++i)
            {
                for (int j = 1; j <= pkgDiv; ++j) 
                {
                    sensors[fsrc].SBuffer.Enqueue(new NetPacket(fsrc, fdest[i], finalDest, j));
                }
            }
        }

        public void setFullForSensor(int id)
        {
            sensors[id].BufferMaxSize = 0;
        }

        public void setFullForChannel(int from, int to)
        {
            channels[from, to].BufferMaxSize = 0;
        }

        public void setDroppedForSensor(int id)
        {
            if (sensors[id].PBuffer.Count > 0)
                sensors[id].PBuffer.Dequeue();
        }

        public bool isFullSensor(int id)
        {
            return sensors[id].PBuffer.Count >= sensors[id].BufferMaxSize;
        }

		public bool isDropChannel(int src, int dest) 
		{
            Queue<NetPacket> ch = channels[src, dest].SBuffer;

			int c = ch.Count;
			bool rs = false;
            // KeyValuePair<int, KeyValuePair<int, int>> k;
            NetPacket k;

            // Drop packet when size of packet lager then channel size
            while (c > 0)
            {
                k = ch.Dequeue();
                if (k.Data > channels[src, dest].BufferMaxSize) rs = true;
				ch.Enqueue(k);
                c--;
            }
            return rs;
		}

        public bool isFullChannel(int src, int dest)
        {
            return channels[src, dest].SBuffer.Count >= channels[src, dest].BufferMaxSize;
        }
		
        //public void setChannelSize(int src, int dest, int chSize) 
        //{
        //    channels[src, dest].ChannelSize = chSize;
        //}
		
        public int getChannelBMS(int src, int dest)
        {
            return channels[src, dest].BufferMaxSize;
        }

        public void setChannelBMS(int src, int dest, int value)
        {
            channels[src, dest].BufferMaxSize = value;
        }

        public int getChannelBS(int src, int dest)
        {
            return channels[src, dest].SBuffer.Count;
        }

        public int getSensorBMS(int id)
        {
            return sensors[id].BufferMaxSize;
        }

        public void setSensorBMS(int id, int value)
        {
            sensors[id].BufferMaxSize = value;
        }

        public int getSensorPBS(int id)
        {
            return sensors[id].PBuffer.Count;
        }

        public int getSensorSBS(int id)
        {
            return sensors[id].SBuffer.Count;
        }

        //public bool isDestinationOk(int id) 
        //{
        //    return sensors[id].isReceiveComplete();
        //}

        public void setChannelSendingRate(int fromId, int toId, int min, int max)
        {
            channels[fromId, toId].setRate(min, max);
        }

        public void setSensorSendingRate(int id, int min, int max)
        {
            sensors[id].setThreadSending(min, max);
        }

        public void setSensorProcessingRate(int id, int min, int max)
        {
            sensors[id].setThreadProcessing(min, max);
        }

        public int getReceiveSize(int id)
        {
            return Enumerable.Range(0, channels.GetLength(0)).Sum(i => channels[i, id].SBuffer.Count);
        }

        // read  data in PBuffer, if reached dest then increase counter else send to SBuffer
        public void processInSensor(int id, int[] toId)
        {
            int c = Math.Min(sensors[id].PBuffer.Count, sensors[id].getProcessingRate());
            NetPacket k;

            while (c > 0)
            {
                k = sensors[id].PBuffer.Dequeue();

                // sensors[id].DataReceive[k.Data] = 1;


                if (k.FinalDest == id)
                {
                    sensors[id].NumOfReceive++;
                    
                    // not delete packet for check
                    // sensors[id].SBuffer.Enqueue(k);
                }
                else
                {
                    int sRID = RandomUtil.GetRandomNumber(0, toId.Length - 1);
                    k.FromId = id;
                    k.ToId = toId[sRID];
                    sensors[id].SBuffer.Enqueue(k);

                    //// broadcast
                    //for (int i = 0; i < toId.Length; ++i)
                    //{
                    //    k.FromId = id;
                    //    k.ToId = toId[i];
                    //    sensors[id].SBuffer.Enqueue(k);
                    //}
                }
                c--;
            }
        }

        // send data from channel to sensor
        public void sendToSensor(int from, int to) {
            int c = Math.Min(channels[from, to].SBuffer.Count, channels[from,to].getRate());
            NetPacket k;

            while (c > 0)
            {
                k = channels[from, to].SBuffer.Dequeue();
                sensors[to].PBuffer.Enqueue(k);
                // mark receive data
                //sensors[to].DataReceive[k.Data] = 1;
                c--;
            }
        }

        public void sendToSensors(int from, int[] to)
        {
            for (int i = 0; i < to.Length; ++i)
            {
                if (to[i] > 0)
                    sendToSensor(from, to[i]);  
            }
        }

        // send data from SBuffer of sensor to channel connected
        public void sendToChannel(int id, int nexthop)
        {
            int c = Math.Min(sensors[id].SBuffer.Count, sensors[id].getSendingRate());
            int l = sensors[id].SBuffer.Count;
            NetPacket k;

            // Get min
            c = l < c ? l : c;

            while (c > 0)
            {
                k = sensors[id].SBuffer.Dequeue();
                channels[id, nexthop].SBuffer.Enqueue(k);
                c--;

                //if (k.ToId == nexthop)
                //{
                //    channels[id, nexthop].SBuffer.Enqueue(k);
                //    c--;
                //}
                //else
                //{
                //    sensors[id].SBuffer.Enqueue(k);
                //}
                //l--;
            }
        }

        // fast send data from SBuffer of sensor to channel connected
        public void fastSendToChannel(int id, int nexthop)
        {
            int l = sensors[id].SBuffer.Count;
            NetPacket k;

            while (l > 0)
            {
                k = sensors[id].SBuffer.Dequeue();
                if (k.ToId == nexthop)
                    channels[id, nexthop].SBuffer.Enqueue(k);
                else
                    sensors[id].SBuffer.Enqueue(k);
                l--;
            }
        }

        public void sendToChannels(int from, int[] nexthop)
        {
            for (int i = 0; i < nexthop.Length; ++i)
            {
                if (nexthop[i] > 0)
                    sendToChannel(from, nexthop[i]);
            }
        }

        public void fastSendToChannels(int from, int[] nexthop)
        {
            for (int i = 0; i < nexthop.Length; ++i)
            {
                if (nexthop[i] > 0)
                    fastSendToChannel(from, nexthop[i]);
            }
        }

        public override string ToString()
        {
            return "<" + ExpressionID + ">";
        }

        public override ExpressionValue GetClone()
        {
            return this;
        }

        public override string ExpressionID
        {
            get
            {
                string rstr = "@@@" + pkgDiv + "\n----------------- CHANNEL ------------------------\n";
                for (int i = 1; i <= size; ++i)
                {
                    for (int j = 1; j <= size; j++) 
                    {
                        if (channels[i, j].SBuffer.Count > 0) 
                            rstr += "\n[ " + i + " # " + j + " ] = " + channels[i, j].SBuffer.Count + " # maxsize = " + channels[i,j].BufferMaxSize;
                    }
                }

                rstr += "\n----------------- SENSOR ------------------------\n";

                for (int i = 1; i <= size; ++i)
                    rstr += sensors[i].ToString() + "\n";

                return rstr;
            }
        }
    }

}
