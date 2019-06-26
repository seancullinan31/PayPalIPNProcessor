using System;
namespace PayPalIPNProcessor.Models
{
    public class PayPalIPNRequest
    {
        public string txn_type { get; set; }
        public string transaction_subject { get; set; }
        public DateTime payment_date { get; set; }
        public string subscr_id { get; set; }
        public string last_name { get; set; }
        public string residence_country { get; set; }
        public string item_name { get; set; }
        public double payment_gross { get; set; }
        public string mc_currency { get; set; }
        public string business { get; set; }
        public string payment_type { get; set; }
        public string protection_eligibility { get; set; }
        public string verify_sign { get; set; }
        public int test_ipn { get; set; }
        public string payer_email { get; set; }
        public string receiver_email { get; set; }
        public string first_name { get; set; }
        public string parent_txn_id { get; set; }
        public string payer_id { get; set; }
        public string receiver_id { get; set; }
        public string reason_code { get; set; }
        public string contact_phone { get; set; }
        public string item_number { get; set; }
        public string payment_status { get; set; }
        public double payment_fee { get; set; }
        public double mc_fee { get; set; }
        public int btn_id { get; set; }
        public double mc_gross { get; set; }
        public string charset { get; set; }
        public string notify_version { get; set; }
        public string ipn_track_id { get; set; }
        public double amount3 { get; set; }
        public int recurring { get; set; }
        public string payer_status { get; set; }
        public int reattempt { get; set; }
        public DateTime subscr_date { get; set; }
        public string period3 { get; set; }
        public double mc_amount3 { get; set; }
        public string txn_id { get; set; }
        public string rawBody { get; set; }
    }
}
