using System.Collections.Generic;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class CustomerInvoiceListRequest : FortnoxApiListedResourceRequest
    {
        public CustomerInvoiceListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public CustomerInvoiceFilters? Filter { get; set; }
        public CustomerInvoiceSortableProperties? SortBy { get; set; }
        public Dictionary<CustomerInvoiceSearchParameters, object> SearchParameters { get; set; }
    }
}