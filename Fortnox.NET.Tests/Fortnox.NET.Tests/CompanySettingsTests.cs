using FortnoxNET.Communication;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CompanySettingsTests : TestBase
    {
        [TestMethod]
        public void GetCompanySettingsTest()
        {
            var response = CompanySettingsService.GetCompanySettingsAsync(new FortnoxApiRequest(
                this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {

            }).GetAwaiter().GetResult();
            
            Assert.IsNotNull(response);
        }
    }
}