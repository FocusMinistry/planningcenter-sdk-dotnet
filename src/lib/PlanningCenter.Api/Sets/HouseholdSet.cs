using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.QueryObjects;

namespace PlanningCenter.Api.Sets {
    public class HouseholdSet : BaseSet<Household> {
        public HouseholdSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        public async Task<IPlanningCenterRestResponse<Household>> CreateAsync(Household entity) {
            return await base.PostAsync(entity, "/people/v2/households");
        }
    }
}