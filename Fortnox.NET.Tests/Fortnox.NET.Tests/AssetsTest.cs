using System;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Assets;
using FortnoxNET.Models.Assets;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AssetsTest : TestBase
    {
        [TestMethod]
        public async Task ItCanGetAssets()
        {
            var request = new AssetListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.GetAssetsAsync(request);
            
            Assert.IsTrue(result.Data.Count() >= 0);
        }

        [TestMethod]
        public async Task ItCanGetAnAsset()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.GetAssetAsync(request, "1");
            
            Assert.AreEqual("1", result.Number);
        }

        [TestMethod]
        public async Task ItCanCreateAndDeleteAnAsset()
        {

            var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var rand = new Random();
            var asset = new Asset()
            {
                Number = "TestProd" + rand.Next(9999999),
                Description = "TEST PRODUCT",
                TypeId = "8",
                DepreciationMethod = "0",
                AcquisitionValue = 13000,
                DepreciateToResidualValue = 1300,
                AcquisitionDate = currentDate.ToString("yyyy-MM-dd"),
                AcquisitionStart = currentDate.AddMonths(1).ToString("yyyy-MM-dd"),
                DepreciationFinal = currentDate.AddYears(1).ToString("yyyy-MM-dd"),
            };

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.CreateAssetAsync(request, asset);
            
            Assert.AreEqual(asset.Number, result.Number);

            await AssetsService.DeleteAssetAsync(request, result.Id.ToString());
        }
        
        [TestMethod]
        public async Task ItCanUpdateAnAsset()
        {
            var updatedDescription = $"Changed {DateTime.UtcNow}";
            var asset = new Asset()
            {
                Id = 1,
                Description = updatedDescription,
            };

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.UpdateAssetAsync(request, asset);
            
            Assert.AreEqual(updatedDescription, result.Description);
        }
    }
}