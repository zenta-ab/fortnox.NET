using System.Collections.Generic;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class VoucherListRequest : FortnoxApiListedResourceRequest
    {
        public VoucherListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            SearchParameters = new Dictionary<VoucherSearchParameters, object>();
        }
        
        public Dictionary<VoucherSearchParameters, object> SearchParameters { get; set; }
        public VoucherSortableProperties? SortBy { get; set; }
    }
}