using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.ModesOfPayments;
using FortnoxNET.Constants;
using FortnoxNET.Models.ModesOfPayments;

namespace FortnoxNET.Services
{
    public class ModesOfPaymentsService
    {
        public static async Task<ListedResourceResponse<ModesOfPaymentsSubset>> GetModesOfPaymentsAsync(ModesOfPaymentsListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ModesOfPaymentsSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.ModesOfPayments);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<ModesOfPayment> GetModesOfPaymentAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ModesOfPayment>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.ModesOfPayments}/{code}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<ModesOfPayment> CreateModesOfPaymentAsync(FortnoxApiRequest request, ModesOfPayment modesOfPayments)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<ModesOfPayment>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.ModesOfPayments}")
                {
                    Data = new SingleResource<ModesOfPayment> { Data = modesOfPayments }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<ModesOfPayment> UpdateModesOfPaymentAsync(FortnoxApiRequest request, ModesOfPayment modesOfPayments)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<ModesOfPayment>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.ModesOfPayments}/{modesOfPayments.Code}")
                {
                    Data = new SingleResource<ModesOfPayment> { Data = modesOfPayments }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}