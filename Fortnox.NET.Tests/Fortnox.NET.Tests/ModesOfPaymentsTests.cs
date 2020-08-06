using System;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.ModesOfPayments;
using FortnoxNET.Models.ModesOfPayments;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ModesOfPaymentsTests : TestBase
    {
        [TestMethod]
        public async Task GetModesOfPaymentsAsyncTest()
        {
            var request = new ModesOfPaymentsListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await ModesOfPaymentsService.GetModesOfPaymentsAsync(request);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetModesOfPaymentAsyncTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ModesOfPaymentsService.GetModesOfPaymentAsync(request, "BG").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "BG");
        }

        [TestMethod]
        public void GetModesOfPaymentsPaginationTest()
        {
            const int PAGES = 1;

            var request = new ModesOfPaymentsListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 10;
            request.Page = 1;

            var modesOfPayments = new List<ModesOfPaymentsSubset>();
            ListedResourceResponse<ModesOfPaymentsSubset> response;

            do
            {
                response = ModesOfPaymentsService.GetModesOfPaymentsAsync(request).GetAwaiter().GetResult();
                modesOfPayments.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;
            } while (response.MetaInformation.CurrentPage < PAGES);

            Assert.IsTrue(modesOfPayments.Count() < 10);
            Assert.IsTrue(response.MetaInformation.CurrentPage == 1);
        }
    }
}