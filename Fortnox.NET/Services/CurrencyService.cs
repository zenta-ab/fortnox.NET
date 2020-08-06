using FortnoxNET.Communication;
using FortnoxNET.Communication.Currency;
using FortnoxNET.Constants;
using FortnoxNET.Models.Currency;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class CurrencyService
    {
        public static async Task<Currency> GetCurrencyAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Currency>>(
                HttpMethod.Get,
                request.AccessToken,
                request.ClientSecret,
                $"{ApiEndpoints.Currencies}/{code}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<ListedResourceResponse<CurrencySubset>> GetCurrenciesAsync(CurrencyListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<CurrencySubset>>(
                HttpMethod.Get,
                listRequest.AccessToken,
                listRequest.ClientSecret,
                ApiEndpoints.Currencies);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task DeleteCurrencyAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<object>>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Currencies}/{code}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Currency> CreateCurrencyAsync(FortnoxApiRequest request, Currency currency)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Currency>>(
                    HttpMethod.Post,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Currencies}")
                {
                    Data = new SingleResource<Currency> { Data = currency }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Currency> UpdateCurrencyAsync(FortnoxApiRequest request, Currency currency)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Currency>>(
                    HttpMethod.Put,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Currencies}/{currency.Code}")
                {
                    Data = new SingleResource<Currency> { Data = currency }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
