namespace FortnoxNET.Communication.Assets
{
    public class AssetListRequest : FortnoxApiListedResourceRequest
    {
        public AssetListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}
