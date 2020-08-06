using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.SupplierInvoiceExternalURLConnection;

namespace FortnoxNET.Services
{
    public class SupplierInvoiceExternalURLConnectionsService
    {
        public static async Task<ListedResourceResponse<SupplierInvoiceExternalURLConnection>>
            GetSupplierInvoiceExternalURLConnectionsAsync(SupplierInvoiceExternalURLConnectionsListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<
                ListedResourceResponse<SupplierInvoiceExternalURLConnection>
            >(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                ApiEndpoints.SupplierInvoiceExternalURLConnections);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<SupplierInvoiceExternalURLConnection> GetSupplierInvoiceExternalURLConnectionsAsync(
            FortnoxApiRequest request,
            string id)
        {
            var apiRequest = new FortnoxApiClientRequest<
                SingleResource<SupplierInvoiceExternalURLConnection>
            >(
                HttpMethod.Get, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.SupplierInvoiceExternalURLConnections}/{id}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SupplierInvoiceExternalURLConnection> CreateSupplierInvoiceExternalURLConnectionsAsync(
            FortnoxApiRequest request,
            SupplierInvoiceExternalURLConnection SupplierInvoiceExternalURLConnections)
        {
            var apiRequest = new FortnoxApiClientRequest<
                SingleResource<SupplierInvoiceExternalURLConnection>
            >(
                HttpMethod.Post, 
                request.AccessToken, 
                request.ClientSecret, 
                $"{ApiEndpoints.SupplierInvoiceExternalURLConnections}")
                {
                    Data = new SingleResource<SupplierInvoiceExternalURLConnection>
                    {
                        Data = SupplierInvoiceExternalURLConnections
                    }
                };
            
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SupplierInvoiceExternalURLConnection> UpdateSupplierInvoiceExternalURLConnectionsAsync(
            FortnoxApiRequest request,
            SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
        {
            var apiRequest = new FortnoxApiClientRequest<
                SingleResource<SupplierInvoiceExternalURLConnection>
            >(
                HttpMethod.Put, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.SupplierInvoiceExternalURLConnections}/{supplierInvoiceExternalURLConnection.Id}/")
                {
                    Data = new SingleResource<SupplierInvoiceExternalURLConnection>
                    {
                        Data = supplierInvoiceExternalURLConnection
                    }
                };
            
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteSupplierInvoiceExternalURLConnectionsAsync(FortnoxApiRequest request, string id)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.SupplierInvoiceExternalURLConnections}/{id}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}