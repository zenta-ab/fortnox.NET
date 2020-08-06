using FortnoxNET.Communication;
using FortnoxNET.Communication.TermsOfPayment;
using FortnoxNET.Models.TermsOfPayment;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class TermsOfPaymentTests : TestBase
    {
        private const string accessToken = "4ad291af-575e-4a4f-a843-cd6c2f7f9a3e";
        private const string clientSecret = "qU9K7Gjs4q";

        [TestMethod]
        public async Task GetTermsOfPaymentsTest()
        {
            var request = new TermsOfPaymentListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await TermsOfPaymentService.GetTermsOfPaymentsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetTermsOfDeliveryTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TermsOfPaymentService.GetTermsOfPaymentAsync(request, "0").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "0");
            Assert.IsTrue(response.Description == "0 dagar");
        }

        [TestMethod]
        public void CreateAndDeleteTermsOfDeliveryTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = TermsOfPaymentService.CreateTermsOfPaymentAsync(request,
                new TermsOfPayment
                {
                    Code = "DEL",
                    Description = "Delete Payment",
                }).GetAwaiter().GetResult();

            Assert.AreEqual("DEL", response.Code);
            Assert.AreEqual("Delete Payment", response.Description);

            TermsOfPaymentService.DeleteTermsOfPaymentAsync(request, "DEL").GetAwaiter().GetResult();
        }

        [TestMethod]
        public void UpdateTermsOfPaymentTest()
        {
            var description = $"{DateTime.Now}";
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var termsOfPayment = new TermsOfPayment { Code = "TEST", Description = description };

            var updatedTermsOfPayment = TermsOfPaymentService.UpdateTermsOfPaymentAsync(request, termsOfPayment).GetAwaiter().GetResult();

            Assert.AreEqual(description, updatedTermsOfPayment.Description);
        }
    }
}
