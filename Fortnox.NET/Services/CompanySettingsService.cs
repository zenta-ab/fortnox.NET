using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.CompanySettings;

namespace FortnoxNET.Services
{
    public class CompanySettingsService
    {
        public static async Task<CompanySettings> GetCompanySettingsAsync(FortnoxApiRequest request)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<CompanySettings>>(HttpMethod.Get, request,
                $"{ApiEndpoints.CompanySettings}/");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}