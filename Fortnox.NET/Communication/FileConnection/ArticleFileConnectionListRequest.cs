namespace FortnoxNET.Communication.FileConnection
{
    public class ArticleFileConnectionListRequest : FortnoxApiListedResourceRequest
    {
        public ArticleFileConnectionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}