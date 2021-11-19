using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.Archive
{
    public class ArchiveListRequest : FortnoxApiListedResourceRequest
    {
        public ArchiveListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ArchiveListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}