using FortnoxNET.Communication;
using FortnoxNET.Communication.SupplierInvoicePayment;
using FortnoxNET.Constants;
using FortnoxNET.Models.SupplierInvoicePayment;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class SupplierInvoicePaymentService
    {
        public static async Task<ListedResourceResponse<SupplierInvoicePaymentSubset>> GetSupplierInvoicePaymentsAsync(SupplierInvoicePaymentListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SupplierInvoicePaymentSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        $"{ApiEndpoints.SupplierInvoicePayments}");

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            if (listRequest.SearchParameters == null)
            {
                return await FortnoxAPIClient.CallAsync(apiRequest);
            }

            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<SupplierInvoicePayment> GetSupplierInvoicePaymentAsync(FortnoxApiRequest request, string number)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SupplierInvoicePayment>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.SupplierInvoicePayments}/{number}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SupplierInvoicePayment> CreateSupplierInvoicePaymentAsync(FortnoxApiRequest request, SupplierInvoicePayment supplierInvoicePayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SupplierInvoicePayment>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.SupplierInvoicePayments}")
                {
                    Data = new SingleResource<SupplierInvoicePayment> { Data = supplierInvoicePayment }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SupplierInvoicePayment> UpdateSupplierInvoicePaymentAsync(FortnoxApiRequest request, SupplierInvoicePayment supplierInvoicePayment)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SupplierInvoicePayment>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.SupplierInvoicePayments}/{supplierInvoicePayment.Number}")
                {
                    Data = new SingleResource<SupplierInvoicePayment> { Data = supplierInvoicePayment }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeletePriceAsync(FortnoxApiRequest request, string number)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.SupplierInvoicePayments}/{number}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
