using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Customer;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class CustomerTests : TestBase
    {
        [TestMethod]
        public void GetCustomers()
        {
            var request = new CustomerListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var customers = CustomerService.GetCustomersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(customers.Data.ToList().Count == 100);
        }

        [TestMethod]
        public void GetCustomersPaginationTest()
        {
            var request = new CustomerListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 500;
            request.Page = 1;

            var customers = new List<CustomerSubset>();
            ListedResourceResponse<CustomerSubset> response;

            do
            {
                response = CustomerService.GetCustomersAsync(request).GetAwaiter().GetResult();
                customers.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;
            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(customers.Count > 10);
        }

        [TestMethod]
        public void GetFilteredCustomers()
        {
            var request = new CustomerListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) 
            {
                Filter = CustomerFilters.Active
            };
            var customers = CustomerService.GetCustomersAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(customers.Data.ToList().First());
        }

        [TestMethod]
        public void GetSortedCustomers()
        {
            var request = new CustomerListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) 
            {
                SortBy = CustomerSortableProperties.Name
            };
            var customers = CustomerService.GetCustomersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(customers.Data.ToList().First().Name.StartsWith("0"));
        }

        [TestMethod]
        public void SearchCustomers()
        {
            var request = new CustomerListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<CustomerSearchParameters, object> {{CustomerSearchParameters.Name, "Interna Arbeten"}}
            };

            var invoiceList = CustomerService.GetCustomersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().Name == "Interna Arbeten");
        }

        [TestMethod]
        public void GetCustomer()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = CustomerService.GetCustomerAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.CustomerNumber == "1");
        }

        [TestMethod]
        public void CreateCustomer()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var customerName = $"TestKund {DateTime.Now.ToShortDateString()}";
            var response = CustomerService.CreateCustomerAsync(request, 
                new Customer 
                { 
                    Name = customerName,
                }).GetAwaiter().GetResult();

            Assert.AreEqual(customerName, response.Name);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var customer = new Customer {Name = $"TestKund {DateTime.UtcNow}", CustomerNumber = "37196" };
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var updatedCustomer = CustomerService.UpdateCustomerAsync(request, customer).GetAwaiter().GetResult();
            
            Assert.AreEqual(customer.Name, updatedCustomer.Name);
        }
    }
}