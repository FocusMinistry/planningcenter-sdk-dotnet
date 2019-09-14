using PlanningCenter.Api.Giving.Sets;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Realms {
    public class GivingRealm {
        public GivingRealm(PlanningCenterOptions options, PlanningCenterToken token) {
            Funds = new FundSet(options, token);
            PaymentSources = new PaymentSourceSet(options, token);
            Donations = new DonationSet(options, token);
            Batches = new BatchSet(options, token);
        }

        public FundSet Funds { get; }

        public PaymentSourceSet PaymentSources { get; }

        public DonationSet Donations { get; }

        public BatchSet Batches { get; set; }
    }
}
