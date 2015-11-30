using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAT.Common.Classes.BA;
using PAT.Common.Classes.DataStructure;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.Ultility;
using QuickGraph;

namespace PAT.Common.Classes.SemanticModels.LTS.Assertion
{
    public partial class AssertionLTL 
    {
        /// <summary>
        /// Run the verification and get the result.
        /// </summary>
        /// <returns></returns>
        public virtual void RunVerificationSafety()
        {
            if (SelectedEngineName == Constants.ENGINE_DEPTH_FIRST_SEARCH)
            {
                DFSVerification();
            }
            else
            {
                BFSVerification();
            }           
        }

        public void DFSVerification()
        {
            //The following are for identifying a counterexample trace. 
            Stack<int> depthStack = new Stack<int>(1024);
            depthStack.Push(0);
            List<int> depthList = new List<int>(1024);
            //The above are for identifying a counterexample trace. 

            Stack<EventBAPairSafety> TaskStack = new Stack<EventBAPairSafety>();

            EventBAPairSafety initialstep = EventBAPairSafety.GetInitialPairs(BA, InitialStep);
            TaskStack.Push(initialstep);

            //Dictionary<string, bool> Visited = new Dictionary<string, bool>();
            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);


            while (TaskStack.Count != 0)
            {
                if (CancelRequested)
                {
                    this.VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                EventBAPairSafety now = TaskStack.Pop();
                string ID = now.GetCompressedState();


                //The following are for identifying a counterexample trace. 
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

                this.VerificationOutput.CounterExampleTrace.Add(now.configuration);
                depthList.Add(depth);
                //The above are for identifying a counterexample trace. 

                if (now.States.Count == 0)
                {
                    this.VerificationOutput.NoOfStates = Visited.Count;
                    this.VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                    return;
                }

                if (!Visited.ContainsKey(ID))
                {
                    Visited.Add(ID);

                    ConfigurationBase[] steps = now.configuration.MakeOneMove().ToArray();
                    this.VerificationOutput.Transitions += steps.Length;
                    EventBAPairSafety[] products = now.Next(BA,steps);
                    foreach (EventBAPairSafety step in products)
                    {
                        TaskStack.Push(step);
                        depthStack.Push(depth + 1);
                    }
                }
            }

            this.VerificationOutput.CounterExampleTrace = null;
            this.VerificationOutput.NoOfStates = Visited.Count;
            this.VerificationOutput.VerificationResult = VerificationResultType.VALID;
        }

        public void BFSVerification()
        {
            //Dictionary<string, bool> Visited = new Dictionary<string, bool>();
            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);
            Queue<EventBAPairSafety> working = new Queue<EventBAPairSafety>();
            Queue<List<ConfigurationBase>> paths = new Queue<List<ConfigurationBase>>(1024);

            EventBAPairSafety initialstep = EventBAPairSafety.GetInitialPairs(BA,InitialStep);
            working.Enqueue(initialstep);

            List<ConfigurationBase> path = new List<ConfigurationBase>();
            path.Add(InitialStep);
            paths.Enqueue(path);
            Visited.Add(initialstep.GetCompressedState());
            
            do
            {
                if (CancelRequested)
                {
                    VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                EventBAPairSafety current = working.Dequeue();
                List<ConfigurationBase> currentPath = paths.Dequeue();
            
                if (current.States.Count == 0)
                {
                    VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                    VerificationOutput.NoOfStates = Visited.Count;
                    VerificationOutput.CounterExampleTrace = currentPath;
                    return;
                }

                ConfigurationBase[] steps = current.configuration.MakeOneMove().ToArray();
                VerificationOutput.Transitions += steps.Length;
                EventBAPairSafety[] products = current.Next(BA, steps);
                foreach (EventBAPairSafety step in products)
                {
                    string stepID = step.GetCompressedState();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Enqueue(step);

                        List<ConfigurationBase> newPath = new List<ConfigurationBase>(currentPath);
                        newPath.Add(step.configuration);
                        paths.Enqueue(newPath);
                    }
                }
               
            } while (working.Count > 0);

            VerificationOutput.NoOfStates = Visited.Count;
            VerificationOutput.VerificationResult = VerificationResultType.VALID;
        }

