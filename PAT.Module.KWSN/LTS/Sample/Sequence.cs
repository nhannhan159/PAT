﻿using System.Collections.Generic;
using PAT.Common.Classes.Expressions;
using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.Ultility;
using PAT.Common.Classes.ModuleInterface;
using PAT.KWSN.Assertions;


namespace PAT.KWSN.LTS{
    public sealed class Sequence : Process
    {
        public Process FirstProcess;
        public Process SecondProcess;

        public Sequence(Process firstProcess, Process secondProcess)
        {
            FirstProcess = firstProcess;
            SecondProcess = secondProcess;

            if (FirstProcess is Skip || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                ProcessID = SecondProcess.ProcessID;
            }
            else if (FirstProcess is Stop || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Stop))
            {
                ProcessID = Constants.STOP;
            }
            else
            {
                ProcessID = DataStore.DataManager.InitializeProcessID(Constants.SEQUENTIAL + FirstProcess.ProcessID + Constants.SEPARATOR + SecondProcess.ProcessID);
            }
        }

        public override void MoveOneStep(Valuation GlobalEnv, List<Configuration> list)
        {
            System.Diagnostics.Debug.Assert(list.Count == 0);

            if (FirstProcess is Skip ||
                (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                SecondProcess.MoveOneStep(GlobalEnv, list);
                return;
            }

            FirstProcess.MoveOneStep(GlobalEnv, list);
            for (int i = 0; i < list.Count; i++)
            {
                Configuration step = list[i];
                if (step.Event == Constants.TERMINATION)
                {
                    step.Event = Constants.TAU;
                    step.Process = SecondProcess;
                }
                else
                {
                    Sequence p = new Sequence(step.Process, this.SecondProcess);
                    step.Process = p;
                }
                list[i] = step;
            }
        }

        public override void SyncOutput(Valuation GlobalEnv, List<ConfigurationWithChannelData> list)
        {
            if (FirstProcess is Skip || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                SecondProcess.SyncOutput(GlobalEnv, list);
                return;
            }

            FirstProcess.SyncOutput(GlobalEnv, list);

            for (int i = 0; i < list.Count; i++)
            {
                Configuration step = list[i];
                step.Process = new Sequence(step.Process, SecondProcess);
            }

            //return list;
        }

        public override void SyncInput(ConfigurationWithChannelData eStep, List<Configuration> list)
        {
            if (FirstProcess is Skip || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                SecondProcess.SyncInput(eStep, list);
                return;
            }

            FirstProcess.SyncInput(eStep, list);
            
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Process = new Sequence(list[i].Process, SecondProcess);
            }

            //return list;
        }

        public override List<string> GetGlobalVariables()
        {
            List<string> Variables = FirstProcess.GetGlobalVariables();
            Common.Classes.Ultility.Ultility.AddList<string>(Variables, SecondProcess.GetGlobalVariables());

            return Variables;
        }

        public override List<string> GetChannels()
        {
            List<string> channels = FirstProcess.GetChannels();
            Common.Classes.Ultility.Ultility.AddList<string>(channels, SecondProcess.GetChannels());
            return channels;
        }

        public override string ToString()
        {
            //return "(" + FirstProcess.ToString() + ";" + SecondProcess.ToString() + ")";
            return FirstProcess.ToString() + ";\r\n" + SecondProcess.ToString();
        }

        public override HashSet<string> GetAlphabets(Dictionary<string, string> visitedDefinitionRefs)
        {
            if (FirstProcess is Skip || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                return SecondProcess.GetAlphabets(visitedDefinitionRefs);
            }

            HashSet<string> list = SecondProcess.GetAlphabets(visitedDefinitionRefs);
            list.UnionWith(FirstProcess.GetAlphabets(visitedDefinitionRefs));
            return list;
        }

        public override Process ClearConstant(Dictionary<string, Expression> constMapping)
        {
            if (FirstProcess is Skip || (FirstProcess is AtomicProcess && (FirstProcess as AtomicProcess).Process is Skip))
            {
                return SecondProcess.ClearConstant(constMapping);
            }
            
            return new Sequence(FirstProcess.ClearConstant(constMapping), SecondProcess.ClearConstant(constMapping));
        }

        public override bool MustBeAbstracted()
        {
            return FirstProcess.MustBeAbstracted() || SecondProcess.MustBeAbstracted();
        }

        public override bool IsBDDEncodable()
        {
            return FirstProcess.IsBDDEncodable() && SecondProcess.IsBDDEncodable();
        }
    }
}