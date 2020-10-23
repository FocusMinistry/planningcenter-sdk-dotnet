using System;
using PlanningCenter.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Sets {
    public class MembershipStatusSet : BaseSet<MembershipStatus> {
        public MembershipStatusSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the campuses in PCO
        /// </summary>
        /// <returns>A collection of campuses</returns>
        public async Task<IPlanningCenterRestResponse<List<MembershipStatus>>> FindAsync() {
            return await base.FindAsync($"/people/v2/membership_statuses");
        }
    }
}