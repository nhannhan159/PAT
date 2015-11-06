using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using PAT.GUI.SVModule.Base;

namespace PAT.GUI.SVModule.Clustering
{
    class DBSCAN
    {
        static int sensRate = 4;
        /**
            Chia cac sensor ra thanh tung nhom
            moi noise = 1 nhóm
        */
        static int transRate = 9;


        public static List<List<Sensor>> clusterRate(List<Sensor> points, double eps)
        {
            if (eps == 0)
            {
                eps = 2 * sensRate / (transRate + 1);
            }
            if (points == null) return null;

            List<List<Sensor>> clusters = new List<List<Sensor>>();
            //eps *= eps; // square eps
            int GroupId = 1;
            for (int i = 0; i < points.Count; i++)
            {
                Sensor p = points[i];
                if (p.GroupId == Sensor.UNCLASSIFIED)
                {
                    if (ExpandClusterRate(points, p, GroupId, eps))
                        GroupId++;
                }
            }

            // Sap xep sensor thanh tung nhom
            int maxGroupId = points.OrderBy(p => p.GroupId).Last().GroupId;
            if (maxGroupId < 1) // ko co cluster
            {
                for (int i = 0; i < points.Count; i++)
                {
                    clusters.Add(new List<Sensor>());
                    clusters[i].Add(points[i]);
                }

                return clusters;
            }

            int numNoise = 0;

            //Real clusters
            for (int i = 0; i < maxGroupId; i++)
                clusters.Add(new List<Sensor>());

            foreach (Sensor p in points)
            {
                if (p.GroupId > 0)
                    clusters[p.GroupId - 1].Add(p);
                else
                    numNoise++;
            }

            //Noise "cluster"
            for (int i = 0; i < numNoise; i++)
                clusters.Add(new List<Sensor>());
            int cpt = 0;
            foreach (Sensor p in points)
            {
                if (p.GroupId == Sensor.NOISE)
                {
                    clusters[maxGroupId + cpt].Add(p);
                    cpt++;
                }
            }
            return clusters;
        }


        static bool ExpandClusterRate(List<Sensor> points, Sensor p, int GroupId, double eps)
        {
            List<Sensor> seeds = GetRegion(points, p, eps);

            //List<Sensor> all = seeds.ConvertAll(s => new Sensor(s.Id, s.SX, s.SY, s.SendingRate));
            List<Sensor> all = new List<Sensor>();
            all.AddRange(seeds);

            if (Fairness(all) < 0.5) // khong phai core
            {
                p.GroupId = Sensor.NOISE;
                return false;
            }
            else // cac điểm trong seeds đều có kết nối với p
            {

                for (int i = 0; i < seeds.Count; i++)
                    seeds[i].GroupId = GroupId;

                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    Sensor currentP = seeds[0];
                    List<Sensor> result = GetRegion(points, currentP, eps);

                    // Remove classified
                    result.RemoveAll(s => (s.GroupId != Sensor.NOISE && s.GroupId != Sensor.UNCLASSIFIED));

                    int startInd = all.Count;

                    //Merge result with all
                    /*
                    for(int i=0; i<result.Count; i++)
                    {
                        all.Add(new Sensor(result[i].Id, result[i].SX, result[i].SY, result[i].SendingRate));
                    }
                    */
                    all.AddRange(result);

                    if (Fairness(all) < 0.5)
                    {
                        all.RemoveRange(startInd, result.Count);
                    }
                    else
                    {

                        for (int i = 0; i < result.Count; i++)
                        {
                            Sensor resultP = result[i];
                            if (resultP.GroupId == Sensor.UNCLASSIFIED || resultP.GroupId == Sensor.NOISE)
                            {
                                //Nếu điểm chưa xét -> đưa vào seeds để xét tiếp
                                if (resultP.GroupId == Sensor.UNCLASSIFIED)
                                    seeds.Add(resultP);

                                resultP.GroupId = GroupId;
                            }
                        }
                    }
                    seeds.Remove(currentP);
                }
                return true;
            }
        }

        static double Fairness(List<Sensor> sensors)
        {
            double fairness = 0;
            double top = 0, bottom = 0;
            foreach (Sensor s in sensors)
            {
                top += s.SendingRate;
                bottom += s.SendingRate * s.SendingRate;
            }
            if (top > 0 && bottom > 0)
                fairness = top * top / (sensors.Count * bottom);

            return fairness;
        }

