﻿using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using PAT.Common;
using PAT.Common.Classes.Assertion;
using PAT.Common.Classes.DataStructure;
using PAT.Common.Classes.Expressions;
using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.LTS;
using PAT.Common.Classes.ModuleInterface;
using PAT.Common.Classes.SemanticModels.LTS.BDD;
using PAT.Common.Classes.Ultility;
using System.Xml;
using PAT.PN.Assertions;
using PAT.Module.PN.Model;

namespace PAT.PN.LTS
{
    /// <summary>
    /// The specification class a collection of the definitions, properties and alphasets
    /// Each of the user's input correspons to a user's input file
    /// </summary>
    public partial class Specification : SpecificationBase
    {
        public Dictionary<string, Definition> DefinitionDatabase = new Dictionary<string, Definition>(16);
        public Dictionary<string, PetriNet> PNDefinitionDatabase = new Dictionary<string, PetriNet>(16);
        public Dictionary<string, ChannelQueue> ChannelDatabase = new Dictionary<string, ChannelQueue>(8);

        public Valuation SpecValuation = new Valuation();

        //constructor used for the console, testing for sequencial access.
        public Specification(string spec)
            : base(spec, null)
        {
            //SharedData = new SharedDataObjects();
            LockSpecificationData();

            ParseSpec(spec, "");
        }

        public Specification(string spec, string option, string filePath)
            : base(spec, filePath)
        {
            //SharedData = new SharedDataObjects();
            PAT.Common.Classes.Ultility.Ultility.LockSharedData(this);

            try
            {
                ParseSpec(spec, option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PAT.Common.Classes.Ultility.Ultility.UnLockSharedData(this);
            }
        }

        /// <summary>
        /// Parse the specification from string input into objects
        /// </summary>
        /// <param name="spec">string input of the model</param>
        /// <param name="option">option for LTL parsing, usually it is an empty string</param>
        protected virtual void ParseSpec(string spec, string option)
        {
            IsParsing = true;

            PNModel pn = PNModel.LoadLTSFromXML(spec);

            //Read Specification Name
            if (pn.Declaration.StartsWith(@"//@@"))
            {
                int index = pn.Declaration.IndexOf("@@", 4);
                if (index != -1)
                    SpecificationName = pn.Declaration.Substring(4, index - 4);
            }

            string program = pn.ToSpecificationString();

            ////parse the specification
            ////build the grammar tree
            ICharStream input = new ANTLRStringStream(program);
            PNTreeLexer lex = new PNTreeLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lex);
            PNTreeParser parser = new PNTreeParser(tokens);
            parser.Spec = this;
            PNTreeParser.specification_return r = parser.specification();
            if (parser.HiddenVars.Count > 0)
                Valuation.HiddenVars = parser.HiddenVars;

            Common.Utility.ParsingUltility.CheckIsParsingComplete(tokens, r.Tree);
            CommonTreeNodeStream nodes = new CommonTreeNodeStream(r.Tree);
            nodes.TokenStream = tokens;

            // construct the internal representation of the tree via a tree walker
            PNTreeWalker walker = new PNTreeWalker(nodes);
            walker.GlobalVarNames = parser.GlobalVarNames;
            walker.GlobalConstNames = parser.GlobalConstNames;
            walker.GlobalRecordNames = parser.GlobalRecordNames;
            walker.ChannelNames = parser.ChannelNames;
            walker.LTLStatePropertyNames = parser.LTLStatePropertyNames;
            walker.DefinitionNames = parser.DefinitionNames;
            walker.IsParameterized = parser.IsParameterized;
            walker.HasArbitraryProcess = parser.HasArbitraryProcess;

            walker.Spec = this;
            walker.program(option);
            IsParsing = false;
            GlobalConstantDatabase = walker.ConstantDatabase;

            foreach (KeyValuePair<string, Definition> pair in DefinitionDatabase)
            {
                List<string> gVar = pair.Value.GlobalVars;

                int i = 0;
                while (i < gVar.Count)
                {
                    if (SpecValuation.Variables != null && !SpecValuation.Variables.ContainsKey(gVar[i]))
                        gVar.RemoveAt(i);
                    else
                        i++;
                }
            }

            //get the relevant channels; 
            if (ChannelDatabase.Count > 0)
            {
                SyncrhonousChannelNames = new List<string>(0);
                Dictionary<string, ChannelQueue> newChannelDatabase = new Dictionary<string, ChannelQueue>();

                foreach (KeyValuePair<string, ChannelQueue> pair in ChannelDatabase)
                {
                    if (pair.Value.Size == 0)
                        SyncrhonousChannelNames.Add(pair.Key);
                    else
                        newChannelDatabase.Add(pair.Key, pair.Value);
                }

                SpecValuation.Channels = newChannelDatabase;
                HasSyncrhonousChannel = SyncrhonousChannelNames.Count > 0;
            }

            foreach (KeyValuePair<string, AssertionBase> entry in AssertionDatabase)
                entry.Value.Initialize(this);

            CheckVariableRange();
        }

