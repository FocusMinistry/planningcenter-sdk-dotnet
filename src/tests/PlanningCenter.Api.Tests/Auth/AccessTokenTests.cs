using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Tests.Auth {
    [TestFixture]
    public class AccessTokenTests : Base {
        [Test]
        public async Task integration_exchange_auth_code() {
            var response = await PlanningCenterClient.ExchangeAuthTokenAsync(Options,
                "f532cf1b3c4d8e7678dc631f7b1a7c7e6cfbe18e7b2fa84c8d0b022666befe61",
                "http://localhost:49941/ajax/planningcenter/auth");

            response.Data.ShouldNotBeNull();
        }

        [Test]
        public async Task integration_refresh_access_token() {
            var response = await PlanningCenterClient.RefreshAccessTokenAsync(Options, "e46de13f23bf21c2e8de16dc8866459060d6387960d242e3a818375e5c9b31d0");
            response.Data.ShouldNotBeNull();
        }
    }
}
