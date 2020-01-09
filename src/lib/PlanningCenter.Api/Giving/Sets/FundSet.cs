using PlanningCenter.Api.Giving.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningCenter.Api.Sets;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Sets {
    public class FundSet : BaseSet<Fund> {
        public FundSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the funds in PCO
        /// </summary>
        /// <returns>A collection of funds</returns>
        public async Task<IPlanningCenterRestResponse<List<Fund>>> FindAsync(int pageNumber = 1, int pageSize = 100) {
            return await base.FindAsync($"/giving/v2/funds", new QueryObjects.BaseQO { PageNumber = pageNumber, PageSize = pageSize });
        }
    }
}