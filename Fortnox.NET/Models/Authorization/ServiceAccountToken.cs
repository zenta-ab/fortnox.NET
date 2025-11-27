using Newtonsoft.Json;

namespace FortnoxNET.Models.Authorization
{
    /// <summary>
    /// Represents the OAuth token response from Fortnox Client Credentials Flow (Service Accounts).
    /// </summary>
    public class ServiceAccountToken
    {
        /// <summary>
        /// The access token to use for API requests. Valid for 1 hour.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The type of token. Always "Bearer" for service accounts.
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// The number of seconds until the token expires.
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
