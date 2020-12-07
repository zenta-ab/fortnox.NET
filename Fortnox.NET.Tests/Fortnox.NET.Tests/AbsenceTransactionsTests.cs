using System;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.AbsenceTransaction;
using FortnoxNET.Models.AbsenceTransactions;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
	[TestClass]
	public class AbsenceTransactionsTests : TestBase
	{
		[TestMethod]
		public async Task GetAbsenceTransactionsTest()
		{
			var request = new AbsenceTransactionListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
			var response = await AbsenceTransactionsService.GetAbsenceTransactionsAsync(request);

			Assert.IsNotNull(response);
		}

        [TestMethod]
        public void GetAbsenceTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = AbsenceTransactionsService.GetAbsenceTransactionAsync(request, "4", "2020-02-24", "SJK").GetAwaiter().GetResult();

            Assert.IsTrue(response.EmployeeId == "4");
        }

        [TestMethod]
        public async Task CreateAbsenceTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await AbsenceTransactionsService.CreateAbsenceTransactionAsync(request,
                new AbsenceTransaction
                {
                    EmployeeId = "2",
                    CauseCode = "SJK",
                    Date = DateTime.Parse("2020-03-1"),
                    Extent = 100.0m,
                });

            Assert.AreEqual(100, response.Extent);

            await AbsenceTransactionsService.DeleteAbsenceTransactionAsync(request, response.EmployeeId, "2020-03-1", response.CauseCode);
        }

        [TestMethod]
        public async Task UpdateAbsenceTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await AbsenceTransactionsService.CreateAbsenceTransactionAsync(request,
                new AbsenceTransaction
                {
                    EmployeeId = "2",
                    CauseCode = "SJK",
                    Date = DateTime.Parse("2020-03-6"),
                    Extent = 50.0m,
                });

            response.Hours = 8.0m;
            var updatedAbsenceTransaction = await AbsenceTransactionsService.UpdateAbsenceTransactionAsync(request, response);

            Assert.AreEqual(8.0m, updatedAbsenceTransaction.Hours);
            await AbsenceTransactionsService.DeleteAbsenceTransactionAsync(request, response.EmployeeId, "2020-03-6", response.CauseCode);
        }
    }
}