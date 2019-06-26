using System;
using System.Collections.Generic;
using System.Text;

namespace PayPalIPNProcessor.Models
{
    public class PurchasedItem
    {
        public int index { get; set; }
        /// <summary>
        /// Item name as passed by you, the merchant. Or, if not passed by you, as entered by your customer. If this is a shopping cart transaction, PayPal will append the number of the item. For example, item_name1, item_name2, and so on..
        /// Length: 127 characters
        /// </summary>
        public string item_name { get; set; }
        /// <summary>
        /// Pass-through variable for you to track purchases. It will get passed back to you at the completion of the payment. If omitted, no variable will be passed back to you. If this is a shopping cart transaction, PayPal will append the number of the item. For example, item_number1, item_number2, and so on..
        /// Length: 127 characters
        /// </summary>
        public string item_number { get; set; }
        /// <summary>
        /// Quantity as entered by your customer or as passed by you, the merchant. If this is a shopping cart transaction, PayPal appends the number of the item (e.g. quantity1, quantity2).
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// The amount of shopping cart detail item prior to discount. The amount is in the currency of mc_currency, where x is the shopping cart detail item number. The value of mc_gross_x is mc_gross minus discount.
        /// </summary>
        public double mc_gross { get; set; }
        /// <summary>
        /// This is the combined total of shipping1 and shipping2 Website Payments Standard variables, where x is the shopping cart detail item number. The shippingx variable is only shown when the merchant applies a shipping amount for a specific item. Because profile shipping might apply, the sum of shippingx might not be equal to shipping
        /// </summary>
        public double mc_shipping { get; set; }
        /// <summary>
        /// Option name as requested by you. PayPal appends the number of the item where x represents the number of the shopping cart detail item. For example, option_name1, option_name2). 
        /// Length: 64 characters
        /// </summary>
        public string option_name { get; set; }
        /// <summary>
        /// Option 1 choice as entered by your customer. 
        /// PayPal appends the number of the item where x represents the number of the shopping cart detail item.For example, option_selection1, option_selection2). 
        /// Length: 200 characters
        /// </summary>
        public string option_selection { get; set; }
    }
}
