using FortnoxNET.Communication;
using FortnoxNET.Communication.LockedPeriod;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FortnoxNET.Tests
{
    [TestClass]
    public class LockedPeriodTests : TestBase
    {
        [TestMethod]
        public void GetLockedPeriodTests()
        {
            var response = LockedPeriodService.GetLockedPeriodAsync(new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {

            }).GetAwaiter().GetResult();
            Assert.IsTrue(response != null);

        }
    }
}