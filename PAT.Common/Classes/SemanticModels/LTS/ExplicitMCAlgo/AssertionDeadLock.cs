using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PAT.Common.Classes.DataStructure;
using System.Text;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.Ultility;
using QuickGraph;

namespace PAT.Common.Classes.SemanticModels.LTS.Assertion
{
    public abstract partial class AssertionDeadLock : AssertionBase
    {
        protected bool isNotTerminationTesting;

        protected AssertionDeadLock()
        {
        }

        protected AssertionDeadLock(bool isNontermination)
        {
            isNotTerminationTesting = isNontermination;
        }

        public override string ToString()
        {
            if (isNotTerminationTesting)
            {
                return StartingProcess + " nonterminating";
            }

            return StartingProcess + " deadlockfree";
        }

        /// <summary>
        /// Run the verification and get the result.
        /// </summary>
        /// <returns></returns>
        public override void RunVerification()
        {
            BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph;
            completeGraph = this.BuildCompleteGraph();
            if (SelectedEngineName == Constants.ENGINE_DEPTH_FIRST_SEARCH)
            {
                DFSVerification(); 
            }
            else if (SelectedEngineName == Constants.ENGINE_BREADTH_FIRST_SEARCH)
            {
                BFSVerification();
            }
            else if (SelectedEngineName == Constants.ENGINE_HEURISTIC_DEPTH_FIRST_SEARCH)
            {
            }
            else if (SelectedEngineName == Constants.ENGINE_HEURISTIC_BREADTH_FIRST_SEARCH)
            {
                BFSHeuristicVerification(completeGraph);
            }
        }

        public void DFSVerification()
        {
            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);

            Stack<ConfigurationBase> working = new Stack<ConfigurationBase>(1024);

            Visited.Add(InitialStep.GetID());

            working.Push(InitialStep);
            Stack<int> depthStack = new Stack<int>(1024);
            depthStack.Push(0);

            List<int> depthList = new List<int>(1024);

            do
            {
                if (CancelRequested)
                {
                    this.VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                ConfigurationBase current = working.Pop();
                int depth = depthStack.Pop();

                if (depth > 0)
                {
                    while (depthList[depthList.Count - 1] >= depth)
                    {
                        int lastIndex = depthList.Count - 1;
                        depthList.RemoveAt(lastIndex);
                        this.VerificationOutput.CounterExampleTrace.RemoveAt(lastIndex);
                    }
                }

                this.VerificationOutput.CounterExampleTrace.Add(current);
                IEnumerable<ConfigurationBase> list = current.MakeOneMove();
                this.VerificationOutput.Transitions += list.Count();

                if (current.IsDeadLock)
                {
                    if (isNotTerminationTesting || current.Event != Constants.TERMINATION)
                    {
                        this.VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                        this.VerificationOutput.NoOfStates = Visited.Count;
                        return;
                    }
                }

                depthList.Add(depth);

                foreach (ConfigurationBase step in list)
                {
                    string stepID = step.GetID();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Push(step);
                        depthStack.Push(depth + 1);
                    }
                }
            } while (working.Count > 0);

            this.VerificationOutput.CounterExampleTrace = null;

            if (MustAbstract)
            {
                this.VerificationOutput.VerificationResult = VerificationResultType.UNKNOWN;
            }
            else
            {
                this.VerificationOutput.VerificationResult = VerificationResultType.VALID;
            }

            this.VerificationOutput.NoOfStates = Visited.Count;
        }

        public void BFSVerification()
        {
            this.BuildCompleteGraph();

            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);

            Queue<ConfigurationBase> working = new Queue<ConfigurationBase>(1024);
            Queue<List<ConfigurationBase>> paths = new Queue<List<ConfigurationBase>>(1024);

            Visited.Add(InitialStep.GetID());

            string test = InitialStep.GetID();

            working.Enqueue(InitialStep);
            List<ConfigurationBase> path = new List<ConfigurationBase>();
            path.Add(InitialStep);
            paths.Enqueue(path);

