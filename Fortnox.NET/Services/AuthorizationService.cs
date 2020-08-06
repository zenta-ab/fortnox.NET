using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Models.Authorization;

namespace FortnoxNET.Services
{
    public class AuthorizationService
    {
        public static async Task<AuthorizationResponse> GetAccessTokenAsync(string authorizationCode, string clientSecret)
        {
            return await FortnoxAPIClient.GetAccessTokenAsync(authorizationCode, clientSecret,
                "https://api.fortnox.se/3/customers");
        }
    }
}