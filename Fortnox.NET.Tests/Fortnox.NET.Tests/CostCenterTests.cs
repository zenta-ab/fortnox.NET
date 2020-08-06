using FortnoxNET.Communication;
using FortnoxNET.Communication.CostCenter;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Models.CostCenter;
using System;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CostCenterTests : TestBase
    {
        [TestMethod]
        public async Task GetCostCentersTest()
        {
            var request = new CostCenterListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await CostCenterService.GetCostCentersAsync(request);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCostCenterTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CostCenterService.GetCostCenterAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "1");
        }

        [TestMethod]
        public void CreateCostCenterTest()
        {
            //TODO: Avoid cluttering Fortnox with data
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CostCenterService.CreateCostCenterAsync(request,
                new CostCenter
                {
                    Code = "K3",
                    Description = "Kassa 3",
                }).GetAwaiter().GetResult();

            Assert.AreEqual("K3", response.Code);

            CostCenterService.DeleteCostCenterAsync(request, "K3").GetAwaiter().GetResult();
        }

        [TestMethod]
        public void DeleteCostCenterTest()
        {
            //TODO: Avoid cluttering Fortnox with data
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CostCenterService.CreateCostCenterAsync(request,
                new CostCenter
                {
                    Code = "TEMP",
                    Description = "To be removed..",
                }).GetAwaiter().GetResult();

            Assert.AreEqual("TEMP", response.Code);

            CostCenterService.DeleteCostCenterAsync(request, "TEMP").GetAwaiter().GetResult();
        }

        [TestMethod]
        public void UpdateCostCenterTest()
        {
            var desc = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var CostCenter = new CostCenter { Code = "1", Description = desc};

            var updatedCostCenter = CostCenterService.UpdateCostCenterAsync(request, CostCenter).GetAwaiter().GetResult();

            Assert.AreEqual(desc, updatedCostCenter.Description);
        }
    }
}
