using FortnoxNET.Communication;
using FortnoxNET.Communication.VoucherSeries;
using FortnoxNET.Models.VoucherSeries;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class VoucherSeriesTests : TestBase
    {
        [TestMethod]
        public async Task GetVoucherSeriesTest()
        {
            var request = new VoucherSeriesListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await VoucherSeriesService.GetVoucherSeriesAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetSingleVoucherSerieTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = VoucherSeriesService.GetVoucherSerieAsync(request, "A").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "A");
            Assert.IsTrue(response.Description == "Redovisning");
        }

        //[TestMethod]
        //public void CreateVoucherSeriesTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = VoucherSeriesService.CreateVoucherSeriesAsync(request,
        //        new VoucherSeries
        //        {
        //            Code = "X",
        //            Description = "Övriga verifikationer",
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual("X", response.Code);
        //    Assert.AreEqual("Övriga verifikationer", response.Description);
        //}

        [TestMethod]
        public void UpdatePriceListTest()
        {
            var description = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var voucherSeries = new VoucherSeries { Code = "X", Description = description };

            var updatedVoucherSeries = VoucherSeriesService.UpdateVoucherSeriesAsync(request, voucherSeries).GetAwaiter().GetResult();

            Assert.AreEqual(description, updatedVoucherSeries.Description);
        }
    }
}
