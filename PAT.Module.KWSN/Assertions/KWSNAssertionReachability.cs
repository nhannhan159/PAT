﻿using System.Collections.Generic;
using PAT.Common.Classes.Assertion;
using PAT.Common.Classes.Expressions;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.Ultility;
using PAT.Common.Classes.SemanticModels.LTS.Assertion;
using PAT.KWSN.LTS;

namespace PAT.KWSN.Assertions
{
    public partial class KWSNAssertionReachability : AssertionReachability
    {
        private DefinitionRef Process;

        public KWSNAssertionReachability(DefinitionRef processDef, string reachableState)
            : base(reachableState)
        {
            Process = processDef;
        }

        public override string StartingProcess
        {
            get { return Process.ToString(); }
        }

        public override void Initialize(SpecificationBase spec)
        {
            //initialize the ModelCheckingOptions
            base.Initialize(spec);

            Specification Spec = spec as Specification;
            ReachableStateCondition = Spec.DeclarationDatabase[ReachableStateLabel];

            List<string> varList = Process.GetGlobalVariables();
            varList.AddRange(ReachableStateCondition.GetVars());

            Valuation GlobalEnv = Spec.SpecValuation.GetVariableChannelClone(varList, Process.GetChannels());

            //Initialize InitialStep
            InitialStep = new Configuration(Process, Constants.INITIAL_EVENT, null, GlobalEnv, false);

            MustAbstract = Process.MustBeAbstracted();
        }

        //todo: override ToString method if your assertion uses different syntax as PAT
        //public override string ToString()
        //{
        //		return "";
        //}        
    }
}