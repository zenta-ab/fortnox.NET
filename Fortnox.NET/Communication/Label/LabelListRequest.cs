using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.Label
{
    public class LabelListRequest : FortnoxApiListedResourceRequest
    {
        public LabelListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public LabelListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}
