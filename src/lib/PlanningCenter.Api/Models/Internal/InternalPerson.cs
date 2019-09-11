using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlanningCenter.Api.Models.Internal {
    internal class InternalPerson : BaseModel {
        public InternalPerson() {
            Type = "Person";
        }

        public InternalPerson(Person person) : this() {
            Id = person.Id;
            AccountingAdministrator = person.AccountingAdministrator;
            Anniversary = person.Anniversary;
            BirthDate = person.BirthDate;
            Child = person.Child;
            GivenName = person.GivenName;
            FirstName = person.FirstName;
            Avatar = person.Avatar;
            Grade = person.Grade;
            GraduationYear = person.GraduationYear;
            Gender = person.Gender;
            InactivatedAt = person.InactivatedAt;
            LastName = person.LastName;
            MedicalNotes = person.MedicalNotes;
            Membership = person.Membership;
            MiddleName = person.MiddleName;
            NickName = person.NickName;
            SiteAdministrator = person.SiteAdministrator;
            Status = person.Status;
            Campus = person.Campus;
            RemoteID = person.RemoteID;
            PeoplePermissions = person.PeoplePermissions;
            SchoolType = person.SchoolType;
        }

        [JsonProperty("accounting_administrator")]
        public bool AccountingAdministrator { get; set; }

        [JsonProperty("anniversary")]
        public DateTime? Anniversary { get; set; }

        [JsonProperty("birthdate")]
        public DateTime? BirthDate { get; set; }

        [JsonProperty("child")]
        public bool Child { get; set; }

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

        [JsonProperty("nickname")]
        public string NickName { get; set; }

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

        [JsonProperty("primary_campus")]
        public Relationship<Campus> Campus { get; set; }
    }
}