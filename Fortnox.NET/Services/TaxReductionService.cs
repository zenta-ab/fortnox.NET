using FortnoxNET.Communication;
using FortnoxNET.Communication.TaxReduction;
using FortnoxNET.Constants;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Models.TaxReduction;

namespace FortnoxNET.Services
{
    public class TaxReductionService
    {
        public static async Task<ListedResourceResponse<TaxReduction>> GetTaxReductionsAsync(TaxReductionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<TaxReduction>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        ApiEndpoints.TaxReductions);

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

        public static async Task<TaxReduction> GetTaxReductionAsync(FortnoxApiRequest request, string taxReductionId)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<TaxReduction>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.TaxReductions}/{taxReductionId}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TaxReduction> CreateTaxReductionAsync(FortnoxApiRequest request, TaxReduction taxReduction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TaxReduction>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.TaxReductions}")
                {
                    Data = new SingleResource<TaxReduction> { Data = taxReduction }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TaxReduction> UpdateTaxReductionAsync(FortnoxApiRequest request, TaxReduction taxReduction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TaxReduction>>(
                    HttpMethod.Put,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.TaxReductions}/{taxReduction.Id}")
                {
                    Data = new SingleResource<TaxReduction> { Data = taxReduction }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteTaxReductionAsync(FortnoxApiRequest request, string taxReductionId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<object>>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.TaxReductions}/{taxReductionId}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}