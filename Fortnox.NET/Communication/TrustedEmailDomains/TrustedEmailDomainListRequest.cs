namespace FortnoxNET.Communication.TrustedEmailDomains
{
    public class TrustedEmailDomainListRequest : FortnoxApiListedResourceRequest
    {
        public TrustedEmailDomainListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}

