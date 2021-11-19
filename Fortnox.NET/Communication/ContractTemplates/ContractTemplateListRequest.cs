using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.ContractTemplates
{
    public class ContractTemplateListRequest : FortnoxApiListedResourceRequest
    {
        public ContractTemplateListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ContractTemplateListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}