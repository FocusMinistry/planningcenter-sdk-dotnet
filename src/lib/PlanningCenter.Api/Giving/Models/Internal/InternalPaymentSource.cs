using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models.Internal {
    internal class InternalPaymentSource {
        public InternalPaymentSource() { }

        public InternalPaymentSource(PaymentSource paymentSource) : this() {
            Id = paymentSource.Id;
            Name = paymentSource.Name;
        }

        [JsonProperty("type")]
        public string Type { get; set; } = "PaymentSource";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
