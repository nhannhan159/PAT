using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.ModuleInterface;

namespace PAT.Console
{
    public interface ISpecificationWorker
    {
        /// <summary>
        /// If there is a special checking or user msg, the sub-class of Model Checking Form should override this method.
        /// </summary>
        /// <returns></returns>
        bool moduleSpecificCheckPassed();

        /// <summary>
        /// Update resource before start verify
        /// </summary>
        void updateResStartVerify();

        /// <summary>
        /// Update resource before verify finished
        /// </summary>
        void updateResFinishedVerify();

        /// <summary>
        /// Return result after verify finisheds
        /// </summary>
        /// <param name="type"></param>
        void onResult(VerificationResultType type);

        /// <summary>
        /// Update label for verify button
        /// </summary>
        /// <param name="label"></param>
        void updateVerifyBtnLabel(string label);

        /// <summary>
        /// Trigger to verify button
        /// </summary>
        void performVerifyBtn();

        int getCmbAdmissibleIndex();

        int getCmbVerificationEngineIndex();

        /// <summary>
        /// Should generate counter example
        /// </summary>
        /// <returns></returns>
        bool generateCounterExample();

        /// <summary>
        /// Update event action
        /// </summary>
        /// <param name="action"></param>
        void onAction(string action);

        /// <summary>
        /// Update textbox for result
        /// </summary>
        void RnderingOutputTextbox();

        /// <summary>
        /// Check verify button status
        /// </summary>
        /// <returns></returns>
        bool isVerifyBtnEnabled();

        void eventResult();

        void eventCancel();

    }

    public class SpecificationWorker
    {
        private const string LABEL_STOP = "Stop";
        private const string LABEL_VERIFY = "Verify";

        public SpecificationBase mSpec;
        private ISpecificationWorker mListener;
        public AssertionBase mAssertion;
        private string mCurAssert;
        private Timer mTimer;

        private int mSeconds = 1;
        private decimal mTimeOut = 0; // mins

        public SpecificationWorker(SpecificationBase spec)
        {
            mSpec = spec;

            // Setup timer
            mTimer = new Timer();
            mTimer.Tick += MCTimer_Tick;
            mTimer.Interval = 1000;
        }

        private void MCTimer_Tick(object sender, EventArgs e)
        {
            mSeconds++;
            if (mTimeOut > 0 && mSeconds > mTimeOut * 60)
            {
                mTimer.Stop();
            }
        }

        public void cancelAssertion()
        {
            if (mAssertion != null)
                mAssertion.Cancel();
        }

        public void unlockShareData()
        {
            if (mSpec != null)
                mSpec.UnLockSharedData();
        }

        public void startVerification(string assert, decimal timeout)
        {
            mTimeOut = timeout;
            startVerification(assert);
        }

        public void startVerification(string assert)
        {
            do
            {
                mCurAssert = assert;
                if (!mListener.moduleSpecificCheckPassed())
                    break;

                if (!mSpec.GrabSharedDataLock())
                    break;

                try
                {
                    mSpec.LockSharedData(false);
                    mListener.updateResStartVerify();

                    mAssertion = mSpec.AssertionDatabase[assert];

                    int admissibleIndex = mListener.getCmbAdmissibleIndex();
                    int verificationEngineIndex = mListener.getCmbVerificationEngineIndex();
                    mAssertion.UIInitialize(mForm, admissibleIndex == -1 ? 0 : admissibleIndex,
                        verificationEngineIndex == -1 ? 0 : verificationEngineIndex);

                    mAssertion.VerificationOutput.GenerateCounterExample = mListener.generateCounterExample();
                    mAssertion.Action += mListener.onAction;
                    mAssertion.ReturnResult += VerificationFinished;
                    mAssertion.Cancelled += Verification_Cancelled;
                    mAssertion.Failed += MC_Failed;

                    mSeconds = 1;
                    mTimer.Start();
                    mAssertion.Start();
                }
                catch (RuntimeException e)
                {
                    mSpec.UnLockSharedData();
                    Common.Utility.Utilities.LogRuntimeException(e);
                    mListener.updateVerifyBtnLabel(LABEL_VERIFY);
                    return;
                }
                catch (Exception ex)
                {
                    mSpec.UnLockSharedData();
                    Common.Utility.Utilities.LogException(ex, mSpec);
                    mListener.updateVerifyBtnLabel(LABEL_VERIFY);
                    return;
                }
            } while (false);
        }

