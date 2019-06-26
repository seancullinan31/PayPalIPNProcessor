using PayPalIPNProcessor.Enums;
using System;
using System.Collections.Generic;

namespace PayPalIPNProcessor.Models
{
    public class PayPalIPNRequest
    {
        /// <summary>
        /// Typically, your back-end or administrative processes will perform specific actions based on the kind of IPN message received. You can use the txn_type variable in the message to trigger the kind of processing you want to perform.
        /// </summary>
        public string txn_type { get; set; }
        public TransactionTypes TransactionType {
            get
            {
                switch(txn_type)
                {
                    case "adjustment":
                        return TransactionTypes.adjustment;
                    case "cart":
                        return TransactionTypes.cart;
                    case "express_checkout":
                        return TransactionTypes.express_checkout;
                    case "masspay":
                        return TransactionTypes.masspay;
                    case "merch_pmt":
                        return TransactionTypes.merch_pmt;
                    case "mp_cancel":
                        return TransactionTypes.mp_cancel;
                    case "new_case":
                        return TransactionTypes.new_case;
                    case "payout":
                        return TransactionTypes.payout;
                    case "pro_hosted":
                        return TransactionTypes.pro_hosted;
                    case "recurring_payment":
                        return TransactionTypes.recurring_payment;
                    case "recurring_payment_expired":
                        return TransactionTypes.recurring_payment_expired;
                    case "recurring_payment_failed":
                        return TransactionTypes.recurring_payment_failed;
                    case "recurring_payment_profile_cancel":
                        return TransactionTypes.recurring_payment_profile_cancel;
                    case "recurring_payment_profile_created":
                        return TransactionTypes.recurring_payment_profile_created;
                    case "recurring_payment_skipped":
                        return TransactionTypes.recurring_payment_skipped;
                    case "recurring_payment_suspended":
                        return TransactionTypes.recurring_payment_suspended;
                    case "recurring_payment_suspended_due_to_max_failed_payment":
                        return TransactionTypes.recurring_payment_suspended_due_to_max_failed_payment;
                    case "send_money":
                        return TransactionTypes.send_money;
                    case "subscr_cancel":
                        return TransactionTypes.subscr_cancel;
                    case "subscr_eot":
                        return TransactionTypes.subscr_eot;
                    case "subscr_failed":
                        return TransactionTypes.subscr_failed;
                    case "subscr_modify":
                        return TransactionTypes.subscr_modify;
                    case "subscr_payment":
                        return TransactionTypes.subscr_payment;
                    case "subscr_signup":
                        return TransactionTypes.subscr_signup;
                    case "virtual_terminal":
                        return TransactionTypes.virtual_terminal;
                    case "web_accept":
                        return TransactionTypes.web_accept;
                    default:
                        return TransactionTypes.not_specified;
                }
            }
        }

        #region "Transaction and notification-related variables"
        /// <summary>
        /// Email address or account ID of the payment recipient (that is, the merchant). Equivalent to the values of receiver_email (if payment is sent to primary account) and business set in the Website Payment HTML.
        /// Note: The value of this variable is normalized to lowercase characters.
        /// Length: 127 characters
        /// </summary>
        public string business { get; set; }
        /// <summary>
        /// Character set.
        /// </summary>
        public string charset { get; set; }
        /// <summary>
        /// Custom value as passed by you, the merchant. These are pass-through variables that are never presented to your customer.
        /// Length: 255 characters
        /// </summary>
        public string custom { get; set; }
        /// <summary>
        /// Internal; only for use by MTS
        /// </summary>
        public string ipn_track_id { get; set; }
        /// <summary>
        /// Message's version number.
        /// </summary>
        public string notify_version { get; set; }
        /// <summary>
        /// In the case of a refund, reversal, or canceled reversal, this variable contains the txn_id of the original transaction, while txn_id contains a new ID for the new transaction. 
        /// Length: 19 characters
        /// </summary>
        public string parent_txn_id { get; set; }
        /// <summary>
        /// Unique ID generated during guest checkout (payment by credit card without logging in).
        /// </summary>
        public string receipt_id { get; set; }
        /// <summary>
        /// Primary email address of the payment recipient (that is, the merchant). If the payment is sent to a non-primary email address on your PayPal account, the receiver_email is still your primary email.
        /// Note: The value of this variable is normalized to lowercase characters.
        /// Length: 127 characters
        /// </summary>
        public string receiver_email { get; set; }
        /// <summary>
        /// Unique account ID of the payment recipient (i.e., the merchant). This is the same as the recipient's referral ID.
        /// Length: 13 characters
        /// </summary>
        public string receiver_id { get; set; }
        /// <summary>
        /// Whether this IPN message was resent (equals true); otherwise, this is the original message.
        /// </summary>
        public string resend { get; set; }
        /// <summary>
        /// ISO 3166 country code associated with the country of residence.
        /// Length: 2 characters
        /// </summary>
        public string residence_country { get; set; }
        /// <summary>
        /// Whether the message is a test message. Value is:
        /// 1 — the message is directed to the Sandbox
        /// </summary>
        public int test_ipn { get; set; }
        /// <summary>
        /// The merchant's original transaction identification number for the payment from the buyer, against which the case was registered.
        /// </summary>
        public string txn_id { get; set; }
        /// <summary>
        /// Encrypted string used to validate the authenticity of the transaction.
        /// </summary>
        public string verify_sign { get; set; }
        #endregion

