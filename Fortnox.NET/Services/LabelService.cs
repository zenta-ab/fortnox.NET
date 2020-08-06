using FortnoxNET.Communication;
using FortnoxNET.Communication.Label;
using FortnoxNET.Constants;
using FortnoxNET.Models.Label;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class LabelService
    {
        public static async Task<ListedResourceResponse<Label>> GetLabelsAsync(LabelListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<Label>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        ApiEndpoints.Labels);
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}
