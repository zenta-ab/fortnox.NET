using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Project;
using FortnoxNET.Constants;
using FortnoxNET.Models.Project;

namespace FortnoxNET.Services
{
    public class ProjectService
    {
        public static async Task<ListedResourceResponse<Project>> GetProjectsAsync(ProjectListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<Project>>(HttpMethod.Get, listRequest,
                                                                                       ApiEndpoints.Projects);
            
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
        
        public static async Task<Project> GetProjectAsync(FortnoxApiRequest request, string projectNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Project>>(HttpMethod.Get, request,
                                                                                       $"{ApiEndpoints.Projects}/{projectNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}