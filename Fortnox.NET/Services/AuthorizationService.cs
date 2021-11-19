using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.Authorization;

namespace FortnoxNET.Services
{
    public class AuthorizationService
    {
        public static async Task<AuthorizationResponse> GetAccessTokenAsync(string authorizationCode, string clientSecret)
        {
            return await FortnoxAPIClient.GetAccessTokenAsync(authorizationCode, clientSecret,
                ApiEndpoints.Customers);
        }

        public static string GetAuthorizationUrl(string clientId, string redirectUri, string scopes, string state)
        {
            var urlContent = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("scope", scopes),
                new KeyValuePair<string, string>("state", state),
                new KeyValuePair<string, string>("access_type", "offline"),
                new KeyValuePair<string, string>("response_type", "code"),
            };

            if (redirectUri != null)
            {
                urlContent.Add(new KeyValuePair<string, string>("redirect_uri", redirectUri));
            }

            var sb = new StringBuilder();
            foreach (var kv in urlContent)
            {
                sb.Append("&");
                sb.Append(kv.Key);
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(kv.Value));
            }

            return $"{ApiEndpoints.OAuthAuth}?{sb}";
        }

        public static async Task<OAuthToken> GetAccessTokenAsync(string authorizationCode, string clientId, string clientSecret, string redirectUri = null)
        {
            return await FortnoxAPIClient.GetAccessTokenAsync(authorizationCode, clientId, clientSecret, redirectUri);
        }

        public static async Task<OAuthToken> RefreshTokenAsync(string clientId, string clientSecret, string refreshToken)
        {
            return await FortnoxAPIClient.RefreshAccessToken(clientId, clientSecret, refreshToken);
        }
    }
}