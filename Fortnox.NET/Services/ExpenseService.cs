using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Expenses;
using FortnoxNET.Constants;
using FortnoxNET.Models.Expense;

namespace FortnoxNET.Services
{
    public class ExpenseService
    {
        public static async Task<ListedResourceResponse<ExpenseSubset>> GetExpensesAsync(ExpenseListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ExpenseSubset>>(HttpMethod.Get, listRequest,
                ApiEndpoints.Expenses);

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<ExpenseSubset> GetExpenseAsync(FortnoxApiRequest request, string expenseCode)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ExpenseSubset>>(HttpMethod.Get, request,
                $"{ApiEndpoints.Expenses}/{expenseCode}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Expense> CreateExpenseAsync(FortnoxApiRequest request, Expense expense)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Expense>>(HttpMethod.Post, request, $"{ApiEndpoints.Expenses}")
                {
                    Data = new SingleResource<Expense> { Data = expense }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
