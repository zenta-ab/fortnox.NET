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
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SalaryTransactionSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.SalaryTransactions);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<SalaryTransaction> GetSalaryTransactionAsync(FortnoxApiRequest request, string salaryRow)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.SalaryTransactions}/{salaryRow}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SalaryTransaction> CreateSalaryTransactionAsync(FortnoxApiRequest request, SalaryTransaction salaryTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Post, request, $"{ApiEndpoints.SalaryTransactions}")
                {
                    Data = new SingleResource<SalaryTransaction> { Data = salaryTransaction }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<SalaryTransaction> UpdateSalaryTransactionAsync(FortnoxApiRequest request, SalaryTransaction salaryTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<SalaryTransaction>>(HttpMethod.Put, request,
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
                    request,
                    $"{ApiEndpoints.SalaryTransactions}/{salaryRow}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
