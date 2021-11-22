using FortnoxNET.Communication;
using FortnoxNET.Communication.CostCenter;
using FortnoxNET.Constants;
using FortnoxNET.Models.CostCenter;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class CostCenterService
    {
        public static async Task<ListedResourceResponse<CostCenterSubset>> GetCostCentersAsync(CostCenterListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<CostCenterSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.CostCenters);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<CostCenter> GetCostCenterAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<CostCenter>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.CostCenters}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<CostCenter> CreateCostCenterAsync(FortnoxApiRequest request, CostCenter costCenter)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<CostCenter>>(HttpMethod.Post, request, $"{ApiEndpoints.CostCenters}")
                {
                    Data = new SingleResource<CostCenter> { Data = costCenter}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<CostCenter> UpdateCostCenterAsync(FortnoxApiRequest request, CostCenter costCenter)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<CostCenter>>(HttpMethod.Put, request,
                    $"{ApiEndpoints.CostCenters}/{costCenter.Code}")
                {
                    Data = new SingleResource<CostCenter> { Data = costCenter }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteCostCenterAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<object>>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.CostCenters}/{code}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
