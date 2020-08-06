using FortnoxNET.Communication;
using FortnoxNET.Communication.AssetType;
using FortnoxNET.Models.AssetType;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AssetTypeTests : TestBase
    {
        [TestMethod]
        public async Task GetAssetTypesTest()
        {
            var request = new AssetTypeListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await AssetTypeService.GetAssetTypesAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetAssetTypeTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = AssetTypeService.GetAssetTypeAsync(request, 1).GetAwaiter().GetResult();

            Assert.IsTrue(response.Number == "1030");
            Assert.IsTrue(response.Description == "Patent");
        }

        [TestMethod]
        public void CreateAndDeleteAssertTypeTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = AssetTypeService.CreateAssetTypeAsync(request,
                new AssetType
                {
                    Number = "3346",
                    Description = "asset type description",
                    Notes = "Some notes",
                    Type = 1,
                    AccountAssetId = 1030,
                    AccountDepreciationId = 7813,
                    AccountValueLossId = 1039
                }).GetAwaiter().GetResult();

            Assert.AreEqual("3346", response.Number);

            AssetTypeService.DeleteAssetTypeAsync(request, response.Id.Value).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void UpdateAssertTypeTest()
        {
            var note = $"{DateTime.Now}";

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var assetType = new AssetType {
                Number = "1030", 
                Description = "Patent", 
                Notes = note, 
                AccountAssetId = 1030,
                AccountValueLossId = 1039,
                AccountSaleLossId = 7971,
                AccountSaleWinId = 3971,
                AccountRevaluationId = 2085,
                AccountWriteDownAckId = 1038,
                AccountWriteDownId = 7710,
                AccountDepreciationId = 7813,
            };

            var updatedAssetType = AssetTypeService.UpdateAssetTypeAsync(request, 1, assetType).GetAwaiter().GetResult();

            Assert.AreEqual(1, updatedAssetType.Id);
            Assert.AreEqual("1030", updatedAssetType.Number);
            Assert.AreEqual("Patent", updatedAssetType.Description);
            Assert.AreEqual(note, updatedAssetType.Notes);
        }
    }
}
