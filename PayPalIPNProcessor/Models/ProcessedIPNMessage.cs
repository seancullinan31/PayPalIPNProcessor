using System;
using PayPalIPNProcessor.Enums;

namespace PayPalIPNProcessor.Models
{
    /// <summary>
    /// Wraps the PayPalIPN Request with a verified status
    /// </summary>
    public class ProcessedIPNMessage

    {
        /// <summary>
        /// This will return "VERIFIED" of it is verified or "INVALID" if not verified.
        /// </summary>
        public VerificationStatuses Verification {
            get {
                if(VerificationString == null)
                {
                    return VerificationStatuses.Unverified;
                }
                switch (VerificationString.ToUpper())
                {
                    case "VERIFIED":
                        return VerificationStatuses.Verified;
                    case "INVALID":
                        return VerificationStatuses.Invalid;
                    default:
                        return VerificationStatuses.Unknown;
                }
            }
        } 
        /// <summary>
        /// Useful if an unknown verification status comes back unkown so you can see the raw value that was obtained from PayPal.
        /// </summary>
        public string VerificationString { get; set; }
        public PayPalIPNRequest PayPalRequest { get; set; }
    }
}
