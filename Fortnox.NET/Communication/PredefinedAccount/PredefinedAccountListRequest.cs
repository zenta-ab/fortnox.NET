namespace FortnoxNET.Communication.PredefinedAccount
{
    public class PredefinedAccountListRequest : FortnoxApiListedResourceRequest
    {
        public PredefinedAccountListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}