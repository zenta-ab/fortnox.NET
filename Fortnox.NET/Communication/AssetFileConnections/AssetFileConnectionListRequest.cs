namespace FortnoxNET.Communication.AssetFileConnections
{
    public class AssetFileConnectionListRequest : FortnoxApiListedResourceRequest
    {
        public AssetFileConnectionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}