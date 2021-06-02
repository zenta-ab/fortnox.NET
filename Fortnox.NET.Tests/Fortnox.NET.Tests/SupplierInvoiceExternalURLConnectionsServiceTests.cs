using System;
using System.Linq;
using FortnoxNET.Communication;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Models.SupplierInvoiceExternalURLConnection;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SupplierInvoiceExternalURLConnectionsServiceTests : TestBase
    {
        private const string ExternalUrl = "http://example.com/image.jpg";

        [TestMethod]
        public async Task GetSupplierInvoiceExternalUrlTest()
        {
            var createdEntity = await CreateEntity(2);
            
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response =
                await SupplierInvoiceExternalURLConnectionsService
                    .GetSupplierInvoiceExternalURLConnectionsAsync(request, createdEntity.Id.ToString());

            await DeleteEntity((int)response.Id);

            Assert.AreEqual(createdEntity.Id, response.Id);
        }

        [TestMethod]
        public async Task CreateSupplierInvoiceExternalUrlConnectionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = 
                await SupplierInvoiceExternalURLConnectionsService.CreateSupplierInvoiceExternalURLConnectionsAsync(
                    request,
                    new SupplierInvoiceExternalURLConnection
                    {
                        SupplierInvoiceNumber = 2,
                        ExternalURLConnection = ExternalUrl,
                    }
                );

            await DeleteEntity((int)response.Id);
            
            Assert.AreEqual(ExternalUrl, response.ExternalURLConnection);
            Assert.AreEqual(2, response.SupplierInvoiceNumber);
        }

        [TestMethod]
        public async Task DeleteSupplierInvoiceExternalUrlConnectionTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await CreateEntity(2);

            await SupplierInvoiceExternalURLConnectionsService
                .DeleteSupplierInvoiceExternalURLConnectionsAsync(
                    request,
                    response.Id.ToString()
                );
        }

        [TestMethod]
        public async Task UpdateSupplierInvoiceExternalUrlConnectionTest()
        {
            var id = 2;
            var createdEntity = await CreateEntity(id);
            
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var supplierInvoiceExternalURLConnection = new SupplierInvoiceExternalURLConnection
            {
                Id = createdEntity.Id, 
                SupplierInvoiceNumber = id,
                ExternalURLConnection = "http://changed.com"
            };

            var updatedSupplierInvoiceExternalURLConnection = await SupplierInvoiceExternalURLConnectionsService
                .UpdateSupplierInvoiceExternalURLConnectionsAsync(
                    request,
                    supplierInvoiceExternalURLConnection
                );

            await DeleteEntity((int)createdEntity.Id);

            Assert.AreEqual("http://changed.com", updatedSupplierInvoiceExternalURLConnection.ExternalURLConnection);
            Assert.AreEqual(createdEntity.Id, updatedSupplierInvoiceExternalURLConnection.Id);
            Assert.AreEqual(id, updatedSupplierInvoiceExternalURLConnection.SupplierInvoiceNumber);
        }

        private async Task<SupplierInvoiceExternalURLConnection> CreateEntity(int supplierInvoiceNumber)
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            
            return
                await SupplierInvoiceExternalURLConnectionsService.CreateSupplierInvoiceExternalURLConnectionsAsync(
                    request,
                    new SupplierInvoiceExternalURLConnection
                    {
                        SupplierInvoiceNumber = supplierInvoiceNumber,
                        ExternalURLConnection = ExternalUrl,
                    }
                );
        }

        private async Task DeleteEntity(int id)
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            await SupplierInvoiceExternalURLConnectionsService
                .DeleteSupplierInvoiceExternalURLConnectionsAsync(
                    request,
                    id.ToString()
                );
        }
    }
}