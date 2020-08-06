using System.Collections.Generic;
using FortnoxNET.Constants.Search;

namespace FortnoxNET.Communication.Project
{
    public class ProjectListRequest : FortnoxApiListedResourceRequest
    {
        public ProjectListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
        
        public Dictionary<ProjectSearchParameters, object> SearchParameters { get; set; }
    }
}