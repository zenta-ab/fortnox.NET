using System.Collections.Generic;
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

        public ArticleFilters? Filter { get; set; }
        public ArticleSortableProperties? SortBy { get; set; }
        public Dictionary<ArticleSearchParameters, object> SearchParameters { get; set; }
    }
}