﻿using System;
using System.Collections.Generic;
using System.Collections;
//using System.Reactive.Concurrency;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
using PAT.Common.Classes.BA;
using PAT.Common.Classes.DataStructure;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.Ultility;

namespace PAT.Common.Classes.SemanticModels.LTS.Assertion
{
    public partial class AssertionLTL
    {
        /// <summary>
        /// Initialize multi threads to run Tarjan algorithms
        /// </summary>
        public void MultiCoreLocalFair()
        {
            //inititialize global variables
            finalTrace = null;
            finalLoopIndex = -1;
            isGlobalStop = false;
            globalCounterExampleLocker = new object();

            int threadNumber = CORES;
            globalFoundSCCs = new ConcurrentDictionary<string, bool>(threadNumber, 5000);

            //initialize visited times
            allVisitedStates = new ConcurrentDictionary<string, int>(threadNumber, 5000);

            //initialize threads
            Thread[] workerThreads = new Thread[threadNumber];
            for (int i = 0; i < threadNumber; i++)
            {
                int tmp = i;
                workerThreads[i] = new Thread(LocalFairTarjan);
                workerThreads[i].Start(tmp);
            }

            //wait for all threads complete
            for (int i = 0; i < threadNumber; i++)
            {
                workerThreads[i].Join();
            }

            //get final result
            if (finalTrace == null)
            {
                VerificationOutput.VerificationResult = VerificationResultType.VALID;
            }
            else
            {
                VerificationOutput.VerificationResult = VerificationResultType.INVALID;
                VerificationOutput.CounterExampleTrace = finalTrace;
                VerificationOutput.LoopIndex = finalLoopIndex;
            }

            //write visited times to file
            writeOverlapToFile(allVisitedStates);
        }

