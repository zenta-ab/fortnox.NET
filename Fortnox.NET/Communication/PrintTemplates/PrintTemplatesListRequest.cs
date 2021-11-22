using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Filter;
using System.Collections.Generic;

namespace FortnoxNET.Communication.PrintTemplates
{
    public class PrintTemplatesListRequest : FortnoxApiListedResourceRequest
    {
        public PrintTemplatesListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public PrintTemplatesListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public PrintTemplatesFilter? Filter { get; set; }

    }
}
