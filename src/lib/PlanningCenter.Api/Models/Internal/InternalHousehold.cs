﻿using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PlanningCenter.Api.Models.Internal {
    internal class InternalHousehold : BaseModel {
        public InternalHousehold() {
            People = new Relationship<List<Lookup>>();
            Type = "Household";
        }

        public InternalHousehold(Household household) : this() {
            Id = household.Id;
            Name = household.Name;
            MemberCount = household.MemberCount;
            PrimaryContactID = household.PrimaryContactID;
            PrimaryContact = household.PrimaryContact;
            People = new Relationship<List<Lookup>> { Data = household.People.Data.Select(x => new Lookup { Type = x.Type, Id = x.Id }).ToList() };
        }

        public string Name { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("primary_contact_id")]
        public int PrimaryContactID { get; set; }

        [JsonProperty("primary_contact")]
        public Relationship<Lookup> PrimaryContact { get; set; }

        [JsonProperty("people")]
        public Relationship<List<Lookup>> People { get; set; }
    }
}
