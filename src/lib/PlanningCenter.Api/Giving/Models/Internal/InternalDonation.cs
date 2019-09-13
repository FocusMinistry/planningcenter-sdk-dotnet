using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using Newtonsoft.Json;
using JsonApiSerializer.JsonApi;

namespace PlanningCenter.Api.Giving.Models.Internal {
    public class InternalDonation : BaseModel {
        public InternalDonation() {
            Type = "Donation";
            Designations = new List<Designation>();
        }

        public InternalDonation(Donation donation) : this() {
            Id = donation.Id;
            PaymentMethod = donation.PaymentMethod;
            PaymentMethodSub = donation.PaymentMethodSub;
            PaymentLast4 = donation.PaymentLast4;
            PaymentBrand = donation.PaymentBrand;
            PaymentCheckNumber = donation.PaymentCheckNumber;
            PaymentCheckDatedAt = donation.PaymentCheckDatedAt;
            ReceivedAt = donation.ReceivedAt;
            Person = donation.Person;
            Person.Data.Type = "Person";
            PaymentSource = new Relationship<InternalPaymentSource> { Data = new InternalPaymentSource(donation.PaymentSource.Data) };
            Designations = donation.Designations;
        }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

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

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("person")]
        public Relationship<Lookup> Person { get; set; }

        [JsonProperty("payment_source")]
        public Relationship<InternalPaymentSource> PaymentSource { get; set; }

        [JsonProperty("designations")]
        public List<Designation> Designations { get; set; }
    }
}
