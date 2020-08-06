using System.Collections.Generic;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class SupplierInvoiceListRequest : FortnoxApiListedResourceRequest
    {
        public SupplierInvoiceListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public Dictionary<SupplierInvoiceSearchParameters, object> SearchParameters { get; set; }
        public SupplierInvoiceSortableProperties? SortBy { get; set; }
    }
}