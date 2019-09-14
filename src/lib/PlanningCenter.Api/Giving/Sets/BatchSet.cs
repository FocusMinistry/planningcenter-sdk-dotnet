using PlanningCenter.Api.Giving.Models;
using PlanningCenter.Api.Giving.Models.Internal;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.Sets;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PlanningCenter.Api.Giving.Sets {
    public class BatchSet : BaseSet<Batch> {
        public BatchSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the batch in PCO
        /// </summary>
        /// <returns>A collection of donations</returns>
        public async Task<IPlanningCenterRestResponse<List<Batch>>> FindAsync() {
            return await base.FindAsync($"/giving/v2/batches");
        }

        /// <summary>
        /// Create a batch in PCO
        /// </summary>
        /// <returns>The newly created batch</returns>
        public async Task<IPlanningCenterRestResponse<Batch>> CreateAsync(Batch entity) {
            return await base.PostAsync<InternalBatch, Batch>(new InternalBatch(entity), $"/giving/v2/batches");
        }

        /// <summary>
        /// Get a batch from PCO
        /// </summary>
        /// <returns>A collection of donations</returns>
        public async Task<IPlanningCenterRestResponse<Batch>> GetAsync(int id) {
            return await base.GetAsync($"/giving/v2/batches/{id}");
        }

        /// <summary>
        /// Commits an uncommitted batch to PCO
        /// </summary>
        /// <returns></returns>
        public async Task<IPlanningCenterRestResponse> CommitAsync(int id) {
            return await base.PostAsync($"/giving/v2/batches/{id}/commit");
        }
    }
}
