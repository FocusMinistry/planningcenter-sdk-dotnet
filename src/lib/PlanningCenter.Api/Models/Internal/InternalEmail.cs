using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;

namespace PlanningCenter.Api.Models.Internal {
    internal class InternalEmail : BaseModel {
        public InternalEmail() {
            Type = "Email";
        }

        public InternalEmail(Email email) : this() {
            Id = email.Id;
            Address = email.Address;
            Location = email.Location;
            Primary = email.Primary;
        }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
