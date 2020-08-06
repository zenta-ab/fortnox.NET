namespace FortnoxNET.Communication.Label
{
    public class LabelListRequest : FortnoxApiListedResourceRequest
    {
        public LabelListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}
