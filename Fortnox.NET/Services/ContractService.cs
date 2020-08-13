using FortnoxNET.Communication;
using FortnoxNET.Communication.Contract;
using FortnoxNET.Constants;
using FortnoxNET.Models.Contract;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class ContractService
    {
        public static async Task<ListedResourceResponse<ContractSubset>> GetContractsAsync(ContractListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ContractSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        $"{ApiEndpoints.Contracts}");

            apiRequest.SetFilter(listRequest.Filter?.ToString());
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
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

        public static async Task<Contract> GetContractAsync(FortnoxApiRequest request, string documentNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.Contracts}/{documentNumber}");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Contract> CreateContractAsync(FortnoxApiRequest request, Contract contract)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Contracts}")
                {
                    Data = new SingleResource<Contract> { Data = contract}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Contract> UpdateContractAsync(FortnoxApiRequest request, Contract contract)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Contracts}/{contract.DocumentNumber}")
                {
                    Data = new SingleResource<Contract> { Data = contract}
                };
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Contract> FinishContractAsync(FortnoxApiRequest request, Contract contract)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Contracts}/{contract.DocumentNumber}/finish");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Contract> CreateInvoiceFromContractAsync(FortnoxApiRequest request, Contract contract)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Contracts}/{contract.DocumentNumber}/createinvoice");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Contract> IncreaseInvoiceCountForContractAsync(FortnoxApiRequest request, Contract contract)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Contract>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Contracts}/{contract.DocumentNumber}/increaseinvoicecount");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
