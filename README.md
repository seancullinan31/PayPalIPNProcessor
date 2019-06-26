# PayPal IPN Processor

Easily Process PayPal IPN Messages with this Class Library for .NET Standard

Use this library in your WebAPI projects to quickly get up and running in processing PayPalIPN Requests.

The PayPalIPNProcessorSample provides a working ASP.NET Core WebAPI project that illustrates how to use the library. Please note that the Startup.cs file has been modified so that the Input Formatter in the library is supported:

services.AddMvc(options =>
{
options.InputFormatters.Insert(0, new PayPalIPNInputFormatter());
}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

That is the trickiest part. After that just follow the sample app in your application and start processing PayPal IPN Requests!

The Postman Collection can be used by the Postman tool located at https://www.getpostman.com/ to generate requests for you to test this. Note that if you use this collection your results will come back as Invalid since the data fed in didn't come from PayPal. This is expected but the tests still show you how the flow of this works and the message that you will get back.
