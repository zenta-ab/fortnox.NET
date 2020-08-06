using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Communication.TrustedEmailDomains;
using FortnoxNET.Models.TrustedEmailDomains;
using FortnoxNET.Services;
using System.Linq;
using FortnoxNET.Communication;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class TrustedEmailDomainTests : TestBase
    {
        [TestMethod]
        public void GetTrustedEmailDomainsTest()
        {
            var request = new TrustedEmailDomainListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var trustedEmailDomainList = TrustedEmailDomainService.GetTrustedEmailDomainsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(trustedEmailDomainList.Data.ToList().Count >= 0);
        }

        [TestMethod]
        public void GetTrustedEmailDomainTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TrustedEmailDomainService.GetTrustedEmailDomainAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.Id == 1);
        }

        [TestMethod]
        public void CreateAndDeleteTrustedEmailDomainTest()
        {
            //TODO: Avoid cluttering Fortnox with data
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TrustedEmailDomainService.CreateTrustedEmailDomainAsync(request,
                new TrustedEmailDomain
                {
                    Domain = "Domän",
                }).GetAwaiter().GetResult();

            Assert.AreEqual("Domän", response.Domain);
            Assert.IsTrue(response.Id.HasValue);

            TrustedEmailDomainService.DeleteTrustedEmailDomainAsync(request, response.Id.ToString()).GetAwaiter().GetResult();
        }
    }
}