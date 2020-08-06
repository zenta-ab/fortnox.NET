using System.Collections.Generic;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class CustomerListRequest : FortnoxApiListedResourceRequest
    {
        public CustomerListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public CustomerFilters? Filter { get; set; }
        public CustomerSortableProperties? SortBy { get; set; }
        public Dictionary<CustomerSearchParameters, object> SearchParameters { get; set; }
    }
}