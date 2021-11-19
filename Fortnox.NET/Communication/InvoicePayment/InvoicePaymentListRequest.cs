using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class InvoicePaymentListRequest : FortnoxApiListedResourceRequest
    {
        public InvoicePaymentListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            SearchParameters = new Dictionary<InvoicePaymentSearchParameters, object>();
        }

        public InvoicePaymentListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
            SearchParameters = new Dictionary<InvoicePaymentSearchParameters, object>();
        }

        public Dictionary<InvoicePaymentSearchParameters, object> SearchParameters { get; set; }
    }
}