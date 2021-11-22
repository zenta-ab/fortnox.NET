using FortnoxNET.Communication;
using FortnoxNET.Communication.AssetType;
using FortnoxNET.Constants;
using FortnoxNET.Models.AssetType;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class AssetTypeService
    {
        public static async Task<ListedResourceResponse<AssetTypeSubset>> GetAssetTypesAsync(AssetTypeListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AssetTypeSubset>>(HttpMethod.Get, listRequest,
                                                                                        $"{ApiEndpoints.AssetTypes}");

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Type> GetAssetTypeAsync(FortnoxApiRequest request, int id)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Type>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.AssetTypes}/{id}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AssetType> CreateAssetTypeAsync(FortnoxApiRequest request, AssetType assetType)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AssetType>>(HttpMethod.Post, request, $"{ApiEndpoints.AssetTypes}")
                {
                    Data = new SingleResource<AssetType> { Data = assetType }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AssetType> UpdateAssetTypeAsync(FortnoxApiRequest request, int id, AssetType assetType)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AssetType>>(HttpMethod.Put, request,
                    $"{ApiEndpoints.AssetTypes}/{id}")
                {
                    Data = new SingleResource<AssetType> { Data = assetType}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteAssetTypeAsync(FortnoxApiRequest request, int id)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.AssetTypes}/{id}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
