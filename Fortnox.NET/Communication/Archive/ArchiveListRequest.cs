namespace FortnoxNET.Communication.Archive
{
    public class ArchiveListRequest : FortnoxApiListedResourceRequest
    {
        public ArchiveListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}