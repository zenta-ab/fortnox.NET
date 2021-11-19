using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;


namespace FortnoxNET.Communication.TaxReduction
{
    public class TaxReductionListRequest : FortnoxApiListedResourceRequest
    {
        public TaxReductionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            SearchParameters = new Dictionary<TaxReductionSearchParameters, object>();
        }

        public TaxReductionListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
            SearchParameters = new Dictionary<TaxReductionSearchParameters, object>();
        }

        public TaxReductionFilter? Filter { get; set; }

        public TaxReductionSortableProperties? SortBy { get; set; }

        public Dictionary<TaxReductionSearchParameters, object> SearchParameters { get; set; }
    }
}