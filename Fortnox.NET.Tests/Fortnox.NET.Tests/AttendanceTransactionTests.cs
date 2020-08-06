using FortnoxNET.Communication;
using FortnoxNET.Communication.AttendanceTransaction;
using FortnoxNET.Models.AttendanceTransaction;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AttendanceTransactionTests : TestBase
    {
        [TestMethod]
        public async Task GetAttendanceTransactionsTest()
        {
            var request = new AttendanceTransactionListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await AttendanceTransactionService.GetAttendanceTransactionsAsync(request);

            Assert.IsNotNull(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetAttendanceTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = AttendanceTransactionService.GetAttendanceTransactionAsync(request, "1", "2020-01-30", "TID").GetAwaiter().GetResult();

            Assert.IsTrue(response.EmployeeId == "1");
        }

        [TestMethod]
        public async Task CreateAndUpdateThenDeleteAttendanceTransactionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var today = DateTime.UtcNow;
            var response = AttendanceTransactionService.CreateAttendanceTransactionAsync(request,
                new AttendanceTransaction
                {
                    EmployeeId = "1593082874",
                    CauseCode = "TID",
                    Date = today,
                    Hours = 2,
                    Project = "",
                }).GetAwaiter().GetResult();

            Assert.AreEqual(2, response.Hours);

            await AttendanceTransactionService.DeleteAttendanceTransactionAsync(request, "1593082874", today.ToShortDateString(), "TID");
        }

        //[TestMethod]
        //public void UpdateAttendanceTransactionTest()
        //{
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var AttendanceTransaction = new AttendanceTransaction 
        //    { 
        //        EmployeeId = "2", 
        //        CauseCode = "TID", 
        //        Date = DateTime.Parse("2020-03-31"), 
        //        Hours = 8 
        //    };

        //    var updatedAttendanceTransaction = AttendanceTransactionService.UpdateAttendanceTransactionAsync(request, AttendanceTransaction).GetAwaiter().GetResult();

        //    Assert.AreEqual(8, updatedAttendanceTransaction.Hours);
        //}
    }
}
