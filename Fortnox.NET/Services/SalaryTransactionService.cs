using FortnoxNET.Communication;
using FortnoxNET.Communication.SalaryTransaction;
using FortnoxNET.Constants;
using FortnoxNET.Models.SalaryTransaction;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class SalaryTransactionService
    {
        public static async Task<ListedResourceResponse<SalaryTransactionSubset>> GetSalaryTransactionsAsync(SalaryTransactionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SalaryTransactionSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.SalaryTransactions);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<SalaryTransaction> GetSalaryTransactionAsync(FortnoxApiRequest request, string salaryRow)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.SalaryTransactions}/{salaryRow}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SalaryTransaction> CreateSalaryTransactionAsync(FortnoxApiRequest request, SalaryTransaction salaryTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.SalaryTransactions}")
                {
                    Data = new SingleResource<SalaryTransaction> { Data = salaryTransaction }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SalaryTransaction> UpdateSalaryTransactionAsync(FortnoxApiRequest request, SalaryTransaction salaryTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.SalaryTransactions}/{salaryTransaction.SalaryRow}/")
                {
                    Data = new SingleResource<SalaryTransaction> { Data = salaryTransaction }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteSalaryTransactionAsync(FortnoxApiRequest request, string salaryRow)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.SalaryTransactions}/{salaryRow}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
