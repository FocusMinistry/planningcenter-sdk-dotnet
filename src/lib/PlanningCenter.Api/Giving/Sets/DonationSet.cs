using PlanningCenter.Api.Giving.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningCenter.Api.Sets;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.Giving.Models.Internal;
using PlanningCenter.Api.Models;
using Newtonsoft.Json;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json.Linq;
using JsonApiSerializer;
using System;

namespace PlanningCenter.Api.Giving.Sets {
    public class DonationSet : BaseSet<Donation> {
        public DonationSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the donations in PCO
        /// </summary>
        /// <returns>A collection of donations</returns>
        public async Task<IPlanningCenterRestResponse<List<Donation>>> FindAsync() {
            return await base.FindAsync($"/giving/v2/donations?include=designations");
        }

        /// <summary>
        /// Refund a donation
        /// </summary>
        /// <returns></returns>
        public async Task<IPlanningCenterRestResponse<Refund>> RefundAsync(int donationID, DateTime refundedDate) {
            var json = JObject.FromObject(new {
                data = new {
                    attributes = new {
                        refunded_at = refundedDate.ToString("yyyy-MM-dd")
                    }
                }
            });
            return await base.PostAsync<Refund>($"/giving/v2/donations/{donationID}/issue_refund", JsonConvert.SerializeObject(json));
        }

        /// <summary>
        /// Create a donation in PCO
        /// </summary>
        /// <returns>The newly created donation</returns>
        public async Task<IPlanningCenterRestResponse<Donation>> CreateAsync(Donation entity, int batchID) {
            var root = new DocumentRoot<InternalDonation> {
                Data = new InternalDonation(entity),
                Included = new List<JObject>()
            };

            entity.Designations.ForEach(x => {
                root.Included.Add(JObject.FromObject(new {
                    type = x.Type,
                    attributes = new {
                        amount_cents = x.AmountCents
                    },
                    relationships = new {
                        fund = new {
                            data = new {
                                type = "Fund",
                                id = x.Fund.Data.Id
                            }
                        }
                    }
                }));
            });


            return await base.PostAsync<DocumentRoot<InternalDonation>, Donation>(root, $"/giving/v2/batches/{batchID}/donations");
        }
    }
}