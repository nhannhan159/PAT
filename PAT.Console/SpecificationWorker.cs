using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PAT.Common;
using PAT.Common.Classes.Expressions.ExpressionClass;
using PAT.Common.Classes.ModuleInterface;

namespace PAT.Console
{
    public class SpecificationWorker
    {
        public SpecificationBase mSpec;
        public AssertionBase mAssertion;
        private string mCurAssert;

        public SpecificationWorker(SpecificationBase spec)
        {
            this.mSpec = spec;
        }

        public void startVerification(string assert)
        {
            do
            {
                mCurAssert = assert;
                if (!mSpec.GrabSharedDataLock())
                    break;

                try
                {
                    mSpec.LockSharedData(false);
                    mAssertion = mSpec.AssertionDatabase[assert];
                    mAssertion.UIInitialize(null, 0, 0);
                    mAssertion.ReturnResult += VerificationFinished;
                    mAssertion.Start();
                    System.Console.WriteLine("\nVerify {0}, result: {1}", assert, mAssertion.VerificationOutput.VerificationResult);
                }
                catch (RuntimeException e)
                {
                    mSpec.UnLockSharedData();
                    Common.Utility.Utilities.LogRuntimeException(e);
                    return;
                }
                catch (Exception ex)
                {
                    mSpec.UnLockSharedData();
                    Common.Utility.Utilities.LogException(ex, mSpec);
                    return;
                }
            } while (false);
        }

        protected virtual void VerificationFinished()
        {
            try
            {
                if (Common.Utility.Utilities.IsValidLicenseAvailable == Common.Utility.Utilities.LicenseType.Evaluation ||
                    Common.Utility.Utilities.IsValidLicenseAvailable == Common.Utility.Utilities.LicenseType.Invalid)
                {
                    if (mAssertion.VerificationOutput.NoOfStates > Common.Utility.Utilities.LicenseBoundedStateNumber)
                    {
                        mAssertion.Clear();

                        //remove the events
                        mAssertion.ReturnResult -= VerificationFinished;
                        return;
                    }
                }

                System.Console.WriteLine(mAssertion.VerificationOutput.VerificationResult);
                mAssertion.ReturnResult -= VerificationFinished;
                mAssertion.ReturnResult += VerificationResult;
                mAssertion.VerificationMode = false;
                mAssertion.Start();

            }
            catch (Exception ex)
            {
                mAssertion.Clear();
                mAssertion.ReturnResult -= VerificationFinished;
                mSpec.AssertionDatabase[mCurAssert] = mAssertion;
                Common.Utility.Utilities.LogException(ex, mSpec);
            }

        }

        protected virtual void VerificationResult()
        {
            try
            {
                mAssertion.Clear();
                mAssertion.ReturnResult -= VerificationResult;
                mSpec.AssertionDatabase[mCurAssert] = mAssertion;
            }
            catch (Exception ex)
            {
                Common.Utility.Utilities.LogException(ex, mSpec);
            }
        }

    }
}
