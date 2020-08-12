using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.ContractAccrual;
using FortnoxNET.Constants;
using FortnoxNET.Models.ContractAccruals;

namespace FortnoxNET.Services
{
    public class ContractAccrualService
    {
        public static async Task<ListedResourceResponse<ContractAccrualSubset>> GetContractAccrualsAsync(
            ContractAccrualListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ContractAccrualSubset>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                $"{ApiEndpoints.ContractAccruals}"
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractAccrual>> GetContractAccrualAsync(
            ContractAccrualListRequest listRequest,
            int documentNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractAccrual>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                $"{ApiEndpoints.ContractAccruals}/{documentNumber}"
            );

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractAccrual>> CreateContractAccrualAsync(
            FortnoxApiRequest request,
            ContractAccrual contractAccrual)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractAccrual>>(
                HttpMethod.Post, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.ContractAccruals}"
            )
            {
                Data = new SingleResource<ContractAccrual>()
                {
                    Data = contractAccrual
                }
            };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractAccrual>> UpdateContractAccrualAsync(
            FortnoxApiRequest request,
            ContractAccrual contractAccrual)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractAccrual>>(
                HttpMethod.Put, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.ContractAccruals}/{contractAccrual.DocumentNumber}"
            )
            {
                Data = new SingleResource<ContractAccrual>()
                {
                    Data = contractAccrual
                }
            };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task DeleteContractAccrualAsync(
            FortnoxApiRequest request,
            int documentNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<object>(
                HttpMethod.Delete, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.ContractAccruals}/{documentNumber}"
            );

            await FortnoxAPIClient.CallAsync(apiRequest);
        } 
    }
}