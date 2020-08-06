using FortnoxNET.Communication;
using FortnoxNET.Communication.WayOfDelivery;
using FortnoxNET.Models.WayOfDelivery;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class WayOfDeliveryTests : TestBase
    {
        [TestMethod]
        public async Task GetWayOfDeliveriesTest()
        {
            var request = new WayOfDeliveryListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await WayOfDeliveryService.GetWayOfDeliveriesAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetWayOfDeliveryTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = WayOfDeliveryService.GetWayOfDeliveryAsync(request, "P").GetAwaiter().GetResult();

            Assert.IsTrue(response.Description == "Post");
        }

        //[TestMethod]
        //public void CreateWayOfDeliveryTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = WayOfDeliveryService.CreateWayOfDeliveryAsync(request,
        //        new WayOfDelivery
        //        {
        //            Code = "TEST",
        //            Description = "Testing Way Of Delivery",
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual("TEST", response.Code);
        //}

        [TestMethod]
        public void DeleteWayOfDeliveryTest()
        {
            //TODO: Avoid cluttering Fortnox with data
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = WayOfDeliveryService.CreateWayOfDeliveryAsync(request,
                new WayOfDelivery
                {
                    Code = "DEL",
                    Description = "Will Be deleted"
                }).GetAwaiter().GetResult();

            Assert.AreEqual("DEL", response.Code);

            WayOfDeliveryService.DeleteWayOfDeliveryAsync(request, response.Code).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void UpdateSupplierInvoicePaymentTest()
        {
            var desc = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var wayOfDelivery= new WayOfDelivery{ Code = "TEST", Description = desc};

            var updatedWayOfDelivery = WayOfDeliveryService.UpdateWayOfDeliveryAsync(request, wayOfDelivery).GetAwaiter().GetResult();

            Assert.AreEqual(desc, updatedWayOfDelivery.Description);
        }
    }
}
