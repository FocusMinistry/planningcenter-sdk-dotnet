using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Api.Models {
    public class Address : BaseModel {
        public Address() {
            Type = "Address";
        }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Street { get; set; }

        public string Location { get; set; }

        public bool Primary { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
