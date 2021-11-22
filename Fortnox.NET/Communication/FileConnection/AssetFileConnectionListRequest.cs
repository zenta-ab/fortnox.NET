using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.FileConnection
{
    public class AssetFileConnectionListRequest : FortnoxApiListedResourceRequest
    {
        public AssetFileConnectionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public AssetFileConnectionListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}