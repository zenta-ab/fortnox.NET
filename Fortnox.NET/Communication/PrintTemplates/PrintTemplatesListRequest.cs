using FortnoxNET.Constants.Filter;
using System.Collections.Generic;

namespace FortnoxNET.Communication.PrintTemplates
{
    public class PrintTemplatesListRequest : FortnoxApiListedResourceRequest
    {
        public PrintTemplatesListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public PrintTemplatesFilter? Filter { get; set; }

    }
}
