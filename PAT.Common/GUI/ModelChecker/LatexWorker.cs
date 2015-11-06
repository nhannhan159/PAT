using PAT.Common.Classes.ModuleInterface;
using PAT.Common.ModelCommon;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon.WSNCommon;
using PAT.Common.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAT.Common.GUI.ModelChecker
{
    public class LatexWorker
    {
        private const string TAG = "LatexWorker";
        private static string ROOT_LATEX_PATH = Utilities.ROOT_WORKING_PATH + "\\latex";
        public static string TMP_LATEX_PATH = ROOT_LATEX_PATH + "\\tmp";

        private const string NONE_ABSTRACION_MODEL = "\\na";
        private const string SENSOR_ABSTRACION_MODEL = "\\sa";
        private const string CHANNEL_ABSTRACION_MODEL = "\\ca";

        private const string BROADCAST_MODE = "\\bc";
        private const string MULTICASE_MODE = "\\mc";
        private const string UNICAST_MODE = "\\uc";

        private List<LatexResult> mLatexList = null;
        private PNExtendInfo mExtInfo;
        private string mFileName;
        private string mPathTmp;

        public LatexWorker(PNExtendInfo extendInfo, string filename)
        {
            this.mFileName = filename;
            mLatexList = new List<LatexResult>();
            mExtInfo = extendInfo;
            
            // Init folder
            try
            {
                Directory.CreateDirectory(ROOT_LATEX_PATH);
                Directory.CreateDirectory(TMP_LATEX_PATH);
                checkLatex();
            }
            catch (Exception e) { }

        }

        public bool addAssertResult(AssertionBase assertion)
        {
            bool ret = false;
            do
            {
                if (assertion == null)
                    break;

                AssertType type = getAssertType(assertion.ToString());

                // Can not detected assert type
                if (type == AssertType.NONE)
                    break;

                int id = getLatexResultByType(type);
                // Found latex instance at id position
                if (id != -1)
                    mLatexList.RemoveAt(id);

                LatexResult lret = new LatexResult();
                lret.mType = type;
                lret.mMemo = assertion.getMems();
                lret.mTransition = assertion.getTransitions();
                lret.mState = assertion.getStates();
                lret.mTime = assertion.getTimes();
                lret.mRes = convertResultToLatex(type, assertion.getResult());

                mLatexList.Add(lret);
                ret = true;
            } while (false);

            return ret;
        }

        private string convertResultToLatex(AssertType type, string pureResult)
        {
            string ret = null;
            if (type == AssertType.DEADLOCK_FREE)
            {
                if ("VALID".Equals(pureResult)) ret = "\\vl";
                else if ("INVALID".Equals(pureResult)) ret = "\\nv";
                else ret = "\\unk";
            }
            else
            {
                if ("VALID".Equals(pureResult)) ret = "\\nv";
                else if ("INVALID".Equals(pureResult)) ret = "\\vl";
                else ret = "\\unk";
            }

            return ret;
        }

        // 20151028-lqv-unifine code-s
        public void checkLatex()
        {
            //Check the existence of ID folder
            string rootPath = TMP_LATEX_PATH + "\\" + mExtInfo.mID;
            mPathTmp = rootPath + "\\" + mExtInfo.mID + "_" + mFileName.Substring(0, mFileName.Length - 3) + ".tex";

            // Init root path
            if (!Directory.Exists(rootPath)) 
                Directory.CreateDirectory(rootPath);

            // Init file
            if (!File.Exists(mPathTmp))
            {
                FileStream fileStream = new FileStream(mPathTmp, FileMode.Create);
                fileStream.Close();
            }
        }
        // 20151028-lqv-unifine code-e

        public bool exportLatex()
        {
            bool ret = false;
            do
            {
                // Get abstraction level
                string absLevel = mExtInfo.mAbsLevel;
                string pnModel = null;

                if ("11".Equals(absLevel))
                    pnModel = NONE_ABSTRACION_MODEL;
                else if ("10".Equals(absLevel))
                    pnModel = CHANNEL_ABSTRACION_MODEL;
                else if ("01".Equals(absLevel))
                    pnModel = SENSOR_ABSTRACION_MODEL;

                if (pnModel == null)
                {
                    DevLog.e(TAG, "Can not get abstraction level.");
                    break;
                }

                string pnMode = null;
                switch (mExtInfo.mMode)
                {
                    case NetMode.BROADCAST:
                        pnMode = BROADCAST_MODE;
                        break;

                    case NetMode.MULTICAST:
                        pnMode = MULTICASE_MODE;
                        break;

                    case NetMode.UNICAST:
                        pnMode = UNICAST_MODE;
                        break;

                    default:
                        break;
                }

                if (pnMode == null)
                {
                    DevLog.e(TAG, "Can not get mode.");
                    break;
                }

                try
                {
                    //string tmpName = "temp.tex";
                    FileStream fileStream = new FileStream(mPathTmp, FileMode.Create);
                    StreamWriter swriter = new StreamWriter(fileStream);

                    switch (pnModel)
                    {
                        case NONE_ABSTRACION_MODEL:
                            
                            exportNoneAbstraction(swriter, pnMode, pnModel);
                            break;

                        case SENSOR_ABSTRACION_MODEL:
                            
                            exportSensorAbstraction(swriter, pnMode, pnModel);
                            break;

                        case CHANNEL_ABSTRACION_MODEL:
                            
                            exportChannelAbstraction(swriter);
                            break;

                        default:
                            break;
                    }
                    swriter.Close();
                    fileStream.Close();
                    ret = true;
                }
                catch (Exception e)
                {
                    DevLog.e(TAG, e.ToString());
                }

            } while (false);

            return ret;
        }

        private void exportChannelAbstraction(StreamWriter swriter)
        {
            do
            {
                LatexResult ret = getLatexByType(AssertType.DEADLOCK_FREE);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & \\multirow{{2}}{{*}}{{\\ca}} & \\dl  & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & \\multirow{{2}}{{*}}{{\\ca}} & \\dl  & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                ret = getLatexByType(AssertType.CONGESTION_SENSOR);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & & \\sen & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & & \\sen  & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);
                swriter.Write(String.Format("\\cline{{5-10}}\n"));
            } while (false);
        }

        private void exportSensorAbstraction(StreamWriter swriter, string mode, string model)
        {
            do
            {
                LatexResult ret = getLatexByType(AssertType.DEADLOCK_FREE);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & \\multirow{{2}}{{*}}{{\\sa}} & \\dl  & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & \\multirow{{2}}{{*}}{{\\sa}} & \\dl  & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                ret = getLatexByType(AssertType.CONGESTION_CHANNEL);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & & \\chan & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & & \\chan & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                swriter.Write(String.Format("\\hline\r\n\n"));
            } while (false);
        }

        private void exportNoneAbstraction(StreamWriter swriter, string mode, string model)
        {
            do
            {
                swriter.Write(String.Format("% " + mExtInfo.mNumberSensor + " nodes - " + mExtInfo.mNumberPacket + " Packet - " + mode + "\n"));
                swriter.Write(String.Format("\\multirow{{10}}{{*}}{{" + mExtInfo.mNumberSensor + "}} & \\multirow{{10}}{{*}}{{" + mExtInfo.mNumberPacket + "}} & \\multirow{{10}}{{*}}{{" + mExtInfo.mSensorMaxBufferSize + "}} &\\multirow{{10}}{{*}}{{" + mode + "}} &\\multirow{{3}}{{*}}{{" + model + "}} & \\dl & "));

                // Write each assert line to file
                LatexResult ret = getLatexByType(AssertType.DEADLOCK_FREE);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format(" \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                ret = getLatexByType(AssertType.CONGESTION_CHANNEL);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & & \\chan & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & & \\chan & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                ret = getLatexByType(AssertType.CONGESTION_SENSOR);
                do
                {
                    if (ret == null)
                        break;

                    if (ret.mRes != "\\vl" && ret.mRes != "\\nv")
                    {
                        swriter.Write(String.Format("& & & & & \\sen & \\multicolumn{{4}}{{|c|}}{{\\cellcolor{{blue!20}}Time out at {0:0.00}}} \\\\\n", ret.mTime / 1.0d));
                        break;
                    }

                    swriter.Write(String.Format("& & & & & \\sen  & " + "{0:0.00}" + " & " + ret.mTransition + " & " + ret.mState + " & " + ret.mRes + " \\\\\n", ret.mMemo / 1024.0f));
                } while (false);

                swriter.Write(String.Format("\\cline{{5-10}}\n"));
            } while (false);
        }

        private LatexResult getLatexByType(AssertType assertType)
        {
            LatexResult ret = null;
            foreach (LatexResult lr in mLatexList)
            {
                if (lr != null && lr.mType == assertType)
                {
                    ret = lr;
                    break;
                }
            }
            return ret;
        }

        private AssertType getAssertType(string strAssert)
        {
            AssertType type = AssertType.NONE;
            do
            {
                if (strAssert.Contains("Congestion") && !strAssert.Contains("_"))
                {
                    type = AssertType.CONGESTION_SENSOR;
                    break;
                }

                if (strAssert.Contains("Congestion") && strAssert.Contains("_"))
                {
                    type = AssertType.CONGESTION_CHANNEL;
                    break;
                }

                if (strAssert.Contains("deadlockfree"))
                {
                    type = AssertType.DEADLOCK_FREE;
                    break;
                }
            } while (false);

            return type;
        }

        /// <summary>
        /// Get latex result instance by assert type
        /// </summary>
        /// <returns>index in list, -1 if not found</returns>
        private int getLatexResultByType(AssertType type)
        {
            int index = -1;
            do
            {
                if (mLatexList.Count == 0)
                    break;

                for (int i = 0; i < mLatexList.Count; ++i)
                {
                    if (mLatexList.ElementAt(i).mType == type)
                    {
                        index = i;
                        break;
                    }
                }
            } while (false);

            return index;
        }
    }
}
