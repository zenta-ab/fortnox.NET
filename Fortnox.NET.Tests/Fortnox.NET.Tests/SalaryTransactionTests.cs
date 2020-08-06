using FortnoxNET.Communication;
using FortnoxNET.Communication.SalaryTransaction;
using FortnoxNET.Models.SalaryTransaction;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SalaryTransactionTests : TestBase
    {
        [TestMethod]
        public async Task GetSalaryTransactionsTest()
        {
            var request = new SalaryTransactionListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await SalaryTransactionService.GetSalaryTransactionsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetPriceForArticleTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SalaryTransactionService.GetSalaryTransactionAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.EmployeeId == "4");
        }

        [TestMethod]
        public void CreateAndUpdateThenDeleteSalaryTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SalaryTransactionService.CreateSalaryTransactionAsync(request,
                new SalaryTransaction
                {
                    EmployeeId = "1593082874",
                    SalaryCode = "1321",
                    Date = DateTime.UtcNow,
                    Number = "10",
                    Amount = "200",
                }).GetAwaiter().GetResult();

            Assert.AreEqual("1593082874", response.EmployeeId);

            var salaryTransaction = new SalaryTransaction { SalaryRow = response.SalaryRow, Number = "20" };
            var updatedSalaryTransaction = SalaryTransactionService.UpdateSalaryTransactionAsync(request, salaryTransaction).GetAwaiter().GetResult();

            Assert.AreEqual("1593082874", updatedSalaryTransaction.EmployeeId);
            Assert.AreEqual("20", updatedSalaryTransaction.Number);

            SalaryTransactionService.DeleteSalaryTransactionAsync(request, response.SalaryRow.ToString()).GetAwaiter().GetResult();
        }
    }
}
