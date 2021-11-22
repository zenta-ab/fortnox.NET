using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.NET.Models.AbsenceTransactions;
using FortnoxNET.Communication;
using FortnoxNET.Communication.AbsenceTransaction;
using FortnoxNET.Constants;
using FortnoxNET.Models.AbsenceTransactions;

namespace FortnoxNET.Services
{
	public class AbsenceTransactionsService
	{
        public static async Task<ListedResourceResponse<AbsenceTransactionSubset>> GetAbsenceTransactionsAsync(AbsenceTransactionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AbsenceTransactionSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.AbsenceTransactions);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<AbsenceTransaction> GetAbsenceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, string causeCode)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.AbsenceTransactions}/{employeeId}/{date}/{causeCode}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AbsenceTransaction> CreateAbsenceTransactionAsync(FortnoxApiRequest request, AbsenceTransaction absenceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Post, request, $"{ApiEndpoints.AbsenceTransactions}")
                {
                    Data = new SingleResource<AbsenceTransaction> { Data = absenceTransaction }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AbsenceTransaction> UpdateAbsenceTransactionAsync(FortnoxApiRequest request, AbsenceTransaction absenceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Put, request, 
                    $"{ApiEndpoints.AbsenceTransactions}/{absenceTransaction.EmployeeId}/{absenceTransaction.Date?.ToString("yyyy-MM-dd")}/{absenceTransaction.CauseCode}")
                {
                    Data = new SingleResource<AbsenceTransaction> { Data = absenceTransaction}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteAbsenceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, CauseCode causeCode)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.AbsenceTransactions}/{employeeId}/{date}/{causeCode}")
                {
                };

            object p = await FortnoxAPIClient.CallAsync<object>(apiRequest);
        }
    }
}
