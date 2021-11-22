using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.AssetType
{
    public class AssetTypeListRequest : FortnoxApiListedResourceRequest
    {
        public AssetTypeListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public AssetTypeListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}
