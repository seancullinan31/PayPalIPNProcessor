using System;
using System.Collections.Generic;
using System.Text;

namespace PayPalIPNProcessor.Enums
{
    public enum VerificationStatuses
    {
        /// <summary>
        /// No verification has been performed yet
        /// </summary>
        Unverified = 0,
        /// <summary>
        /// Verification has been performed and was successful.  PayPal Returned "VERIFIED"
        /// </summary>
        Verified = 1,
        /// <summary>
        /// Verification has been performed but was not successful.  PayPal Returned "INVALID"
        /// </summary>
        Invalid = 2,
        /// <summary>
        /// Verification has been performed but an unexpected value came back from PayPal.
        /// </summary>
        Unknown = 3
    }
}
