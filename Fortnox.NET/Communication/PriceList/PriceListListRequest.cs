using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.PriceList
{
    public class PriceListListRequest : FortnoxApiListedResourceRequest
    {
        public PriceListListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public PriceListListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public PriceListsSortableProperties? SortBy { get; set; }

        public Dictionary<PriceListsSearchParameters, object> SearchParameters { get; set; }
    }
}