        #region "Buyer information variables"
        /// <summary>
        /// Country of customer's address.
        /// Length: 64 characters
        /// </summary>
        public string address_country { get; set; }
        /// <summary>
        /// City of customer's address.
        /// Length: 40 characters
        /// </summary>
        public string address_city { get; set; }
        /// <summary>
        /// ISO 3166 country code associated with customer's address.
        /// Length: 2 characters
        /// </summary>
        public string address_country_code { get; set; }
        /// <summary>
        /// Name used with address (included when the customer provides a Gift Address).
        /// Length: 128 characters
        /// </summary>
        public string address_name { get; set; }
        /// <summary>
        /// State of customer's address.
        /// Length: 40 characters
        /// </summary>
        public string address_state { get; set; }
        /// <summary>
        /// Whether the customer provided a confirmed address. Possible values are confirmed and unconfirmed
        /// </summary>
        public string address_status { get; set; }
        /// <summary>
        /// Customer's street address.
        /// Length: 200 characters
        /// </summary>
        public string address_street { get; set; }
        /// <summary>
        /// Zip code of customer's address.
        /// Length: 20 characters
        /// </summary>
        public string address_zip { get; set; }
        
        /// <summary>
        /// Customer's telephone number. 
        /// Length: 20 characters
        /// </summary>
        public string contact_phone { get; set; }
        /// <summary>
        /// Customer's first name.
        /// Length: 64 characters
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// Account holder's last name.
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// Customer's company name, if customer is a business 
        /// Length: 127 characters
        /// </summary>
        public string payer_business_name { get; set; }
        /// <summary>
        /// Customer's primary email address. Use this email to provide any credits.
        /// Length: 127 characters
        /// </summary>
        public string payer_email { get; set; }
        /// <summary>
        /// Unique customer ID.
        /// Length: 13 characters
        /// </summary>
        public string payer_id { get; set; }
        #endregion

