using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Communication.Currency;
using FortnoxNET.Services;
using System.Linq;
using FortnoxNET.Models.Currency;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CurrencyTests : TestBase
    {
        [TestMethod]
        public void GetCurrencyTest()
        {
            var request = new CurrencyListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var currency = CurrencyService.GetCurrencyAsync(request, "SEK").GetAwaiter().GetResult();

            Assert.AreEqual("SEK", currency.Code);
            Assert.AreEqual(1, currency.BuyRate);
            Assert.AreEqual("Svensk krona", currency.Description);
            Assert.AreEqual(false, currency.IsAutomatic);
            Assert.AreEqual(1, currency.SellRate);
            Assert.AreEqual(1, currency.Unit);
            Assert.AreEqual(null, currency.Url);
        }

        [TestMethod]
        public void GetCurrenciesTest()
        {
            var request = new CurrencyListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CurrencyService.GetCurrenciesAsync(request).GetAwaiter().GetResult();
            var currencies = response.Data.ToList();

            Assert.IsTrue(currencies.Any(), "There should be atleast one currency");

            var currency = currencies.First();

            Assert.AreEqual("SEK", currency.Code);
            Assert.AreEqual(1, currency.BuyRate);
            Assert.AreEqual("Svensk krona", currency.Description);
            Assert.AreEqual(false, currency.IsAutomatic);
            Assert.AreEqual(1, currency.SellRate);
            Assert.AreEqual(1, currency.Unit);
            Assert.AreEqual("https://api.fortnox.se/3/currencies/SEK", currency.Url);
        }

        [TestMethod]
        public void UpdateCurrencyTest()
        {
            var code = "SEK";
            var normalDescription = "Svensk krona";
            var changedDescription = "Hagelsprakare";

            var request = new CurrencyListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var currency = CurrencyService.GetCurrencyAsync(request, code).GetAwaiter().GetResult();

            Assert.AreEqual(normalDescription, currency.Description);

            currency.Description = changedDescription;

            var updatedCurrency = CurrencyService.UpdateCurrencyAsync(request, currency).GetAwaiter().GetResult();

            Assert.AreEqual(changedDescription, updatedCurrency.Description);

            currency.Description = normalDescription;

            var revertedCurrency = CurrencyService.UpdateCurrencyAsync(request, currency).GetAwaiter().GetResult();

            Assert.AreEqual(normalDescription, revertedCurrency.Description);
        }

        [TestMethod]
        public void DeleteAndCreateCurrencyTest()
        {
            var newCurrency = new Currency
            {
                BuyRate = 1,
                Code = "DKK",
                Description = "Danks krona",
                SellRate = 1000,
                Unit = 1,
                IsAutomatic = false,
            };

            var request = new CurrencyListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            try
            {
                // delete, or we can't add
                CurrencyService.DeleteCurrencyAsync(request, newCurrency.Code).GetAwaiter().GetResult();
            }
            catch
            {
                // nothing, the currency did not exist
            }
            finally
            {
                var createdCurrency = CurrencyService.CreateCurrencyAsync(request, newCurrency).GetAwaiter().GetResult();
            
                Assert.IsNotNull(createdCurrency);

                Assert.AreEqual(newCurrency.Code, createdCurrency.Code);
                Assert.AreEqual(newCurrency.BuyRate, createdCurrency.BuyRate);
                Assert.AreEqual(newCurrency.Description, createdCurrency.Description);
                Assert.AreEqual(newCurrency.IsAutomatic, createdCurrency.IsAutomatic);
                Assert.AreEqual(newCurrency.SellRate, createdCurrency.SellRate);
                Assert.AreEqual(newCurrency.Unit, createdCurrency.Unit);
                Assert.AreEqual(null, createdCurrency.Url);
            }
        }
    }
}
