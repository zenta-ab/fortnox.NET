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

        //[TestMethod]
        //public void CreateAbsenceTransactionTest()
        //{
        //    //TODO: Get some proper test accounts to avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = AbsenceTransactionsService.CreateAbsenceTransactionAsync(request,
        //        new AbsenceTransaction
        //        {
        //            EmployeeId = "2",
        //            CauseCode = "SJK",
        //            Date = DateTime.Parse("2020-03-31"),
        //            Extent = 100,
        //            HolidayEntitling = false,
        //            Hours = 2,
        //            Project = "",
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual(100, response.Extent);
        //}

        //[TestMethod]
        //public void UpdateAbsenceTransactionTest()
        //{
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var absenceTransaction = new AbsenceTransaction { EmployeeId = "4", CauseCode = "SJK", Date = DateTime.Parse("2020-02-24"), Hours = 8 };

        //    var updatedAbsenceTransaction = AbsenceTransactionsService.UpdateAbsenceTransactionAsync(request, absenceTransaction).GetAwaiter().GetResult();

        //    Assert.AreEqual(8, updatedAbsenceTransaction.Hours);
        //}
    }
}