        #region "Payment information variables"
        /// <summary>
        /// Authorization amount
        /// </summary>
        public double auth_amount { get; set; }
        /// <summary>
        /// Authorization expiration date and time in the following format: HH:MM:SS DD Mmm YY, YYYY PST 
        /// Length: 28 characters
        /// </summary>
        public DateTime auth_exp { get; set; }
        /// <summary>
        /// Authorization identification number 
        /// Length: 19 characters
        /// </summary>
        public string auth_id { get; set; }
        /// <summary>
        /// Status of authorization
        /// </summary>
        public string auth_status { get; set; }
        /// <summary>
        /// The total discount to be applied to a shopping cart in the currency of mc_currency.
        /// </summary>
        public double discount { get; set; }
        /// <summary>
        /// The time an eCheck was processed; for example, when the status changes to Success or Completed. The format is: hh:mm:ss MM DD, YYYY ZONE. For example, 04:55:30 May 26, 2011 PDT
        /// </summary>
        public DateTime echeck_time_processed { get; set; }
        /// <summary>
        /// NOT IMPLEMENTED
        /// One or more filters that identify a triggering action associated with one of the following payment_status values: Pending, Completed, Denied, where x is a number starting with 1 that makes the IPN variable name unique; x is not the filter's ID number. The filters and their ID numbers are as follows:
        /// 1—AVS No Match
        /// 2—AVS Partial Match
        /// 3—AVS Unavailable/Unsupported
        /// 4—Card Security Code(CSC) Mismatch
        /// 5—Maximum Transaction Amount
        /// 6—Unconfirmed Address
        /// 7—Country Monitor
        /// 8—Large Order Number
        /// 9—Billing/Shipping Address Mismatch
        /// 10—Risky ZIP Code
        /// 11—Suspected Freight Forwarder Check
        /// 12—Total Purchase Price Minimum
        /// 13—IP Address Velocity
        /// 14—Risky Email Address Domain Check
        /// 15—Risky Bank Identification Number(BIN) Check
        /// 16—Risky IP Address Range
        /// 17—PayPal Fraud Model
        /// </summary>
        public List<int> fraud_management_pending_filters { get; set; }
        /// <summary>
        /// Pass-through variable you can use to identify your invoice number for the purchase. If omitted, no variable is passed back.
        /// Length: 127 characters
        /// </summary>
        public string invoice { get; set; }
        /// <summary>
        /// List of purchased items including their name, number and quantity.
        /// </summary>
        public List<PurchasedItem> purchased_items { get; set; } = new List<PurchasedItem>();
        /// <summary>
        /// For payment IPN notifications, this is the currency of the payment.
        /// For non-payment subscription IPN notifications(e.g., txn_type= signup, cancel, failed, eot, or modify), this is the currency of the subscription.
        /// For payment subscription IPN notifications, it is the currency of the payment(e.g., txn_type = subscr_payment).
        /// </summary>
        public string mc_currency { get; set; }
        /// <summary>
        /// Transaction fee associated with the payment. mc_gross minus mc_fee equals the amount deposited into the receiver_email account. Equivalent to payment_fee for USD payments. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction fee.
        /// </summary>
        public double mc_fee { get; set; }
        /// <summary>
        /// Full amount of the customer's payment, before transaction fee is subtracted. Equivalent to payment_gross for USD payments. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction.
        /// </summary>
        public double mc_gross { get; set; }
        /// <summary>
        /// Total shipping amount associated with the transaction.
        /// </summary>
        public double mc_shipping { get; set; }
        /// <summary>
        /// Memo as entered by your customer in PayPal Website Payments Pro note field.
        /// Length: 255 characters
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// If this is a PayPal Shopping Cart transaction, number of items in cart.
        /// </summary>
        public int num_cart_items { get; set; }
        /// <summary>
        /// Whether the customer has a verified PayPal account. Possible values are verified or unverified.
        /// </summary>
        public string payer_status { get; set; }
        /// <summary>
        /// The PayPal-generated time and date stamp in the format HH:MM:SS Mmm DD, YYYY PDT.
        /// Length: 28 characters
        /// </summary>
        public DateTime payment_date { get; set; }
        /// <summary>
        /// USD transaction fee associated with the payment. payment_gross minus payment_fee equals the amount deposited into the receiver email account. Is empty for non-USD payments. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction fee.
        /// Note: This is a deprecated field.Use mc_fee instead.
        /// </summary>
        public double payment_fee { get; set; }
        /// <summary>
        /// Full USD amount of the customer's payment, before transaction fee is subtracted. Will be empty for non-USD payments. This is a deprecated field replaced by mc_gross. If this amount is negative, it signifies a refund or reversal, and either of those payment statuses can be for the full or partial amount of the original transaction.
        /// </summary>
        public double payment_gross { get; set; }
        /// <summary>
        /// The status of the payment:
        /// Canceled_Reversal: A reversal has been canceled.For example, you won a dispute with the customer, and the funds for the transaction that was reversed have been returned to you.
        /// Completed: The payment has been completed, and the funds have been added successfully to your account balance.
        /// Created: A German ELV payment is made using Express Checkout.
        /// Denied: The payment was denied.This happens only if the payment was previously pending because of one of the reasons listed for the pending_reason variable or the Fraud_Management_Filters_x variable.
        /// Expired: This authorization has expired and cannot be captured.
        /// Failed: The payment has failed. This happens only if the payment was made from your customer's bank account.
        /// Pending: The payment is pending.See pending_reason for more information.
        /// Refunded: You refunded the payment.
        /// Reversed: A payment was reversed due to a chargeback or other type of reversal.The funds have been removed from your account balance and returned to the buyer. The reason for the reversal is specified in the ReasonCode element.
        /// Processed: A payment has been accepted.
        /// Voided: This authorization has been voided.
        /// </summary>
        public string payment_status { get; set; }
        /// <summary>
        /// echeck: This payment was funded with an eCheck.
        /// instant: This payment was funded with PayPal balance, credit card, or Instant Transfer.
        /// </summary>
        public string payment_type { get; set; }
        /// <summary>
        /// This variable is set only if payment_status is Pending.
        /// address: Your Payment Receiving Preferences are set so that if a customer does not include a confirmed shipping address, you must manually accept or deny the payment.To change your preference, go to the Preferences section of your Profile.
        /// authorization: You set the payment action to Authorization and have not yet captured funds.
        /// delayed_disbursement: The transaction has been approved and is currently awaiting funding from the bank. This typically takes less than 48 hrs.
        /// echeck: The payment is pending because it was made by an eCheck that has not yet cleared.
        /// intl: The payment is pending because you hold a non-U.S.account and do not have a withdrawal mechanism.You must manually accept or deny this payment from your Account Overview.
        /// multi_currency: You do not have a balance in the currency sent, and you do not have your profile's Payment Receiving Preferences option set to automatically convert and accept this payment. As a result, you must manually accept or deny this payment.
        /// order: You set the payment action to Order and have not yet captured funds.
        /// paymentreview: The payment is pending while it is reviewed by PayPal for risk.
        /// regulatory_review: The payment is pending because PayPal is reviewing it for compliance with government regulations. PayPal will complete this review within 72 hours.When the review is complete, you will receive a second IPN message whose payment_status/reason code variables indicate the result.
        /// unilateral: The payment is pending because it was made to an email address that is not yet registered or confirmed.
        /// upgrade: The payment is pending because it was made via credit card and you must upgrade your account to Business or Premier status before you can receive the funds.upgrade can also mean that you have reached the monthly limit for transactions on your account.
        /// verify: The payment is pending because you are not yet verified.You must verify your account before you can accept this payment.
        /// other: The payment is pending for a reason other than those listed above.For more information, contact PayPal Customer Service.
        /// </summary>
        public string pending_reason { get; set; }
        /// <summary>
        /// The status of the seller's protection eligibility. Possible values: Eligible, Ineligible, Partially Eligible - INR Only, Partially Eligible - Unauth Only, PartiallyEligible, None, Active Fraud Control - Unauth Premium Eligible.
        /// </summary>
        public string protection_eligibility { get; set; }
        /// <summary>
        /// Can be used for 2 scenarios: payment reversal:
        /// This variable is set if payment_status is Reversed, Refunded, Canceled_Reversal, or Denied.
        /// adjustment_reversal: Reversal of an adjustment.
        /// admin_fraud_reversal: The transaction has been reversed due to fraud detected by PayPal administrators.
        /// admin_reversal: The transaction has been reversed by PayPal administrators.
        /// buyer-complaint: The transaction has been reversed due to a complaint from your customer.
        /// chargeback: The transaction has been reversed due to a chargeback by your customer.
        /// chargeback_reimbursement: Reimbursement for a chargeback.
        /// chargeback_settlement: Settlement of a chargeback.
        /// guarantee: The transaction has been reversed because your customer exercised a money-back guarantee.
        /// other: Unspecified reason.
        /// refund: The transaction has been reversed because you gave the customer a refund.
        /// regulatory_block: PayPal blocked the transaction due to a violation of a government regulation. In this case, payment_status is Denied.
        /// regulatory_reject: PayPal rejected the transaction due to a violation of a government regulation and returned the funds to the buyer.In this case, payment_status is Denied.
        /// regulatory_review_exceeding_sla: PayPal did not complete the review for compliance with government regulations within 72 hours, as required.Consequently, PayPal auto-reversed the transaction and returned the funds to the buyer. In this case, payment_status is Denied.Note that `sla` stands for `service level agreement`.
        /// unauthorized_claim: The transaction has been reversed because it was not authorized by the buyer.
        /// unauthorized_spoof: The transaction has been reversed due to a customer dispute in which an unauthorized spoof is suspected.
        /// Note: Additional codes may be returned.
        /// 
        /// Can also be used for Disputes:
        /// Reason for the case. 
        /// Values for case_type set to complaint:
        /// non_receipt: Buyer claims that he did not receive goods or service.
        /// not_as_described: Buyer claims that the goods or service received differ from merchant's description of the goods or service.
        /// unauthorized_claim: Buyer claims that an unauthorized payment was made for this particular transaction.
        /// Values for case_type set to chargeback:
        /// unauthorized
        /// adjustment_reimburse: A case that has been resolved and closed requires a reimbursement.
        /// non_receipt: Buyer claims that he did not receive goods or service.
        /// duplicate: Buyer claims that a possible duplicate payment was made to the merchant.
        /// merchandise: Buyer claims that the received merchandise is unsatisfactory, defective, or damaged.
        /// billing: Buyer claims that the received merchandise is unsatisfactory, defective, or damaged.
        /// special: Some other reason.Usually, special indicates a credit card processing error for which the merchant is not responsible and for which no debit to the merchant will result. PayPal must review the documentation from the credit card company to determine the nature of the dispute and possibly contact the merchant to resolve it.
        /// </summary>
        public string reason_code { get; set; }
        /// <summary>
        /// Remaining amount that can be captured with Authorization and Capture
        /// </summary>
        public double remaining_settle { get; set; }
        /// <summary>
        /// Amount that is deposited into the account's primary balance after a currency conversion from automatic conversion (through your Payment Receiving Preferences) or manual conversion (through manually accepting a payment)
        /// </summary>
        public double settle_amount { get; set; }
        /// <summary>
        /// Currency of settle_amount.
        /// </summary>
        public string settle_currency { get; set; }
        /// <summary>
        /// Shipping charges associated with this transaction. 
        /// Format: unsigned, no currency symbol, two decimal places.
        /// </summary>
        public double shipping { get; set; }
        /// <summary>
        /// The name of a shipping method from the Shipping Calculations section of the merchant's account profile. The buyer selected the named shipping method for this transaction.
        /// </summary>
        public string shipping_method { get; set; }
        /// <summary>
        /// Amount of tax charged on payment. PayPal appends the number of the item. For example, item_name1, item_name2). The taxx variable is included only if there was a specific tax amount applied to a particular shopping cart item. Because total tax may apply to other items in the cart, the sum of tax might not total to tax.
        /// </summary>
        public double tax { get; set; }
        /// <summary>
        /// Authorization and Capture transaction entity
        /// </summary>
        public string transaction_entity { get; set; }
        #endregion