        /// <summary>
        /// Local Tarjan in each thread to find SCC
        /// </summary>
        /// <param name="o"></param>
        public void LocalFairTarjan(object o)
        {
            //order of this thread
            int order = (int)o;
            Random rand = new Random(order);

            //on-the-fly data
            Stack<LocalPair> localCallStack = new Stack<LocalPair>(5000);
            Stack<LocalPair> localCurrentStack = new Stack<LocalPair>(1024);
            Dictionary<string, int[]> localDFSNumber = new Dictionary<string, int[]>(5000);
            int localNumber = 0;
            Dictionary<string, List<LocalPair>> localExpendedNodes = new Dictionary<string, List<LocalPair>>(5000);

            //initial states
            List<LocalPair> initialStates = LocalPair.GetInitialPairsLocal(BA, InitialStep);

            //check valid result
            if (initialStates.Count == 0 || !BA.HasAcceptState)
            {
                return;
            }

            //push local initial states to local call stack
            int[] localPerm = Permutation(initialStates.Count, rand);
            for (int i = 0; i < initialStates.Count; i++)
            {
                LocalPair tmp = initialStates[localPerm[i]];
                localCallStack.Push(tmp);
            }

            //start loop
            while (localCallStack.Count > 0)
            {
                //cancel if take long time
                if (CancelRequested || isGlobalStop)
                {
                    return;
                }

                //get top of call stack
                LocalPair pair = localCallStack.Peek();
                ConfigurationBase LTSState = pair.configuration;
                string BAState = pair.state;
                string v = pair.GetCompressedState();

                //get successors
                List<LocalPair> successors = null;
                if (localExpendedNodes.ContainsKey(v))
                {
                    successors = localExpendedNodes[v];
                }
                else
                {
                    IEnumerable<ConfigurationBase> nextLTSStates = LTSState.MakeOneMove();
                    pair.SetEnabled(nextLTSStates, FairnessType);
                    successors = LocalPair.NextLocal(BA, nextLTSStates, BAState);
                    localExpendedNodes.Add(v, successors);
                }

                //if v is not number yet
                if (!localDFSNumber.ContainsKey(v))
                {
                    //number v
                    int[] vData = new int[] { localNumber, localNumber };
                    localDFSNumber.Add(v, vData);
                    localNumber = localNumber + 1;

                    //push to currentStack
                    localCurrentStack.Push(pair);

                    //update lowlink for already numbered successors
                    for (int i = successors.Count - 1; i >= 0; i--)
                    {
                        LocalPair succ = successors[i];
                        string w = succ.GetCompressedState();

                        if (localDFSNumber.ContainsKey(w))
                        {
                            int[] wData = localDFSNumber[w];
                            //if w is in current stack
                            if (wData[0] >= 0)
                            {
                                vData[1] = Math.Min(vData[1], wData[0]);
                            }
                        }
                    }
                }

                //------------------------------------------------------------------------
                //filter successors
                List<int> unvisitedIndexs = new List<int>(successors.Count);//not numbered and not global found
                for (int i = successors.Count - 1; i >= 0; i--)
                {
                    LocalPair succ = successors[i];
                    string w = succ.GetCompressedState();

                    //if w is not cyan and not global red
                    if (!localDFSNumber.ContainsKey(w) && !globalFoundSCCs.ContainsKey(w))
                    {
                        unvisitedIndexs.Add(i);
                    }
                }
                //------------------------------------------------------------------------

                //get random unvisited successors
                if (unvisitedIndexs.Count > 0)
                {
                    bool isFresh = false;
                    List<int> unFreshIndexs = new List<int>();
                    while (unvisitedIndexs.Count > 0)
                    {
                        int r = rand.Next(unvisitedIndexs.Count);
                        LocalPair succ = successors[unvisitedIndexs[r]];
                        string w = succ.GetCompressedState();

                        //if w is fresh successor
                        if (!allVisitedStates.ContainsKey(w))
                        {
                            localCallStack.Push(succ);

                            allVisitedStates.GetOrAdd(w, 0);
                            allVisitedStates[w]++;

                            isFresh = true;
                            break;
                        }
                        else
                        {
                            unFreshIndexs.Add(unvisitedIndexs[r]);
                            unvisitedIndexs.RemoveAt(r);
                        }
                    }
                    if (!isFresh)
                    {
                        int r = rand.Next(unFreshIndexs.Count);
                        LocalPair succ = successors[unFreshIndexs[r]];
                        string w = succ.GetCompressedState();
                        localCallStack.Push(succ);

                        allVisitedStates.GetOrAdd(w, 0);
                        allVisitedStates[w]++;
                    }
                }
                else
                {
                    int[] vData = localDFSNumber[v];
                    //if v is root
                    if (vData[0] == vData[1])
                    {
                        // check selfLoop
                        bool selfLoop = false;
                        foreach (LocalPair succ in successors)
                        {
                            string w = succ.GetCompressedState();
                            if (v.Equals(w))
                            {
                                selfLoop = true;
                                break;
                            }
                        }

                        //remove states from current stack and goal stack 
                        //updata global
                        bool isBuchiFair = false;
                        Dictionary<string, LocalPair> newSCC = new Dictionary<string, LocalPair>(1024);
                        List<ConfigurationBase> cycle = new List<ConfigurationBase>(1024);
                        LocalPair tmp = null;
                        string tmpID = null;
                        do
                        {
                            //get states in SCC
                            tmp = localCurrentStack.Pop();
                            if (!isBuchiFair && tmp.state.EndsWith(Constants.ACCEPT_STATE))
                            {
                                isBuchiFair = true;
                            }
                            tmpID = tmp.GetCompressedState();
                            newSCC.Add(tmpID, tmp);
                            cycle.Insert(0, tmp.configuration);

                            //local
                            localDFSNumber[tmpID][0] = SCC_FOUND;

                            //update global
                            globalFoundSCCs.GetOrAdd(tmpID, true);
                        } while (tmp != pair);

                        //local check fairness
                        if (isBuchiFair && (selfLoop || newSCC.Count > 1 || LTSState.IsDeadLock))
                        {
                            //get outgoing transition table
                            Dictionary<string, List<string>> outgoingTransitionTable = new Dictionary<string, List<string>>(newSCC.Count);
                            foreach (KeyValuePair<string, LocalPair> kv in newSCC)
                            {
                                string s = kv.Key;
                                List<LocalPair> nextStates = localExpendedNodes[s];
                                List<string> outgoing = new List<string>(nextStates.Count);
                                foreach (LocalPair next in nextStates)
                                {
                                    string n = next.GetCompressedState();
                                    outgoing.Add(n);
                                }
                                outgoingTransitionTable.Add(s, outgoing);
                            }
                            
                            Dictionary<string, LocalPair> fairSCC = IsFair(newSCC, outgoingTransitionTable);

                            if (fairSCC != null)
                            {
                                //REPORT COUNTEREXAMPLE
                                GetLocalFairCounterExample(localCallStack, cycle, LTSState.IsDeadLock);
                                return;
                            }
                        }

                        //pop call stack
                        localCallStack.Pop();
                    }
                    else
                    {
                        //pop call stack and update lowlink of top
                        LocalPair pop = localCallStack.Pop();
                        LocalPair top = localCallStack.Peek();
                        string popID = pop.GetCompressedState();
                        string topID = top.GetCompressedState();
                        int[] popData = localDFSNumber[popID];
                        int[] topData = localDFSNumber[topID];
                        topData[1] = Math.Min(topData[1], popData[1]);
                    }
                }
            }
        }

        /// <summary>
        /// Get local fair counter example
        /// </summary>
        /// <param name="newSCC"></param>
        /// <param name="localCallStack"></param>
        /// <param name="isDeadLock"></param>
        public void GetLocalFairCounterExample(Stack<LocalPair> localCallStack, List<ConfigurationBase> cycle, bool isDeadLock)
        {
            localCallStack.Pop();
            int traceLen = localCallStack.Count;
            List<ConfigurationBase> trace = new List<ConfigurationBase>(traceLen);
            while (localCallStack.Count > 0)
            {
                LocalPair tmp = localCallStack.Pop();
                trace.Insert(0, tmp.configuration);

                if (tmp.configuration.Event == Constants.INITIAL_EVENT)
                {
                    break;
                }
            }

            lock (globalCounterExampleLocker)
            {
                if (isGlobalStop)
                {
                    return;
                }

                if (!isDeadLock)
                {
                    finalLoopIndex = trace.Count;
                }
                trace.AddRange(cycle);
                finalTrace = trace;
                isGlobalStop = true;
            }
        }
    }
}