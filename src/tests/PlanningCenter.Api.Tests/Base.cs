using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api;

namespace PlanningCenter.Api.Tests {
    public class Base {
        public PlanningCenterOptions Options;
        public PlanningCenterClient Client;

        public Base() {
            Options = new PlanningCenterOptions
            {
                ApiUrl = "https://api.planningcenteronline.com",
                ClientID = "bd8e6a7444956c44eeb137bcd767d334c43f379f02809dace78915b142a42944",
                ClientSecret = "bf60ccd70dabb0bf6d30913d9588bc7421e1fbca6c9cd1f72a4feed5723ef3c0"
            };
        }

        public void PopulateClient(PlanningCenterClient client) {
            Client = client;
        }
    }
}