        #region "Auction variables"
        /// <summary>
        /// The customer's auction ID. 
        /// Length: 64 characters
        /// </summary>
        public string auction_buyer_id { get; set; }
        /// <summary>
        /// The auction's close date in the format HH:MM:SS Mmm DD, YYYY PDT 
        /// Length: 28 characters
        /// </summary>
        public DateTime auction_closing_date { get; set; }
        /// <summary>
        /// The number of items purchased in multi-item auction payments. It enables you to count the mc_gross or payment_gross for the first IPN you receive from a multi-item auction (auction_multi_item), since each item from the auction will generate an Instant Payment Notification showing the amount for the entire auction.
        /// </summary>
        public int auction_multi_item { get; set; }
        /// <summary>
        /// This is an auction payment—payments made using Pay for eBay Items or Smart Logos—as well as Send Money/Money Request payments with the type eBay items or Auction Goods (non-eBay).
        /// </summary>
        public string for_auction { get; set; }
        #endregion

        #region "Mass Pay Variables"
        //todo: implement these.  They are tricky
        #endregion

        #region "Recurring Payment Variables"
        /// <summary>
        /// Amount of recurring payment
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// Amount of recurring payment per cycle
        /// </summary>
        public double amount_per_cycle { get; set; }
        /// <summary>
        /// Initial payment amount for recurring payments
        /// </summary>
        public double initial_payment_amount { get; set; }
        /// <summary>
        /// Next payment date for a recurring payment
        /// </summary>
        public DateTime next_payment_date { get; set; }
        /// <summary>
        /// Outstanding balance for recurring payments
        /// </summary>
        public double outstanding_balance { get; set; }
        /// <summary>
        /// Payment cycle for recurring payments
        /// </summary>
        public string payment_cycle { get; set; }
        /// <summary>
        /// Kind of period for a recurring payment
        /// </summary>
        public string period_type { get; set; }
        /// <summary>
        /// Product name associated with a recurring payment
        /// </summary>
        public string product_name { get; set; }
        /// <summary>
        /// Product name associated with a recurring payment
        /// </summary>
        public string product_type { get; set; }
        /// <summary>
        /// Profile status for a recurring payment
        /// </summary>
        public string profile_status { get; set; }
        /// <summary>
        /// Recurring payment ID
        /// </summary>
        public string recurring_payment_id { get; set; }
        /// <summary>
        /// The merchant's own unique reference or invoice number, which can be used to uniquely identify a profile. 
        /// Length: 127 single-byte alphanumeric characters
        /// </summary>
        public string rp_invoice_id { get; set; }
        /// <summary>
        /// When a recurring payment was created
        /// </summary>
        public DateTime time_created { get; set; }
        #endregion

