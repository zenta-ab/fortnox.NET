using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
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
                                                     {SupplierInvoiceSearchParameters.FromDate, "2018-02-18"}, {SupplierInvoiceSearchParameters.ToDate, "2018-12-31"},
                                                 }
                          };
            request.SearchParameters[SupplierInvoiceSearchParameters.FinancialYearDate] = DateTime.UtcNow.AddYears(-1).ToShortDateString();

            var invoiceList = await SupplierInvoiceService.GetSupplierInvoicesAsync(request);

            Assert.IsNotNull(invoiceList);
        }

        [TestMethod]
        public async Task GetSupplierInvoice()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await SupplierInvoiceService.GetSupplierInvoiceAsync(request, 4, 33);

            Assert.IsNotNull(response);
        }
    }
}