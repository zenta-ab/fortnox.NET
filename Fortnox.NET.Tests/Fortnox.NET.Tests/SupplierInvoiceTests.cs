using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.SupplierInvoice;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SupplierInvoiceTests : TestBase
    {
        [TestMethod]
        public async Task GetSupplierInvoicesTest()
        {
            var request = new SupplierInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var invoiceList = await SupplierInvoiceService.GetSupplierInvoicesAsync(request);

            Assert.IsTrue(invoiceList.Data.ToList().Count > 0);
        }
        
        [TestMethod]
        public async Task GetSupplierInvoicesSearchTest()
        {
            var request = new SupplierInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.SearchParameters = new Dictionary<SupplierInvoiceSearchParameters, object>();
            request.SearchParameters[SupplierInvoiceSearchParameters.Project] = "1";
            var invoiceList = await SupplierInvoiceService.GetSupplierInvoicesAsync(request);

            Assert.IsTrue(invoiceList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetSupplierInvoicesFromDateToDateTest()
        {
            var request = new SupplierInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                {
                    SearchParameters = new Dictionary<SupplierInvoiceSearchParameters, object>()
                        {
                            {SupplierInvoiceSearchParameters.FromDate, "2018-02-18"}, 
                            {SupplierInvoiceSearchParameters.ToDate, "2030-12-31"},
                        }
                };
            request.SearchParameters[SupplierInvoiceSearchParameters.FinancialYearDate] = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var invoiceList = await SupplierInvoiceService.GetSupplierInvoicesAsync(request);

            Assert.IsNotNull(invoiceList);
        }

        [TestMethod]
        public async Task GetSupplierInvoice()
        {
            var invoices = await GetSupplierInvoices();

            if (!invoices.Data.Any())
            {
                Assert.Inconclusive("No SupplierInvoices exist in the system");
                return;
            }
            
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await SupplierInvoiceService.GetSupplierInvoiceAsync(
                request, 
                Convert.ToInt32(invoices.Data.First().GivenNumber)
            );

            Assert.IsNotNull(response);
        }

        private async Task<ListedResourceResponse<SupplierInvoiceSubset>> GetSupplierInvoices()
        {
            var request = new SupplierInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            return await SupplierInvoiceService.GetSupplierInvoicesAsync(request);
        }
    }
}