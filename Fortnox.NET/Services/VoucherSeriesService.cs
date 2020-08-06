using FortnoxNET.Communication;
using FortnoxNET.Communication.VoucherSeries;
using FortnoxNET.Constants;
using FortnoxNET.Models.VoucherSeries;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class VoucherSeriesService
    {
        public static async Task<ListedResourceResponse<VoucherSeriesSubset>> GetVoucherSeriesAsync(VoucherSeriesListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<VoucherSeriesSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.VoucherSeries);
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<VoucherSeries> GetVoucherSerieAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<VoucherSeries>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.VoucherSeries}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<VoucherSeries> CreateVoucherSeriesAsync(FortnoxApiRequest request, VoucherSeries voucherSeries)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<VoucherSeries>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.VoucherSeries}")
                {
                    Data = new SingleResource<VoucherSeries> { Data = voucherSeries }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<VoucherSeries> UpdateVoucherSeriesAsync(FortnoxApiRequest request, VoucherSeries voucherSeries)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<VoucherSeries>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.VoucherSeries}/{voucherSeries.Code}/")
                {
                    Data = new SingleResource<VoucherSeries> { Data = voucherSeries }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
