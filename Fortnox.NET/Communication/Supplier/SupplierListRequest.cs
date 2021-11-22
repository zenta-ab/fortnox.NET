using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.Supplier
{
    public class SupplierListRequest : FortnoxApiListedResourceRequest
    {
        public SupplierListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public SupplierListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public SupplierSortableProperties? SortBy { get; set; }

        public Dictionary<SupplierSearchParameters, object> SearchParameters { get; set; }
    }
}
