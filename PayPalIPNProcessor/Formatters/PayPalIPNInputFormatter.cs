using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PayPalIPNProcessor.Models;
using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayPalIPNProcessor.Formatters
{
    public class PayPalIPNInputFormatter : TextInputFormatter
    {
        public PayPalIPNInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded"));
            SupportedEncodings.Add(Encoding.ASCII);
        }
        public async override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }
            var request = context.HttpContext.Request.HttpContext.Request;
            try
            {
                var ret = new PayPalIPNRequest();
                StringBuilder rawBody = new StringBuilder();
                foreach(string key in request.Form.Keys)
                {
                    string strVal = request.Form[key].ToString();
                    rawBody.Append(WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(strVal) + "&");
                    PropertyInfo propInfo = typeof(PayPalIPNRequest).GetProperty(key);
                    if(propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(DateTime))
                        {
                            DateTime val;
                            if (DateTime.TryParse(strVal, out val))
                            {
                                propInfo.SetValue(ret, val, null);
                            }
                        }
                        else if (propInfo.PropertyType == typeof(int))
                        {
                            int val;
                            if (int.TryParse(strVal, out val))
                            {
                                propInfo.SetValue(ret, val, null);
                            }
                        }
                        else if (propInfo.PropertyType == typeof(double))
                        {
                            double val;
                            if (double.TryParse(strVal, out val))
                            {
                                propInfo.SetValue(ret, val, null);
                            }
                        }
                        else
                        {
                            propInfo.SetValue(ret, strVal, null);
                        }
                    }
                }
                ret.rawBody = rawBody.ToString().TrimEnd("&".ToCharArray());
                return await InputFormatterResult.SuccessAsync(ret);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return await InputFormatterResult.FailureAsync();
            }
            
        }
    }
}
