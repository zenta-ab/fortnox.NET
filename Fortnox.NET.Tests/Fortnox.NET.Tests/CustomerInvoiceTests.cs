using System.Collections.Generic;
using System.Linq;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CustomerInvoiceTests : TestBase
    {
        [TestMethod]
        public void GetCustomerInvoices()
        {
            var request = new CustomerInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var invoiceList = CustomerInvoiceService.GetCustomerInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().Count >= 10);
        }

        [TestMethod]
        public void GetFilteredCustomerInvoices()
        {
            var request = new CustomerInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) 
            {
                Filter = CustomerInvoiceFilters.FullyPaid
            };
            var invoiceList = CustomerInvoiceService.GetCustomerInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetSortedCustomerInvoices()
        {
            var request = new CustomerInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) 
            {
                SortBy = CustomerInvoiceSortableProperties.CustomerName
            };
            var invoiceList = CustomerInvoiceService.GetCustomerInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().CustomerName.StartsWith("I"));
        }

        [TestMethod]
        public void SearchCustomerInvoices()
        {
            var request = new CustomerInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters =
                    new Dictionary<CustomerInvoiceSearchParameters, object> {{CustomerInvoiceSearchParameters.CustomerName, "Interna Arbeten"}}
            };

            var invoiceList = CustomerInvoiceService.GetCustomerInvoicesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().CustomerName == "Interna Arbeten");
        }

        [TestMethod]
        public void GetCustomerInvoice()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CustomerInvoiceService.GetCustomerInvoiceAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == "1");
        }
    }
}