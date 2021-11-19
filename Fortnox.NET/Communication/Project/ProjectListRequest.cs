using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;

namespace FortnoxNET.Communication.Project
{
    public class ProjectListRequest : FortnoxApiListedResourceRequest
    {
        public ProjectListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ProjectListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public Dictionary<ProjectSearchParameters, object> SearchParameters { get; set; }
    }
}