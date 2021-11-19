using FortnoxNET.Communication;
using FortnoxNET.Communication.TermsOfDelivery;
using FortnoxNET.Constants;
using FortnoxNET.Models.TermsOfDelivery;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class TermsOfDeliveryService
    {
        public static async Task<ListedResourceResponse<TermsOfDeliverySubset>> GetTermsOfDeliveriesAsync(TermsOfDeliveryListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<TermsOfDeliverySubset>>(HttpMethod.Get, listRequest,
                                                                                        ApiEndpoints.TermsOfDeliveries);

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

        public static async Task<TermsOfDelivery> GetTermsOfDeliveryAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<TermsOfDelivery>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.TermsOfDeliveries}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TermsOfDelivery> CreateTermsOfDeliveryAsync(FortnoxApiRequest request, TermsOfDelivery termsOfDelivery)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TermsOfDelivery>>(HttpMethod.Post, request, $"{ApiEndpoints.TermsOfDeliveries}")
                {
                    Data = new SingleResource<TermsOfDelivery> { Data = termsOfDelivery }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TermsOfDelivery> UpdateTermsOfDeliveryAsync(FortnoxApiRequest request, TermsOfDelivery termsOfDelivery)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TermsOfDelivery>>(HttpMethod.Put, request,
                    $"{ApiEndpoints.TermsOfDeliveries}/{termsOfDelivery.Code}/")
                {
                    Data = new SingleResource<TermsOfDelivery> { Data = termsOfDelivery }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
