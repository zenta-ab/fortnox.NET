using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.ContractTemplates;
using FortnoxNET.Constants;
using FortnoxNET.Models.ContractTemplates;

namespace FortnoxNET.Services
{
    public class ContractTemplateService
    {
        public static async Task<ListedResourceResponse<ContractTemplates>> GetContractTemplatesAsync(
            ContractTemplateListRequest listRequest
        )
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<ContractTemplates>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                ApiEndpoints.ContractTemplates
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractTemplate>> GetContractTemplateAsync(
            ContractTemplateListRequest listRequest,
            int contractTemplate
        )
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractTemplate>>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                $"{ApiEndpoints.ContractTemplates}/{contractTemplate}"
            );

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractTemplate>> CreateContractTemplateAsync(
            FortnoxApiRequest request,
            ContractTemplate contractTemplate
        )
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractTemplate>>(
                HttpMethod.Post, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.ContractTemplates}"
            )
            {
                Data = new SingleResource<ContractTemplate>()
                {
                    Data = contractTemplate
                }
            };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<SingleResource<ContractTemplate>> UpdateContractTemplateAsync(
            FortnoxApiRequest request,
            ContractTemplate contractTemplate
        )
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<ContractTemplate>>(
                HttpMethod.Put, 
                request.AccessToken, 
                request.ClientSecret,
                $"{ApiEndpoints.ContractTemplates}/{contractTemplate.TemplateNumber}"
            )
            {
                Data = new SingleResource<ContractTemplate>()
                {
                    Data = contractTemplate
                }
            };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}