        #region "Reference Transaction and Billing Agreement Variables"
        /// <summary>
        /// The merchants primary currency.
        /// </summary>
        public string mp_currency { get; set; }
        /// <summary>
        /// Custom text passed by the merchant during DoReferenceTransaction call at creation.
        /// </summary>
        public string mp_custom { get; set; }
        /// <summary>
        /// The month and day the agreement was created.
        /// </summary>
        public string mp_cycle_start { get; set; }
        /// <summary>
        /// The agreement description set in SetExpressCheckout call.
        /// </summary>
        public string mp_desc { get; set; }
        /// <summary>
        /// The encrypted billing agreement ID.
        /// </summary>
        public string mp_id { get; set; }
        /// <summary>
        /// Sent to the merchant when an account is locked. All billing agreements for the account are canceled.
        /// </summary>
        public string mp_notification { get; set; }
        /// <summary>
        /// The accepted payment type. Possible values are INSTANT, ANY, and ECHECK.
        /// </summary>
        public string mp_pay_type { get; set; }
        /// <summary>
        /// The agreement status. Possible values are A for an active agreement and I for an inactive agreement (equivalent to canceled).
        /// </summary>
        public string mp_status { get; set; }
        /// <summary>
        /// The discount amount for shipping charges in amount, not percentage.
        /// </summary>
        public double shipping_discount { get; set; }
        /// <summary>
        /// A note or memo for the transaction. Applicable only after notify_version >=2.6
        /// </summary>
        public string transaction_subject { get; set; }
        #endregion
        
