namespace FortnoxNET.Communication.ContractAccrual
{
    public class ContractAccrualListRequest : FortnoxApiListedResourceRequest
    {
        public ContractAccrualListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}