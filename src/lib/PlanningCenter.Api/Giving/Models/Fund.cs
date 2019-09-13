using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models {
    public class Fund : BaseModel {
        public Fund() {
            Type = "Fund";
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ledger_code")]
        public string LedgerCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("deletable")]
        public bool Deletable { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}