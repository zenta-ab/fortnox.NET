using FortnoxNET.Constants.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Communication.SupplierInvoicePayment
{
    public class SupplierInvoicePaymentListRequest : FortnoxApiListedResourceRequest
    {
        public SupplierInvoicePaymentListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            SearchParameters = new Dictionary<SupplierInvoicePaymentSearchParameters, object>();
        }

        public Dictionary<SupplierInvoicePaymentSearchParameters, object> SearchParameters { get; set; }
    }
}
