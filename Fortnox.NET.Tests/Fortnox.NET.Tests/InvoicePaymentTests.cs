using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.InvoicePayment;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class InvoicePaymentTests : TestBase
    {
        [TestMethod]
        public async Task GetInvoicePaymentInvoiceNumberTest()
        {
            var request = new InvoicePaymentListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.SearchParameters.Add(InvoicePaymentSearchParameters.InvoiceNumber, 15);
            var InvoicePaymentList = await InvoicePaymentService.GetInvoicePaymentsAsync(request);

            Assert.IsTrue(InvoicePaymentList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetInvoicePaymentsListTest()
        {
            var request = new InvoicePaymentListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
            };
            
            var InvoicePaymentList = await InvoicePaymentService.GetInvoicePaymentsAsync(request);

            Assert.IsNotNull(InvoicePaymentList);
        }

        [TestMethod]
        public void GetInvoicesPaymentPaginationTest()
        {
            var request = new InvoicePaymentListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 100;
            request.Page = 1;

            var InvoicePayments = new List<InvoicePaymentSubset>();
            ListedResourceResponse<InvoicePaymentSubset> response;

            do
            {
                response = InvoicePaymentService.GetInvoicePaymentsAsync(request).GetAwaiter().GetResult();
                InvoicePayments.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;

            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(InvoicePayments.Count > 0);
        }
        [TestMethod]
        public async Task GetInvoicePaymentNumber()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await InvoicePaymentService.GetInvoicePaymentAsync(request, 3);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateAndDeleteInvoicePaymentTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoicePaymentService.CreateInvoicePaymentAsync(request,
                new InvoicePayment
                {
                    Amount = 99,
                    AmountCurrency = 99,
                    InvoiceNumber = 2
                }).GetAwaiter().GetResult();

            await InvoicePaymentService.DeleteInvoicePaymentAsync(request, $"{response.Number}");

            Assert.AreEqual("2", response.InvoiceCustomerNumber);
            Assert.AreEqual(99, response.Amount);
            Assert.AreEqual(99, response.AmountCurrency);
        }

        [TestMethod]
        public async Task UpdateInvoicePaymentTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoicePaymentService.CreateInvoicePaymentAsync(request,
                new InvoicePayment
                {
                    Amount = 99,
                    AmountCurrency = 99,
                    InvoiceNumber = 2
                }).GetAwaiter().GetResult();

            var updatedInvoicePayment = InvoicePaymentService.UpdateInvoicePaymentAsync(request, response.Number,
                new InvoicePayment
                {
                    Amount = response.Amount + 1,
                    AmountCurrency = response.AmountCurrency + 1,
                    InvoiceNumber = response.InvoiceNumber
                }).GetAwaiter().GetResult();

            await InvoicePaymentService.DeleteInvoicePaymentAsync(request, $"{response.Number}");

            Assert.AreEqual(updatedInvoicePayment.InvoiceCustomerNumber, response.InvoiceCustomerNumber);
            Assert.AreEqual(updatedInvoicePayment.Amount, response.Amount + 1);
            Assert.AreEqual(updatedInvoicePayment.AmountCurrency, response.AmountCurrency + 1);
        }

        [TestMethod]
        public async Task BookkeepInvoicePaymentTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoicePaymentService.CreateInvoicePaymentAsync(request,
                new InvoicePayment
                {
                    Amount = 99,
                    AmountCurrency = 99,
                    InvoiceNumber = 2
                }).GetAwaiter().GetResult();

            var bookkeeptInvoicePayment = await InvoicePaymentService.BookkeepInvoicePaymentAsync(request, response.Number);
            
            Assert.AreEqual(false, response.Booked);
            Assert.AreEqual(true, bookkeeptInvoicePayment.Booked);
        }
    }
}