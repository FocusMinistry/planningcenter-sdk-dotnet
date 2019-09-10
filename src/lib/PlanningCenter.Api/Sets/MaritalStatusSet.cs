using PlanningCenter.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Sets {
    public class MaritalStatusSet : BaseSet<MaritalStatus> {
        public MaritalStatusSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the marital statuses in PCO
        /// </summary>
        /// <returns>A collection of mairtal statuses</returns>
        public async Task<IPlanningCenterRestResponse<List<MaritalStatus>>> FindAsync() {
            return await base.FindAsync($"/people/v2/marital_statuses");
        }
    }
}