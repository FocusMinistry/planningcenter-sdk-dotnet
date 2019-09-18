using System;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models {
    public class Batch : BaseModel {
        public Batch() {
            Type = "Batch";
        }

        [JsonProperty("total_cents")]
        public int TotalCents { get; set; }

        [JsonProperty("total_currency")]
        public string TotalCurrency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("committed_at")]
        public DateTime? CommittedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("batch_group")]
        public Relationship<BatchGroup> BatchGroup { get; set; }
    }
}
