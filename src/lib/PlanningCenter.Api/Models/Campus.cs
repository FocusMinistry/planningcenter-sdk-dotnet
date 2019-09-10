using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlanningCenter.Api.Models {
    public class Campus {
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("twenty_four_hour_time")]
        public bool TwentyFourHourTime { get; set; }

        [JsonProperty("date_format")]
        public int DateFormat { get; set; }

        [JsonProperty("church_center_enabled")]
        public bool ChurchCenterEnabled { get; set; }

        [JsonProperty("contact_email_address")]
        public string ContactEmailAddress { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("geolocation_set_manually")]
        public bool GeoLocationSetManually { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
