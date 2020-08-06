using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.AbsenceTransaction;
using FortnoxNET.Constants;
using FortnoxNET.Models.AbsenceTransactions;

namespace FortnoxNET.Services
{
	public class AbsenceTransactionsService
	{
        public static async Task<ListedResourceResponse<AbsenceTransaction>> GetAbsenceTransactionsAsync(AbsenceTransactionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AbsenceTransaction>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.AbsenceTransactions);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<AbsenceTransaction> GetAbsenceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, string causeCode)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.AbsenceTransactions}/{employeeId}/{date}/{causeCode}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AbsenceTransaction> CreateAbsenceTransactionAsync(FortnoxApiRequest request, AbsenceTransaction absenceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.AbsenceTransactions}")
                {
                    Data = new SingleResource<AbsenceTransaction> { Data = absenceTransaction }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<AbsenceTransaction> UpdateAbsenceTransactionAsync(FortnoxApiRequest request, AbsenceTransaction absenceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AbsenceTransaction>>(HttpMethod.Put, request.AccessToken, request.ClientSecret, 
                    $"{ApiEndpoints.AbsenceTransactions}/{absenceTransaction.EmployeeId}/{absenceTransaction.Date}/{absenceTransaction.CauseCode}")
                {
                    Data = new SingleResource<AbsenceTransaction> { Data = absenceTransaction}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task DeleteAbsenceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, string causeCode)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<object>>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.AbsenceTransactions}/{employeeId}/{date}/{causeCode}")
                {
                };

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
