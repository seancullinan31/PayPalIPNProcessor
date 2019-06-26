using System;
using System.Collections.Generic;
using System.Text;

namespace PayPalIPNProcessor.Enums
{
    /// <summary>
    /// Enumerates the transaction types located in the txn_type field of an IPN Message
    /// </summary>
    public enum TransactionTypes
    {
        /// <summary>
        /// No transaction type specified
        /// </summary>
        not_specified = 1,
        /// <summary>
        /// A dispute has been resolved and closed
        /// </summary>
        adjustment = 2,
        /// <summary>
        /// Payment received for multiple items; source is Express Checkout or the PayPal Shopping Cart.
        /// </summary>
        cart = 3,
        /// <summary>
        /// Payment received for a single item; source is Express Checkout
        /// </summary>
        express_checkout = 4,
        /// <summary>
        /// Payment sent using Mass Pay
        /// </summary>
        masspay = 5,
        /// <summary>
        /// Monthly subscription paid for Website Payments Pro, Reference transactions, or Billing Agreements
        /// </summary>
        merch_pmt = 6,
        /// <summary>
        /// Billing agreement cancelled
        /// </summary>
        mp_cancel = 7,
        /// <summary>
        /// A new dispute was filed
        /// </summary>
        new_case = 8,
        /// <summary>
        /// A payout related to a global shipping transaction was completed.
        /// </summary>
        payout = 9,
        /// <summary>
        /// Payment received; source is Website Payments Pro Hosted Solution.
        /// </summary>
        pro_hosted = 10,
        /// <summary>
        /// Recurring payment received
        /// </summary>
        recurring_payment = 11,
        /// <summary>
        /// Recurring payment expired
        /// </summary>
        recurring_payment_expired = 12,
        /// <summary>
        /// Recurring payment failed 
        /// This transaction type is sent if:
        /// The attempt to collect a recurring payment fails
        /// The "max failed payments" setting in the customer's recurring payment profile is 0 
        /// In this case, PayPal tries to collect the recurring payment an unlimited number of times without ever suspending the customer's recurring payments profile.
        /// </summary>
        recurring_payment_failed = 13,
        /// <summary>
        /// Recurring payment profile canceled
        /// </summary>
        recurring_payment_profile_cancel = 14,
        /// <summary>
        /// Recurring payment profile created
        /// </summary>
        recurring_payment_profile_created = 15,
        /// <summary>
        /// Recurring payment skipped; it will be retried up to 3 times, 5 days apart
        /// </summary>
        recurring_payment_skipped = 16,
        /// <summary>
        /// Recurring payment suspended 
        /// This transaction type is sent if PayPal tried to collect a recurring payment, but the related recurring payments profile has been suspended.
        /// </summary>
        recurring_payment_suspended = 17,
        /// <summary>
        /// Recurring payment failed and the related recurring payment profile has been suspended 
        /// This transaction type is sent if:
        /// PayPal's attempt to collect a recurring payment failed
        /// The "max failed payments" setting in the customer's recurring payment profile is 1 or greater
        /// the number of attempts to collect payment has exceeded the value specified for "max failed payments" 
        /// In this case, PayPal suspends the customer's recurring payment profile.
        /// </summary>
        recurring_payment_suspended_due_to_max_failed_payment = 18,
        /// <summary>
        /// Payment received; source is the Send Money tab on the PayPal website
        /// </summary>
        send_money = 19,
        /// <summary>
        /// Subscription canceled
        /// </summary>
        subscr_cancel = 20,
        /// <summary>
        /// Subscription expired
        /// </summary>
        subscr_eot = 21,
        /// <summary>
        /// Subscription payment failed
        /// </summary>
        subscr_failed = 22,
        /// <summary>
        /// Subscription modified
        /// </summary>
        subscr_modify = 23,
        /// <summary>
        /// Subscription payment received
        /// </summary>
        subscr_payment = 24,
        /// <summary>
        /// Subscription started
        /// </summary>
        subscr_signup = 25,
        /// <summary>
        /// Payment received; source is Virtual Terminal
        /// </summary>
        virtual_terminal = 26,
        /// <summary>
        /// Payment received; source is any of the following:
        /// A Direct Credit Card (Pro) transaction
        /// A Buy Now, Donation or Smart Logo for eBay auctions button
        /// </summary>
        web_accept = 27
    }
}
