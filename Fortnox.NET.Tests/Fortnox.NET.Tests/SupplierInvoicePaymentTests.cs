using FortnoxNET.Communication;
using FortnoxNET.Communication.SupplierInvoicePayment;
using FortnoxNET.Models.SupplierInvoicePayment;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SupplierInvoicePaymentTests : TestBase
    {
        [TestMethod]
        public async Task GetSupplierInvoicePaymentsTest()
        {
            var request = new SupplierInvoicePaymentListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await SupplierInvoicePaymentService.GetSupplierInvoicePaymentsAsync(request);

            Assert.IsTrue(response.Data.Count() > 0);
        }

        [TestMethod]
        public void GetSupplierInvoicePaymentTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SupplierInvoicePaymentService.GetSupplierInvoicePaymentAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.Amount == 3012.5);
        }

        //[TestMethod]
        //public void CreateSupplierInvoicePaymentTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = SupplierInvoicePaymentService.CreateSupplierInvoicePaymentAsync(request,
        //        new SupplierInvoicePayment
        //        {
        //            Amount = 99,
        //            InvoiceNumber = "1",
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual(99, response.Amount);
        //}

        //[TestMethod]
        //public void DeleteSupplierInvoicePaymentTest()
        //{
        //    //TODO: Avoid cluttering Fortnox with data
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
        //    var response = SupplierInvoicePaymentService.CreateSupplierInvoicePaymentAsync(request,
        //        new SupplierInvoicePayment
        //        {
        //            Amount = 99,
        //            InvoiceNumber = "2"
        //        }).GetAwaiter().GetResult();

        //    Assert.AreEqual(99, response.Amount);

        //    SupplierInvoicePaymentService.DeletePriceAsync(request, response.Number.ToString()).GetAwaiter().GetResult();
        //}

        [TestMethod]
        public void UpdateSupplierInvoicePaymentTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var supplierInvoicePayment = new SupplierInvoicePayment { Number = 2, Amount = 99, InvoiceNumber = "1", ModeOfPayment = "BG" };

            var updatedSupplierInvoicePayment = SupplierInvoicePaymentService.UpdateSupplierInvoicePaymentAsync(request, supplierInvoicePayment).GetAwaiter().GetResult();

            Assert.AreEqual(99, updatedSupplierInvoicePayment.Amount);
        }
    }
}
