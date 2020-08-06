using System;
using System.Threading.Tasks;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Communication;
using FortnoxNET.Communication.TaxReduction;
using FortnoxNET.Models.TaxReduction;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class TaxReductionTests : TestBase
    {
        [TestMethod]
        public async Task GetTaxReductionsTest()
        {
            var request = new TaxReductionListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await TaxReductionService.GetTaxReductionsAsync(request);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetTaxReductionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TaxReductionService.GetTaxReductionAsync(request, "12").GetAwaiter().GetResult();

            Assert.IsTrue(response.Id == "12");
        }

        // [TestMethod]
        // public void CreateTaxReductionTest()
        // {
        //     //TODO: Get some proper test accounts to avoid cluttering Fortnox with data
        //     var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //     var response = TaxReductionService.CreateTaxReductionAsync(request,
        //         new TaxReduction
        //         {
        //             AskedAmount = 2000,
        //             CustomerName = "TEST",
        //             ReferenceDocumentType = "INVOICE",
        //             ReferenceNumber = 5,
        //             SocialSecurityNumber = "11223344-5566",
        //         }).GetAwaiter().GetResult();

        //     Assert.AreEqual(2000, response.AskedAmount);
        // }

        //[TestMethod]
        //public void UpdateTaxReductionTest()
        //{
        //    var taxReduction = new TaxReduction { AskedAmount = 2000, ReferenceNumber = 5 };
        //    var newTaxReduction = new TaxReduction { AskedAmount = 2500, ReferenceNumber = 5 };

        //    TaxReduction.AskedAmount = newTaxReduction;
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

        //    var updatedTaxReduction = TaxReductionService.UpdateTaxReductionAsync(request, TaxReduction).GetAwaiter().GetResult();

        //    Assert.AreEqual(newTaxReduction.AskedAmount, updatedTaxReduction.AskedAmount);
        //}
    }
}