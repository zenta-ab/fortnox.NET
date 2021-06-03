using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.InvoicePayment;

namespace FortnoxNET.Services
{
    public class InvoicePaymentService
    {
        public static async Task<ListedResourceResponse<InvoicePaymentSubset>> GetInvoicePaymentsAsync(InvoicePaymentListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<InvoicePaymentSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret, ApiEndpoints.InvoicePayments);

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<InvoicePayment> GetInvoicePaymentAsync(FortnoxApiRequest request, int InvoicePaymentNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<InvoicePayment>>(HttpMethod.Get, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.InvoicePayments}/{InvoicePaymentNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task<InvoicePayment> GetInvoicePaymentAsync(FortnoxApiRequest request, string url)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<InvoicePayment>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,url);

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<InvoicePayment> CreateInvoicePaymentAsync(FortnoxApiRequest request, InvoicePayment invoicePayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<InvoicePayment>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.InvoicePayments}")
                {
                    Data = new SingleResource<InvoicePayment> { Data = invoicePayment }
                };
            return (await FortnoxAPIClient.CallAsync<SingleResource<InvoicePayment>, SingleResource<InvoicePayment>>(apiRequest)).Data;
        }

        public static async Task<InvoicePayment> UpdateInvoicePaymentAsync(FortnoxApiRequest request, string invoicePaymentNumber, InvoicePayment invoicePayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<InvoicePayment>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.InvoicePayments}/{invoicePaymentNumber}")
                {
                    Data = new SingleResource<InvoicePayment> { Data = invoicePayment }
                };
            return (await FortnoxAPIClient.CallAsync<SingleResource<InvoicePayment>, SingleResource<InvoicePayment>>(apiRequest)).Data;
        }

        public static async Task DeleteInvoicePaymentAsync(FortnoxApiRequest request, string articleNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.InvoicePayments}/{articleNumber}");

            await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<InvoicePayment> BookkeepInvoicePaymentAsync(FortnoxApiRequest request, string invoicePaymentNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<InvoicePayment>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.InvoicePayments}/{invoicePaymentNumber}/bookkeep");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}