using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using Newtonsoft.Json;
using JsonApiSerializer.JsonApi;

namespace PlanningCenter.Api.Giving.Models.Internal {
    public class InternalDesignation : BaseModel {
        public InternalDesignation() {
            Type = "Designation";
        }

        public InternalDesignation(Designation designation) : this() {
            AmountCents = designation.AmountCents;
            AmountCurrency = designation.AmountCurrency;
            Fund = new Relationship<Lookup> {
                Data = new Lookup {
                    Id = designation.Fund.Data.Id,
                    Type = "Fund"
                }
            };
        }

        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty("amount_currency")]
        public string AmountCurrency { get; set; }

        [JsonProperty("fund")]
        public Relationship<Lookup> Fund { get; set; }

        public void SetFund(Fund fund) {
            Fund = new Relationship<Lookup> {
                Data = new Lookup {
                    Id = fund.Id,
                    Type = "Fund"
                }
            };
        }
    }
}
