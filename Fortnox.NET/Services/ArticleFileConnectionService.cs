using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.FileConnection;
using FortnoxNET.Constants;
using FortnoxNET.Models.FileConnections;

namespace FortnoxNET.Services
{
    public class ArticleFileConnectionService
    {
        public static async Task<ListedResourceResponse<ArticleFileConnections>> GetArticleFileConnectionsAsync(
            ArticleFileConnectionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ArticleFileConnections>>(
                HttpMethod.Get, 
                listRequest, 
                ApiEndpoints.ArticleFileConnections
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<ArticleFileConnections> GetArticleFileConnectionAsync(
            ArticleFileConnectionListRequest listRequest,
            string fileId)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ArticleFileConnections>>(
                HttpMethod.Get, 
                listRequest, 
                $"{ApiEndpoints.ArticleFileConnections}/{fileId}"
            );

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<ArticleFileConnection> CreateArticleFileConnection(
            FortnoxApiRequest request,
            string articleNumber,
            string fileId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<ArticleFileConnection>>(
                    HttpMethod.Post,
                    request,
                    $"{ApiEndpoints.ArticleFileConnections}")
                {
                    Data = new SingleResource<ArticleFileConnection>()
                    {
                        Data = new ArticleFileConnection()
                        {
                            ArticleNumber = articleNumber,
                            FileId = fileId,
                        }
                    }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteArticleFileConnection(FortnoxApiRequest request, string fileId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.ArticleFileConnections}/{fileId}");

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}