using FortnoxNET.Communication;
using FortnoxNET.Communication.LockedPeriod;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class LockedPeriodTests : TestBase
    {
        [TestMethod]
        public async Task GetLockedPeriodTests()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await LockedPeriodService.GetLockedPeriodAsync(request);
            Assert.IsNull(response.EndDate);
        }
    }
}