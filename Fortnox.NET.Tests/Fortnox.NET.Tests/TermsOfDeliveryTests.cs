using FortnoxNET.Communication;
using FortnoxNET.Communication.TermsOfDelivery;
using FortnoxNET.Models.TermsOfDelivery;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class TermsOfDeliveryTests : TestBase
    {
        [TestMethod]
        public async Task GetTermsOfDeliveriesTest()
        {
            var request = new TermsOfDeliveryListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await TermsOfDeliveryService.GetTermsOfDeliveriesAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetTermsOfDeliveryTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TermsOfDeliveryService.GetTermsOfDeliveryAsync(request, "FK").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "FK");
            Assert.IsTrue(response.Description == "Fritt kund");
        }

        //[TestMethod]
        //public void CreateTermsOfDeliveryTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = TermsOfDeliveryService.CreateTermsOfDeliveryAsync(request,
        //        new TermsOfDelivery
        //        {
        //            Code = "TEST",
        //            Description = "Test Delivery",
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual("TEST", response.Code);
        //    Assert.AreEqual("Test Delivery", response.Description);
        //}

        [TestMethod]
        public void UpdateTermsOfDeliveryTest()
        {
            var description = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var termsOfDelivery = new TermsOfDelivery { Code = "TEST", Description = description };

            var updatedTermsOfDelivery = TermsOfDeliveryService.UpdateTermsOfDeliveryAsync(request, termsOfDelivery).GetAwaiter().GetResult();

            Assert.AreEqual(description, updatedTermsOfDelivery.Description);
        }
    }
}
