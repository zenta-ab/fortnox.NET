using FortnoxNET.Communication;
using FortnoxNET.Communication.TermsOfPayment;
using FortnoxNET.Constants;
using FortnoxNET.Models.TermsOfPayment;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class TermsOfPaymentService
    {
        public static async Task<ListedResourceResponse<TermsOfPaymentSubset>> GetTermsOfPaymentsAsync(TermsOfPaymentListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<TermsOfPaymentSubset>>(HttpMethod.Get, listRequest,
                                                                                        ApiEndpoints.TermsOfPayments);

            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<TermsOfPayment> GetTermsOfPaymentAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<TermsOfPayment>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.TermsOfPayments}/{code}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TermsOfPayment> CreateTermsOfPaymentAsync(FortnoxApiRequest request, TermsOfPayment termsOfPayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TermsOfPayment>>(HttpMethod.Post, request, $"{ApiEndpoints.TermsOfPayments}")
                {
                    Data = new SingleResource<TermsOfPayment> { Data = termsOfPayment }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<TermsOfPayment> UpdateTermsOfPaymentAsync(FortnoxApiRequest request, TermsOfPayment termsOfPayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<TermsOfPayment>>(HttpMethod.Put, request,
                    $"{ApiEndpoints.TermsOfPayments}/{termsOfPayment.Code}/")
                {
                    Data = new SingleResource<TermsOfPayment> { Data = termsOfPayment }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteTermsOfPaymentAsync(FortnoxApiRequest request, string code)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.TermsOfPayments}/{code}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
