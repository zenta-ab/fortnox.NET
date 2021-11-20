using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Communication.Order;
using FortnoxNET.Services;
using FortnoxNET.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Fortnox.NET.Tests.Authorization
{
    // NOTE(Oskar): The current test suite wont be able to provide unit tests for this as of now. In the future we will
    // probably have to mock some of the calls for this to work on other developers machines. For now this is to provide
    // an implementation reference for users.
    [TestClass]
    public class AuthorizationTests : TestBase
    {
        [TestMethod]
        public void BuildAuthorizationCodeURL()
        {
            var authCodeURL = AuthorizationService.GetAuthorizationUrl("MyClientId", "https://www.example.com/auth", "customerinformation", "StateValue");

            var expectedURL = "https://apps.fortnox.se/oauth-v1/auth?&client_id=MyClientId&scope=customerinformation&state=StateValue&access_type=offline&response_type=code&redirect_uri=https%3a%2f%2fwww.example.com%2fauth";
            Assert.AreEqual(authCodeURL, expectedURL);
        }

        [TestMethod]
        public async Task GetAccessToken()
        {
            var AuthorizationCode = "Redacted";
            var ClientId = "Redacted";
            var ClientSecret = "Redacted";
            var ReturnURL = "Redacted";
            var oAuthToken = await AuthorizationService.GetAccessTokenAsync(AuthorizationCode, ClientId, ClientSecret, ReturnURL);

            // NOTE(Oskar): Example list request
            {
                var request = new OrderListRequest(oAuthToken);
                var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();

                Assert.IsTrue(orders.Data.ToList().Count > 0);
            }

            // NOTE(Oskar): Example single request
            {
                var request = new OrderListRequest(oAuthToken);
                var response = OrderService.GetOrderAsync(request, 1).GetAwaiter().GetResult();

                Assert.IsTrue(response.DocumentNumber == 1);
                Assert.IsTrue(response.OrderRows.Count() == 2);
            }
        }
    }
}
