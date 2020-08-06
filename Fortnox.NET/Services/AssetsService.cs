using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Assets;
using FortnoxNET.Constants;
using FortnoxNET.Models.Assets;

namespace FortnoxNET.Services
{
    public class AssetsService
    {
        public static async Task<ListedResourceResponse<AssetSubset>> GetAssetsAsync(AssetListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AssetSubset>>(
                HttpMethod.Get,
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                ApiEndpoints.Assets
            );

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Asset> GetAssetAsync(FortnoxApiRequest request, string identifier)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Asset>>(
                HttpMethod.Get, 
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/{identifier}"
            );

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Asset> CreateAssetAsync(FortnoxApiRequest request, Asset asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Asset>>(
                HttpMethod.Post,
                request.AccessToken,
                request.ClientSecret,
                ApiEndpoints.Assets
            )
            {
                Data = new SingleResource<Asset> {Data = asset}
            };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Asset> UpdateAssetAsync(FortnoxApiRequest request, Asset asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Asset>>(
                HttpMethod.Put,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/{asset.Id}"
            )
            {
                Data = new SingleResource<Asset> {Data = asset}
            };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task DeleteAssetAsync(FortnoxApiRequest request, string identifier)
        {
            var apiRequest = new FortnoxApiClientRequest<string>(
                HttpMethod.Delete,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/{identifier}"
            );

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}