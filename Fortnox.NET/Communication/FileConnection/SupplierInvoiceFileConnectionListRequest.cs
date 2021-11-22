using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Communication;

namespace Fortnox.NET.Communication.FileConnection
{
    public class SupplierInvoiceFileConnectionListRequest : FortnoxApiListedResourceRequest
    {
        public SupplierInvoiceFileConnectionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public SupplierInvoiceFileConnectionListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}