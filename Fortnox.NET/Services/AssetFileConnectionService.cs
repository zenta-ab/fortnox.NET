using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.AssetFileConnections;
using FortnoxNET.Communication.FileConnection;
using FortnoxNET.Constants;
using FortnoxNET.Models.FileConnections;

namespace FortnoxNET.Services
{
    public class AssetFileConnectionService
    {
        public static async Task<ListedResourceResponse<AssetFileConnections>> GetAssetFileConnectionsAsync(
            AssetFileConnectionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AssetFileConnections>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret, 
                ApiEndpoints.AssetFileConnections
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<AssetFileConnection> GetAssetFileConnectionAsync(
            AssetFileConnectionListRequest listRequest,
            string fileId)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<AssetFileConnection>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret, 
                $"{ApiEndpoints.AssetFileConnections}/{fileId}"
            );

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AssetFileConnection> CreateAssetFileConnection(
            FortnoxApiRequest request,
            string assetId,
            string fileId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AssetFileConnection>>(
                    HttpMethod.Post,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.AssetFileConnections}")
                {
                    Data = new SingleResource<AssetFileConnection>()
                    {
                        Data = new AssetFileConnection()
                        {
                            AssetId = assetId,
                            FileId = fileId,
                        }
                    }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteAssetFileConnection(FortnoxApiRequest request, string fileId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.AssetFileConnections}/{fileId}");

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}