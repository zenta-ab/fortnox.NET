using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.NET.Communication.FileConnection;
using FortnoxNET.Communication;
using FortnoxNET.Models.FileConnections;
using FortnoxNET.Models.SupplierInvoice;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SupplierInvoiceFileConnectionsTests : BaseFileConnectionTest
    {
        [TestMethod]
        public async Task ItCanGetConnections()
        {
            var request = new SupplierInvoiceFileConnectionListRequest(
                connectionSettings.AccessToken, 
                connectionSettings.ClientSecret
            );
            var response = await SupplierInvoiceFileConnectionService.GetSupplierInvoiceFileConnectionsAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetAConnection()
        {
            var connections = await GetConnections();

            if (connections == null || !connections.Any())
            {
                Assert.Inconclusive("No connections exist between a file and a supplier invoice in the system");
            }
            
            var request = new SupplierInvoiceFileConnectionListRequest(
                connectionSettings.AccessToken, 
                connectionSettings.ClientSecret
            );
            var response = await SupplierInvoiceFileConnectionService.GetSupplierInvoiceFileConnectionAsync(
                request,
                connections.First().FileId
            );
            
            Assert.IsNotNull(response);
            Assert.AreEqual(connections.First().FileId, response.FileId);
        }

        [TestMethod]
        public async Task ItCanCreateAConnection()
        {
            var fileId = await CreateInboxFile("inbox_s");
            var supplierInvoices = await GetInvoices();
            var supplierInvoice = supplierInvoices.FirstOrDefault(x => x.GivenNumber != string.Empty);
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);

            if (supplierInvoice == null)
            {
                // Supplier invoices cannot be deleted through the API - don't pollute the system.
                Assert.Inconclusive("No supplier invoices exist in the system");
            }

            try
            {
                var response = await SupplierInvoiceFileConnectionService.CreateSupplierInvoiceFileConnection(
                    request,
                    fileId,
                    supplierInvoice.GivenNumber
                );
                
                await DeleteConnection(fileId);
            
                Assert.IsNotNull(response);
                Assert.AreEqual(fileId, response.FileId);
                Assert.AreEqual(supplierInvoice.SupplierName, response.SupplierName);
                Assert.AreEqual(supplierInvoice.GivenNumber, response.SupplierInvoiceNumber);
            }
            finally
            {
                await DeleteFile(fileId);
            }   
        }

        private async Task<List<SupplierInvoiceFileConnections>> GetConnections()
        {
            var request = new SupplierInvoiceFileConnectionListRequest(
                connectionSettings.AccessToken, 
                connectionSettings.ClientSecret
            );
            return (await SupplierInvoiceFileConnectionService.GetSupplierInvoiceFileConnectionsAsync(request)).Data?.ToList();
        }

        private async Task<List<SupplierInvoiceSubset>> GetInvoices()
        {
            var request = new SupplierInvoiceListRequest(
                connectionSettings.AccessToken, 
                connectionSettings.ClientSecret
            );
            return (await SupplierInvoiceService.GetSupplierInvoicesAsync(request)).Data?.ToList();
        }

        private async Task DeleteConnection(string fileId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);

            await SupplierInvoiceFileConnectionService.DeleteSupplierInvoiceFileConnection(request, fileId);
        }
    }
}