using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using PlanningCenter.Api;

namespace PlanningCenter.Api.Tests.Sets {
    public class PeopleSetTests : Base {

        [OneTimeSetUp]
        public void OneTimeSetup() {
            PopulateClient(new PlanningCenterClient(Options, new Models.PlanningCenterToken {
                access_token = "05f878e42b185843b3d8a9b5b6cf411ac83ce82c876a169c801d24ae975ed83c",
                refresh_token = "31437de3c021571b82a43489cd1cfc5711b8f85e8386ee184440ed8867b09465"
            }));
        }

        [Test]
        public async Task integration_people_get_all() {
            var peopleResult = await Client.People.FindAsync();
            peopleResult.IsSuccessful.ShouldBeTrue();
        }

        [Test]
        public async Task integration_people_get_me() {
            var peopleResult = await Client.People.MeAsync();
            peopleResult.IsSuccessful.ShouldBeTrue();
        }
    }
}