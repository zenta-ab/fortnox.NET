using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication
{
    public class SupplierInvoiceExternalURLConnectionsListRequest : FortnoxApiListedResourceRequest
    {
        public SupplierInvoiceExternalURLConnectionsListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public SupplierInvoiceExternalURLConnectionsListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}