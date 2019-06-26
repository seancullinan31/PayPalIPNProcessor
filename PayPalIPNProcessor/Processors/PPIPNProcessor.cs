using PayPalIPNProcessor.Models;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace PayPalIPNProcessor.Processors
{
    public class PPIPNProcessor
    {
        #region "ctor"
        /// <summary>
        /// Default Constructor that assumes production instance of PayPal
        /// </summary>
        public PPIPNProcessor()
        {

        }
        /// <summary>
        /// Constructor that lets you set IsSandbox to True so that you can hit PayPal's sandbox for return message
        /// </summary>
        /// <param name="IsSandBox"></param>
        public PPIPNProcessor(Boolean IsSandBox)
        {
            if(IsSandBox)
            {
                _IPNString = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            }
        }
        private string _IPNString = "https://ipnpb.paypal.com/cgi-bin/webscr";
        #endregion
        
        /// <summary>
        /// Pass in the request from PayPal and it will do the required reply back to PayPal asynch.
        /// It then fires an event that your 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A ProcessedIPNMessage that contains the request plus the verification status as obtained
        /// when we sent back the message to FaceBook</returns>
        public ProcessedIPNMessage Process(PayPalIPNRequest request)
        {
            ProcessedIPNMessage ipnContext = new ProcessedIPNMessage();
            ipnContext.PayPalRequest = request;
            VerifyTask(ipnContext);
            //Reply back with true
            return ipnContext;
        }
        /// <summary>
        /// This sends the message back to PayPal which will reply with the verification status.
        /// </summary>
        /// <param name="ipnContext">The IPN Context message that was built by Process</param>
        private void VerifyTask(ProcessedIPNMessage ipnContext)
        {
            try
            {
                var verificationRequest = WebRequest.Create(_IPNString);
                //Set values for the verification request
                verificationRequest.Method = "POST";
                verificationRequest.ContentType = "application/x-www-form-urlencoded";
                //Add cmd=_notify-validate to the payload
                string strRequest = "cmd=_notify-validate&" + ipnContext.PayPalRequest.rawBody;
                verificationRequest.ContentLength = strRequest.Length;
                //Attach payload to the verification request
                using (StreamWriter writer = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII))
                {
                    writer.Write(strRequest);
                }
                //Send the request to PayPal and get the response
                using (StreamReader reader = new StreamReader(verificationRequest.GetResponse().GetResponseStream()))

                {
                    ipnContext.VerificationString = reader.ReadToEnd();
                }
            }
            catch (Exception exception)

            {
                throw new Exception(exception.ToString());
            }
        }
    }
}
