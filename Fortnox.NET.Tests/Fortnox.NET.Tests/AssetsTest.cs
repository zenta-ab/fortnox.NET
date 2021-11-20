using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.NET.Models.Assets;
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
                AcquisitionDate = currentDate,
                AcquisitionStart = currentDate.AddMonths(1),
                DepreciationFinal = currentDate.AddYears(1),
            };

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.CreateAssetAsync(request, asset);

            await AssetsService.DeleteAssetAsync(request, result.Id.ToString());
            
            Assert.AreEqual(asset.Number, result.Number);
        }
        
        //[TestMethod]
        //public async Task ItCanUpdateAnAsset()
        //{
        //    var updatedDescription = $"Changed {DateTime.UtcNow}";
        //    var asset = new Asset()
        //    {
        //        Id = 1,
        //        Description = updatedDescription,
        //    };

        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var result = await AssetsService.UpdateAssetAsync(request, asset);
            
        //    Assert.AreEqual(updatedDescription, result.Description);
        //}

        //[TestMethod]
        //public async Task ItCanWriteUpAndDownAnAsset()
        //{
        //    var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var result = await AssetsService.GetAssetAsync(request, "4");

        //    Assert.AreEqual("2", result.Number);

        //    var writeUp = new WriteUpOrDownAsset { Amount = 300, Comment = "WriteUp, Possible comment", Date = currentDate.AddMonths(1)};
        //    var writeUpAsset = await AssetsService.WriteUpAssetAsync(request, $"{result.Id}", writeUp);

        //    var latestWriteUp = writeUpAsset.History.Where(e => e.Date.Equals(writeUp.Date)).First();
        //    Assert.IsTrue(latestWriteUp.Notes.Contains(writeUp.Comment));

        //    var writeDown = new WriteUpOrDownAsset { Amount = 200, Comment = "WriteDown, Possible comment", Date = currentDate.AddMonths(1) };
        //    var writeDownAsset = await AssetsService.WriteDownAssetAsync(request, $"{result.Id}", writeDown);

        //    var latestWriteDown = writeDownAsset.History.Where(e => e.Date.Equals(writeDown.Date)).Last();
        //    Assert.IsTrue(latestWriteDown.Notes.Contains(writeDown.Comment));
        //}

        [TestMethod]
        public async Task ItCanScrapAnAsset()
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
                AcquisitionDate = currentDate,
                AcquisitionStart = currentDate.AddMonths(1),
                DepreciationFinal = currentDate.AddYears(1),
            };

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.CreateAssetAsync(request, asset);

            Assert.AreEqual(asset.Number, result.Number);

            var scrapAsset = new AssetScrap { Percentage = 5, Comment = "Scrap comment", Date = currentDate.AddMonths(1) };
            var scrappedAsset = await AssetsService.ScrapAssetAsync(request, $"{result.Id}", scrapAsset);

            await AssetsService.DeleteAssetAsync(request, result.Id.ToString());
        }

        [TestMethod]
        public async Task ItCanSellAnAsset()
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
                AcquisitionDate = currentDate,
                AcquisitionStart = currentDate.AddMonths(1),
                DepreciationFinal = currentDate.AddYears(1),
            };

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var result = await AssetsService.CreateAssetAsync(request, asset);

            Assert.AreEqual(asset.Number, result.Number);

            var sellAsset = new SellAsset { Percentage = 0, Price = 10000, Comment = "Sell comment", Date = currentDate.AddMonths(1).ToString("yyyy-MM-dd") };
            var soldAsset = await AssetsService.SellAssetAsync(request, $"{result.Id}", sellAsset);
        }

        //[TestMethod]
        //public async Task ItCanDepreciateAnAsset()
        //{

        //    var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        //    var rand = new Random();
        //    var asset = new Asset()
        //    {
        //        Number = "TestProd" + rand.Next(9999999),
        //        Description = "TEST PRODUCT",
        //        TypeId = "8",
        //        DepreciationMethod = "0",
        //        AcquisitionValue = 13000,
        //        DepreciateToResidualValue = 1300,
        //        AcquisitionDate = currentDate,
        //        AcquisitionStart = currentDate.AddMonths(1),
        //        DepreciationFinal = currentDate.AddYears(1),
        //    };

        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var result = await AssetsService.CreateAssetAsync(request, asset);

        //    Assert.AreEqual(asset.Number, result.Number);

        //    var depreciationDate = currentDate.AddMonths(2);
        //    depreciationDate = new DateTime(depreciationDate.Year, depreciationDate.Month, DateTime.DaysInMonth(depreciationDate.Year, depreciationDate.Month));
        //    var assetDepreciation = new DepreciateAssets { DepreciateUntil = depreciationDate, AssetIds = new List<int> { result.Id } };
        //    var depreciatedAssetResponse = await AssetsService.DepreciateAssetAsync(request, assetDepreciation);

        //    var depreciationResult = depreciatedAssetResponse.Data.First();
        //    Assert.IsTrue(depreciationResult.FinancialYear == 3);
        //    Assert.IsTrue(depreciationResult.VoucherSeries.Equals("G"));
        //}
    }
}