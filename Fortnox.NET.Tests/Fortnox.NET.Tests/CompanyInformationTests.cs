using FortnoxNET.Communication;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CompanyInformationTests : TestBase
    {
        [TestMethod]
        public void GetCompanyInformationTest()
        {
            var response = CompanyInformationService.GetCompanyInformationAsync(
                new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {

            }).GetAwaiter().GetResult();

            Assert.IsNotNull(response);
        }
    }
}
