using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class CompanyInformationService
    {
        public static async Task<CompanyInformation> GetCompanyInformationAsync(FortnoxApiRequest request)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<CompanyInformation>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                $"{ApiEndpoints.CompanyInformation}/");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
