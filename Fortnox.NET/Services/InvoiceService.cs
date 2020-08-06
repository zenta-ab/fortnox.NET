using FortnoxNET.Communication;
using FortnoxNET.Communication.Invoice;
using FortnoxNET.Constants;
using FortnoxNET.Models.Invoice;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class InvoiceService
    {
        public static async Task<ListedResourceResponse<InvoiceSubset>> GetInvoicesAsync(InvoiceListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<InvoiceSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        ApiEndpoints.Invoices);

            apiRequest.SetFilter(listRequest.Filter?.ToString());
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            if (listRequest.SearchParameters == null)
            {
                return await FortnoxAPIClient.CallAsync(apiRequest);
            }

            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Invoice> GetInvoiceAsync(FortnoxApiRequest request, string invoiceNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Invoice>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                $"{ApiEndpoints.Invoices}/{invoiceNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Invoice> CreateInvoiceAsync(FortnoxApiRequest request, Invoice invoice)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Invoice>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Invoices}")
                {
                    Data = new SingleResource<Invoice> { Data = invoice}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Invoice> UpdateInvoiceAsync(FortnoxApiRequest request, Invoice invoice)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Invoice>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                                                                   $"{ApiEndpoints.Invoices}/{invoice.DocumentNumber}")
                {
                    Data = new SingleResource<Invoice> { Data = invoice}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
