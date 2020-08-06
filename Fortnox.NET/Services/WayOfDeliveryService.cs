using FortnoxNET.Communication;
using FortnoxNET.Communication.WayOfDelivery;
using FortnoxNET.Constants;
using FortnoxNET.Models.WayOfDelivery;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class WayOfDeliveryService
    {
        public static async Task<ListedResourceResponse<WayOfDeliverySubset>> GetWayOfDeliveriesAsync(WayOfDeliveryListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<WayOfDeliverySubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.WayOfDeliveries);
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<WayOfDelivery> GetWayOfDeliveryAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<WayOfDelivery>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.WayOfDeliveries}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<WayOfDelivery> CreateWayOfDeliveryAsync(FortnoxApiRequest request, WayOfDelivery wayOfDelivery)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<WayOfDelivery>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.WayOfDeliveries}")
                {
                    Data = new SingleResource<WayOfDelivery> { Data = wayOfDelivery }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<WayOfDelivery> UpdateWayOfDeliveryAsync(FortnoxApiRequest request, WayOfDelivery wayOfDelivery)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<WayOfDelivery>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.WayOfDeliveries}/{wayOfDelivery.Code}/")
                {
                    Data = new SingleResource<WayOfDelivery> { Data = wayOfDelivery }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteWayOfDeliveryAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.WayOfDeliveries}/{code}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
