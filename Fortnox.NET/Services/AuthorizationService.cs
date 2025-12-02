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

        /// <summary>
        /// Get an URL to visit in order to get the authorization code used to retrieve a access token.
        /// </summary>
        /// <param name="clientId">The client_id is the public identifier for the app.</param>
        /// <param name="redirectUri">URL-encoded URI that must match the Redirect URI for the app set in the Developer Portal. If omitted, it will default to the registered Redirect URI.</param>
        /// <param name="scopes">The request should have one or more scope values indicating access requested by the application. </param>
        /// <param name="state">The state parameter is used by the application to store request-specific data and/or prevent CSRF attacks.</param>
        /// <param name="accountType">Optional. Set to "service" to create a service account instead of a user account. Service accounts are not tied to individual users and support Client Credentials Flow.</param>
        /// <returns>A string with the URL to redirect to in order to initiate the OAuth flow.</returns>
        public static string GetAuthorizationUrl(string clientId, string redirectUri, string scopes, string state, string accountType = null)
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

            if (accountType != null)
            {
                urlContent.Add(new KeyValuePair<string, string>("account_type", accountType));
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

        /// <summary>
        /// Exchange an Authorization Code for an OAuthToken
        /// </summary>
        /// <param name="authorizationCode">Generated when the customer authenticates and approves the connection between their account and your application</param>
        /// <param name="clientId">The client_id is the public identifier for the app.</param>
        /// <param name="clientSecret">The client secret is the secret identifier.</param>
        /// <param name="redirectUri">The client_id is the public identifier for the app.</param>
        /// <returns>An OAuthToken object.</returns>
        public static async Task<OAuthToken> GetAccessTokenAsync(string authorizationCode, string clientId, string clientSecret, string redirectUri = null)
        {
            return await FortnoxAPIClient.GetAccessTokenAsync(authorizationCode, clientId, clientSecret, redirectUri);
        }

        /// <summary>
        /// Refreshes an OAuthToken
        /// </summary>
        /// <param name="clientId">The client_id is the public identifier for the app.</param>
        /// <param name="clientSecret">The client secret is the secret identifier.</param>
        /// <param name="refreshToken">The refresh token for your OAuthToken</param>
        /// <returns>An OAuthToken object.</returns>
        public static async Task<OAuthToken> RefreshTokenAsync(string clientId, string clientSecret, string refreshToken)
        {
            return await FortnoxAPIClient.RefreshAccessToken(clientId, clientSecret, refreshToken);
        }

        /// <summary>
        /// Gets an access token using Client Credentials Flow for service accounts.
        /// This is the recommended flow for integrations that use service accounts instead of user accounts.
        /// Service accounts are not tied to individual users and are ideal for server-to-server integrations.
        /// </summary>
        /// <remarks>
        /// <para>To use this flow, the integration must first be activated with account_type=service parameter.</para>
        /// <para>Access tokens are valid for 1 hour (3600 seconds). When expired, simply request a new token - no refresh token is used.</para>
        /// </remarks>
        /// <param name="clientId">The client_id is the public identifier for the app.</param>
        /// <param name="clientSecret">The client secret is the secret identifier.</param>
        /// <param name="tenantId">The customer's tenant ID</param>
        /// <returns>A ServiceAccountToken containing access_token, token_type, and expires_in.</returns>
        public static async Task<ServiceAccountToken> GetServiceAccountTokenAsync(string clientId, string clientSecret, long tenantId)
        {
            return await FortnoxAPIClient.GetServiceAccountTokenAsync(clientId, clientSecret, tenantId);
        }
    }
}