using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Unit;
using FortnoxNET.Constants;
using FortnoxNET.Models.Unit;

namespace FortnoxNET.Services
{
    public class UnitService
    {
        public static async Task<ListedResourceResponse<Unit>> GetUnitsAsync(UnitListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<Unit>>(HttpMethod.Get, listRequest,
                                                                                                 ApiEndpoints.Units);
            
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
        
        public static async Task<Unit> GetUnitAsync(FortnoxApiRequest request, string unitCode)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Unit>>(HttpMethod.Get, request,
                                                                                           $"{ApiEndpoints.Units}/{unitCode}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}