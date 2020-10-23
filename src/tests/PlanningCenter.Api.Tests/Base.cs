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
                ClientID = "",
                ClientSecret = ""
            };
        }

        public void PopulateClient(PlanningCenterClient client) {
            Client = client;
        }
    }
}
