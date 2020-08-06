using FortnoxNET.Communication;
using FortnoxNET.Communication.Invoice;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Invoice;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class InvoiceTests : TestBase
    {
        [TestMethod]
        public void GetInvoices()
        {
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var invoiceList = InvoiceService.GetInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetFilteredInvoices()
        {
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { Filter = InvoiceFilters.Unbooked };
            var invoiceList = InvoiceService.GetInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().Balance > 0);
        }

        [TestMethod]
        public void GetSortedInvoices()
        {
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { SortBy = InvoiceSortableProperties.CustomerName };
            var invoiceList = InvoiceService.GetInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().CustomerName.StartsWith("I"));
        }

        [TestMethod]
        public void SearchInvoices()
        {
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters =
                                  new Dictionary<InvoiceSearchParameters, object> { { InvoiceSearchParameters.CustomerName, "Kund" } }
            };

            var invoiceList = InvoiceService.GetInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().CustomerName.Contains("Kund"));
        }

        [TestMethod]
        public void GetInvoice()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.GetInvoiceAsync(request, "12").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == "12");
        }

        [TestMethod]
        public void UpdateInvoice()
        {
            var comment = $"Comment: {DateTime.Now}";
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var response = InvoiceService.GetInvoiceAsync(request, "12").GetAwaiter().GetResult();
            response.Comments = comment;

            var updatedInvoice = InvoiceService.UpdateInvoiceAsync(request, response).GetAwaiter().GetResult();

            Assert.AreEqual(comment, updatedInvoice.Comments);
        }
    }
}
