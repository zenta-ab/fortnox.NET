using FortnoxNET.Communication;
using FortnoxNET.Communication.FinancialYear;
using FortnoxNET.Constants;
using FortnoxNET.Models.FinancialYear;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class FinancialYearService
    {
        public static async Task<ListedResourceResponse<FinancialYearSubset>> GetFinancialYearsAsync(FinancialYearListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<FinancialYearSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.FinancialYears);
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

        public static async Task<FinancialYear> GetFinancialYearAsync(FortnoxApiRequest request, int id)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<FinancialYear>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.FinancialYears}/{id}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<FinancialYear> CreateFinancialYearAsync(FortnoxApiRequest request, FinancialYear financialYear)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<FinancialYear>>(HttpMethod.Post, request, $"{ApiEndpoints.FinancialYears}")
                {
                    Data = new SingleResource<FinancialYear> { Data = financialYear }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
