using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class FortnoxApiListedResourceRequest : FortnoxApiRequest
    {
        public FortnoxApiListedResourceRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
            Page = 0;
            Limit = 100;
            SortOrder = SortOrder.Ascending;
        }

        public FortnoxApiListedResourceRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
            Page = 0;
            Limit = 100;
            SortOrder = SortOrder.Ascending;
        }

        public SortOrder SortOrder { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}