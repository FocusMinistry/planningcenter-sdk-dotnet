using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using Newtonsoft.Json;
using JsonApiSerializer.JsonApi;

namespace PlanningCenter.Api.Giving.Models {
    public class Donation : BaseModel {
        public Donation() {
            Type = "Donation";
            Designations = new List<Designation>();
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// For cards only. Will be null for other payment method types. Possible values: credit, debit, prepaid, or unknown
        /// </summary>
        [JsonProperty("payment_method_sub")]
        public string PaymentMethodSub { get; set; }

        [JsonProperty("payment_last4")]
        public string PaymentLast4 { get; set; }

        /// <summary>
        /// For cards, this is the card brand (eg Visa, Mastercard, etc). For checks, this is the bank name
        /// </summary>
        [JsonProperty("payment_brand")]
        public string PaymentBrand { get; set; }

        [JsonProperty("payment_check_number")]
        public int? PaymentCheckNumber { get; set; }

        [JsonProperty("payment_check_dated_at")]
        public string PaymentCheckDatedAt { get; set; }

        [JsonProperty("fee_cents")]
        public int FeeCents { get; set; }

        /// <summary>
        /// Possible values: ach, cash, check, or card
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }

        /// <summary>
        /// Read only. One of pending, succeeded, failed, or unknown.For Stripe donations, this is the payment status. For batch donations, pending and succeeded values are dependent on whether the batch has been committed.
        /// </summary>
        [JsonProperty("payment_status")]
        public string PaymentStatus { get; set; }

        [JsonProperty("amount_currency")]
        public string AmountCurrency { get; set; }

        [JsonProperty("fee_currency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("refunded")]
        public bool Refunded { get; set; }

        /// <summary>
        /// ead only. A boolean indicating whether this donation can be refunded via the API. Note that for some donations, this may be false, even though the donation can be refunded in the UI.
        /// </summary>
        [JsonProperty("refundable")]
        public bool Refundable { get; set; }

        [JsonProperty("person")]
        public Relationship<Lookup> Person { get; set; }

        [JsonProperty("payment_source")]
        public Relationship<PaymentSource> PaymentSource { get; set; }

        [JsonProperty("designations")]
        public List<Designation> Designations { get; set; }

        public void SetPerson(Lookup person) {
            Person = new Relationship<Lookup> {
                Data = person
            };
        }

        public void SetPaymentSource(PaymentSource paymentSource) {
            PaymentSource = new Relationship<PaymentSource> {
                Data = paymentSource
            };
        }
    }
}