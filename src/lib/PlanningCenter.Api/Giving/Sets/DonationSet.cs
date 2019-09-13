using PlanningCenter.Api.Giving.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningCenter.Api.Sets;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.Giving.Models.Internal;

namespace PlanningCenter.Api.Giving.Sets {
    public class DonationSet : BaseSet<Donation> {
        public DonationSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the donations in PCO
        /// </summary>
        /// <returns>A collection of donations</returns>
        public async Task<IPlanningCenterRestResponse<List<Donation>>> FindAsync() {
            return await base.FindAsync($"/giving/v2/donations");
        }

        /// <summary>
        /// Create a donation in PCO
        /// </summary>
        /// <returns>The newly created donation</returns>
        public async Task<IPlanningCenterRestResponse<Donation>> CreateAsync(Donation entity) {
            return await base.PostAsync<InternalDonation, Donation>(new InternalDonation(entity), $"/giving/v2/donations");
        }
    }
}