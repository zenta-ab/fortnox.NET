using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.Invoice;
using FortnoxNET.Models.Account;

namespace FortnoxNET.Services
{
    public class AccountService
    {
        public static async Task<ListedResourceResponse<AccountSubset>> GetAccountsAsync(AccountListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AccountSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret, ApiEndpoints.Accounts);

            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);
            
            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<Account> GetAccountAsync(FortnoxApiRequest request, int financialYear, int AccountNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Account>>(HttpMethod.Get, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Accounts}/{AccountNumber}?financialyear={financialYear}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
        
        public static async Task<Account> GetAccountAsync(FortnoxApiRequest request, string url)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Account>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,url);

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}