using Newtonsoft.Json;

namespace PlanningCenter.Api.Models {
    public class MembershipStatus : BaseModel {
        public MembershipStatus() {
            Type = "MembershipStatus";
        }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
