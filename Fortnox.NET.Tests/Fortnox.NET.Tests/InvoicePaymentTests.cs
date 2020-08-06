using System;
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
    }
}