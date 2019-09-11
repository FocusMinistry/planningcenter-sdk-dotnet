using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace PlanningCenter.Api.Models.Internal {
    internal class InternalPhoneNumber : BaseModel {
        public InternalPhoneNumber() {
            Type = "PhoneNumber";
        }

        public InternalPhoneNumber(PhoneNumber phoneNumber) : this() {
            Id = phoneNumber.Id;
            Number = phoneNumber.Number;
            Carrier = phoneNumber.Carrier;
            Location = phoneNumber.Location;
            Primary = phoneNumber.Primary;
        }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