        protected virtual void VerificationFinished()
        {
            try
            {
                if (Utility.Utilities.IsValidLicenseAvailable == Utility.Utilities.LicenseType.Evaluation ||
                    Utility.Utilities.IsValidLicenseAvailable == Utility.Utilities.LicenseType.Invalid)
                {
                    if (mAssertion.VerificationOutput.NoOfStates > Utility.Utilities.LicenseBoundedStateNumber)
                    {
                        mListener.updateResFinishedVerify();
                        mAssertion.Clear();

                        //remove the events
                        mAssertion.Action -= mListener.onAction;
                        mAssertion.Cancelled -= Verification_Cancelled;
                        mAssertion.ReturnResult -= VerificationFinished;
                        mAssertion.Failed -= MC_Failed;
                        return;
                    }
                }

                mListener.onAction(mAssertion.GetVerificationStatistics());
                mListener.onResult(mAssertion.VerificationOutput.VerificationResult);

                mAssertion.ReturnResult -= VerificationFinished;
                mAssertion.ReturnResult += VerificationResult;
                mAssertion.VerificationOutput.GenerateCounterExample = mListener.generateCounterExample();
                mAssertion.VerificationMode = false;
                mAssertion.Start();

            }
            catch (Exception ex)
            {
                mAssertion.Clear();

                //remove the events
                mAssertion.Action -= mListener.onAction;
                mAssertion.Cancelled -= Verification_Cancelled;
                mAssertion.ReturnResult -= VerificationFinished;
                mAssertion.Failed -= MC_Failed;
                mSpec.AssertionDatabase[mCurAssert] = mAssertion;

                Common.Utility.Utilities.LogException(ex, mSpec);
            }

        }

        protected virtual void VerificationResult()
        {
            try
            {
                mListener.onAction(mAssertion.VerificationOutput.ResultString);
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpec);
            }
            finally
            {
                mAssertion.Clear();

                //remove the events
                mAssertion.Action -= mListener.onAction;
                mAssertion.Cancelled -= Verification_Cancelled;
                mAssertion.ReturnResult -= VerificationResult;
                mAssertion.Failed -= MC_Failed;
                mSpec.AssertionDatabase[mCurAssert] = mAssertion;

                mListener.eventResult();
            }
        }

        protected virtual void Verification_Cancelled(object sender, EventArgs e)
        {
            try
            {
                //cancel the verification 
                if (mAssertion.VerificationMode)
                {
                    mListener.onAction(mAssertion.GetVerificationStatistics());
                    mListener.onAction(mAssertion.VerificationOutput.ResultString);
                    mListener.RnderingOutputTextbox();

                    mAssertion.Clear();

                    //remove the events
                    mAssertion.Action -= mListener.onAction;
                    mAssertion.ReturnResult -= VerificationFinished;
                    mAssertion.Cancelled -= Verification_Cancelled;
                    mAssertion.Failed -= MC_Failed;
                    mAssertion.VerificationOutput = null;
                    mAssertion = null;

                    //set the verification result to be unknow.
                    mListener.eventCancel();
                    //ListView_Assertions.SelectedItems[VerificationIndex].ImageIndex = UNKNOWN_ICON;
                }
                //cancel the result generation
                else
                {
                    mListener.onAction(mAssertion.VerificationOutput.ResultString);
                    mListener.RnderingOutputTextbox();
                    mAssertion.VerificationOutput = null;
                }
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpec);
            }
        }

        protected virtual void MC_Failed(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                if (e.Exception is RuntimeException)
                {
                    Common.Utility.Utilities.LogRuntimeException(e.Exception as RuntimeException);
                    if (mAssertion != null)
                    {
                        mListener.onAction(mAssertion.GetVerificationStatistics());
                        mListener.onAction(mAssertion.VerificationOutput.ResultString);
                        mListener.RnderingOutputTextbox();
                    }
                }
                else
                {
                    //if the button is enabled -> the failure is not triggered by cancel action.
                    if (mListener.isVerifyBtnEnabled())
                    {
                        Common.Utility.Utilities.LogException(e.Exception, mSpec);
                        mSpec.UnLockSharedData();
                    }

                }

                if (mAssertion != null)
                {
                    mAssertion.Clear();

                    //remove the events
                    mAssertion.Action -= mListener.onAction;
                    mAssertion.ReturnResult -= VerificationFinished;
                    mAssertion.Cancelled -= Verification_Cancelled;
                    mAssertion.Failed -= MC_Failed;
                    mAssertion = null;
                }
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpec);
            }
        }

    }
}
