using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PAT.Common;
using PAT.Common.Utility;
using Ultility = PAT.Common.Classes.Ultility.Ultility;

namespace PAT.GUI.Utility
{
    internal class GUIUtility
    {
        public static bool CHECK_UPDATE_AT_START = true;
        public static bool LINK_CSP = false;
        public static bool AUTO_SAVE = true;
        public static string GUI_LANGUAGE = "en";
        public static string DEFAULT_MODELING_LANGUAGE = "";

        // Module define
        public static string PN_MODEL = "PN Model";
        public static string KWSN_MODEL = "KWSN Model";

        public static void ReadSettingValue()
        {
            PAT.Common.Utility.ConfigSettings.Settings = new ConfigSettings();
            string file = Path.Combine(Common.Utility.Utilities.APPLICATION_PATH, Common.Utility.Utilities.APPLICATION_NAME + ".ini");

            //if file exist, then no problem, simply s
            if (File.Exists(file))
                ConfigSettings.Settings.Initialize(file);
            else
            {
                //create the file 
                ConfigSettings.Settings.Initialize(file);

                //if cannot save, then user may not have the 
                if (!ConfigSettings.Settings.Store())
                {
                    file = Path.Combine(Common.Utility.Utilities.UserDocumentFolderPath, Common.Utility.Utilities.APPLICATION_NAME + ".ini");
                    ConfigSettings.Settings.Initialize(file);
                }
            }

            ////update
            CHECK_UPDATE_AT_START = ConfigSettings.Settings.GetOption("Setting", "CHECK_UPDATE_AT_START", CHECK_UPDATE_AT_START.ToString()) == "True";

            ////update
            AUTO_SAVE = ConfigSettings.Settings.GetOption("Setting", "AUTO_SAVE", AUTO_SAVE.ToString()) == "True";

            ////update
            Common.Utility.Utilities.SEND_EMAIL_USE_SSL = ConfigSettings.Settings.GetOption("Setting", "SEND_EMAIL_USE_SSL", Common.Utility.Utilities.SEND_EMAIL_USE_SSL.ToString()) == "True";

            ////gui language
            GUI_LANGUAGE = ConfigSettings.Settings.GetOption("Setting", "GUI_LANGUAGE", GUI_LANGUAGE);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(GUI_LANGUAGE);

            ////modeling language
            DEFAULT_MODELING_LANGUAGE = ConfigSettings.Settings.GetOption("Setting", "DEFAULT_MODELING_LANGUAGE", DEFAULT_MODELING_LANGUAGE);

            ////Simulation
            Ultility.SIMULATION_BOUND = ConfigSettings.Settings.GetOption("Setting", "SIMULATION_BOUND", Ultility.SIMULATION_BOUND);

            ////Model Checking
            Ultility.MC_INITIAL_SIZE = ConfigSettings.Settings.GetOption("Setting", "MC_INITIAL_SIZE", Ultility.MC_INITIAL_SIZE);

            ////Model Checking
            Ultility.PERFORM_DETERMINIZATION = ConfigSettings.Settings.GetOption("Setting", "PERFORM_DETERMINIZATION", Ultility.PERFORM_DETERMINIZATION.ToString()) == "True";

            Ultility.ENABLE_PARSING_OUTPUT = ConfigSettings.Settings.GetOption("Setting", "ENABLE_PARSING_OUTPUT", Ultility.ENABLE_PARSING_OUTPUT.ToString()) == "True";

            ////link CSP
            LINK_CSP = ConfigSettings.Settings.GetOption("CSP Module", "LINK_CSP", LINK_CSP.ToString()) == "True";

            Ultility.ABSTRACT_CUT_NUMBER = ConfigSettings.Settings.GetOption("CSP Module", "ABSTRACT_CUT_NUMBER", Ultility.ABSTRACT_CUT_NUMBER);

            Ultility.ABSTRACT_CUT_NUMBER_BOUND = ConfigSettings.Settings.GetOption("CSP Module", "ABSTRACT_CUT_NUMBER_BOUND", Ultility.ABSTRACT_CUT_NUMBER_BOUND);
        }

        public static void SaveSettingValue()
        {
            ////update
            ConfigSettings.Settings.SetOption("Setting", "CHECK_UPDATE_AT_START", CHECK_UPDATE_AT_START.ToString());

            ////setup
            ConfigSettings.Settings.SetOption("Setting", "AUTO_SAVE", AUTO_SAVE.ToString());

            ////setup
            ConfigSettings.Settings.SetOption("Setting", "SEND_EMAIL_USE_SSL", Common.Utility.Utilities.SEND_EMAIL_USE_SSL.ToString());

            ////gui language
            ConfigSettings.Settings.SetOption("Setting", "GUI_LANGUAGE", GUI_LANGUAGE);

            ////modeling language
            ConfigSettings.Settings.SetOption("Setting", "DEFAULT_MODELING_LANGUAGE", DEFAULT_MODELING_LANGUAGE);

            ////Simulation
            ConfigSettings.Settings.SetOption("Setting", "SIMULATION_BOUND", Ultility.SIMULATION_BOUND);

            ////Model Checking
            ConfigSettings.Settings.SetOption("Setting", "MC_INITIAL_SIZE", Ultility.MC_INITIAL_SIZE);

            ConfigSettings.Settings.SetOption("Setting", "PERFORM_DETERMINIZATION", Ultility.PERFORM_DETERMINIZATION.ToString());

            ConfigSettings.Settings.SetOption("Setting", "ENABLE_PARSING_OUTPUT", Ultility.ENABLE_PARSING_OUTPUT.ToString());

            ////link CSP
            ConfigSettings.Settings.SetOption("CSP Module", "LINK_CSP", LINK_CSP.ToString());

            ConfigSettings.Settings.SetOption("CSP Module", "ABSTRACT_CUT_NUMBER", Ultility.ABSTRACT_CUT_NUMBER.ToString());

            ConfigSettings.Settings.SetOption("CSP Module", "ABSTRACT_CUT_NUMBER_BOUND", Ultility.ABSTRACT_CUT_NUMBER_BOUND.ToString());

            foreach (KeyValuePair<string, ModuleFacadeBase> pair in PAT.Common.Utility.Utilities.ModuleDictionary)
                pair.Value.WriteConfiguration();

            ConfigSettings.Settings.Store();
        }

    }
}