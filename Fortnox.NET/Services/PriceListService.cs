using FortnoxNET.Communication;
using FortnoxNET.Communication.PriceList;
using FortnoxNET.Constants;
using FortnoxNET.Models.PriceList;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class PriceListService
    {
        public static async Task<ListedResourceResponse<PriceListSubset>> GetPriceListsAsync(PriceListListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<PriceListSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.PriceLists);
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

        public static async Task<PriceList> GetPriceListAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<PriceList>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.PriceLists}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<PriceList> CreatePriceListAsync(FortnoxApiRequest request, PriceList priceList)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<PriceList>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.PriceLists}")
                {
                    Data = new SingleResource<PriceList> { Data = priceList}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<PriceList> UpdatePriceListAsync(FortnoxApiRequest request, PriceList priceList)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<PriceList>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.PriceLists}/{priceList.Code}/")
                {
                    Data = new SingleResource<PriceList> { Data = priceList}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
