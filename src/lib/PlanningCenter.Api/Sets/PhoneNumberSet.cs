using PlanningCenter.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Sets {
    public class PhoneNumberSet : BaseSet<PhoneNumber> {
        public PhoneNumberSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the people in PCO
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<PhoneNumber>>> FindAsync(int personId) {
            return await base.FindAsync($"/people/v2/people{personId}/phone_numbers");
        }

        public async Task<IPlanningCenterRestResponse<PhoneNumber>> CreateAsync(PhoneNumber entity, int personId) {
            return await base.PostAsync(entity, $"/people/v2/people/{personId}/phone_numbers");
        }

        public async Task<IPlanningCenterRestResponse<PhoneNumber>> UpdateAsync(PhoneNumber entity, int personId) {
            return await base.PatchAsync(entity, $"/people/v2/people/{personId}/phone_numbers/{entity.Id}");
        }

        public async Task<IPlanningCenterRestResponse> DeleteAsync(int phoneNumberId, int personId) {
            return await base.DeleteAsync($"/people/v2/people/{personId}/phone_numbers/{phoneNumberId}");
        }
    }
}