            do
            {
                if (CancelRequested)
                {
                    VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                ConfigurationBase current = working.Dequeue();
                List<ConfigurationBase> currentPath = paths.Dequeue();
                //IEnumerable<ConfigurationBase> list = current.MakeOneMove();
                IEnumerable<ConfigurationBase> list = current.MakeOneMove();
                
                this.VerificationOutput.Transitions += list.Count();

                Debug.Assert(currentPath[currentPath.Count - 1].GetID() == current.GetID());

                //If the current process is deadlocked, return true if the current BA state is accepting. Otherwise, return false;
                if (current.IsDeadLock)
                {
                    if (this.isNotTerminationTesting || current.Event != Constants.TERMINATION)
                    {
                        this.VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                        this.VerificationOutput.NoOfStates = Visited.Count;
                        this.VerificationOutput.CounterExampleTrace = currentPath;
                        return;
                    }
                }

                foreach (ConfigurationBase step in list)
                {
                    string stepID = step.GetID();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Enqueue(step);

                        List<ConfigurationBase> newPath = new List<ConfigurationBase>(currentPath);
                        newPath.Add(step);
                        paths.Enqueue(newPath);
                    }
                }
            } while (working.Count > 0);

            this.VerificationOutput.CounterExampleTrace = null;
            if (MustAbstract)
            {
                VerificationOutput.VerificationResult = VerificationResultType.UNKNOWN;
            }
            else
            {
                VerificationOutput.VerificationResult = VerificationResultType.VALID;
            }

