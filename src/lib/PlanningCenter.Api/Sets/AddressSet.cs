using PlanningCenter.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Sets {
    public class AddressSet : BaseSet<Address> {
        public AddressSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the people in PCO
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<Address>>> FindAsync(int personId) {
            return await base.FindAsync($"/people/v2/people{personId}/addresses");
        }

        public async Task<IPlanningCenterRestResponse<Address>> CreateAsync(Address entity, int personId) {
            return await base.PostAsync(entity, $"/people/v2/people/{personId}/addresses");
        }

        public async Task<IPlanningCenterRestResponse<Address>> UpdateAsync(Address entity) {
            return await base.PostAsync(entity, $"/people/v2/addresses/{entity.Id}");
        }
    }
}