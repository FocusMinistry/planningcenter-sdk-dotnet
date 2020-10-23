using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Api.Models {
    public class Person : BaseModel {
        public Person() {
            Emails = new List<Email>();
            PhoneNumbers = new List<PhoneNumber>();
            Addresses = new List<Address>();
            Type = "Person";
        }

        [JsonProperty("accounting_administrator")]
        public bool AccountingAdministrator { get; set; }

        [JsonProperty("anniversary")]
        public DateTime? Anniversary { get; set; }

        [JsonProperty("birthdate")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("child")]
        public bool Child { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("grade")]
        public string Grade { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("graduation_year")]
        public int? GraduationYear { get; set; }

        [JsonProperty("inactivated_at")]
        public DateTime? InactivatedAt { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("medical_notes")]
        public string MedicalNotes { get; set; }

        [JsonProperty("membership")]
        public string Membership { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonProperty("passed_background_check")]
        [JsonIgnore]
        public bool PassedBackgroundCheck { get; set; }

        [JsonProperty("people_permissions")]
        public string PeoplePermissions { get; set; }

        [JsonProperty("remote_id")]
        public string RemoteID { get; set; }

        [JsonProperty("school_type")]
        public string SchoolType { get; set; }

        [JsonProperty("site_administrator")]
        public bool SiteAdministrator { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_at")]
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("demographic_avatar_url")]
        public string DemographicAvatarUrl { get; set; }

        [JsonProperty("primary_campus")]
        [JsonIgnore]
        public Relationship<Lookup> Campus { get; set; }

        [JsonProperty("emails")]
        public List<Email> Emails { get; set; }

        [JsonProperty("phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }

        [JsonProperty("households")]
        public List<Household> Households { get; set; }
    }
}
