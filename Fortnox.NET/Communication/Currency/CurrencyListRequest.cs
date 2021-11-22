using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.Currency
{
    public class CurrencyListRequest : FortnoxApiListedResourceRequest
    {
        public CurrencyListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public CurrencyListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}
