using Fireball.Docking;
using PAT.Common;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.Utility;
using PAT.GUI.Docking;
using PAT.GUI.KWSNDrawing;
using PAT.GUI.PNDrawing;
using PAT.GUI.SVModule.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PAT.GUI.SVModule.Clustering
{
    public interface ICluster
    {
        /// <summary>
        /// Update progress bar of cluster progress
        /// </summary>
        /// <param name="per"></param>
        void onUpdateProgressbar(int per);

        void onSave();

        void onOpenFile(string fname);

        void onConvertToPNAfterCluster(bool b1, bool b2, string fname);

        SpecificationBase onParseSpecificationAfterCluster(EditorTabItem currentPNItem);

        void onShowModelCheckingWindow(string PNItem, PNExtendInfo extenInfo);

        DockContainer onDockContainer();

    }

    public class ClusterHelper
    {
        private static string TAG = "ClusterHelper";
        private static string ROOT_CLUSTER = Utilities.ROOT_WORKING_PATH + "\\cluster";
        public static string BEFORE_FOLDER = "\\before";
        public static string AFTER_FOLDER = "\\after";
        public static string PN_FOLDER = "\\pn";
        public static string CURRENT_PATH = ROOT_CLUSTER + "\\tmp_" + DateTime.Now.Ticks.ToString();

        private PNTabItem mPNItem;
        private ModuleFacadeBase mCModule;
        private ICluster mClusterListener;

        #region Clustering Variables
        //Save list sensor + link from loaded file
        private List<Sensor> listSensor = new List<Sensor>();
        double[][] rawdata;
        //private int flag_check_state = 0;//check number test clustering
        //[START]Variables for create virtual link
        int tm = 0;
        int[] color = new int[50];
        int[] times = new int[50];
        int[] back = new int[50];
        string path = "";//All path type index of 2 sensor need create virtual link
        string PathID = "";//All path type ID of 2 sensor need create virtual link
        int Dem_path = 0;//Count path from sensor A to sensor B
        int[] L = new int[99];//Storage path
        char[] DanhDau = new char[99];//Tick path
        //[END]
        private List<String> listBeforeClusters = new List<String>();//Storage all before clusters
        private List<String> listAfterClusters = new List<String>();//Storage all after clusters
        private List<String> listPathDirectoryOpen = new List<String>();//Storage all path to open file kwsn of clusters
        private List<String> Pathfull = new List<String>();//Storage pathful kind of index of two sensors
        private List<Link> listLink = new List<Link>();
        private List<Sensor> listSensorBefore = new List<Sensor>();//Storage all sensors export .KWSN before create virtual link
        private List<Link> listLinkBefore = new List<Link>();///Storage all links export .KWSN before create virtual link
        private List<Sensor> listSensorAfter = new List<Sensor>();//Storage all sensors remained to export .KWSN after create virtual link
        private List<Link> listLinkAfter = new List<Link>();//Storage all links remained and virtual link to export .KWSN after create virtual link

        private List<Sensor> listSensorAfterCluster = new List<Sensor>();//Storage all sensors of clusters to export .KWSN after create virtual link
        private List<Link> listLinkAfterCluster = new List<Link>();//Storage all links of clusters to export .KWSN after create virtual link
        private List<String> listParameterNetwork = new List<String>();// Storage NumSensors, NumPacket, AVGBuffer of Network

        private List<Sensor> listVirtualSource = new List<Sensor>();//Storage virtual sources of one cluster
        private List<Sensor> listVirtualSink = new List<Sensor>();//Storage virtual sinks of one cluster
        //Save list sensor + link from clustered graph
        private List<Sensor> newSensors = new List<Sensor>();
        private List<Link> newLinks = new List<Link>();

        private List<Link> listLinkSource = new List<Link>();//Storage links of virtual Sources
        private List<Link> listLinkSink = new List<Link>();//Storage links of virtual Sinks

        //Settings to generate random sensor
        private static int NUM_SENSOR;
        private static int NUM_LINK;
        public int numCluster;
        public int minPts;
        public double eps;
        public String tmpName;
        public int numDir = 0;
        public int state = 0; //Flag to create Result_DBScan directory
        #endregion


        public ClusterHelper(ICluster listener)
        {
            mClusterListener = listener;
        }

        public void openClusters()
        {
            OpenClustersForm openClusterForm = new OpenClustersForm(listBeforeClusters, listAfterClusters, mClusterListener);
            openClusterForm.ShowDialog();
            clean();
        }

        public void verifyAllCluster()
        {
            VerifyAllClusters verifyForm = new VerifyAllClusters(listBeforeClusters, listPathDirectoryOpen, mClusterListener);
            verifyForm.ShowDialog();
            //verifyForm.autoVerify = this;
            //Verify_all_clusters.Enabled = false;
        }

        private void clean()
        {
            listSensorBefore.Clear();
            listLinkBefore.Clear();
            listSensorAfter.Clear();
            listLinkAfter.Clear();
            listSensorAfterCluster.Clear();
            listLinkAfterCluster.Clear();
        }

        private void ez_load_xml(string fileName)
        {
            #region ez load xml
            //Lam gi do
            listLink.Clear();
            listSensor.Clear();
            Pathfull.Clear();
            listParameterNetwork.Clear();
            newLinks.Clear();
            newSensors.Clear();

            //Doc Xml luu vao ArrayList listSensor
            XElement doc = XElement.Load(fileName);
            IEnumerable<XElement> parameters = doc.Descendants("Network");
            string NoSensor = parameters.First<XElement>().Attribute("NumberOfSensors").Value;
            string NoPacket = parameters.First<XElement>().Attribute("NumberOfPackets").Value;
            string SensorBuffer = parameters.First<XElement>().Attribute("SensorMaxBufferSize").Value;
            string SensorQueue = parameters.First<XElement>().Attribute("SensorMaxQueueSize").Value;
            string ChannelBuffer = parameters.First<XElement>().Attribute("ChannelMaxBufferSize").Value;
            //Log.d(TAG, "0: " + NoSensor);
            //Log.d(TAG, "1: " + NoPacket);
            //Log.d(TAG, "2: " + SensorBuffer);
            //Log.d(TAG, "3: " + SensorQueue);
            //Log.d(TAG, "4: " + ChannelBuffer);
            listParameterNetwork.Add(NoSensor);
            listParameterNetwork.Add(NoPacket);
            listParameterNetwork.Add(SensorBuffer);
            listParameterNetwork.Add(SensorQueue);
            listParameterNetwork.Add(ChannelBuffer);
            //Log.d(TAG, "Load:....." + "numPack: " + PNTag.TAG_NUMOFPACKETS + "numSen: " + PNTag.TAG_NUMOFSENSORS);
            //string SensorMaxBufferSize = parameters.Attribute("SensorMaxBufferSize").Value;
            //string SensorMaxQueueSize = parameters.Attribute("MaxQueueSize").Value;
            //string ChannelMaxBufferSize = parameters.Attribute("MaxBufferSize").Value;
            IEnumerable<XElement> sensors = doc.Descendants("Sensor");
            rawdata = new double[sensors.Count<XElement>()][];
            Random r = new Random();

            foreach (var sensor in sensors)
            {
                string id = sensor.Attribute("id").Value;
                string x = sensor.Element("Position").Attribute("X").Value;
                string y = sensor.Element("Position").Attribute("Y").Value;
                string stype = sensor.Attribute("SType").Value;
                string maxSendingRate = sensor.Attribute("MaxSendingRate").Value;
                //string minSendingRate = sensor.Attribute("MinSendingRate").Value;
                string maxProcessingRate = sensor.Attribute("MaxProcessingRate").Value;
                //string minProcessingRate = sensor.Attribute("MinProcessingRate").Value;
                string xLabel = sensor.Element("Label").Element("Position").Attribute("X").Value;
                string yLabel = sensor.Element("Label").Element("Position").Attribute("Y").Value;

                //int sending_rate = r.Next(2, 4);
                //int processing_rate = r.Next(1, 3);
                Sensor s = new Sensor(Int32.Parse(id), Double.Parse(x), Double.Parse(y), Int16.Parse(stype), Int16.Parse(maxSendingRate), Int16.Parse(maxProcessingRate), Double.Parse(xLabel), Double.Parse(yLabel));
                listSensor.Add(s);
            }

            /////Tao listLink
            IEnumerable<XElement> links = doc.Descendants("Link");
            foreach (var link in links)
            {
                string source = link.Attribute("id").Value;
                string Ltype = link.Attribute("LType").Value;
                string maxSendingRate = link.Attribute("MaxSendingRate").Value;
                DevLog.d(TAG, "MaxSendingRate of Link: " + maxSendingRate);
                //string minSendingRate = link.Attribute("MinSendingRate").Value;
                string[] res = source.Split('_');
                //int transfer_rate = r.Next(2, 4);
                //Console.WriteLine(res[0]+" "+res[1]);
                Sensor from = null;
                Sensor to = null;
                foreach (Sensor s in listSensor)
                {

                    if (s.getId() == Int32.Parse(res[0]))
                    {
                        from = s;
                    }
                    if (s.getId() == Int32.Parse(res[1]))
                    {
                        to = s;
                    }
                    if (from != null && to != null)
                        break;
                }
                listLink.Add(new Link(from, to, Ltype, Int16.Parse(maxSendingRate)));
            }
            #endregion
        }

        private bool checkSensorHave(Sensor sen, List<Sensor> listVirtual)
        {
            // verifyForm.finished();

            bool flag = false;
            foreach (Sensor Sen in listVirtual)
            {
                if (sen.getId() == Sen.getId())
                {
                    flag = true;//have this sensor in listVirtual
                    break;
                }
            }
            return flag;
        }

        private bool checkLinkHave(Link thisLink, List<Link> listLinks)
        {
            bool flag = false;
            foreach (Link links in listLinks)
            {
                if ((thisLink.getSource().getId() == links.getSource().getId()) && (thisLink.getDest().getId() == links.getDest().getId()))
                {
                    flag = true;//have this link in listLinks
                    break;
                }
            }
            return flag;
        }

        private void ConvertPathID(string[] path, List<Sensor> lSensor)
        {
            DevLog.d(TAG, "=====Path index=====");

            for (int z = 0; z < path.Length; z++)
            {
                string temp = "";
                temp += path[z];
                DevLog.d(TAG, "" + temp);
                char[] d = new char[] { '-' };
                string[] s1 = temp.Split(d, StringSplitOptions.RemoveEmptyEntries);
                string suffixId = "";
                for (int r = 0; r < s1.Length; r++)
                {
                    for (int k = 0; k < lSensor.Count; k++)
                    {
                        if (!s1[r].Equals(k.ToString()))
                            continue;

                        suffixId = "";
                        if (r != s1.Length - 1)
                            suffixId = "-";
                        PathID += lSensor[k].getId().ToString() + suffixId;
                    }
                }
                PathID += ";";
            }
            DevLog.d(TAG, "=====Path convert ID=====");
            DevLog.d(TAG, "" + PathID);
            //MessageBox.Show("Path ID tr? v?: " + PathID, "msg");
            //return PathID;
        }

        private double DelayTime(string pathID, List<Sensor> lSensor, List<Link> lLink)
        {
            //MessageBox.Show("Path Id: " + path, "Msg");
            char[] c = new char[] { ';' };
            string[] s1 = pathID.Split(c, StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            int count_path = 0;
            double newTransfer = 0;
            int index = 0;
            double[] delayTime = new double[s1.Length];
            for (int z = 0; z < s1.Length; z++)
            {
                string temp = "";
                temp += s1[z];
                char[] d = new char[] { '-' };
                string[] s = temp.Split(d, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < s.Length - 1; i++)
                {
                    for (int j = 0; j < lSensor.Count; j++)
                    {
                        if (s[i] == lSensor[j].getId().ToString())
                        {
                            result += (1 / lSensor[j].getprocessing_rate()) + (1 / lSensor[j].getsending_rate());
                            break;
                        }
                    }
                    for (int l = 0; l < lLink.Count; l++)
                    {
                        if (lLink[l].getSource().getId().ToString() == s[i])
                        {
                            result += 1 / lLink[l].getTranfer_rate();
                            break;
                        }
                    }

                }
                result = Math.Round(result, 2);
                delayTime[count_path] = result;
                count_path++;
            }
            //maxDelay = delayTime.Max();
            for (int j = 0; j < delayTime.Length; j++)
            {
                if (delayTime[j] == delayTime.Max())
                {
                    index = j;
                    break;
                }
            }

            string temp2 = "";
            temp2 += s1[index];
            char[] d2 = new char[] { '-' };
            string[] s2 = temp2.Split(d2, StringSplitOptions.RemoveEmptyEntries);
            int m = 0;
            while (m < s2.Length - 1)
            {
                for (int l = 0; l < lLink.Count; l++)
                {
                    if ((s2[m] == lLink[l].getSource().getId().ToString()) && (s2[m + 1] == lLink[l].getDest().getId().ToString()))
                    {
                        newTransfer += lLink[l].getTranfer_rate();
                        break;
                    }
                }
                m++;
            }

            newTransfer = Math.Round(newTransfer, 2);
            //MessageBox.Show("Result: " + result, "Msg");
            DevLog.d(TAG, "New Tranfer rate: " + newTransfer);
            return newTransfer;

        }

        //hàm xu?t file XML t?ng c?m tru?c và sau khi x? lý, có luôn c? file full sau khi x? lý
        private void saveClusters(List<Sensor> listSensors, List<Link> listLinks, int NoCluster, int state, List<String> Pathfull)
        {
            do
            {
                if (state == 1)
                    tmpName = CURRENT_PATH + BEFORE_FOLDER + @"\Before_cluster " + NoCluster.ToString() + ".kwsn";
                else if (state == 2)
                    tmpName = CURRENT_PATH + AFTER_FOLDER + @"\After_cluster " + NoCluster.ToString() + ".kwsn";
                else if (state == 3)
                    tmpName = CURRENT_PATH + @"\full_After_cluster" + ".kwsn";
                else
                {
                    MessageBox.Show("Cannot write file .kwsn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                XmlTextWriter writer = new XmlTextWriter(tmpName, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                GraphXML graph = new GraphXML();
                graph.createXML(writer, listSensors, listLinks, Pathfull, listParameterNetwork);
                writer.Close();

                // Only open last Kwsn
                if (state == 3)
                    mClusterListener.onOpenFile(tmpName);
            } while (false);
        }

        private bool Route(int start, int finish, int[] back)
        {
            #region DFS
            //if (start == finish)
            //    //cout << finish << " ";
            //    path += finish;
            //else
            //    if (back[finish] == -1)
            //    {
            //        path = "Khong co duong di";

            //    }
            //    else
            //    {
            //        Route(start, back[finish]);
            //        path += finish;
            //    } 
            #endregion

            if (start == finish)
            {
                path += finish + "-";
            }
            else
                if (back[finish] == -1)
                {    //cout << "\nKhong co dg\n";
                    path = "Khong co duong di";
                }
                else
                {
                    Route(start, back[finish], back);
                    path += "-" + finish;
                }
            if (path[0].ToString() == "K")
            {
                //MessageBox.Show(""+path[0].ToString(), "Message");
                return false;
            }
            else return true;
        }
        public bool dijkstra(int start, int finish, double[][] A)
        {
            int[] back = new int[200];//luu d?nh cha d? bi?t quay l?i
            double[] weight = new double[200];//luu tr?ng s?
            int[] mark = new int[200];//dánh d?u d?nh
            int temp = start;
            for (int i = 0; i < A.Length; i++)
            {
                back[i] = -1;
                mark[i] = 0;
                weight[i] = 999;
            }
            back[start] = 0;//xu?t phát t? d?nh start
            weight[start] = 0;
            //ki?m tra d? th? có liên thông không
            int connect;
            do
            {
                connect = -1;
                double min = 999;
                for (int j = 0; j < A.Length; j++)
                {
                    if (mark[j] == 0)
                    {
                        if ((A[start][j] != 0) && (weight[j] > weight[start] + A[start][j]))
                        {
                            weight[j] = weight[start] + A[start][j];
                            back[j] = start;
                        }
                        if (min > weight[j])
                        {
                            min = weight[j];
                            connect = j;//bi?t dc d? th? có liên thông không
                            start = connect;
                            mark[start] = 1;
                        }
                    }

                }

            } while (connect != -1 && start != finish);
            //start != finish : d?nh d?u và cu?i g?p nhau
            //connect != -1 : n?u ko liên thông thì d?ng vi?c tìm du?ng di ng?n nh?t

            //xem tr?ng s? v?a tìm du?c
            /*for (int j = 0; j < n; j++)
            {
                cout << "\nBack:["<<j<<"]"<<"="<< back[j];
            }*/
            //cout << "Weight: " << weight[finish] << endl;
            //cout << "\nGo:\n";
            //in du?ng di
            if (Route(temp, finish, back) == true)
                return true;
            else return false;
            //cout << "null\n";


        }
        public double TinhKhoangCach(double Xf, double Yf, double Xt, double Yt)
        {
            double KhoangCach;
            double dX = Math.Abs(Xt - Xf);// x2-x1
            double dY = Math.Abs(Yt - Yf);//y2-y1
            KhoangCach = Math.Round(Math.Sqrt(dX * dX + dY * dY), 2);
            //int result = Convert.ToInt16(KhoangCach);
            return KhoangCach;
            //return result;
        }
        #region //In nhi?u du?ng di
        public void KhoiTao(int from, int to, int[][] graph)
        {

            //int n = 10;

            for (int i = 0; i < graph.Length; i++)
            {
                DanhDau[i] = '0';
                L[i] = 0;
            }
            DanhDau[from] = '1';
            L[0] = from;

        }
        public void InDuongDi(int SoCanh, int from)
        {
            Dem_path++;
            //cout << endl << D;
            path += from;
            for (int i = 1; i < SoCanh; i++)
            {
                //cout << " -> " << L[i];
                path += "-" + L[i];
            }
            path += ";";
        }
        public void Try(int SoCanh, int from, int to, int[][] graph)
        {
            if (L[SoCanh - 1] == to)
                InDuongDi(SoCanh, from);
            else
            {
                for (int i = 0; i < graph.Length; i++)
                    if (graph[L[SoCanh - 1]][i] > 0 && DanhDau[i] == '0')
                    {
                        L[SoCanh] = i;
                        DanhDau[i] = '1';
                        Try(SoCanh + 1, from, to, graph);
                        L[SoCanh] = 0;
                        DanhDau[i] = '0';
                    }
            }
        }
        public bool FindAllPath(int from, int to, int[][] graph)
        {
            bool temp = true;
            KhoiTao(from, to, graph);
            Try(1, from, to, graph);
            if (Dem_path == 0)
            {
                //path = "Khong co duong";
                temp = false;// ko có du?ng di
            }
            else
            {
                //MessageBox.Show("Path in FindAlPath: " + path, "msg");
                temp = true;
            }
            return temp;
        }
        #endregion

        public void clustering(ClusterType type, string fname)
        {
            #region lam clustering
            switch (type)
            {
                #region case "DBScan": Code by Minh & V?ng
                case ClusterType.DBSCAN:
                    // Save();
                    mClusterListener.onSave();

                    ez_load_xml(fname);

                    mClusterListener.onUpdateProgressbar(0);

                    DBScanForm dbscanForm = new DBScanForm();
                    dbscanForm.ShowDialog();

                    if ((dbscanForm.EpsBox.Text == "") || (dbscanForm.PtsBox.Text == ""))
                    {
                        break;
                    }

                    minPts = Int32.Parse(dbscanForm.PtsBox.Text);
                    eps = Double.Parse(dbscanForm.EpsBox.Text);
                    if (newLinks != null && newSensors != null)
                    {
                        newLinks.Clear();
                        newSensors.Clear();
                        listBeforeClusters.Clear();
                        listAfterClusters.Clear();
                        listPathDirectoryOpen.Clear();
                        int[] LinkFrom = new int[listLink.Count];//M?ng 1 chi?u luu các link vào
                        int[] LinkTo = new int[listLink.Count];//M?ng 1 chi?u luu các link ra
                        double[][] sensor = new double[listSensor.Count][];//M?ng 2 chi?u luu ID và t?a d? X Y và stype c?a các sensor
                        int[] LinkFromgiunguyen = new int[LinkFrom.Length];
                        int[] LinkTogiunguyen = new int[LinkTo.Length];
                        //SplashScreen.ShowSplashScreen();
                        //SplashScreen.SetStatus("Please wait ... ");
                        //Clustering.dbscanClustering(listSensor, listLink, ref newSensors, ref newLinks, minPts, eps);
                        //Console.WriteLine("\n================================");
                        List<List<Sensor>> clusters = DBSCAN.GetClusters(listSensor, eps, minPts);
                        //Console.WriteLine("\nXu?t t?ng c?m");
                        Console.WriteLine("\n===================================");
                        int countcluster = 0;//d?m xem trong list clusters có bn cluster
                        for (int i = 0; i < clusters.Count; i++)
                        {
                            countcluster++;
                        }
                        Console.WriteLine("\n===================================");
                        //T?o b?ng LinkFrom và LinkTo
                        int demLink = 0;
                        for (int i = 0; i < listLink.Count; i++)
                        {
                            LinkTo[i] = listLink[i].getDest().getId();
                            LinkFrom[i] = listLink[i].getSource().getId();
                            demLink++;
                            //Console.WriteLine("Link: from sensor {0} to sensor {1}\n", listLink[i].getSource().getId(), listLink[i].getDest().getId());
                        }
                        //B?ng các Sensor
                        for (int i = 0; i < listSensor.Count; i++)
                        {
                            sensor[i] = new double[8];
                            sensor[i][0] = listSensor[i].getId();//C?t 1 ID sensor
                            sensor[i][1] = listSensor[i].getX();//C?t 2 t?a d? X
                            sensor[i][2] = listSensor[i].getY();//C?t 3 t?a d? Y     
                            sensor[i][3] = listSensor[i].getstype();//C?t 4 ch?a ki?u sensor (0 là source, 1 là sink, 2 là trung gian)
                            sensor[i][4] = listSensor[i].getsending_rate();//ch?a sending rate c?a sensor
                            sensor[i][5] = listSensor[i].getprocessing_rate();//ch?a processing rate c?a sensor
                            sensor[i][6] = listSensor[i].getXLabel();//X of label
                            sensor[i][7] = listSensor[i].getYLabel();//Y of label
                        }
                        int[][] cluster = new int[countcluster][];//B?ng ch?a ID các sensor trong t?ng c?m
                        int[][] sensorgiunguyen = new int[countcluster][];//Ch?a các sensor du?c gi? nguyên trong t?ng c?m
                        int[] numsensorincluster = new int[countcluster];//Th?ng kê s? lu?ng sensor trong t?ng c?m
                        for (int i = 0; i < countcluster; i++)
                        {
                            for (int j = 0; j < clusters[i].Count; j++)
                            {
                                numsensorincluster[i] += 1;
                            }
                            //MessageBox.Show("Cluster thu"+(i + 1).ToString() + "có"+numsensorincluster[i].ToString()+"sensor","Message");
                        }
                        //B?ng ch?a ID các sensor trong t?ng c?m
                        Console.WriteLine("\n===================================");
                        for (int i = 0; i < countcluster; i++)
                        {
                            cluster[i] = new int[numsensorincluster[i]];
                            Console.WriteLine("\nCluster {0}:", i + 1);
                            for (int j = 0; j < clusters[i].Count; j++)
                            {
                                cluster[i][j] = clusters[i][j].getId();
                                Console.WriteLine(" {0} ", cluster[i][j]);
                            }

                        }

                        //B?ng ID sensor gi? nguyên c?a t?ng c?m
                        //Gi? nguyên sink source
                        for (int i = 0; i < cluster.Length; i++)
                        {
                            sensorgiunguyen[i] = new int[numsensorincluster[i]];
                            for (int j = 0; j < cluster[i].Length; j++)
                            {
                                for (int n = 0; n < sensor.Length; n++)
                                {
                                    if (cluster[i][j] == sensor[n][0])
                                    {
                                        if ((sensor[n][3] == 1) || (sensor[n][3] == 2))
                                        {
                                            sensorgiunguyen[i][j] = cluster[i][j];
                                            Console.WriteLine("\ni={0}, j={1}", i, j);
                                        }
                                    }
                                }
                            }
                        }
                        //Gi? nguyên sensor có link di ra ho?c di vào c?m
                        #region //Gi? nguyên sensor có link di ra ho?c di vào c?m
                        Boolean flag = false;//c? ki?m tra xem m?t sensor có n?m cùng c?m v?i sensor dang xét không
                        for (int i = 0; i < cluster.Length; i++)
                        {
                            for (int j = 0; j < cluster[i].Length; j++)
                            {
                                for (int k = 0; k < LinkFrom.Length; k++)
                                {
                                    if (LinkFrom[k] == cluster[i][j])//N?u nó có du?ng ra - n?m trong b?ng from
                                    {
                                        for (int n = 0; n < cluster[i].Length; n++)
                                        {
                                            if (LinkTo[k] == cluster[i][n])// và n?u nó n?i d?n sensor cùng c?m
                                            {
                                                flag = true;//b?t c? thành true
                                                break;
                                            }
                                            else flag = false;
                                        }
                                        if (flag == false)//n?u c? false, nghia là nó có link ra ngoài kh?i c?m dang xét
                                        {
                                            sensorgiunguyen[i][j] = LinkFrom[k];//gi? nó l?i thôi
                                            LinkFromgiunguyen[k] = LinkFrom[k];
                                            LinkTogiunguyen[k] = LinkTo[k];
                                        }

                                    }
                                    if (LinkTo[k] == cluster[i][j])//N?u nó có du?ng vào - n?m trong b?ng to
                                    {
                                        for (int n = 0; n < cluster[i].Length; n++)
                                        {
                                            if (LinkFrom[k] == cluster[i][n])// và n?u nó du?c n?i t? sensor cùng c?m
                                            {
                                                flag = true;//b?t c? thành true
                                                break;
                                            }
                                            else flag = false;

                                        }
                                        if (flag == false)//n?u c? false, nghia là nó có link t? sensor c?m khác link vào c?m dang xét
                                        {
                                            sensorgiunguyen[i][j] = LinkTo[k];//gi? l?i nó thôi
                                            LinkFromgiunguyen[k] = LinkFrom[k];
                                            LinkTogiunguyen[k] = LinkTo[k];
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        // Create new cluster path
                        //CURRENT_PATH = ROOT_CLUSTER + "\\" + DateTime.Now.Millisecond.ToString();
                        //BCdirectoryPath = ResultdirectoryPath + @"\" + "Before_Cluster";
                        //ACdirectoryPath = ResultdirectoryPath + @"\" + "After_Cluster";
                        listPathDirectoryOpen.Add(CURRENT_PATH + AFTER_FOLDER);
                        listPathDirectoryOpen.Add(CURRENT_PATH + BEFORE_FOLDER);
                        //if (Directory.Exists(ROOT_CLUSTER + CURRENT_FOLDER))
                        //{
                        //    numDir++;
                        //    ResultdirectoryPath = ResultdirectoryPath + "_(" + numDir + ")";
                        //    Directory.CreateDirectory(ResultdirectoryPath);
                        //    Directory.CreateDirectory(BCdirectoryPath);
                        //    Directory.CreateDirectory(ACdirectoryPath);
                        //}
                        //else
                        {
                            Directory.CreateDirectory(CURRENT_PATH);
                            Directory.CreateDirectory(CURRENT_PATH + AFTER_FOLDER);
                            Directory.CreateDirectory(CURRENT_PATH + BEFORE_FOLDER);
                            Directory.CreateDirectory(CURRENT_PATH + PN_FOLDER);
                        }
                        //StatusLabel_Status.Text = "Clustering....";
                        //Log.d(TAG, ProgressBar1.Step.ToString());
                        //Xu?t XML t?ng c?m tru?c khi x? lý
                        for (int i = 0; i < cluster.Length; i++)
                        {
                            mClusterListener.onUpdateProgressbar((100 / countcluster) - 1);
                            // ProgressBar1.Value += (100 / countcluster) - 1;

                            DevLog.d(TAG, "Cluster " + (i + 1) + ":");
                            for (int j = 0; j < cluster[i].Length; j++)
                            {

                                //MessageBox.Show(""+cluster[i][j], "Message");
                                for (int n = 0; n < sensor.Length; n++)
                                {
                                    if (cluster[i][j] == sensor[n][0])
                                    {
                                        Sensor test = new Sensor(cluster[i][j], sensor[n][1], sensor[n][2], Convert.ToInt16(sensor[n][3]), Convert.ToInt16(sensor[n][4]), Convert.ToInt16(sensor[n][5]), sensor[n][6], sensor[n][7]);
                                        listSensorBefore.Add(test);
                                    }
                                    if (sensorgiunguyen[i][j] == sensor[n][0])
                                    {
                                        Sensor test = new Sensor(cluster[i][j], sensor[n][1], sensor[n][2], Convert.ToInt16(sensor[n][3]), Convert.ToInt16(sensor[n][4]), Convert.ToInt16(sensor[n][5]), sensor[n][6], sensor[n][7]);
                                        listSensorAfter.Add(test);
                                        if (checkSensorHave(test, listSensorAfterCluster) == false)
                                        {
                                            listSensorAfterCluster.Add(test);
                                        }
                                    }
                                }
                                for (int n = j + 1; n < cluster[i].Length; n++)
                                {
                                    for (int k = 0; k < LinkFrom.Length; k++)
                                    {
                                        if ((LinkFrom[k] == cluster[i][j]) && (LinkTo[k] == cluster[i][n]))
                                        {
                                            Sensor src = new Sensor(cluster[i][j]);
                                            Sensor dest = new Sensor(cluster[i][n]);
                                            Link testLink = new Link(src, dest, "Real", listLink[k].getTranfer_rate());
                                            listLinkBefore.Add(testLink);
                                        }
                                        if ((LinkFrom[k] == cluster[i][n]) && (LinkTo[k] == cluster[i][j]))
                                        {
                                            Sensor src = new Sensor(cluster[i][n]);
                                            Sensor dest = new Sensor(cluster[i][j]);
                                            Link testLink = new Link(src, dest, "Real", listLink[k].getTranfer_rate());
                                            //if(listLinkTest.Contains(testLink))
                                            listLinkBefore.Add(testLink);
                                        }
                                        if ((LinkFrom[k] == sensorgiunguyen[i][j]) && (LinkTo[k] == sensorgiunguyen[i][n]))
                                        {
                                            Sensor src = new Sensor(sensorgiunguyen[i][j]);
                                            Sensor dest = new Sensor(sensorgiunguyen[i][n]);
                                            Link testLink = new Link(src, dest, "Real", listLink[k].getTranfer_rate());
                                            listLinkAfter.Add(testLink);
                                            //listLinkAfterCluster.Add(testLink);
                                        }
                                        if ((LinkFrom[k] == sensorgiunguyen[i][n]) && (LinkTo[k] == sensorgiunguyen[i][j]))
                                        {
                                            Sensor src = new Sensor(sensorgiunguyen[i][n]);
                                            Sensor dest = new Sensor(sensorgiunguyen[i][j]);
                                            Link testLink = new Link(src, dest, "Real", listLink[k].getTranfer_rate());
                                            listLinkAfter.Add(testLink);
                                            //listLinkAfterCluster.Add(testLink);
                                        }
                                    }
                                }
                            }
                            #region //T?o link gi?
                            //T?o link gi?
                            //T?o list các sensor c?n t?o link gi?
                            List<Link> listVirtualLinkNeedCreate = new List<Link>();
                            bool flag1 = false;//c? d? ki?m tra link c?a m?i sensor d? chuy?n v? d? th? vô hu?ng

                            int[][] graphRouting = new int[listSensorBefore.Count][];
                            //Ðua v? d? th? qu?n lý b?ng m?ng 2 chi?u
                            for (int k = 0; k < listSensorBefore.Count; k++)
                            {
                                graphRouting[k] = new int[listSensorBefore.Count];
                                for (int m = 0; m < graphRouting[k].Length; m++)
                                {
                                    graphRouting[k][m] = 0;
                                }
                            }

                            for (int f = 0; f < listSensorBefore.Count; f++)
                            {
                                for (int t = 0; t < listSensorBefore.Count; t++)
                                {
                                    foreach (Link l in listLinkBefore)
                                    {
                                        if ((listSensorBefore[f].getId() == l.getSource().getId()) && (listSensorBefore[t].getId() == l.getDest().getId()))
                                        {
                                            //graphRouting[f][t] = TinhKhoangCach(listSensorBefore[f].getX(), listSensorBefore[f].getY(), listSensorBefore[t].getX(), listSensorBefore[t].getY());
                                            graphRouting[f][t] = 1;
                                            flag1 = true;
                                            break;
                                        }
                                    }
                                    if (flag1 == true)
                                        continue;
                                }
                            }
                            //DFS(graphRouting);//Duy?t d? th?

                            //Xét di?u ki?n d? t?o link gi?
                            bool flag4 = false;
                            for (int f = 0; f < listSensorAfter.Count; f++)
                            {
                                for (int t = 0; t < listSensorAfter.Count; t++)
                                {
                                    if (f == t)
                                    {
                                        continue;
                                    }
                                    foreach (Link l in listLinkAfter)
                                    {
                                        if ((listSensorAfter[f].getId() == l.getSource().getId()) && (listSensorAfter[t].getId() == l.getDest().getId()))
                                        {
                                            flag4 = true;
                                            break;
                                        }
                                        if ((listSensorAfter[t].getId() == l.getSource().getId()) && (listSensorAfter[f].getId() == l.getDest().getId()))
                                        {
                                            flag4 = true;
                                            break;
                                        }
                                    }
                                    if (flag4 == true)
                                    {
                                        flag4 = false;
                                        continue;
                                    }
                                    if (listSensorAfter[t].getstype() == 1)//1 là src - To đến src
                                    {
                                        continue;
                                    }
                                    if (listSensorAfter[f].getstype() == 2)//2 là sink - sink To ra
                                    {
                                        break;
                                    }
                                    Link virtuallink = new Link(listSensorAfter[f], listSensorAfter[t], "Virtual");
                                    listVirtualLinkNeedCreate.Add(virtuallink);
                                }
                            }
                            checkListVirtualLinkNeedCreate(listVirtualLinkNeedCreate);
                            //for (int test = 0; test < listVirtualLinkNeedCreate.Count; test++)
                            //{

                            //    //MessageBox.Show("Src: " + listVirtualLinkNeedCreate[test].getSource().getId() + " - dest: " + listVirtualLinkNeedCreate[test].getDest().getId(), "msg");
                            //}
                            //string[][] Pathfull = new string[listVirtualLinkNeedCreate.Count][];
                            for (int test = 0; test < listVirtualLinkNeedCreate.Count; test++)
                            {
                                DevLog.d(TAG, "Link need create: " + listVirtualLinkNeedCreate[test].getSource().getId() + " _ " + listVirtualLinkNeedCreate[test].getDest().getId());
                            }
                            int from = 0;
                            int to = 0;
                            bool flag2 = false;
                            bool flag3 = false;
                            //int countVirtualLink = 0;
                            //truy?n các c?p c?n t?o link gi? vào.
                            for (int g = 0; g < listVirtualLinkNeedCreate.Count; g++)
                            {
                                DevLog.d(TAG, "Src: " + listVirtualLinkNeedCreate[g].getSource().getId() + " - dest: " + listVirtualLinkNeedCreate[g].getDest().getId());
                                for (int index = 0; index < listSensorBefore.Count; index++)
                                {
                                    if (listVirtualLinkNeedCreate[g].getSource().getId() == listSensorBefore[index].getId())
                                    {
                                        flag2 = true;
                                        from = index;
                                    }
                                    else if (listVirtualLinkNeedCreate[g].getDest().getId() == listSensorBefore[index].getId())
                                    {
                                        flag3 = true;
                                        to = index;
                                    }
                                    if (flag2 && flag3)
                                    {
                                        break;
                                    }
                                }
                                if (flag2 && flag3)
                                {
                                    flag2 = false;
                                    flag3 = false;
                                    DevLog.d(TAG, "=======START========");
                                    //string temp11 = "";
                                    //for (int list = 0; list < listSensorAfter.Count; list++)
                                    //{

                                    //    temp11 += listSensorAfter[list].getId();
                                    //    temp11 += ", ";

                                    //}
                                    //MessageBox.Show("list Sensor gi? nguyên: " + temp11, "msg");
                                    path = "";
                                    PathID = "";
                                    Dem_path = 0;
                                    DevLog.d(TAG, "Checking...from_to: " + from + " _ " + to);
                                    //MessageBox.Show("Path from " + from + " to " + to, "msg");
                                    //PrintPath(from, to);//hàm in ra du?ng di
                                    //if (dijkstra(from, to, graphRouting) == true)//hàm ktra t? from d?n to có du?ng di không
                                    if (FindAllPath(from, to, graphRouting) == true)
                                    {
                                        //MessageBox.Show("Path: " + path, "msg");

                                        //In ra t?t c? du?ng di
                                        double newTransfer;
                                        int dem_path_valid = Dem_path;//s? du?ng di h?p l?
                                        double[] delayRate = new double[Dem_path];
                                        char[] c = new char[] { ';' };
                                        string[] s1 = path.Split(c, StringSplitOptions.RemoveEmptyEntries);
                                        //Chuy?n các du?ng di index thành du?ng di d?ng ID
                                        ConvertPathID(s1, listSensorBefore);
                                        //MessageBox.Show("Path ID: " + PathID, "msg");
                                        //xét t?ng du?ng di có th?a di?u ki?n t?o link gi? không
                                        //string[] s2 = PathID.Split(c, StringSplitOptions.RemoveEmptyEntries);
                                        //for (int k = 0; k < s2.Length; k++)
                                        //{
                                        //    string temp = "";
                                        //    temp += s2[k];
                                        //    char[] d = new char[] { '-' };
                                        //    string[] temp_path = temp.Split(d, StringSplitOptions.RemoveEmptyEntries);
                                        //for (int z = 1; z < temp_path.Length - 1; z++)//ph?n t? d?u và cu?i luôn là 2 sensor du?c gi? l?i sau khi cluster
                                        //{
                                        //    for (int p = 0; p < listSensorAfter.Count; p++)
                                        //    {
                                        //        if (temp_path[z] == listSensorAfter[p].getId().ToString())
                                        //        {
                                        //            dem_path_valid--;//có b?t k? sensor nào du?c gi? l?i thì du?ng di dó b? b?
                                        //            //MessageBox.Show("Path not valid: " + temp, "Msg");
                                        //            //MessageBox.Show("path valid to break: " + dem_path_valid, "Msg");
                                        //            break;
                                        //        }
                                        //    }
                                        //    break;
                                        //}
                                        //}
                                        //if (dem_path_valid != 0)
                                        //{
                                        //MessageBox.Show("path valid: " + dem_path_valid, "Msg");
                                        graphRouting[from][to] = 1;
                                        Pathfull.Add(PathID);
                                        newTransfer = DelayTime(PathID, listSensorBefore, listLinkBefore);
                                        Link createVirtualLink = new Link(listSensorBefore[from], listSensorBefore[to], "Virtual", Convert.ToInt16(newTransfer));
                                        if (checkLinkHave(createVirtualLink, listLinkAfter) == false)
                                        {
                                            DevLog.d(TAG, "Link created: " + createVirtualLink.getSource().getId() + " _ " + createVirtualLink.getDest().getId());
                                            listLinkAfter.Add(createVirtualLink);
                                            DevLog.d(TAG, "=======END========");
                                        }
                                        //listLinkAfterCluster.Add(createVirtualLink);
                                        //}


                                    }
                                    else
                                    {
                                        path = "";
                                        PathID = "";
                                        Dem_path = 0;
                                        DevLog.d(TAG, "Checking...to_from: " + to + " _ " + from);
                                        //MessageBox.Show("Path from " + to + " to " + from, "msg");
                                        //if (dijkstra(to, from, graphRouting) == true)
                                        if (FindAllPath(to, from, graphRouting) == true)
                                        {
                                            //MessageBox.Show("Path: " + path, "msg");

                                            //In ra t?t c? du?ng di
                                            double newTransfer;
                                            int dem_path_valid = Dem_path;//s? du?ng di h?p l?
                                            double[] delayRate = new double[Dem_path];
                                            char[] c = new char[] { ';' };
                                            string[] s1 = path.Split(c, StringSplitOptions.RemoveEmptyEntries);
                                            //Chuy?n các du?ng di index thành du?ng di d?ng ID
                                            ConvertPathID(s1, listSensorBefore);
                                            //MessageBox.Show("Path ID: " + PathID, "msg");
                                            //xét t?ng du?ng di có th?a di?u ki?n t?o link gi? không
                                            //string[] s2 = PathID.Split(c, StringSplitOptions.RemoveEmptyEntries);
                                            //for (int k = 0; k < s2.Length; k++)
                                            //{
                                            //    string temp = "";
                                            //    temp += s2[k];
                                            //    char[] d = new char[] { '-' };
                                            //    string[] temp_path = temp.Split(d, StringSplitOptions.RemoveEmptyEntries);
                                            //for (int z = 1; z < temp_path.Length - 1; z++)//ph?n t? d?u và cu?i luôn là 2 sensor du?c gi? l?i sau khi cluster
                                            //{
                                            //    for (int p = 0; p < listSensorAfter.Count; p++)
                                            //    {
                                            //        if (temp_path[z] == listSensorAfter[p].getId().ToString())
                                            //        {
                                            //            dem_path_valid--;//có b?t k? sensor nào du?c gi? l?i thì du?ng di dó b? b?
                                            //            //MessageBox.Show("Path not valid: " + temp, "Msg");
                                            //            //MessageBox.Show("path valid to break: " + dem_path_valid, "Msg");
                                            //            break;
                                            //        }
                                            //    }
                                            //    break;
                                            //}
                                            //}
                                            //if (dem_path_valid != 0)
                                            //{
                                            //MessageBox.Show("path valid: " + dem_path_valid, "Msg");
                                            graphRouting[to][from] = 1;
                                            Pathfull.Add(PathID);
                                            newTransfer = DelayTime(PathID, listSensorBefore, listLinkBefore);
                                            Link createVirtualLink = new Link(listSensorBefore[to], listSensorBefore[from], "Virtual", Convert.ToInt16(newTransfer));
                                            if (checkLinkHave(createVirtualLink, listLinkAfter) == false)
                                            {
                                                DevLog.d(TAG, "Link created: " + createVirtualLink.getSource().getId() + " _ " + createVirtualLink.getDest().getId());
                                                listLinkAfter.Add(createVirtualLink);
                                                DevLog.d(TAG, "=======END========");
                                            }
                                            //listLinkAfterCluster.Add(createVirtualLink);
                                            //}

                                        }
                                    }
                                    #region //Ðang th? in ra du?ng di
                                    //            //Ð?m du?ng
                                    //            int demduong = 0;
                                    //            for (int b = 0; b < path.Length; b++)
                                    //            {
                                    //                //MessageBox.Show("from " + (char)path[b] + " " + from, "Message");
                                    //                if (((char)path[b]).ToString() == from.ToString())
                                    //                {
                                    //                    demduong++;
                                    //                    //MessageBox.Show("from2 " + (char)path[b] + " " + from, "Message");
                                    //                }
                                    //                //MessageBox.Show("to " + (char)path[b] + " " + to, "Message");
                                    //                else if (((char)path[b]).ToString() == to.ToString())
                                    //                {
                                    //                    demduong++;
                                    //                    //MessageBox.Show("to2 " + (char)path[b] + " " + to, "Message");
                                    //                    break;
                                    //                }
                                    //                else demduong++;
                                    //                //MessageBox.Show("mang gom: " + demduong, "Message");
                                    //            }

                                    //            //MessageBox.Show("Break r: " + demduong, "Message");
                                    //            //for (int o = 0; o < temp.Length; o++)
                                    //            //{
                                    //            //    MessageBox.Show("" + temp[o], "Message");
                                    //            //}
                                    //            //Luu du?ng di vào m?ng 2 chi?u
                                    //            Pathfull[countVirtualLink] = new string[demduong];
                                    //            int dem = 0;

                                    //            for (int e = 0; e < Pathfull[countVirtualLink].Length; e++)
                                    //            {
                                    //                while (dem < path.Length)
                                    //                {
                                    //                    if (dem == demduong)
                                    //                    {
                                    //                        break;
                                    //                    }
                                    //                    //MessageBox.Show("from " + (char)path[b] + " " + from, "Message");
                                    //                    if (((char)path[dem]).ToString() == from.ToString())
                                    //                    {
                                    //                        Pathfull[countVirtualLink][e] = ((char)path[dem]).ToString();
                                    //                        dem++;
                                    //                        break;
                                    //                        //demduong++;

                                    //                        //MessageBox.Show("from2 " + (char)path[b] + " " + from, "Message");
                                    //                    }
                                    //                    //MessageBox.Show("to " + (char)path[b] + " " + to, "Message");
                                    //                    else if (((char)path[dem]).ToString() == to.ToString())
                                    //                    {
                                    //                        Pathfull[countVirtualLink][e] = ((char)path[dem]).ToString();
                                    //                        dem++;
                                    //                        //demduong++;

                                    //                        //demduong++;
                                    //                        //MessageBox.Show("to2 " + (char)path[b] + " " + to, "Message");
                                    //                        break;
                                    //                    }
                                    //                    else
                                    //                    {
                                    //                        Pathfull[countVirtualLink][e] = ((char)path[dem]).ToString();
                                    //                        dem++;
                                    //                        break;
                                    //                        //MessageBox.Show("mang gom: " + demduong, "Message");
                                    //                    }
                                    //                }
                                    //            }
                                    #endregion
                                }
                            }

                            //Ki?m tra list link after l?n n?a
                        Exception_Link:
                            for (int f1 = 0; f1 < listLinkAfter.Count; f1++)
                            {
                                if (listLinkAfter[f1].getLType() == "Virtual")
                                {
                                    for (int f2 = 0; f2 < listLinkAfter.Count; f2++)
                                    {
                                        if (listLinkAfter[f1].getDest().getId() == listLinkAfter[f2].getSource().getId())
                                        {
                                            for (int f3 = 0; f3 < listLinkAfter.Count; f3++)
                                            {
                                                if ((listLinkAfter[f1].getSource().getId() == listLinkAfter[f3].getSource().getId()) && (listLinkAfter[f2].getDest().getId() == listLinkAfter[f3].getDest().getId()))
                                                {
                                                    if (listLinkAfter[f3].getLType() == "Virtual")
                                                    {
                                                        listLinkAfter.RemoveAt(f3);
                                                        goto Exception_Link;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (listLinkAfter[f1].getLType() == "Real")
                                {
                                    for (int f2 = 0; f2 < listLinkAfter.Count; f2++)
                                    {
                                        if (listLinkAfter[f1].getDest().getId() == listLinkAfter[f2].getSource().getId())
                                        {
                                            for (int f3 = 0; f3 < listLinkAfter.Count; f3++)
                                            {
                                                if ((listLinkAfter[f1].getSource().getId() == listLinkAfter[f3].getSource().getId()) && (listLinkAfter[f2].getDest().getId() == listLinkAfter[f3].getDest().getId()))
                                                {
                                                    if (listLinkAfter[f3].getLType() == "Virtual")
                                                    {
                                                        listLinkAfter.RemoveAt(f3);
                                                        goto Exception_Link;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            //Log.d(TAG, "====START=======");
                            //Log.d(TAG, "====LIST LINK AFTER CLUSTER=======");
                            //foreach (Link l in listLinkAfterCluster)
                            //{
                            //   DevLog.d(TAG, "src: " + l.getSource().getId() + " dest: " + l.getDest().getId());
                            //}
                            //Log.d(TAG, "====LIST LINK AFTER=======");
                            //foreach (Link l2 in listLinkAfter)
                            //{
                            //   DevLog.d(TAG, "src2: " + l2.getSource().getId() + " dest2: " + l2.getDest().getId());
                            //}
                            listLinkAfterCluster.AddRange(listLinkAfter);

                            //Log.d(TAG, "====END=======");


                            #region cmt
                            ////T?o các src sink gi? trong t?ng c?m
                            //int sourc = 0;
                            //int sink = 0;
                            ////int index_src;
                            ////int index_sink;
                            //bool flagCheck = false;
                            ///*
                            // * gi? nguyên source sink g?c, 
                            // * n?u có source r thì các sensor khác không du?c là source,
                            // * n?u có sink r thì các sensor khác không du?c là sink,
                            // * 
                            // */
                            //for (int s = 0; s < listSensorBefore.Count; s++)
                            //{
                            //    if (listSensorBefore[s].getstype() == 1)
                            //    {
                            //        sourc = listSensorBefore[s].getId();
                            //        //index_src = s;
                            //        //continue;
                            //    }
                            //    if (listSensorBefore[s].getstype() == 2)
                            //    {
                            //        sink = listSensorBefore[s].getId();
                            //        //index_sink = s;
                            //        //break;
                            //    }
                            //}
                            //#region //ch? có src
                            //if ((sourc != 0) && (sink == 0))//ch? có src
                            //{
                            //    for (int f = 0; f < listSensorAfter.Count; f++)
                            //    {
                            //        if (listSensorAfter[f].getId() == sourc)
                            //        {
                            //            continue;
                            //        }
                            //        else
                            //        {
                            //            //T?o sink gi?
                            //            for (int t = 0; t < LinkTo.Length; t++)
                            //            {
                            //                if (LinkTo[t] == listSensorAfter[f].getId())// có link di vào
                            //                {
                            //                    for (int s = 0; s < listSensorBefore.Count; s++)
                            //                    {
                            //                        if (LinkFrom[t] == listSensorBefore[s].getId())
                            //                        {
                            //                            flagCheck = false;//link t? sensor trong c?m
                            //                            continue;
                            //                        }
                            //                        else
                            //                        {
                            //                            flagCheck = true;//link t? sensor khác c?m
                            //                            break;
                            //                        }

                            //                    }
                            //                    if (flagCheck == true)
                            //                    {
                            //                        for (int g = 0; g < listSensorBefore.Count; g++)
                            //                        {
                            //                            if (listSensorAfter[f].getId() == listSensorBefore[g].getId())
                            //                            {
                            //                                listSensorBefore[g].SType = 2;
                            //                                //MessageBox.Show("Sensor " + listSensorBefore[g].getId() + ": " + listSensorBefore[g].getstype(), "msg");
                            //                            }

                            //                        }
                            //                        flagCheck = false;
                            //                    }
                            //                }
                            //            }

                            //        }

                            //    }
                            //}
                            //#endregion
                            //#region //ch? có sink
                            //if ((sourc == 0) && (sink != 0))//ch? có sink
                            //{
                            //    for (int f = 0; f < listSensorAfter.Count; f++)
                            //    {
                            //        if (listSensorAfter[f].getId() == sink)
                            //        {
                            //            continue;
                            //        }
                            //        else
                            //        {
                            //            //T?o src gi?
                            //            for (int t = 0; t < LinkFrom.Length; t++)
                            //            {
                            //                if (LinkFrom[t] == listSensorAfter[f].getId())// có link di ra
                            //                {
                            //                    for (int s = 0; s < listSensorBefore.Count; s++)
                            //                    {
                            //                        if (LinkTo[t] == listSensorBefore[s].getId())
                            //                        {
                            //                            flagCheck = false;//link ra sensor trong c?m
                            //                            continue;
                            //                        }
                            //                        else
                            //                        {
                            //                            flagCheck = true;//link ra sensor khác c?m
                            //                            break;
                            //                        }
                            //                    }
                            //                    if (flagCheck == true)
                            //                    {
                            //                        for (int g = 0; g < listSensorBefore.Count; g++)
                            //                        {
                            //                            if (listSensorAfter[f].getId() == listSensorBefore[g].getId())
                            //                            {
                            //                                listSensorBefore[g].SType = 1;
                            //                                //MessageBox.Show("Sensor " + listSensorBefore[g].getId() + ": " + listSensorBefore[g].getstype(), "msg");
                            //                            }

                            //                        }
                            //                        flagCheck = false;
                            //                    }
                            //                }

                            //            }

                            //        }

                            //    }
                            //}
                            //#endregion
                            //#region //không có src sink
                            //if ((sourc == 0) && (sink == 0))//không có src sink
                            //{

                            //}
                            //#endregion 
                            #endregion
                            #endregion
                            #region //create virtual src & virtual sink
                            for (int g = 0; g < LinkFromgiunguyen.Length; g++)
                            {
                                //Log.d(TAG, "Link from " + LinkFromgiunguyen[g] + " to " + LinkTogiunguyen[g]);
                                if ((LinkFromgiunguyen[g] != 0) && (LinkTogiunguyen[g] != 0))
                                {
                                    //MessageBox.Show("Link from " + LinkFromgiunguyen[g] + " to " + LinkTogiunguyen[g], "msg");
                                    for (int f = 0; f < listSensorBefore.Count; f++)
                                    {
                                        //create virtual sink
                                        if (listSensorBefore[f].getId() == LinkFromgiunguyen[g])
                                        {
                                            for (int t = 0; t < sensor.Length; t++)
                                            {
                                                if (LinkTogiunguyen[g] == sensor[t][0])
                                                {
                                                    if (sensor[t][3] == 1)
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        //tempStype = sensor[t][3];
                                                        sensor[t][3] = 2;
                                                        Sensor virtualSink = new Sensor(LinkTogiunguyen[g], sensor[t][1], sensor[t][2], Convert.ToInt16(sensor[t][3]), Convert.ToInt16(sensor[t][4]), Convert.ToInt16(sensor[t][5]), sensor[t][6], sensor[t][7]);
                                                        if (listVirtualSink.Count == 0)
                                                        {
                                                            listVirtualSink.Add(virtualSink);
                                                            //break;
                                                        }
                                                        else if ((checkSensorHave(virtualSink, listVirtualSink)) == false)//check this sensor can have found in listSensorBefore return true, otherwise return false
                                                        {
                                                            listVirtualSink.Add(virtualSink);
                                                            //MessageBox.Show("list virtual from: "+listSensorBefore[f].getId() + " to sink " + virtualSink.getId(), "msg");
                                                            //MessageBox.Show("list virtual sink: " + (listVirtualSink.Contains(virtualSink)), "msg");
                                                            //sensor[t][3] = tempStype;
                                                            //break;
                                                        }
                                                        for (int k = 0; k < listLink.Count; k++)
                                                        {
                                                            if ((listLink[k].getSource().getId() == listSensorBefore[f].getId()) && (listLink[k].getDest().getId() == virtualSink.getId()))
                                                            {
                                                                if (checkLinkHave(listLink[k], listLinkBefore) == false)
                                                                {
                                                                    listLinkSink.Add(listLink[k]);
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                            break;
                                        }
                                        //create virtual src
                                        else if (listSensorBefore[f].getId() == LinkTogiunguyen[g])
                                        {
                                            for (int t = 0; t < sensor.Length; t++)
                                            {
                                                if (LinkFromgiunguyen[g] == sensor[t][0])
                                                {
                                                    if (sensor[t][3] == 2)
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        //tempStype = sensor[t][3];
                                                        sensor[t][3] = 1;
                                                        Sensor virtualSource = new Sensor(LinkFromgiunguyen[g], sensor[t][1], sensor[t][2], Convert.ToInt16(sensor[t][3]), Convert.ToInt16(sensor[t][4]), Convert.ToInt16(sensor[t][5]), sensor[t][6], sensor[t][7]);
                                                        if (listVirtualSource.Count == 0)
                                                        {
                                                            listVirtualSource.Add(virtualSource);
                                                            //break;
                                                        }
                                                        else if ((checkSensorHave(virtualSource, listVirtualSource)) == false)//check this sensor can have found in listSensorBefore return true, otherwise return false
                                                        {
                                                            listVirtualSource.Add(virtualSource);
                                                            //MessageBox.Show("list virtual from src: " + listSensorBefore[f].getId() + " to " + virtualSource.getId(), "msg");
                                                            //MessageBox.Show("list virtual src: " + (listVirtualSource.Contains(virtualSource)), "msg");
                                                            //sensor[t][3] = tempStype;
                                                            //break;
                                                        }
                                                        for (int k = 0; k < listLink.Count; k++)
                                                        {
                                                            if ((listLink[k].getSource().getId() == virtualSource.getId()) && (listLink[k].getDest().getId() == listSensorBefore[f].getId()))
                                                            {
                                                                if (checkLinkHave(listLink[k], listLinkBefore) == false)
                                                                {
                                                                    listLinkSource.Add(listLink[k]);
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            #endregion

                            DevLog.d(TAG, "=======LIST VIRTUAL SRC=====");
                            foreach (Sensor src in listVirtualSource)
                            {
                                DevLog.d(TAG, "src: " + src.getId());
                            }
                            DevLog.d(TAG, "=======LIST VIRTUAL SINK=====");
                            foreach (Sensor sink in listVirtualSink)
                            {
                                DevLog.d(TAG, "sink: " + sink.getId());
                            }
                            //create one new virtual src & virtual sink
                            DevLog.d(TAG, "=======NEW VIRTUAL SRC=====");
                            int newIDSrc = maxIDSensor(listVirtualSource);//ID of Src have maxSending & minProcessing
                            DevLog.d(TAG, "=======NEW VIRTUAL SINK=====");
                            int newIDSink = maxIDSensor(listVirtualSink);//ID of Sink have maxSending & minProcessing
                            //int oldIDSrc=0;
                            //int oldIDSink=0;
                            foreach (Sensor src in listVirtualSource)
                            {
                                if (src.getId() == newIDSrc)
                                {
                                    Sensor newSrc = new Sensor(newIDSrc, averagePosition(listVirtualSource, 1), averagePosition(listVirtualSource, 2), src.getstype(), src.getsending_rate(), src.getprocessing_rate(), averageLabel(listVirtualSource, 1), averageLabel(listVirtualSource, 2));
                                    listSensorBefore.Add(newSrc);
                                }
                            }
                            foreach (Sensor sink in listVirtualSink)
                            {
                                if (sink.getId() == newIDSink)
                                {
                                    Sensor newSink = new Sensor(newIDSink, averagePosition(listVirtualSink, 1), averagePosition(listVirtualSink, 2), sink.getstype(), sink.getsending_rate(), sink.getprocessing_rate(), averageLabel(listVirtualSink, 1), averageLabel(listVirtualSink, 2));
                                    listSensorBefore.Add(newSink);
                                }
                            }
                            foreach (Link linkSrc in listLinkSource)
                            {
                                //oldIDSrc = linkSrc.getSource().getId();
                                linkSrc.getSource().setId = newIDSrc;
                                //listLinkBefore.Add(linkSrc);
                                //linkSrc.getSource().setId = oldIDSrc;
                            }
                            foreach (Link linkSink in listLinkSink)
                            {
                                //oldIDSink = linkSink.getDest().getId();
                                linkSink.getDest().setId = newIDSink;
                                //listLinkBefore.Add(linkSink);
                                //linkSink.getDest().setId = oldIDSink;
                            }
                            for (int s = 0; s < sensor.Length; s++)
                            {
                                DevLog.d(TAG, "Sensor in array sensor: " + sensor[s][0] + " - Stype: " + sensor[s][3]);
                                DevLog.d(TAG, "Sensor in list: " + listSensor[s].getId() + " - Stype: " + listSensor[s].getstype());
                            }


                            //listSensorBefore.AddRange(listVirtualSource);

                            //listSensorBefore.AddRange(listVirtualSink);
                            foreach (Link lSource in listLinkSource)
                            {
                                if (checkLinkHave(lSource, listLinkBefore) == false)
                                {
                                    listLinkBefore.Add(lSource);
                                }

                            }
                            foreach (Link lSink in listLinkSink)
                            {
                                if (checkLinkHave(lSink, listLinkBefore) == false)
                                {
                                    listLinkBefore.Add(lSink);
                                }

                            }



                            //listSensorBefore.AddRange(listVirtualSource);

                            //listSensorBefore.AddRange(listVirtualSink);

                            listVirtualLinkNeedCreate.RemoveRange(0, listVirtualLinkNeedCreate.Count);
                            state = 1;
                            saveClusters(listSensorBefore, listLinkBefore, i + 1, state, Pathfull);

                            DevLog.d(TAG, "=====Cluster " + i + "=========");
                            for (int s = 0; s < sensor.Length; s++)
                            {
                                if (Convert.ToInt16(sensor[s][0]) != listSensor[s].getId())
                                {
                                    listSensor[s].setId = Convert.ToInt16(sensor[s][0]);

                                }
                                if (Convert.ToInt16(sensor[s][3]) != listSensor[s].getstype())
                                {
                                    sensor[s][3] = listSensor[s].getstype();
                                    //Log.d(TAG, "Sensor: " + sen.getId() + " - Stype: " + sensor[s][3]);
                                    //break;
                                }
                                //Log.d(TAG, "Sensor: " + sen.getId() + " - Stype: " + sen.getstype());

                            }

                            listSensorBefore.Clear();
                            listLinkBefore.Clear();
                            listVirtualSource.Clear();
                            listVirtualSink.Clear();
                            listLinkSink.Clear();
                            listLinkSource.Clear();
                            //MessageBox.Show("Ðã xóa c?m: " + (i + 1), "Message");

                            state = 2;
                            saveClusters(listSensorAfter, listLinkAfter, i + 1, state, Pathfull);
                            listSensorAfter.Clear();
                            listLinkAfter.Clear();
                            //Pathfull.RemoveRange(0, Pathfull.Count);
                            String NoBeforeClusters = "Before_cluster " + (i + 1); ;
                            String NoAfterClusters = "After_cluster " + (i + 1); ;
                            listBeforeClusters.Add(NoBeforeClusters);
                            listAfterClusters.Add(NoAfterClusters);

                        }
                        DevLog.d(TAG, "======Path Full=======");
                        foreach (String pathfull in Pathfull)
                        {
                            DevLog.d(TAG, "" + pathfull);
                        }
                        for (int z = 0; z < LinkFromgiunguyen.Length; z++)
                        {
                            if ((LinkFromgiunguyen[z] != 0) && (LinkTogiunguyen[z] != 0))
                            {
                                foreach (Link l in listLink)
                                {
                                    if ((l.getSource().getId() == LinkFromgiunguyen[z]) && (l.getDest().getId() == LinkTogiunguyen[z]))
                                    {
                                        if (checkLinkHave(l, listLinkAfterCluster) == false)
                                        {
                                            listLinkAfterCluster.Add(l);
                                        }
                                    }
                                }
                            }
                        }
                        state = 3;
                        saveClusters(listSensorAfterCluster, listLinkAfterCluster, 0, state, Pathfull);
                        state = 1;// gán l?i b?ng 1 d? mu?n ch?y cluster n?a thì ch?y

                        #region cmt
                        //DialogResult traloi2;
                        //traloi2 = MessageBox.Show("Do you want export file XML of all clusters after calculate?", "Export Clusters DBScan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (traloi2 == DialogResult.Yes)
                        //{
                        //    //Xu?t XML t?ng c?m sau khi x? lý
                        //    for (int i = 0; i < sensorgiunguyen.Length; i++)
                        //    {

                        //        for (int j = 0; j < sensorgiunguyen[i].Length; j++)
                        //        {
                        //            for (int n = 0; n < sensor.Length; n++)
                        //            {
                        //                if (sensorgiunguyen[i][j] == sensor[n][0])
                        //                {
                        //                    Sensor test = new Sensor(sensorgiunguyen[i][j], sensor[n][1], sensor[n][2], Convert.ToInt16(sensor[n][3]));
                        //                    listSensorAfter.Add(test);
                        //                    listSensorAfterCluster.Add(test);
                        //                }
                        //            }
                        //            for (int n = j + 1; n < sensorgiunguyen[i].Length; n++)
                        //            {
                        //                for (int k = 0; k < LinkFrom.Length; k++)
                        //                {

                        //                }
                        //            }
                        //        }


                        //    }
                        //}


                        #endregion
                        // }
                        //listPathDirectoryOpen.RemoveRange(0,listPathDirectoryOpen.Count);
                        mClusterListener.onUpdateProgressbar(0);
                        //ProgressBar1.Value = 0;

                        //state = 3;
                        //SaveClusters(listSensorAfterCluster, listLinkAfterCluster, 0, state);
                        //state = 1;// gán l?i b?ng 1 d? mu?n ch?y cluster n?a thì ch?y
                        //saveClustering.ShowDialog();
                        //OpenFile(tmpName, true);
                    };
                    break;
                #endregion

                #region case "Random":
                case ClusterType.Random:
                    {
                        RandomForm rd = new RandomForm();
                        rd.Show();
                        rd.ButtonGetNumSenLinkClicked += (s4, e4) =>
                        {
                            NUM_SENSOR = Int32.Parse(rd.textBox1.Text);
                            NUM_LINK = Int32.Parse(rd.textBox2.Text);
                            rd.Close();

                            //// mlqvu -- Current disable this function
                            //saveRandomNetwork.ShowDialog();
                            //OpenFile(tmpName, true);
                        };
                        //WaitCallback wait = new WaitCallback(saveClustering_FileOk());

                        //rd.getsenlink(ref NUM_SENSOR, ref NUM_LINK);
                        break;
                    }
                #endregion
                default:
                    break;
            }
            //};
            #endregion
        }
        
        private void checkListVirtualLinkNeedCreate(List<Link> listVirtualLinks)
        {
            for (int i = 0; i < listVirtualLinks.Count; i++)
            {
                foreach (Link l2 in listVirtualLinks)
                {
                    if ((listVirtualLinks[i].getSource().getId().ToString() == l2.getDest().getId().ToString()) && (listVirtualLinks[i].getDest().getId().ToString() == l2.getSource().getId().ToString()))
                    {
                        listVirtualLinks.Remove(l2);
                        break;
                    }
                }
            }
        }

        private void convertToPN(string kwsnName)
        {
            string kwsnPath = CURRENT_PATH + BEFORE_FOLDER + "\\" + kwsnName + ".kwsn";
            WSNTabItem wsnTabItem = new WSNTabItem("KWSN Model", "KWSN", null);
            wsnTabItem.Open(kwsnPath);

            string pnName = CURRENT_PATH + PN_FOLDER + "\\" + kwsnName + ".pn"; // 13486468456456.pn
            PNGenerationHelper helper = new PNGenerationHelper(pnName, wsnTabItem);
            XmlDocument pnFile = helper.GenerateXML(false, false);
            pnFile.Save(helper.GetGeneratedFileName());
        }

        private void verifyPN(string pnPath)
        {
            // verify pn and logs verify result.
        }

        public void verifyKwsn(string name)
        {
            convertToPN(name);
            verifyPN("");
        }

        private SpecificationBase parseSpecification()
        {
            SpecificationBase spec = null;

            do
            {
                if (mPNItem == null || mPNItem.Text.Trim() == "")
                    break;

                // DisableAllControls();
                try
                {
                    string moduleName = mPNItem.ModuleName;
                    if (loadModule(moduleName))
                    {
                        Stopwatch t = new Stopwatch();
                        t.Start();
                        spec = mCModule.ParseSpecification(mPNItem.Text, "", mPNItem.FileName);
                        t.Stop();

                        if (spec != null)
                        {
                            mPNItem.Specification = spec;
                            if (spec.Errors.Count > 0)
                            {
                                string key = "";
                                foreach (KeyValuePair<string, ParsingException> pair in spec.Errors)
                                {
                                    key = pair.Key;
                                    break;
                                }

                                ParsingException parsingException = spec.Errors[key];
                                spec.Errors.Remove(key);
                                throw parsingException;
                            }

                            //EnableAllControls();
                            break;
                        }
                        //else
                        //{
                        //    //EnableAllControls();
                        //    return null;
                        //}
                    }
                }
                catch (ParsingException ex) { }
                catch (Exception ex) { }
            } while (false);

            return spec;
        }

        private bool loadModule(string moduleName)
        {
            bool ret = true;

            do
            {
                try
                {
                    if (Common.Utility.Utilities.ModuleDictionary.ContainsKey(moduleName))
                    {
                        if (mCModule == null || moduleName != mCModule.ModuleName)
                            mCModule = Common.Utility.Utilities.ModuleDictionary[moduleName];
                        break;
                    }

                    string facadeClass = "PAT." + moduleName + ".ModuleFacade";
                    string file = Path.Combine(Path.Combine(Common.Utility.Utilities.ModuleFolderPath, moduleName), "PAT.Module." + moduleName + ".dll");

                    Assembly assembly = Assembly.LoadFrom(file);
                    mCModule = (ModuleFacadeBase)assembly.CreateInstance(facadeClass, true, BindingFlags.CreateInstance,
                                                           null, null, null, null);

                    if (mCModule.GetType().Namespace != "PAT." + moduleName)
                    {
                        mCModule = null;
                        ret = false;
                        break;
                    }

                    //mCModule.ShowModel += new ShowModelHandler(ShowModel);
                    //mCModule.ExampleMenualToolbarInitialize(this.MenuButton_Examples);
                    mCModule.ReadConfiguration();
                }
                catch { }
            } while (false);

            return ret;
        }
        private int maxIDSensor(List<Sensor> virtualSensors)
        {
            int newId = 0;
            for (int i = 0; i < virtualSensors.Count; i++)
            {
                if ((virtualSensors[i].getsending_rate() == maxSending(virtualSensors)) && (virtualSensors[i].getprocessing_rate() == minProcessing(virtualSensors)))
                {
                    newId = virtualSensors[i].getId();
                    break;
                }
            }
            DevLog.d(TAG, "ID new: " + newId);
            return newId;

        }
        private int maxSending(List<Sensor> virtualSensors)
        {
            int max = virtualSensors[0].getsending_rate();
            for (int i = 1; i < virtualSensors.Count; i++)
            {
                if (virtualSensors[i].getsending_rate() > max)
                {
                    max = virtualSensors[i].getsending_rate();
                }
            }
            DevLog.d(TAG, "Max Sending: " + max);
            return max;
        }
        private int minProcessing(List<Sensor> virtualSensors)
        {
            int min = virtualSensors[0].getprocessing_rate();
            for (int i = 1; i < virtualSensors.Count; i++)
            {
                if (virtualSensors[i].getprocessing_rate() < min)
                {
                    min = virtualSensors[i].getprocessing_rate();
                }
            }
            DevLog.d(TAG, "Min Process: " + min);
            return min;

        }

        private double averagePosition(List<Sensor> virtualSensors, int position)
        {
            /**position=1: Position X
             **position=2: Position Y
             **/
            double newPos = 0;
            if (position == 1)
            {
                foreach (Sensor sen in virtualSensors)
                {
                    newPos += sen.getX();
                }
            }
            else if (position == 2)
            {
                foreach (Sensor sen in virtualSensors)
                {
                    newPos += sen.getY();
                }
            }
            newPos = newPos / virtualSensors.Count;
            return newPos;
        }

        private double averageLabel(List<Sensor> virtualSensors, int label)
        {
            /**label=1: label X
             **label=2: label Y
             **/
            double newPos = 0;
            if (label == 1)
            {
                foreach (Sensor sen in virtualSensors)
                {
                    newPos += sen.getXLabel();
                }
            }
            else if (label == 2)
            {
                foreach (Sensor sen in virtualSensors)
                {
                    newPos += sen.getYLabel();
                }
            }
            newPos = newPos / virtualSensors.Count;
            return newPos;
        }
    }
}
