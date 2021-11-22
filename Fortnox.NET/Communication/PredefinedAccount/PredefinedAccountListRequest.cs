using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.PredefinedAccount
{
    public class PredefinedAccountListRequest : FortnoxApiListedResourceRequest
    {
        public PredefinedAccountListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public PredefinedAccountListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}