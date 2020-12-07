using FortnoxNET.Communication;
using FortnoxNET.Communication.Contract;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Contract;
using FortnoxNET.Models.Invoice;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ContractTests : TestBase
    {
        [TestMethod]
        public async Task GetContractsTest()
        {
            var request = new ContractListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await ContractService.GetContractsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetContractTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ContractService.GetContractAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.ContractLength == 1);
            Assert.IsTrue(response.DocumentNumber == 1);
        }

        [TestMethod]
        public void CreateContractTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ContractService.CreateContractAsync(request,
                new Contract
                {
                    CustomerNumber = "1",
                    InvoiceRows = new List<InvoiceRow>() 
                    { 
                        new InvoiceRow { ArticleNumber = "1", DeliveredQuantity = 1000, AccountNumber = 3001 } 
                    },
                    ContractDate = DateTime.Now,
                    PeriodStart = DateTime.Now.AddDays(1),
                    PeriodEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
                }).GetAwaiter().GetResult();

            Assert.AreEqual("1", response.CustomerNumber);
        }

        [TestMethod]
        public void UpdateContractTest()
        {
            var comment = $"{DateTime.Now}";

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var contract = ContractService.GetContractAsync(request, "1").GetAwaiter().GetResult();

            var updatedContract = new Contract { DocumentNumber = contract.DocumentNumber, Comments = comment };
            var response = ContractService.UpdateContractAsync(request, updatedContract).GetAwaiter().GetResult();


            Assert.AreEqual(contract.DocumentNumber, response.DocumentNumber);
            Assert.AreEqual(comment, response.Comments);
        }

        [TestMethod]
        public async Task FinishContractTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ContractService.CreateContractAsync(request,
                new Contract
                {
                    CustomerNumber = "1",
                    InvoiceRows = new List<InvoiceRow>()
                    {
                        new InvoiceRow { ArticleNumber = "1", DeliveredQuantity = 1000, AccountNumber = 3001 }
                    },
                    ContractDate = DateTime.Now,
                    PeriodStart = DateTime.Now.AddDays(1),
                    PeriodEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
                }).GetAwaiter().GetResult();

            Assert.AreEqual("1", response.CustomerNumber);

            var finishedContract = await ContractService.FinishContractAsync(request, response);
            Assert.IsNotNull(finishedContract);
            Assert.AreEqual(response.DocumentNumber, finishedContract.DocumentNumber);
        }

        [TestMethod]
        public async Task CreateInvoiceFromContractTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ContractService.CreateContractAsync(request,
                new Contract
                {
                    CustomerNumber = "1",
                    InvoiceRows = new List<InvoiceRow>()
                    {
                        new InvoiceRow { ArticleNumber = "1", DeliveredQuantity = 1000, AccountNumber = 3001 }
                    },
                    ContractDate = DateTime.Now,
                    PeriodStart = DateTime.Now.AddDays(1),
                    PeriodEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
                }).GetAwaiter().GetResult();

            Assert.AreEqual("1", response.CustomerNumber);

            var contract = await ContractService.CreateInvoiceFromContractAsync(request, response);
            Assert.IsNotNull(contract);
            Assert.AreEqual(response.DocumentNumber, contract.DocumentNumber);

            var invoiceRequest = new CustomerInvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SortBy = CustomerInvoiceSortableProperties.DocumentNumber,
                SortOrder = SortOrder.Descending
            };
            var invoiceList = await CustomerInvoiceService.GetCustomerInvoicesAsync(invoiceRequest);
            var latestInvoice = invoiceList.Data.First();

            Assert.AreEqual(latestInvoice.CustomerName, contract.CustomerName);
            Assert.AreEqual(latestInvoice.CustomerNumber, contract.CustomerNumber);
        }

        [TestMethod]
        public async Task IncreaseInvoiceCountForContractTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ContractService.CreateContractAsync(request,
                new Contract
                {
                    CustomerNumber = "1",
                    InvoiceRows = new List<InvoiceRow>()
                    {
                        new InvoiceRow { ArticleNumber = "1", DeliveredQuantity = 1000, AccountNumber = 3001 }
                    },
                    ContractDate = DateTime.Now,
                    PeriodStart = DateTime.Now.AddDays(1),
                    PeriodEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
                }).GetAwaiter().GetResult();

            Assert.AreEqual("1", response.CustomerNumber);

            var finishedContract = await ContractService.IncreaseInvoiceCountForContractAsync(request, response);
            Assert.IsNotNull(finishedContract);
            Assert.AreEqual(response.DocumentNumber, finishedContract.DocumentNumber);
        }
    }
}
