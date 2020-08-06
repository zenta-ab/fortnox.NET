namespace FortnoxNET.Communication
{
    public class FortnoxApiRequest
    {
        public FortnoxApiRequest(string accessToken, string clientSecret)
        {
            AccessToken = accessToken;
            ClientSecret = clientSecret;
        }
        
        public string AccessToken { get; private set; }
        public string ClientSecret { get; private set; }
    }
}