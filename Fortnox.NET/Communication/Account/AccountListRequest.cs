using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class AccountListRequest : FortnoxApiListedResourceRequest
    {
        public AccountListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            SearchParameters = new Dictionary<AccountSearchParameters, object>();
        }

        public AccountListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
            SearchParameters = new Dictionary<AccountSearchParameters, object>();
        }

        public Dictionary<AccountSearchParameters, object> SearchParameters { get; set; }
        public AccountSortableProperties? SortBy { get; set; }
    }
}