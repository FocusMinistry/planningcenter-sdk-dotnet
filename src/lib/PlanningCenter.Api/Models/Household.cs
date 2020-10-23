using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Api.Models {
    public class Household : BaseModel {
        public Household() {
            People = new Relationship<List<Person>>();
            Type = "Household";
        }

        public string Name { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("primary_contact_name")]
        public string PrimaryContactName { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("primary_contact_id")]
        public int PrimaryContactID { get; set; }

        [JsonProperty("primary_contact")]
        public Relationship<Lookup> PrimaryContact { get; set; }

        [JsonProperty("people")]
        public Relationship<List<Person>> People { get; set; }
    }
}
