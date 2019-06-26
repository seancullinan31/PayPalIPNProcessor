using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayPalIPNProcessor.Enums;
using PayPalIPNProcessor.Models;
using PayPalIPNProcessor.Processors;

namespace PayPalIPNProcessorSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalIPNController : ControllerBase
    {
        // POST api/values
        [HttpPost("", Name="ProcessIPN")]
        public IActionResult ProcessIPN([FromBody] PayPalIPNRequest requestData)
        {
            Task.Run(() => processData(requestData)); // fire and forget processing...we need to return ok as quick as possible per PayPal guidelines
            return Ok();
        }
        private void processData(PayPalIPNRequest requestData)
        {
            PPIPNProcessor processor = new PPIPNProcessor(true);
            try
            {
                ProcessedIPNMessage result = processor.Process(requestData);
                if (result.Verification == VerificationStatuses.Verified)

                {
                    // check that Payment_status=Completed

                    // check that Txn_id has not been previously processed

                    // check that Receiver_email is your Primary PayPal email

                    // check that Payment_amount/Payment_currency are correct

                    // process payment
                }
                else if (result.Verification == VerificationStatuses.Invalid)
                {
                    //Log for manual investigation Note that you WILL get this value if you are testing from local data as PayPal didn't initiate the transaction!
                }
                else
                {
                    //Log error based on result.VerificationString value
                    Console.WriteLine(result.VerificationString);
                }
            } catch (Exception e)
            {
                // todo: log exception
            }
        }
    }
}
