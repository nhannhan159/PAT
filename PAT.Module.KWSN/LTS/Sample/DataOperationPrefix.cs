﻿using System.Collections.Generic;
using PAT.Common.Classes.DataStructure;
using PAT.Common.Classes.Expressions;
using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.Ultility;
using PAT.Common.Classes.ModuleInterface;
using PAT.KWSN.Assertions;

namespace PAT.KWSN.LTS{
    public sealed class DataOperationPrefix : Process
    {
        public Event Event;
        public Process Process;
        public Expression AssignmentExpr;
        public string[] LocalVariables;

        public DataOperationPrefix(Event e, Expression assignment, Process process, string[] localvar) 
        {
            Event = e;
            AssignmentExpr = assignment;
            Process = process;
            LocalVariables = localvar;

            ProcessID = DataStore.DataManager.InitializeProcessID(Event.GetID() + "{" + AssignmentExpr.ExpressionID + "}" + Constants.EVENTPREFIX + Process.ProcessID);              
        }

        public override void MoveOneStep(Valuation GlobalEnv, List<Configuration> list)
        {
            System.Diagnostics.Debug.Assert(list.Count == 0);

            string name = Event.GetEventName(GlobalEnv);

            Valuation newGlobleEnv = GlobalEnv.GetVariableClone();
       
            EvaluatorDenotational.Evaluate(AssignmentExpr, newGlobleEnv);

            if (LocalVariables != null)
            {
                Valuation tempEnv = GlobalEnv.GetVariableClone();
                for (int i = 0; i < tempEnv.Variables._entries.Length; i++)
                {
                    StringDictionaryEntryWithKey<ExpressionValue> pair = tempEnv.Variables._entries[i];
                    if (pair != null)
                    {
                        pair.Value = newGlobleEnv.Variables[pair.Key];
                    }
                }

                newGlobleEnv = tempEnv;
            }

            string ID = Event.GetEventID(GlobalEnv);

            if (ID != name)
            {
                list.Add(new Configuration(Process, ID, name, newGlobleEnv, true));
            }
            else
            {
                list.Add(new Configuration(Process, ID, null, newGlobleEnv, true));
            }
            //return list;
        }
    
        public override string ToString()
        {
            if (Event.ToString() == Constants.TAU)
            {
                return "{" + AssignmentExpr + "}->" + Process;                
            }

            return Event + "{" + AssignmentExpr + "}->" + Process;
        }

        public override HashSet<string> GetAlphabets(Dictionary<string, string> visitedDefinitionRefs)
        {
            if(Specification.CollectDataOperationEvent == true && Event.ToString() != Constants.TAU)
            {
                HashSet<string> set = Process.GetAlphabets(visitedDefinitionRefs);
                set.Add(Event.BaseName);

                return set;

            }
            else
            {
                return Process.GetAlphabets(visitedDefinitionRefs);    
            }            
        }

        public override List<string> GetGlobalVariables()
        {
            List<string> Variables = Process.GetGlobalVariables();
            Common.Classes.Ultility.Ultility.AddList(Variables, AssignmentExpr.GetVars());

            if (Event.ExpressionList != null)
            {
                foreach (Expression expression in Event.ExpressionList)
                {
                    Common.Classes.Ultility.Ultility.AddList(Variables, expression.GetVars());
                }
            }

            return Variables;
        }

        public override List<string> GetChannels()
        {
            return Process.GetChannels();
        }

        public override Process ClearConstant(Dictionary<string, Expression> constMapping)
        {
            Expression newAssign = AssignmentExpr.ClearConstant(constMapping);
            return new DataOperationPrefix(Event.ClearConstant(constMapping), newAssign, Process.ClearConstant(constMapping), LocalVariables);
        }

        public override bool MustBeAbstracted()
        {
            return Process.MustBeAbstracted();
        }

        public override bool IsBDDEncodable()
        {
            return Process.IsBDDEncodable();
        }
    }
}