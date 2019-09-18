using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using Newtonsoft.Json;

namespace PlanningCenter.Api.Giving.Models {
    public class Refund : BaseModel {
        public Refund() {
            Type = "Refund";
        }

        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty("amount_currency")]
        public string AmountCurrency { get; set; }

        [JsonProperty("fee_cents")]
        public int FeeCents { get; set; }

        [JsonProperty("fee_currency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("refunded_at")]
        public DateTime RefundedAt { get; set; }
    }
}