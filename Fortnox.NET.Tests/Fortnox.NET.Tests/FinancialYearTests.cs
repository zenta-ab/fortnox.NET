using Fortnox.NET.Models.FinancialYear;
using FortnoxNET.Communication;
using FortnoxNET.Communication.FinancialYear;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class FinancialYearTests : TestBase
    {
        [TestMethod]
        public async Task GetFinancialYearsTest()
        {
            var request = new FinancialYearListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await FinancialYearService.GetFinancialYearsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetFinancialYearTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = FinancialYearService.GetFinancialYearAsync(request, 1).GetAwaiter().GetResult();

            Assert.IsTrue(response.Id == 1);
            Assert.IsTrue(response.AccountingMethod == AccountingMethod.ACCRUAL);
        }

        //[TestMethod]
        //public void CreateFinancialYearTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = FinancialYearService.CreateFinancialYearAsync(request,
        //        new FinancialYear
        //        {
        //            FromDate = DateTime.Parse("2020-01-01"),
        //            ToDate = DateTime.Parse("2020-12-31"),
        //            AccountingMethod = "ACCRUAL"
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual("ACCRUAL", response.AccountingMethod);
        //}
    }
}
