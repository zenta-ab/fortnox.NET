using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication
{
    public class FortnoxApiRequest
    {
        public FortnoxApiRequest(string accessToken, string clientSecret)
        {
            AccessToken = accessToken;
            ClientSecret = clientSecret;
        }

        public FortnoxApiRequest(OAuthToken oAuthToken)
        {
            OAuthToken = oAuthToken;
        }

        public string AccessToken { get; private set; }
        public string ClientSecret { get; private set; }

        public OAuthToken OAuthToken { get; private set; }

        public bool UsesOAuth()
        {
            return OAuthToken != null;
        }
    }
}