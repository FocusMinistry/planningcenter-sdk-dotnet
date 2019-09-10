using PlanningCenter.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Sets {
    public class EmailSet : BaseSet<Email> {
        public EmailSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the people in PCO
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<Email>>> FindAsync(int personId) {
            return await base.FindAsync($"/people/v2/people{personId}/emails");
        }

        public async Task<IPlanningCenterRestResponse<Email>> CreateAsync(Email entity, int personId) {
            return await base.PostAsync(entity, $"/people/v2/people/{personId}/emails");
        }

        public async Task<IPlanningCenterRestResponse<Email>> UpdateAsync(Email entity) {
            return await base.PatchAsync(entity, $"/people/v2/emails/{entity.Id}");
        }

        public async Task<IPlanningCenterRestResponse> DeleteAsync(int emailId) {
            return await base.DeleteAsync($"/people/v2/people/emails/{emailId}");
        }
    }
}