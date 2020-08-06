using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Communication.Invoice
{
    public class InvoiceListRequest : FortnoxApiListedResourceRequest
    {
        public InvoiceListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public InvoiceFilters? Filter { get; set; }
        public InvoiceSortableProperties? SortBy { get; set; }
        public Dictionary<InvoiceSearchParameters, object> SearchParameters { get; set; }
    }
}
