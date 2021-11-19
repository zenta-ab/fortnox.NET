
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.Offer
{
    public class OfferListRequest : FortnoxApiListedResourceRequest
    {
        public OfferListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public OfferListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public OfferFilters? Filter { get; set; }

        public OfferSortableProperties? SortBy { get; set; }

        public Dictionary<OfferSearchParameters, object> SearchParameters { get; set; }
    }
}
