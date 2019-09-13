using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models {
    public class PaymentSource {
        public PaymentSource() {
        }

        [JsonProperty("type")]
        public string Type { get; set; } = "PaymentSource";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
