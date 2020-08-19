namespace FortnoxNET.Communication.ContractTemplates
{
    public class ContractTemplateListRequest : FortnoxApiListedResourceRequest
    {
        public ContractTemplateListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}