using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.Invoice;
using FortnoxNET.Models.Voucher;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Services
{
    public class VoucherService
    {
        public static async Task<ListedResourceResponse<VoucherSubset>> GetVouchersAsync(VoucherListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<VoucherSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.Vouchers);

            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
                       
            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<Voucher> GetVoucherAsync(FortnoxApiRequest request, int financialYear, string series, int voucherNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Voucher>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.Vouchers}/{series}/{voucherNumber}?financialyear={financialYear}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task<Voucher> GetVoucherAsync(FortnoxApiRequest request, string url)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Voucher>>(HttpMethod.Get, request, url);

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}