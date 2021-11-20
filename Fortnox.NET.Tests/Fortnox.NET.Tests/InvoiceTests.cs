using Fortnox.NET.Models.Common;
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
using System.Threading.Tasks;

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

            Assert.IsTrue(invoiceList.Data.ToList().First().CustomerName.StartsWith("C"));
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
            var response = InvoiceService.GetInvoiceAsync(request, 12).GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == 12);
        }

        [TestMethod]
        public void UpdateInvoice()
        {
            var comment = $"Comment: {DateTime.Now}";
            var request = new InvoiceListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var response = InvoiceService.GetInvoiceAsync(request, 12).GetAwaiter().GetResult();
            response.Comments = comment;
            response.TaxReductionType = TaxReductionType.None;

            var updatedInvoice = InvoiceService.UpdateInvoiceAsync(request, response).GetAwaiter().GetResult();

            Assert.AreEqual(comment, updatedInvoice.Comments);
        }

        [TestMethod]
        public async Task BookkeepInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",

                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var bookkeeptInvoice = await InvoiceService.BookkeepInvoiceAsync(request, response.DocumentNumber);
            
            Assert.AreEqual(false, response.Booked);
            Assert.AreEqual(true, bookkeeptInvoice.Booked);
        }

        [TestMethod]
        public async Task CancelInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                        }
                    }
                }).GetAwaiter().GetResult();

            var cancelledInvoice = await InvoiceService.CancelInvoiceAsync(request, response.DocumentNumber);

            Assert.AreEqual(false, response.Cancelled);
            Assert.AreEqual(true, cancelledInvoice.Cancelled);
        }

        [TestMethod]
        public async Task CreditInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var bookkeeptInvoice = await InvoiceService.BookkeepInvoiceAsync(request, response.DocumentNumber);
            Assert.IsTrue(bookkeeptInvoice.Booked);

            var creditedInvoice = await InvoiceService.CreditInvoiceAsync(request, response.DocumentNumber);
            var updatedDebitInvoice = await InvoiceService.GetInvoiceAsync(request, response.DocumentNumber);

            Assert.IsTrue(creditedInvoice.CreditInvoiceReference.HasValue);
            Assert.IsTrue(updatedDebitInvoice.CreditInvoiceReference.HasValue);
            Assert.AreEqual(updatedDebitInvoice.CreditInvoiceReference.Value, creditedInvoice.CreditInvoiceReference.Value);
        }

        [TestMethod]
        public async Task EmailInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var emailedInvoice = await InvoiceService.SendInvoiceEmailAsync(request, response.DocumentNumber);
            
            Assert.AreEqual(false, response.Sent);
            Assert.AreEqual(true, emailedInvoice.Sent);
        }

        [TestMethod]
        public async Task PrintInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var pdfBytes = await InvoiceService.PrintInvoiceAsync(request, response.DocumentNumber);

            // NOTE(Oskar): Assert that the PDF magic number exists in the recieved bytes.
            Assert.IsTrue(pdfBytes[0] == 0x25); // %
            Assert.IsTrue(pdfBytes[1] == 0x50); // P
            Assert.IsTrue(pdfBytes[2] == 0x44); // D
            Assert.IsTrue(pdfBytes[3] == 0x46); // F
        }

        [TestMethod]
        public async Task PrintInvoiceReminderTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var pdfBytes = await InvoiceService.PrintInvoiceReminderAsync(request, response.DocumentNumber);

            // NOTE(Oskar): Assert that the PDF magic number exists in the recieved bytes.
            Assert.IsTrue(pdfBytes[0] == 0x25); // %
            Assert.IsTrue(pdfBytes[1] == 0x50); // P
            Assert.IsTrue(pdfBytes[2] == 0x44); // D
            Assert.IsTrue(pdfBytes[3] == 0x46); // F
        }

        [TestMethod]
        public async Task ExternalPrintInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var externallyPrintedInvoice = await InvoiceService.ExternalPrintInvoiceAsync(request, response.DocumentNumber);

            Assert.IsFalse(response.Sent);
            Assert.IsTrue(externallyPrintedInvoice.Sent);
        }

        [TestMethod]
        public async Task PreviewInvoiceAsync()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                    new List<InvoiceRow>
                    {
                        new InvoiceRow
                        {
                            ArticleNumber = "100029",
                            DeliveredQuantity = 10,
                            AccountNumber = 1010,
                            CostCenter = "TEST"
                        }
                    }
                }).GetAwaiter().GetResult();

            var pdfBytes = await InvoiceService.PreviewInvoiceAsync(request, response.DocumentNumber);

            // NOTE(Oskar): Assert that the PDF magic number exists in the recieved bytes.
            Assert.IsTrue(pdfBytes[0] == 0x25); // %
            Assert.IsTrue(pdfBytes[1] == 0x50); // P
            Assert.IsTrue(pdfBytes[2] == 0x44); // D
            Assert.IsTrue(pdfBytes[3] == 0x46); // F
        }


        [TestMethod]
        public async Task CreateInvoiceTest()
        {
            // This test needs the following setting:
            // Fortnox: Settings / Invoicing / Registration view / Round-off = Nearest femtioöring

            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await InvoiceService.CreateInvoiceAsync(request,
                new Invoice
                {
                    CustomerNumber = "1",
                    InvoiceRows =
                        new List<InvoiceRow>
                        {
                            new InvoiceRow
                            {
                                ArticleNumber = "2",
                                DeliveredQuantity = 1,
                                Price = 99.5m
                            }
                        }
                });

            Assert.AreEqual(99.5m, response.Total);
        }
    }
}
