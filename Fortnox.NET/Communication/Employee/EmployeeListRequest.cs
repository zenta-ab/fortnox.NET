using System.Collections.Generic;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication
{
    public class EmployeeListRequest : FortnoxApiListedResourceRequest
    {
        public EmployeeListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public EmployeeListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public EmployeeFilters? Filter { get; set; }
    }
}