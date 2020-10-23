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
                access_token = "",
                refresh_token = ""
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