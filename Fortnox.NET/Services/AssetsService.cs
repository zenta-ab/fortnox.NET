using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.NET.Models.Assets;
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

        public static async Task<Asset> WriteUpAssetAsync(FortnoxApiRequest request, string identifier, WriteUpOrDownAsset asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<WriteUpOrDownAsset>>(
                HttpMethod.Put,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/writeup/{identifier}"
            )
            {
                Data = new SingleResource<WriteUpOrDownAsset> { Data = asset }
            };

            return (await FortnoxAPIClient.CallAsync<SingleResource<WriteUpOrDownAsset>, SingleResource<Asset>>(apiRequest)).Data;
        }

        public static async Task<Asset> WriteDownAssetAsync(FortnoxApiRequest request, string identifier, WriteUpOrDownAsset asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<WriteUpOrDownAsset>>(
                HttpMethod.Put,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/writedown/{identifier}"
            )
            {
                Data = new SingleResource<WriteUpOrDownAsset> { Data = asset }
            };

            return (await FortnoxAPIClient.CallAsync<SingleResource<WriteUpOrDownAsset>, SingleResource<Asset>>(apiRequest)).Data;
        }

        public static async Task<Asset> ScrapAssetAsync(FortnoxApiRequest request, string identifier, AssetScrap asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<AssetScrap>>(
                HttpMethod.Put,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/scrap/{identifier}"
            )
            {
                Data = new SingleResource<AssetScrap> { Data = asset }
            };

            return (await FortnoxAPIClient.CallAsync<SingleResource<AssetScrap>, SingleResource<Asset>>(apiRequest)).Data;
        }

        public static async Task<Asset> SellAssetAsync(FortnoxApiRequest request, string identifier, SellAsset asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SellAsset>>(
                HttpMethod.Put,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/sell/{identifier}"
            )
            {
                Data = new SingleResource<SellAsset> { Data = asset }
            };

            return (await FortnoxAPIClient.CallAsync<SingleResource<SellAsset>, SingleResource<Asset>>(apiRequest)).Data;
        }

        public static async Task<ListedResourceResponse<AssetsDepreciation>> DepreciateAssetAsync(FortnoxApiRequest request, DepreciateAssets asset)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<DepreciateAssets>>(
                HttpMethod.Post,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Assets}/depreciate"
            )
            {
                Data = new SingleResource<DepreciateAssets> { Data = asset }
            };

            return (await FortnoxAPIClient.CallAsync<SingleResource<DepreciateAssets>, ListedResourceResponse<AssetsDepreciation>>(apiRequest));
        }
    }
}