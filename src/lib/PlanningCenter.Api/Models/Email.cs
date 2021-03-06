﻿using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;

namespace PlanningCenter.Api.Models {
    public class Email : BaseModel {
        public Email() {
            Type = "Email";
        }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
