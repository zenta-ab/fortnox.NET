using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Article;
using FortnoxNET.Constants;
using FortnoxNET.Models.Article;

namespace FortnoxNET.Services
{
    public class ArticleService
    {
        public static async Task<ListedResourceResponse<ArticleSubset>> GetArticlesAsync(ArticleListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ArticleSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                 ApiEndpoints.Articles);

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
        
        public static async Task<Article> GetArticleAsync(FortnoxApiRequest request, string articleNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Article>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                           $"{ApiEndpoints.Articles}/{articleNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task<Article> CreateArticleAsync(FortnoxApiRequest request, Article article)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Article>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Articles}")
                {
                    Data = new SingleResource<Article> {Data = article}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Article> UpdateArticleAsync(FortnoxApiRequest request, Article article)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Article>>(HttpMethod.Put, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Articles}/{article.ArticleNumber}")
                {
                    Data = new SingleResource<Article> {Data = article}
                };
            
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}