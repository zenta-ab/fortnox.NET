using FortnoxNET.Communication.AccountChart;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AccountChartTests : TestBase
    {
        [TestMethod]
        public void GetAccountCharts()
        {
            var request = new AccountChartListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var accountCharts = AccountChartService.GetAccountChartsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(accountCharts.Data.Count() > 0);
        }
    }
}
