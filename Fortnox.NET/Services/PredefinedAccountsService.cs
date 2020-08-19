using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.PredefinedAccount;
using FortnoxNET.Constants;
using FortnoxNET.Models.Account;
using FortnoxNET.Models.PredefinedAccounts;
using Newtonsoft.Json;

namespace FortnoxNET.Services
{
    public class PredefinedAccountsService
    {
        public static async Task<ListedResourceResponse<PredefinedAccounts>> GetPredefinedAccountsAsync(
            PredefinedAccountListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<PredefinedAccounts>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret, 
                ApiEndpoints.PredefinedAccounts
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<PredefinedAccount>> GetPredefinedAccountAsync(
            PredefinedAccountListRequest listRequest,
            string accountName)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<PredefinedAccount>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret, 
                $"{ApiEndpoints.PredefinedAccounts}/{accountName.ToUpper()}"
            );

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<SingleResource<PredefinedAccount>> UpdateAccountAsync(
            FortnoxApiRequest request,
            int accountNumber,
            string accountName
        )
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<PredefinedAccount>>(
                HttpMethod.Put, 
                request.AccessToken, 
                request.ClientSecret, 
                $"{ApiEndpoints.PredefinedAccounts}/{accountName.ToUpper()}"
            )
            {
                Data = new SingleResource<PredefinedAccount>()
                {
                    Data = new PredefinedAccount()
                    {
                        Account = accountNumber
                    }
                }
            };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}