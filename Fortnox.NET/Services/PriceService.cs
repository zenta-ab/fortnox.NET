using FortnoxNET.Communication;
using FortnoxNET.Communication.Price;
using FortnoxNET.Constants;
using FortnoxNET.Models.Price;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class PriceService
    {
        public static async Task<ListedResourceResponse<PriceSubset>> GetPricesAsync(PriceListRequest listRequest, string priceList, string articleNumber = "")
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<PriceSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        $"{ApiEndpoints.Prices}/sublist/{priceList}/{articleNumber}");

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

        public static async Task<Price> GetPriceForArticleAsync(FortnoxApiRequest request, string priceList, string articleNumber, string fromQuantity)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Price>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.Prices}/{priceList}/{articleNumber}/{fromQuantity}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Price> CreatePriceAsync(FortnoxApiRequest request, Price price)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Price>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Prices}")
                {
                    Data = new SingleResource<Price> { Data = price }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Price> UpdatePriceAsync(FortnoxApiRequest request, Price price)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Price>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Prices}/{price.PriceList}/{price.ArticleNumber}/{price.FromQuantity}")
                {
                    Data = new SingleResource<Price> { Data = price }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeletePriceAsync(FortnoxApiRequest request, string priceList, string articleNumber, string fromQuantity)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<object>>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Prices}/{priceList}/{articleNumber}/{fromQuantity}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
