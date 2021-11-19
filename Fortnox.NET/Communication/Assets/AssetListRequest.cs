using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.Assets
{
    public class AssetListRequest : FortnoxApiListedResourceRequest
    {
        public AssetListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public AssetListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}