            VerificationOutput.NoOfStates = Visited.Count;
        }

        public void BFSHeuristicVerification(BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            // Test Caculate Distance
            List<ConfigurationBase> testList = this.retriveVertex(completeGraph);
            ConfigurationBase vertex1 = testList[0];
            ConfigurationBase vertex2 = testList[1];
            List<int> distanceList = caculateDistanceList(vertex1, vertex2, completeGraph);

            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);

            Queue<ConfigurationBase> working = new Queue<ConfigurationBase>(1024);
            Queue<List<ConfigurationBase>> paths = new Queue<List<ConfigurationBase>>(1024);

            Visited.Add(InitialStep.GetID());

            working.Enqueue(InitialStep);
            List<ConfigurationBase> path = new List<ConfigurationBase>();
            path.Add(InitialStep);
            paths.Enqueue(path);

            do
            {
                if (CancelRequested)
                {
                    VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                ConfigurationBase current = working.Dequeue();

                List<ConfigurationBase> currentPath = paths.Dequeue();
                //IEnumerable<ConfigurationBase> list = current.MakeOneMove();

                //IEnumerable<ConfigurationBase> list = current.MakeOneMove();

                // Find next step in complete graph
                IEnumerable<ConfigurationBase> list = findNextStep(current, completeGraph);


                this.VerificationOutput.Transitions += list.Count();

                Debug.Assert(currentPath[currentPath.Count - 1].GetID() == current.GetID());

                //If the current process is deadlocked, return true if the current BA state is accepting. Otherwise, return false;
                if (current.IsDeadLock)
                {
                    if (this.isNotTerminationTesting || current.Event != Constants.TERMINATION)
                    {
                        this.VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                        this.VerificationOutput.NoOfStates = Visited.Count;
                        this.VerificationOutput.CounterExampleTrace = currentPath;
                        return;
                    }
                }

                foreach (ConfigurationBase step in list)
                {
                    string stepID = step.GetID();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Enqueue(step);

                        List<ConfigurationBase> newPath = new List<ConfigurationBase>(currentPath);
                        newPath.Add(step);
                        paths.Enqueue(newPath);
                    }
                }
            } while (working.Count > 0);

            this.VerificationOutput.CounterExampleTrace = null;
            if (MustAbstract)
            {
                VerificationOutput.VerificationResult = VerificationResultType.UNKNOWN;
            }
            else
            {
                VerificationOutput.VerificationResult = VerificationResultType.VALID;
            }

            VerificationOutput.NoOfStates = Visited.Count;
        }

        // For test only
        private List<ConfigurationBase> retriveVertex(BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            List<ConfigurationBase> list = new List<ConfigurationBase>();
            int i = 0;
            foreach(ConfigurationBase vertex in completeGraph.Vertices)
            {
                i++;
            }

            int k = 0;
            foreach(ConfigurationBase vertex in completeGraph.Vertices)
            {
                if (k==0)
                {
                    list.Add(vertex);
                } 
                else if(k == (i-1))
                {
                    list.Add(vertex);
                }
                k++;
            }
            return list;
        }

        private IEnumerable<ConfigurationBase> findNextStep(ConfigurationBase current, BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            List<ConfigurationBase> list = new List<ConfigurationBase>();
            foreach(TaggedEdge<ConfigurationBase, string> edge in completeGraph.Edges)
            {
                   if(edge.Source.GetID() == current.GetID())
                   {
                       list.Add(edge.Target);
                   }
            }
            return list;
        }

        private Dictionary

        private List<int> caculateDistanceList(ConfigurationBase start, ConfigurationBase destination, BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            Queue<List<ConfigurationBase>> working = new Queue<List<ConfigurationBase>>();

            List<List<ConfigurationBase>> paths = new List<List<ConfigurationBase>>();

            List<ConfigurationBase> initialList = new List<ConfigurationBase>();
            initialList.Add(start);

            working.Enqueue(initialList);

            do
            {
                List<ConfigurationBase> current = working.Dequeue();
                ConfigurationBase u = current[current.Count - 1];

                if (u.GetID() == destination.GetID())
                {
                    paths.Add(current);
                }

                foreach (ConfigurationBase vertex in completeGraph.Vertices)
                {
                    if((!checkNodeExistInList(vertex, current)) && (isHaveEdge(u, vertex, completeGraph)))
                    {
                        List<ConfigurationBase> tempList = new List<ConfigurationBase>();
                        for (int i = 0; i < current.Count; i++ )
                        {
                            tempList.Add(current[i]);
                        }
                        tempList.Add(vertex);
                        working.Enqueue(tempList);
                    }
                }
            } while (working.Count > 0);

            List<int> distanceList = new List<int>();
            foreach(List<ConfigurationBase> path in paths)
            {
                distanceList.Add(path.Count - 1);
            }
            return distanceList;
        }

        private bool checkNodeExistInList(ConfigurationBase node, List<ConfigurationBase> nodeList)
        {
            if(nodeList.Count <= 0)
            {
                return false;
            }
            else
            {
                foreach(ConfigurationBase current in nodeList)
                {
                    if(current.GetID() == node.GetID())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool isHaveEdge(ConfigurationBase vertex1, ConfigurationBase vertex2, BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            foreach(TaggedEdge<ConfigurationBase, string> edge in completeGraph.Edges)
            {
                if(edge.Source.GetID() == vertex1.GetID())
                {
                    if(edge.Target.GetID() == vertex2.GetID())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string GetResultString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Constants.VERFICATION_RESULT_STRING);
            if (VerificationOutput.VerificationResult == VerificationResultType.VALID)
            {
                sb.AppendLine("The Assertion (" + ToString() + ") is VALID.");    
            }
            else if (VerificationOutput.VerificationResult == VerificationResultType.UNKNOWN)
            {
                sb.AppendLine("The Assertion (" + ToString() + ") is NEITHER PROVED NOR DISPROVED.");                
            }
            else
            {
                sb.AppendLine("The Assertion (" + ToString() + ") is NOT valid.");
                if(isNotTerminationTesting)
                {
                    sb.AppendLine("The following trace leads to a terminating situation.");    
                }
                else
                {
                    sb.AppendLine("The following trace leads to a deadlock situation.");    
                }

                VerificationOutput.GetCounterxampleString(sb);
            }

            sb.AppendLine();

            sb.AppendLine("********Verification Setting********");
            sb.AppendLine("Admissible Behavior: " + SelectedBahaviorName);  
            sb.AppendLine("Search Engine: " + SelectedEngineName);  
            sb.AppendLine("System Abstraction: " + MustAbstract);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}