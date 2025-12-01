using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Communication.Order;
using FortnoxNET.Models.Authorization;
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
        public void BuildAuthorizationCodeURL_WithServiceAccountType()
        {
            var authCodeURL = AuthorizationService.GetAuthorizationUrl("MyClientId", "https://www.example.com/auth", "customerinformation", "StateValue", "service");

            var expectedURL = "https://apps.fortnox.se/oauth-v1/auth?&client_id=MyClientId&scope=customerinformation&state=StateValue&access_type=offline&response_type=code&redirect_uri=https%3a%2f%2fwww.example.com%2fauth&account_type=service";
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

        [TestMethod]
        public async Task GetServiceAccountToken()
        {
            var ClientId = "Test";
            var ClientSecret = "Test";
            var TenantId = 123456789L;

            var serviceAccountToken = await AuthorizationService.GetServiceAccountTokenAsync(ClientId, ClientSecret, TenantId);

            // Verify token properties
            Assert.IsNotNull(serviceAccountToken);
            Assert.IsNotNull(serviceAccountToken.AccessToken);
            Assert.AreEqual("Bearer", serviceAccountToken.TokenType);
            Assert.IsTrue(serviceAccountToken.ExpiresIn > 0);

            // NOTE: Example list request using service account token
            // Service account tokens use access_token directly without client_secret for API calls
            {
                var request = new OrderListRequest(serviceAccountToken.AccessToken, ClientSecret);
                var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();

                Assert.IsTrue(orders.Data.ToList().Count > 0);
            }

            // NOTE: Example single request using service account token
            {
                var request = new OrderListRequest(serviceAccountToken.AccessToken, ClientSecret);
                var response = OrderService.GetOrderAsync(request, 1).GetAwaiter().GetResult();

                Assert.IsTrue(response.DocumentNumber == 1);
                Assert.IsTrue(response.OrderRows.Count() == 2);
            }
        }
    }
}
