using FortnoxNET.Communication;
using FortnoxNET.Communication.Price;
using FortnoxNET.Models.Price;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class PriceTests : TestBase
    {
        [TestMethod]
        public async Task GetPricesTest()
        {
            var request = new PriceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await PriceService.GetPricesAsync(request, "A");

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetPriceForArticleTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = PriceService.GetPriceForArticleAsync(request, "A", "10", "0").GetAwaiter().GetResult();

            Assert.IsTrue(response.PriceValue == 320);
        }

        [TestMethod]
        public void CreateAndDeletePriceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = PriceService.CreatePriceAsync(request,
                new Price
                {
                    ArticleNumber = "10",
                    FromQuantity = 11,
                    PriceValue = 123,
                    PriceList = "A"
                }).GetAwaiter().GetResult();

            Assert.AreEqual(123, response.PriceValue);

            PriceService.DeletePriceAsync(request, "A", "10", "11").GetAwaiter().GetResult();
        }

        [TestMethod]
        public void UpdatePriceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var price = new Price { ArticleNumber= "9", PriceList = "A", PriceValue = 555};

            var updatedCostCenter = PriceService.UpdatePriceAsync(request, price).GetAwaiter().GetResult();

            Assert.AreEqual(555, updatedCostCenter.PriceValue);
        }
    }
}
