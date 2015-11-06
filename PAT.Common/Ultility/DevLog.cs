using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PAT.Common.Utility
{
    public static class DevLog
    {
        private static string LOG_FOLDER = "logs";
        private static string mLogFile;

        public static void setup(string logName) 
        { 
            mLogFile = "logs.txt";
            if (String.IsNullOrEmpty(logName))
                mLogFile = logName;

            mLogFile = LOG_FOLDER + "\\" + mLogFile;
            Utilities.CreateFolder(LOG_FOLDER);
        }

        public static void d(string TAG, string message)
        {
            string msg = String.Format(
                DateTime.Now.ToLocalTime() + " DEBUG[{0}]: {1}", TAG, message);
#if DEBUG
            Debug.WriteLine(msg);
#else
            Utilities.WriteText(mLogFile, msg, true);
#endif
        }

        public static void e(string TAG, string message)
        {
            string msg = String.Format(
                DateTime.Now.ToLocalTime() + " ERROR[{0}]: {1}", TAG, message);
#if DEBUG
            Debug.WriteLine(msg);
#else
            Utilities.WriteText(mLogFile, msg, true);
#endif
        }
    }
}