        public void BFSHeuristicVerification(BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph, Dictionary<ConfigurationBase, int> optimizeHeuristicTable)
        {
            //Dictionary<string, bool> Visited = new Dictionary<string, bool>();
            StringHashTable Visited = new StringHashTable(Ultility.Ultility.MC_INITIAL_SIZE);
            Queue<EventBAPairSafety> working = new Queue<EventBAPairSafety>();
            Queue<List<ConfigurationBase>> paths = new Queue<List<ConfigurationBase>>(1024);

            EventBAPairSafety initialstep = EventBAPairSafety.GetInitialPairs(BA, InitialStep);
            working.Enqueue(initialstep);

            List<ConfigurationBase> path = new List<ConfigurationBase>();
            path.Add(InitialStep);
            paths.Enqueue(path);
            Visited.Add(initialstep.GetCompressedState());

            do
            {
                if (CancelRequested)
                {
                    VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                EventBAPairSafety current = working.Dequeue();
                List<ConfigurationBase> currentPath = paths.Dequeue();

                if (current.States.Count == 0)
                {
                    VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                    VerificationOutput.NoOfStates = Visited.Count;
                    VerificationOutput.CounterExampleTrace = currentPath;
                    return;
                }

                // Need to fix here
                //ConfigurationBase[] steps = current.configuration.MakeOneMove().ToArray();

                List<ConfigurationBase> totalList = this.findNextStep(current.configuration, completeGraph);
                ConfigurationBase[] steps = totalList.ToArray();

                VerificationOutput.Transitions += steps.Length;
                EventBAPairSafety[] products = current.Next(BA, steps);
                foreach (EventBAPairSafety step in products)
                {
                    string stepID = step.GetCompressedState();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Enqueue(step);

                        List<ConfigurationBase> newPath = new List<ConfigurationBase>(currentPath);
                        newPath.Add(step.configuration);
                        paths.Enqueue(newPath);
                    }
                }

            } while (working.Count > 0);

            VerificationOutput.NoOfStates = Visited.Count;
            VerificationOutput.VerificationResult = VerificationResultType.VALID;
        }

        private List<ConfigurationBase> retriveVertex(BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            List<ConfigurationBase> list = new List<ConfigurationBase>();
            int i = 0;
            foreach (ConfigurationBase vertex in completeGraph.Vertices)
            {
                i++;
            }

            int k = 0;
            foreach (ConfigurationBase vertex in completeGraph.Vertices)
            {
                if (k == 0)
                {
                    list.Add(vertex);
                }
                else if (k == (i - 1))
                {
                    list.Add(vertex);
                }
                k++;
            }
            return list;
        }

        private List<ConfigurationBase> findNextStep(ConfigurationBase current, BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            List<ConfigurationBase> list = new List<ConfigurationBase>();
            foreach (TaggedEdge<ConfigurationBase, string> edge in completeGraph.Edges)
            {
                if (edge.Source.GetID() == edge.Target.GetID())
                    continue;
                else
                {
                    if (edge.Source.GetID() == current.GetID())
                    {
                        list.Add(edge.Target);
                    }
                }
            }
            return list;
        }

        private Dictionary<ConfigurationBase, List<int>> generateHeuristicTable(BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph, ConfigurationBase congestionNode)
        {
            Dictionary<ConfigurationBase, List<int>> heuristicTable = new Dictionary<ConfigurationBase, List<int>>();
            foreach (ConfigurationBase vertex in completeGraph.Vertices)
            {
                if (vertex.GetID() != congestionNode.GetID())
                {
                    List<int> tmpList = this.caculateDistanceList(vertex, congestionNode, completeGraph);
                    heuristicTable.Add(vertex, tmpList);
                }
            }
            return heuristicTable;
        }

