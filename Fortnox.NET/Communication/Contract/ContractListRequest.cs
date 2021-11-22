using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.Contract
{
    public class ContractListRequest : FortnoxApiListedResourceRequest
    {
        public ContractListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ContractListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public ContractFilters? Filter { get; set; }

        public ContractSortableProperties? SortBy { get; set; }

        public Dictionary<ContractSearchParameters, object> SearchParameters { get; set; }
    }
}
