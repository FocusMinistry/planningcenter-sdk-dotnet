using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models {
    public class Designation : BaseModel {
        public Designation() {
            Type = "Designation";
        }

        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty("amount_currency")]
        public string AmountCurrency { get; set; }

        [JsonProperty("fund")]
        public Relationship<Fund> Fund { get; set; }

        public void SetFund(Fund fund) {
            Fund = new Relationship<Fund> {
                Data = fund
            };
        }
    }
}