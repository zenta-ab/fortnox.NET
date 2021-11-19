using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.Article
{
    public class ArticleListRequest : FortnoxApiListedResourceRequest
    {
        public ArticleListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ArticleListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public ArticleFilters? Filter { get; set; }
        public ArticleSortableProperties? SortBy { get; set; }
        public Dictionary<ArticleSearchParameters, object> SearchParameters { get; set; }
    }
}