        private Dictionary<ConfigurationBase, int> optimizeHeuristicTable(Dictionary<ConfigurationBase, List<int>> heuristicTable)
        {
            Dictionary<ConfigurationBase, int> optimizeHeuristicTable = new Dictionary<ConfigurationBase, int>();

            foreach (KeyValuePair<ConfigurationBase, List<int>> heurtisticLine in heuristicTable)
            {
                List<int> tmpList = heurtisticLine.Value;
                int MIN = 100000;
                if (tmpList.Count > 0)
                {
                    MIN = tmpList[0];
                }
                foreach (int value in tmpList)
                {
                    if (value < MIN)
                    {
                        MIN = value;
                    }
                }
                optimizeHeuristicTable.Add(heurtisticLine.Key, MIN);
            }
            return optimizeHeuristicTable;
        }

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
                    if ((!checkNodeExistInList(vertex, current)) && (isHaveEdge(u, vertex, completeGraph)))
                    {
                        List<ConfigurationBase> tempList = new List<ConfigurationBase>();
                        for (int i = 0; i < current.Count; i++)
                        {
                            tempList.Add(current[i]);
                        }
                        tempList.Add(vertex);
                        working.Enqueue(tempList);
                    }
                }
            } while (working.Count > 0);

            List<int> distanceList = new List<int>();
            foreach (List<ConfigurationBase> path in paths)
            {
                int tmpInt = path.Count - 1;
                distanceList.Add(tmpInt);
            }
            return distanceList;
        }

        private IEnumerable<ConfigurationBase> evaluationNextStep(List<ConfigurationBase> allNextStep, Dictionary<ConfigurationBase, int> optimizeHeuristicTable)
        {
            List<ConfigurationBase> nextSteps = new List<ConfigurationBase>();

            int MIN = 100000;

            // Set initial MIN
            if (optimizeHeuristicTable.ContainsKey(allNextStep[0]))
            {
                MIN = optimizeHeuristicTable[allNextStep[0]];
            }

            // Find vertex have smallest path
            foreach (ConfigurationBase nextStep in allNextStep)
            {
                int value = 100000;
                if (optimizeHeuristicTable.ContainsKey(nextStep))
                {
                    value = optimizeHeuristicTable[nextStep];
                }
                if (value < MIN)
                {
                    MIN = value;
                }
            }

            // Add to IENumrable List nextSteps
            foreach (KeyValuePair<ConfigurationBase, int> heuristicLine in optimizeHeuristicTable)
            {
                if (heuristicLine.Value == MIN)
                {
                    nextSteps.Add(heuristicLine.Key);
                    break;
                }
            }
            return nextSteps;
        }

        private bool checkNodeExistInList(ConfigurationBase node, List<ConfigurationBase> nodeList)
        {
            if (nodeList.Count <= 0)
            {
                return false;
            }
            else
            {
                foreach (ConfigurationBase current in nodeList)
                {
                    if (current.GetID() == node.GetID())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool isHaveEdge(ConfigurationBase vertex1, ConfigurationBase vertex2, BidirectionalGraph<ConfigurationBase, TaggedEdge<ConfigurationBase, string>> completeGraph)
        {
            foreach (TaggedEdge<ConfigurationBase, string> edge in completeGraph.Edges)
            {
                if (edge.Source.GetID() == vertex1.GetID())
                {
                    if (edge.Target.GetID() == vertex2.GetID())
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public virtual string GetResultStringSafety()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Constants.VERFICATION_RESULT_STRING);

            if (this.VerificationOutput.VerificationResult == VerificationResultType.VALID)
            {
                sb.AppendLine("The Assertion (" + ToString() + ") is VALID.");
            }
            else
            {
                if (this.VerificationOutput.VerificationResult == VerificationResultType.UNKNOWN)
                {
                    sb.AppendLine("The Assertion (" + ToString() + ") is NEITHER PROVED NOR DISPROVED.");
                }
                else
                {
                    sb.AppendLine("The Assertion (" + ToString() + ") is NOT valid.");
                    sb.AppendLine("A counterexample is presented as follows.");
                    //GetCounterxampleString(sb);
                    VerificationOutput.GetCounterxampleString(sb);
                }
            }

            sb.AppendLine();
            sb.AppendLine("********Verification Setting********");
            sb.AppendLine("Admissible Behavior: " + SelectedBahaviorName);
            if (SelectedEngineName == Constants.ENGINE_DEPTH_FIRST_SEARCH)
            {
                sb.AppendLine("Method: Refinement Based Safety Analysis using DFS - The LTL formula is a safety property!"); 
            }
            else
            {
                sb.AppendLine("Method: Refinement Based Safety Analysis using BFS - The LTL formula is a safety property!");                    
            }            
            sb.AppendLine("System Abstraction: " + MustAbstract);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}