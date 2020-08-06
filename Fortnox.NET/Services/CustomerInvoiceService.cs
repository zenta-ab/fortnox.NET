using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.Invoice;

namespace FortnoxNET.Services
{
    public class CustomerInvoiceService
    {
        public static async Task<ListedResourceResponse<InvoiceSubset>> GetCustomerInvoicesAsync(CustomerInvoiceListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<InvoiceSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                           ApiEndpoints.CustomerInvoices);

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

        public static async Task<CustomerInvoice> GetCustomerInvoiceAsync(FortnoxApiRequest request, string documentNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<CustomerInvoice>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                       $"{ApiEndpoints.CustomerInvoices}/{documentNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}