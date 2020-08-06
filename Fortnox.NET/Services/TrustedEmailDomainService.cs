using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.TrustedEmailDomains;
using FortnoxNET.Constants;
using FortnoxNET.Models.TrustedEmailDomains;

namespace FortnoxNET.Services
{
    public class TrustedEmailDomainService
    {
        public static async Task<ListedResourceResponse<TrustedEmailDomainSubset>> GetTrustedEmailDomainsAsync(TrustedEmailDomainListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<TrustedEmailDomainSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.EmailTrustedDomains);
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<TrustedEmailDomain> GetTrustedEmailDomainAsync(FortnoxApiRequest request, string id)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<TrustedEmailDomain>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.EmailTrustedDomains}/{id}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TrustedEmailDomain> CreateTrustedEmailDomainAsync(FortnoxApiRequest request, TrustedEmailDomain trustedEmailDomain)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TrustedEmailDomain>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.EmailTrustedDomains}")
                {
                    Data = new SingleResource<TrustedEmailDomain> { Data = trustedEmailDomain }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteTrustedEmailDomainAsync(FortnoxApiRequest request, string id)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.EmailTrustedDomains}/{id}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}