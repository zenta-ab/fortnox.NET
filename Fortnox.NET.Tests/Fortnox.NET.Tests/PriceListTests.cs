using FortnoxNET.Communication;
using FortnoxNET.Communication.PriceList;
using FortnoxNET.Models.PriceList;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class PriceListTests : TestBase
    {
        [TestMethod]
        public async Task GetPriceListsTest()
        {
            var request = new PriceListListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await PriceListService.GetPriceListsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetPriceListTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = PriceListService.GetPriceListAsync(request, "A").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "A");
        }

        //[TestMethod]
        //public void CreatePriceListTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = PriceListService.CreatePriceListAsync(request,
        //        new PriceList
        //        {
        //            Code = "AB",
        //            Description = "Prislista AB",
        //            Comments = ""
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual("AB", response.Code);
        //}

        [TestMethod]
        public void UpdatePriceListTest()
        {
            var description = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var priceList = new PriceList { Code = "AB", Description = description};

            var updatedPriceList = PriceListService.UpdatePriceListAsync(request, priceList).GetAwaiter().GetResult();

            Assert.AreEqual(description, updatedPriceList.Description);
        }
    }
}
