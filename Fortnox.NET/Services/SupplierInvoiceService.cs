using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.Invoice;
using FortnoxNET.Models.SupplierInvoice;

namespace FortnoxNET.Services
{
    public class SupplierInvoiceService
    {
        public static async Task<ListedResourceResponse<SupplierInvoiceSubset>> GetSupplierInvoicesAsync(SupplierInvoiceListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SupplierInvoiceSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.SupplierInvoices);

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
        
        public static async Task<SupplierInvoice> GetSupplierInvoiceAsync(FortnoxApiRequest request, int financialYear, int SupplierInvoiceNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SupplierInvoice>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.SupplierInvoices}/{SupplierInvoiceNumber}?financialyear={financialYear}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task<SupplierInvoice> GetSupplierInvoiceAsync(FortnoxApiRequest request, string url)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SupplierInvoice>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,url);

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}