        #region "subscription variables"
        /// <summary>
        /// (Optional) Amount of payment for trial period 1 for USD payments; otherwise blank.
        /// </summary>
        public double amount1 { get; set; }
        /// <summary>
        /// Optional) Amount of payment for trial period 2 for USD payments; otherwise blank.
        /// </summary>
        public double amount2 { get; set; }
        /// <summary>
        /// Amount of payment for regular subscription period for USD payments; otherwise blank.
        /// </summary>
        public double amount3 { get; set; }
        /// <summary>
        /// (Optional) Amount of payment for trial period 1, regardless of currency.
        /// </summary>
        public double mc_amount1 { get; set; }
        /// <summary>
        /// Optional) Amount of payment for trial period 2, regardless of currency.
        /// </summary>
        public double mc_amount2 { get; set; }
        /// <summary>
        /// Amount of payment for regular subscription period, regardless of currency.
        /// </summary>
        public double mc_amount3 { get; set; }
        /// <summary>
        /// (Optional) Password generated by PayPal and given to subscriber to access the subscription (password will be encrypted). 
        /// Length: 24 characters
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// (Optional) Trial subscription interval in days, weeks, months, years (example: a 4 day interval is "period1: 4 D").
        /// </summary>
        public string period1 { get; set; }
        /// <summary>
        /// (Optional) Trial subscription interval in days, weeks, months, or years.
        /// </summary>
        public string period2 { get; set; }
        /// <summary>
        /// Regular subscription interval in days, weeks, months, or years.
        /// </summary>
        public string period3 { get; set; }
        /// <summary>
        /// Indicates whether reattempts should occur upon payment failures (1 is yes, blank is no).
        /// </summary>
        public int reattempt { get; set; }
        /// <summary>
        /// The number of payment installments that will occur at the regular rate.
        /// </summary>
        public int recur_times { get; set; }
        /// <summary>
        /// Indicates whether regular rate recurs (1 is yes, blank is no).
        /// </summary>
        public int recurring { get; set; }
        /// <summary>
        /// Date PayPal will retry a failed subscription payment.
        /// </summary>
        public DateTime retry_at { get; set; }
        /// <summary>
        /// Start date or cancellation date depending on whether transaction is subscr_signup or subscr_cancel. 
        /// Time/Date stamp generated by PayPal in the format HH:MM:SS Mmm DD, YYYY PDT
        /// </summary>
        public DateTime subscr_date { get; set; }
        /// <summary>
        /// ID generated by PayPal for the subscriber. 
        /// Length: 19 characters
        /// </summary>
        public string subscr_id { get; set; }
        /// <summary>
        /// (Optional) Username generated by PayPal and given to subscriber to access the subscription. 
        /// Length: 64 characters
        /// </summary>
        public string username { get; set; }
        #endregion

