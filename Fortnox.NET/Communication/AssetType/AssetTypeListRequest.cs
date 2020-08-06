namespace FortnoxNET.Communication.AssetType
{
    public class AssetTypeListRequest : FortnoxApiListedResourceRequest
    {
        public AssetTypeListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}
