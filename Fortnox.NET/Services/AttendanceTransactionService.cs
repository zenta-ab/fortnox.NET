using FortnoxNET.Communication;
using FortnoxNET.Communication.AttendanceTransaction;
using FortnoxNET.Constants;
using FortnoxNET.Models.AttendanceTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class AttendanceTransactionService
    {
        public static async Task<ListedResourceResponse<AttendanceTransactionSubset>> GetAttendanceTransactionsAsync(AttendanceTransactionListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AttendanceTransactionSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.AttendanceTransactions);
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        public static async Task<AttendanceTransaction> GetAttendanceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, string causeCode)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<AttendanceTransaction>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.AttendanceTransactions}/{employeeId}/{date}/{causeCode}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        public static async Task<AttendanceTransaction> CreateAttendanceTransactionAsync(FortnoxApiRequest request, AttendanceTransaction attendanceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AttendanceTransaction>>(HttpMethod.Post, request, $"{ApiEndpoints.AttendanceTransactions}")
                {
                    Data = new SingleResource<AttendanceTransaction> { Data = attendanceTransaction }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        public static async Task<AttendanceTransaction> UpdateAttendanceTransactionAsync(FortnoxApiRequest request, AttendanceTransaction attendanceTransaction)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<AttendanceTransaction>>(HttpMethod.Put, request,
                    $"{ApiEndpoints.AttendanceTransactions}/{attendanceTransaction.EmployeeId}/{attendanceTransaction.Date}/{attendanceTransaction.CauseCode}")
                {
                    Data = new SingleResource<AttendanceTransaction> { Data = attendanceTransaction }
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        public static async Task DeleteAttendanceTransactionAsync(FortnoxApiRequest request, string employeeId, string date, string causeCode)
        {
            var apiRequest =
                new FortnoxApiClientRequest<string>(
                    HttpMethod.Delete,
                    request,
                    $"{ApiEndpoints.AttendanceTransactions}/{employeeId}/{date}/{causeCode}")
                {
                };
            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
