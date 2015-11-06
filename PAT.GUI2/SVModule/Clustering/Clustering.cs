using PAT.GUI.SVModule.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAT.GUI.SVModule.Clustering
{
    public enum ClusterType
    { 
        KMEAN,
        DBSCAN,
        WSNClustering,
        Random
    }


    class Clustering
    {
        //KMeans Clustering
        public static void kmeansClustering(List<Sensor> oldSensors, List<Link> oldLinks, double[][] rawdata,
            ref List<Sensor> newSensors, ref List<Link> newLinks, int numCluster)
        {

            int numAttribut = 2;
            int numLoop = rawdata.Length * 10;
            int cpt = 0;
            foreach (Sensor s in oldSensors)
            {
                rawdata[cpt] = new double[numAttribut];
                rawdata[cpt][0] = s.getX();
                rawdata[cpt][1] = s.getY();
                cpt++;
            }

            int[] result = KMeansClustering.Cluster(rawdata, numCluster, numAttribut, numLoop);
            KMeansClustering.ShowClustering(rawdata, numCluster, result, true);

            List<List<Sensor>> listClusters = KMeansClustering.divideCluster(oldSensors, result, numCluster);
            newSensors = createNewSensor(listClusters);
            newLinks = createNewLinks(oldLinks, listClusters, newSensors, numCluster);

            foreach (Link l in newLinks)
            {
                string a = "[(" + l.getSource().getX() + "-" + l.getSource().getY() + ")(" + l.getDest().getX() + "-" + l.getDest().getY() + ")]";
                Console.WriteLine(a);
            }

        }


        public static void WSNClustering(List<Sensor> oldSensors, List<Link> oldLinks,
            ref List<Sensor> newSensors, ref List<Link> newLinks, int minPts, double eps)
        {
            //DBSCAN
            //sw = Stopwatch.StartNew();
            List<List<Sensor>> clusters1 = new List<List<Sensor>>();
            clusters1 = DBSCAN.GetClusters(oldSensors, eps, minPts);

            newSensors = createNewSensor(clusters1);
            newLinks = createNewLinks(oldLinks, clusters1, newSensors, newSensors.Count);
            //sw.Stop();
            //timer[0] = sw.Elapsed.TotalMilliseconds;
            //result[0] = newSensors.Count;

            //Sending Rate
            //sw = Stopwatch.StartNew();
            List<Sensor> lSens = newSensors;
            List<Link> lLinks = newLinks;
            newSensors = new List<Sensor>();
            newLinks = new List<Link>();

            List<List<Sensor>> clusters2 = new List<List<Sensor>>();
            clusters2 = DBSCAN.clusterRate(lSens, eps);
            //Replace clusters in clusters1 by initial nodes
            int numSensVerify = 0;

            foreach (List<Sensor> ls in clusters2)
            {
                //Check cluster or noise?
                /*
                foreach(Sensor s in ls)
                {
                    //Compare sensor in [clusters2] with sensor in lSens
                    //then find how to link them to the sensor in [clusters1]
                    //lSens: sensors after DBSCAN
                    //clusters1: list of list
                    
                }
                */
                for (int i = 0; i < lSens.Count; i++)
                {
                    if (ls.Contains(lSens[i]))
                    {
                        ls.AddRange(clusters1[i]);
                        ls.Remove(lSens[i]);
                    }
                }
                numSensVerify += ls.Count;
            }

            numSensVerify += 0;
            clusters2.RemoveAll(s => s.Count == 0);
            newSensors = createNewSensor(clusters2);
            newLinks = createNewLinks(lLinks, clusters2, newSensors, newSensors.Count);
            //sw.Stop();
            //timer[1] = sw.Elapsed.TotalMilliseconds;
            //result[1] = newSensors.Count;
        }

        public static void dbscanClustering(List<Sensor> oldSensors, List<Link> oldLinks,
            ref List<Sensor> newSensors, ref List<Link> newLinks, int minPts, double eps)
        {
            /*
            double eps = 100.0;
            int minPts = 3;
            List<Sensor> points = new List<Sensor>();
            points.Add(new Sensor(1, 0, 100));
            points.Add(new Sensor(2, 0, 200));
            points.Add(new Sensor(3, 0, 275));
            points.Add(new Sensor(4, 100, 150));
            points.Add(new Sensor(5, 200, 100));
            points.Add(new Sensor(6, 250, 200));
            points.Add(new Sensor(7, 0, 300));
            points.Add(new Sensor(8, 100, 200));
            points.Add(new Sensor(9, 600, 700));
            points.Add(new Sensor(10, 650, 700));
            points.Add(new Sensor(11, 675, 700));
            points.Add(new Sensor(12, 675, 710));
            points.Add(new Sensor(13, 675, 720));
            points.Add(new Sensor(14, 50, 400));
            */

            List<List<Sensor>> clusters = DBSCAN.GetClusters(oldSensors, eps, minPts);
            newSensors = createNewSensor(clusters);
            newLinks = createNewLinks(oldLinks, clusters, newSensors, newSensors.Count);
            // print clusters to console
            int total = 0;
            if (clusters.Count == 0)
            {
                Console.WriteLine("No cluster");
            }
            for (int i = 0; i < clusters.Count; i++)
            {
                int count = clusters[i].Count;
                total += count;
                string plural = (count != 1) ? "s" : "";
                Console.WriteLine("\nCluster {0} consists of the following {1} point{2} :\n", i + 1, count, plural);
                foreach (Sensor p in clusters[i]) Console.Write(" {0} ", p);
                Console.WriteLine();
            }
        }


        //Other methods
        //Check sensor thuoc ve nhom nao
        private static Sensor groupBelongs(Sensor s, List<List<Sensor>> newClusters, List<Sensor> newSensors)
        {
            for (int i = 0; i < newClusters.Count; i++)
            {
                foreach (Sensor sen in newClusters[i])
                {
                    if (sen.getId() == s.getId())
                    {
                        return (Sensor)newSensors[i];
                    }
                }
            }
            return null;
        }

        //Tao ra sensor moi
        public static List<Sensor> createNewSensor(List<List<Sensor>> newClusters)
        {
            ////Sensor[] res = new Sensor[newSensor.Length];
            List<Sensor> result = new List<Sensor>();
            //for (int i = 0; i < newSensor.Count; i++)
            //{
            //    double x = ((Sensor)newSensor[i][0]).getX();
            //    double y = ((Sensor)newSensor[i][0]).getY();
            //    result.Add(new Sensor(i + 1, x, y));
            //}
            //return result;
            int i = 1;
            foreach (List<Sensor> l in newClusters)
            {
                double x = 0, y = 0;
                int stype = 0;
                int rate = 0;
                if (l.Count == 0)
                    continue;
                foreach (Sensor s in l)
                {
                    x += s.SX;
                    y += s.SY;
                    rate += s.SendingRate;
                }
                Sensor n = new Sensor(i, x / l.Count, y / l.Count, stype);
                n.SendingRate = rate / l.Count;
                n.GroupId = Sensor.UNCLASSIFIED;
                result.Add(n);
                i++;
            }

            return result;
        }

        //Tao ra link voi sensor moi
        public static List<Link> createNewLinks(List<Link> links, List<List<Sensor>> newClusters, List<Sensor> newSensors, int numCluster)
        {
            int maxLink = numCluster * (numCluster - 1) / 2;

            List<Link> result = new List<Link>();

            foreach (Link l in links)
            {
                if (result.Count == maxLink)
                    break;

                Sensor groupFrom = groupBelongs(l.getSource(), newClusters, newSensors);
                Sensor groupDest = groupBelongs(l.getDest(), newClusters, newSensors);
                if (groupDest == null)
                {
                    Console.WriteLine(l.getDest());
                }
                Sensor nFrom = null;
                Sensor nTo = null;

                if (groupFrom.getId() != groupDest.getId())
                {
                    nFrom = groupFrom;
                    nTo = groupDest;
                }
                else
                {
                    continue;
                }

                Link nlink = new Link(nFrom, nTo, "Real");

                if (result.Count == 0)
                    result.Add(nlink);
                else
                {
                    //foreach (Link ol in result)

                    for (int i = 0; i < result.Count; i++)
                    {
                        if (!((Link)result[i]).isSame(nlink))
                        {
                            result.Add(nlink);
                            break;
                        }
                    }

                    /*
                    if(!result.Contains(nlink)) {
                        result.Add(nlink);
                    }
                    */
                }

            }

            return result;
        }
    }
}
