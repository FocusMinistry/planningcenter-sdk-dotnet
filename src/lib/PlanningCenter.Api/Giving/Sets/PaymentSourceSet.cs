using PlanningCenter.Api.Giving.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningCenter.Api.Sets;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.Giving.Models;
using PlanningCenter.Api.Giving.Models.Internal;

namespace PlanningCenter.Api.Giving.Sets {
    public class PaymentSourceSet : BaseSet<PaymentSource> {
        public PaymentSourceSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the payment sources in PCO
        /// </summary>
        /// <returns>A collection of payment sources</returns>
        public async Task<IPlanningCenterRestResponse<List<PaymentSource>>> FindAsync() {
            return await base.FindAsync($"/giving/v2/payment_sources");
        }

        /// <summary>
        /// Creates a new payment source in PCO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The newly created Payment Source</returns>
        public async Task<IPlanningCenterRestResponse<PaymentSource>> CreateAsync(PaymentSource entity) {
            return await base.PostAsync<InternalPaymentSource, PaymentSource>(new InternalPaymentSource(entity), "/giving/v2/payment_sources");
        }
    }
}