        #region "Dispute resolution variables"
        /// <summary>
        /// Notes the buyer entered into the Resolution Center.
        /// </summary>
        public string buyer_additional_information { get; set; }
        /// <summary>
        /// Date and time case was registered in the format HH:MM:SS Mmm DD, YYYY PDT
        /// </summary>
        public DateTime case_creation_date { get; set; }
        /// <summary>
        /// Case identification number. 
        /// Format: PP-D-nD-nn-nnn-nnn-nnn where n is any numeric character.
        /// </summary>
        public string case_id { get; set; }
        /// <summary>
        /// chargeback: A buyer has filed a chargeback with his credit card company, which has notified PayPal of the reason for the chargeback.
        /// complaint: A buyer has logged a complaint through the PayPal Resolution Center.
        /// dispute: A buyer and seller post communications to one another through the Resolution Center to try to work out issues without intervention by PayPal.
        /// bankreturn: An ACH return was initiated from the buyer's bank, and the money was removed from the seller's PayPal account.
        /// </summary>
        public string case_type { get; set; }
        #endregion

        #region "Global shipping program message variables"
        /// <summary>
        /// Country of fulfillment center address Length: 64 characters
        /// </summary>
        public string fulfillment_address_country { get; set; }
        /// <summary>
        /// City of fulfillment center address Length: 40 characters
        /// </summary>
        public string fulfillment_address_city { get; set; }
        /// <summary>
        /// ISO 3166 country code associated with fulfillment center address Length: 2 characters
        /// </summary>
        public string fulfillment_address_country_code { get; set; }
        /// <summary>
        /// Name used with fulfillment center address Length: 128 characters
        /// </summary>
        public string fulfillment_address_name { get; set; }
        /// <summary>
        /// State of fulfillment center address Length: 40 characters
        /// </summary>
        public string fulfillment_address_state { get; set; }
        /// <summary>
        /// Street of fulfillment center address Length: 200 characters
        /// </summary>
        public string fulfillment_address_street { get; set; }
        /// <summary>
        /// Zip code of fulfillment center address Length: 20 characters
        /// </summary>
        public string fulfillment_address_zip { get; set; }
        #endregion

        #region "Pay message variables"
        //todo: add pay message variables
        #endregion

        #region "Preapproval message variables"
        //todo: add preapproval variables
        #endregion

        #region "Adaptive accounts IPN messages"
        //todo: add Adaptive accounts IPN messages variables
        #endregion



        public int btn_id { get; set; }
        /// <summary>
        ///  raw body that came in from form data.  You can use this to process any variables that were missed by this class/de-serialization
        /// </summary>
        public string rawBody { get; set; }
    }
}