        protected void CheckVariableRange()
        {
            foreach (KeyValuePair<string, Declaration> declaration in DeclaritionTable)
            {
                if (declaration.Value.DeclarationType == DeclarationType.Variable)
                    Valuation.CheckVariableRange(declaration.Key, SpecValuation.Variables[declaration.Key],
                        declaration.Value.DeclarationToken.Line, declaration.Value.DeclarationToken.CharPositionInLine);
            }
        }

        /// <summary>
        /// return the initial configuration of the given startingProcess, this is used by the simulator
        /// </summary>
        /// <param name="startingProcess"></param>
        /// <returns></returns>
        public override ConfigurationBase SimulationInitialization(string startingProcess)
        {
            Definition def = DefinitionDatabase[startingProcess];
            DefinitionRef defref = new DefinitionRef(def.Name, new Expression[0]) { Def = def };

            return new PNConfiguration(defref, Constants.INITIAL_EVENT, null, SpecValuation, false, this);
        }


        /// <summary>
        /// return the string representation of the model. This can be helpful info that will be displayed 
        /// in the output box after checking grammar
        /// </summary>
        /// <returns></returns>
        public override string GetSpecification()
        {
            StringBuilder sb = new StringBuilder();

            if (GlobalConstantDatabase != null && GlobalConstantDatabase.Count > 0)
            {
                sb.AppendLine("//====================Global Constants====================");
                foreach (KeyValuePair<string, Expression> pair in GlobalConstantDatabase)
                {
                    if (pair.Value is ExpressionValue)
                        sb.AppendLine("#define " + pair.Key + " " + pair.Value.ExpressionID + ";");
                    else
                        sb.AppendLine("#define " + pair.Key + " " + pair.Value.ToString() + ";");
                }
            }

            if (SpecValuation.Variables != null)
            {
                sb.AppendLine("//====================Global Variable Definitions====================");
                foreach (StringDictionaryEntryWithKey<ExpressionValue> pair in SpecValuation.Variables._entries)
                {
                    if (pair != null)
                    {
                        string range = "";
                        if (Valuation.VariableLowerBound.ContainsKey(pair.Key))
                            range = ":{" + Valuation.VariableLowerBound.GetContainsKey(pair.Key) + "..";

                        if (Valuation.VariableUpperLowerBound.ContainsKey(pair.Key))
                        {
                            if (range == "")
                                range = ":{.." + Valuation.VariableUpperLowerBound.GetContainsKey(pair.Key) + "}";
                            else
                                range += Valuation.VariableUpperLowerBound.GetContainsKey(pair.Key) + "}";
                        }
                        else
                        {
                            if (range != "")
                                range += "}";
                        }

                        if (Valuation.HiddenVars != null && Valuation.HiddenVars.ContainsKey(pair.Key))
                            sb.AppendLine("hvar " + pair.Key + range + " = " + pair.Value + ";");
                        else
                            sb.AppendLine("var " + pair.Key + range + " = " + pair.Value + ";");
                    }
                }
            }


            if (ChannelDatabase.Count > 0)
            {
                sb.AppendLine("//====================Channel Definitions====================");
                foreach (KeyValuePair<string, ChannelQueue> pair in ChannelDatabase)
                    sb.AppendLine("channel " + pair.Key + " " + pair.Value.Size + ";");
            }

            sb.AppendLine("//====================Process Definitions====================");
            foreach (Definition entry in DefinitionDatabase.Values)
                sb.AppendLine(entry.GetFullDefinition() + "\r\n");

            sb.AppendLine("\r\n");
            foreach (Definition entry in DefinitionDatabase.Values)
            {
                if (entry.AlphabetEvents != null)
                    sb.AppendLine("#alphabet " + entry.Name + " {" + Common.Classes.Ultility.Ultility.PPStringList(entry.AlphabetEvents) + "};");
            }


            if (DeclarationDatabase.Count > 0)
            {
                sb.AppendLine("\r\n//============================Declarations============================");
                foreach (KeyValuePair<string, Expression> entry in DeclarationDatabase)
                    sb.AppendLine("#define " + entry.Key + " " + entry.Value + ";");
            }

            if (AssertionDatabase.Count > 0)
            {
                sb.AppendLine("\r\n//============================Asserstion Definitions============================");
                foreach (KeyValuePair<string, AssertionBase> entry in AssertionDatabase)
                    sb.AppendLine("#assert " + entry.Key + ";");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Clear the information in the specification.
        /// </summary>
        public void ClearDatabase()
        {
            DeclarationDatabase.Clear();
            DefinitionDatabase.Clear();
            AssertionDatabase.Clear();
            ChannelDatabase.Clear();
        }

        /// <summary>
        /// Return all process definition names in the model, whose number of parameter is 0. Used by 
        /// the simulator find out all processes that can be simulated.
        /// </summary>
        /// <returns></returns>
        public override List<string> GetProcessNames()
        {
            List<string> sb = new List<string>();
            foreach (KeyValuePair<string, Definition> pair in DefinitionDatabase)
            {
                if (pair.Value.LocalVariables.Length == 0)
                    sb.Add(pair.Key);
            }

            sb.Sort();
            return sb;
        }


        /// <summary>
        /// Return all process definition names in the model, used by the intellesense
        /// </summary>
        /// <returns></returns>
        public override List<string> GetAllProcessNames()
        {
            List<string> sb = new List<string>(DefinitionDatabase.Count);
            foreach (KeyValuePair<string, Definition> pair in DefinitionDatabase)
                sb.Add(pair.Key);

            sb.Sort();
            return sb;
        }

        /// <summary>
        /// Return all global variable names in the model, used by the intellesense
        /// </summary>
        /// <returns></returns>
        public override List<string> GetGlobalVarNames()
        {
            List<string> sb = new List<string>();
            if (SpecValuation.Variables != null)
            {
                foreach (StringDictionaryEntryWithKey<ExpressionValue> pair in SpecValuation.Variables._entries)
                    if (pair != null)
                        sb.Add(pair.Key);
            }

            sb.Sort();
            return sb;
        }

        /// <summary>
        /// Return all channel names in the model, used by the intellesense
        /// </summary>
        /// <returns></returns>
        public override List<string> GetChannelNames()
        {
            List<string> sb = new List<string>();
            foreach (KeyValuePair<string, ChannelQueue> pair in ChannelDatabase)
                sb.Add(pair.Key);

            sb.Sort();
            return sb;
        }

        /// <summary>
        /// Return the parameters of a process, used by the intellesense
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public override string[] GetParameterNames(string process)
        {
            if (DefinitionDatabase.ContainsKey(process))
                return DefinitionDatabase[process].LocalVariables;

            return null;
        }


        public override void LockSpecificationData()
        {
        }

        /// <summary>
        /// this variable is used as trick to control what to be returned in calling GetAlphabets method of the processes
        /// CollectDataOperationEvent == null: the normal calculation
        /// CollectDataOperationEvent == true: only collect the event name (without componend events parts) of data operations
        /// CollectDataOperationEvent == false: nly collect the event name (without componend events parts) of event prefix
        /// </summary>
        public static bool? CollectDataOperationEvent = null;
    }


    public sealed class SharedDataObjects : SharedDataObjectBase
    {
        public DataStore DataManager;

        public SharedDataObjects()
        {
            DataManager = new DataStore();
        }
    }
}