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
                    if (key.StartsWith("item_name"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "item_name", ret);
                        itm.item_name = strVal;
                    }
                    else if (key.StartsWith("item_number"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "item_number", ret);
                        itm.item_number = strVal;
                    }
                    else if (key.StartsWith("quantity"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "quantity", ret);
                        int val;
                        if(int.TryParse(strVal, out val))
                        {
                            itm.quantity = val;
                        }
                    }
                    else if (key.StartsWith("mc_gross"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "mc_gross", ret);
                        double val;
                        if (double.TryParse(strVal, out val))
                        {
                            itm.mc_gross = val;
                        }
                    }
                    else if (key.StartsWith("mc_shipping"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "mc_shipping", ret);
                        double val;
                        if (double.TryParse(strVal, out val))
                        {
                            itm.mc_gross = val;
                        }
                    }
                    else if (key.StartsWith("option_name"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "option_name", ret);
                        itm.item_number = strVal;
                    }
                    else if (key.StartsWith("option_selection"))
                    {
                        PurchasedItem itm = addGetItemFromList(key, "option_selection", ret);
                        itm.item_number = strVal;
                    }
                    else if (key.StartsWith("fraud_management_pending_filters_"))
                    {
                        int val;
                        if (int.TryParse(strVal, out val))
                        {
                            ret.fraud_management_pending_filters.Add(val);
                        }
                    }
                    else
                    {
                        PropertyInfo propInfo = typeof(PayPalIPNRequest).GetProperty(key);
                        if (propInfo != null)
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
        private int getItemNumber(string key, string keyUpToNumber)
        {
            string strNumPart = key.Replace(keyUpToNumber, "");
            int ret;
            if(int.TryParse(strNumPart, out ret))
            {
                return ret;
            } else
            {
                return 0;
            }
        }
        private PurchasedItem addGetItemFromList(string key, string keyUpToNumber, PayPalIPNRequest ret)
        {
            int itemIndex = getItemNumber(key, keyUpToNumber);
            PurchasedItem itm = ret.purchased_items.Find(item => item.index == itemIndex);
            if (itm == null)
            {
                itm = new PurchasedItem();
                itm.index = itemIndex;
                ret.purchased_items.Add(itm);
            }
            return itm;
        }
    }
}
