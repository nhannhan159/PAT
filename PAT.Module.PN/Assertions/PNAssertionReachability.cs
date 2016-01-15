using System.Collections.Generic;
using System.Linq;
using PAT.Common.Classes.Assertion;
using PAT.Common.Classes.Expressions;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.Ultility;
using PAT.Common.Classes.SemanticModels.LTS.Assertion;
using PAT.PN.LTS;
using PAT.Common.Classes.DataStructure;
using PAT.Common.Classes.Expressions.ExpressionClass;

namespace PAT.PN.Assertions{
    public partial class PNAssertionReachability : AssertionReachability
    {
        private DefinitionRef Process;

        public PNAssertionReachability(DefinitionRef processDef, string reachableState) : base(reachableState)
        {
            Process = processDef;
        }

        public override string StartingProcess
        {
            get
            {
                return Process.ToString();
            }
        }

        public override void Initialize(SpecificationBase spec)
        {
            //initialize the ModelCheckingOptions
            base.Initialize(spec);
            
            Specification Spec = spec as Specification;
            ReachableStateCondition = Spec.DeclarationDatabase[ReachableStateLabel];

            List<string> varList = Process.GetGlobalVariables();
            varList.AddRange(ReachableStateCondition.GetVars());
                                    
            // Valuation GlobalEnv = Spec.SpecValuation.GetVariableChannelClone(varList, Process.GetChannels());
            // editted by Tinh
            Valuation GlobalEnv = Spec.SpecValuation.GetClone();
            
            //Initialize InitialStep
            // editted by Tinh
            InitialStep = new PNConfiguration(Process, Constants.INITIAL_EVENT, null, GlobalEnv, false, spec);
            MustAbstract = Process.MustBeAbstracted();
        }

        public int HVal(Valuation val, Expression exp)
        {
            //throw new System.Exception();
            PrimitiveApplication pa = exp as PrimitiveApplication;
            foreach (StringDictionaryEntryWithKey<ExpressionValue> expVal in val.Variables._entries)
            {
                if (expVal != null && pa.Argument1.ExpressionID.Equals(expVal.Key))
                {
                    return (expVal.Value as IntConstant).Value;
                }
            }
            return -1;
        }

        override public void DFSVerification()
        {
            //throw new System.Exception();
            StringHashTable Visited = new StringHashTable(Ultility.MC_INITIAL_SIZE);

            Expression conditionExpression = ReachableStateCondition;

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
                    VerificationOutput.NoOfStates = Visited.Count;
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
                        VerificationOutput.CounterExampleTrace.RemoveAt(lastIndex);
                    }
                }

                VerificationOutput.CounterExampleTrace.Add(current);

                if (current.ImplyCondition(conditionExpression))
                {
                    VerificationOutput.VerificationResult = VerificationResultType.VALID;
                    VerificationOutput.NoOfStates = Visited.Count;
                    return;
                }

                depthList.Add(depth);
                IEnumerable<ConfigurationBase> list = current.MakeOneMove();
                list = list.OrderBy(p => this.HVal(p.GlobalEnv, this.ReachableStateCondition));
                VerificationOutput.Transitions += list.Count();

                //for (int i = list.Length - 1; i >= 0; i--)
                foreach (ConfigurationBase step in list)
                {
                    //ConfigurationBase step = list[i];

                    string stepID = step.GetID();
                    if (!Visited.ContainsKey(stepID))
                    {
                        Visited.Add(stepID);
                        working.Push(step);
                        depthStack.Push(depth + 1);
                    }
                }
            } while (working.Count > 0);

            VerificationOutput.CounterExampleTrace = null;
            VerificationOutput.VerificationResult = VerificationResultType.INVALID;
            VerificationOutput.NoOfStates = Visited.Count;
        }
    }
}