        public static List<List<Sensor>> GetClusters(List<Sensor> points, double eps, int minPts)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine("\nSensor {0}: {1}-{2}-Stype={3}", points[i].getId(), points[i].getX(), points[i].getY(), points[i].getstype());
            }
            if (points == null) return null;
            if (eps == 0)
            {
                eps = 2 * sensRate / (transRate + 1);
            }
            List<List<Sensor>> clusters = new List<List<Sensor>>();
            //eps *= eps; // square eps
            int GroupId = 1;
            for (int i = 0; i < points.Count; i++)
            {
                Sensor p = points[i];
                if (p.GroupId == Sensor.UNCLASSIFIED)
                {
                    if (ExpandCluster(points, p, GroupId, eps, minPts))
                        GroupId++;
                }
            }

            // Sap xep sensor thanh tung nhom
            int maxGroupId = points.OrderBy(p => p.GroupId).Last().GroupId;
            if (maxGroupId < 1)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    clusters.Add(new List<Sensor>());
                    clusters[i].Add(points[i]);
                }
                return clusters; // ko co cluster -> list rỗng
            }
            int numNoise = 0;

            //Real clusters
            for (int i = 0; i < maxGroupId; i++)
                clusters.Add(new List<Sensor>());

            foreach (Sensor p in points)
            {
                if (p.GroupId > 0)
                    clusters[p.GroupId - 1].Add(p);
                else
                    numNoise++;
            }

            //Noise "cluster"
            for (int i = 0; i < numNoise; i++)
                clusters.Add(new List<Sensor>());
            int cpt = 0;
            foreach (Sensor p in points)
            {
                if (p.GroupId == Sensor.NOISE)
                {
                    clusters[maxGroupId + cpt].Add(p);
                    cpt++;
                }
            }


            return clusters;
        }

        //Lay list cac sensor trong pham vi epsilon
        static List<Sensor> GetRegion(List<Sensor> points, Sensor p, double eps)
        {
            List<Sensor> region = new List<Sensor>();
            for (int i = 0; i < points.Count; i++)
            {
                double dist = Sensor.Distance(p, points[i]);
                if (dist <= eps) region.Add(points[i]);
            }
            return region;
        }

        /**
            Mo rong cluster
            Neu xung quanh co số sensor > minPts -> core -> mo rong tiep tuc
        */
        static bool ExpandCluster(List<Sensor> points, Sensor p, int GroupId, double eps, int minPts)
        {
            List<Sensor> seeds = GetRegion(points, p, eps);
            if (seeds.Count < minPts) // khong phai core
            {
                p.GroupId = Sensor.NOISE;
                return false;
            }
            else // cac điểm trong seeds đều có kết nối với p
            {
                for (int i = 0; i < seeds.Count; i++)
                    seeds[i].GroupId = GroupId;

                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    Sensor currentP = seeds[0];
                    List<Sensor> result = GetRegion(points, currentP, eps);
                    if (result.Count >= minPts)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            Sensor resultP = result[i];
                            if (resultP.GroupId == Sensor.UNCLASSIFIED || resultP.GroupId == Sensor.NOISE)
                            {
                                //Nếu điểm chưa xét -> đưa vào seeds để xét tiếp
                                if (resultP.GroupId == Sensor.UNCLASSIFIED)
                                    seeds.Add(resultP);

                                resultP.GroupId = GroupId;
                            }
                        }
                    }
                    seeds.Remove(currentP);
                }
                return true;
            }
        }

        public static List<Sensor> newSensor(List<List<Sensor>> newCluster)
        {
            //Sensor[] res = new Sensor[newSensor.Length];
            List<Sensor> result = new List<Sensor>();

            //Cluster
            for (int i = 0; i < newCluster.Count; i++)
            {
                double x = newCluster[i][0].getX();
                double y = newCluster[i][0].getY();
                result.Add(new Sensor(i + 1, x, y));
            }
            return result;
        }

        private static Sensor groupBelongs(Sensor s, List<List<Sensor>> newClusters, List<Sensor> newSensors)
        {
            for (int i = 0; i < newClusters.Count; i++)
            {
                foreach (Sensor sen in newClusters[i])
                {
                    if (sen.getId() == s.getId())
                    {
                        return newSensors[i];
                    }
                }
            }
            return null;
        }
    }
}
