using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.NET.Communication.FileConnection;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.FileConnections;
using Newtonsoft.Json;

namespace FortnoxNET.Services
{
    public class SupplierInvoiceFileConnectionService
    {
        public static async Task<ListedResourceResponse<SupplierInvoiceFileConnections>> GetSupplierInvoiceFileConnectionsAsync(
            SupplierInvoiceFileConnectionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SupplierInvoiceFileConnections>>(
                HttpMethod.Get, 
                listRequest, 
                ApiEndpoints.SupplierInvoiceFileConnections
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SupplierInvoiceFileConnection> GetSupplierInvoiceFileConnectionAsync(
            SupplierInvoiceFileConnectionListRequest listRequest,
            string fileId)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SupplierInvoiceFileConnection>>(
                HttpMethod.Get, 
                listRequest, 
                $"{ApiEndpoints.SupplierInvoiceFileConnections}/{fileId}"
            );

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SupplierInvoiceFileConnection> CreateSupplierInvoiceFileConnection(
            FortnoxApiRequest request,
            string fileId,
            string supplierInvoiceNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SupplierInvoiceFileConnection>>(
                    HttpMethod.Post,
                    request,
                    $"{ApiEndpoints.SupplierInvoiceFileConnections}")
                {
                    Data = new SingleResource<SupplierInvoiceFileConnection>()
                    {
                        Data = new SupplierInvoiceFileConnection()
                        {
                            FileId = fileId,
                            SupplierInvoiceNumber = supplierInvoiceNumber
                        }
                    }
                };

            return (await FortnoxAPIClient.CallAsync<
                SingleResource<SupplierInvoiceFileConnection>,
                SingleResource<SupplierInvoiceFileConnection>>(apiRequest)).Data;
        }

        public static async Task DeleteSupplierInvoiceFileConnection(FortnoxApiRequest request, string fileId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.SupplierInvoiceFileConnections}/{fileId}");

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}