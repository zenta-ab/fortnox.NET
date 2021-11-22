using FortnoxNET.Communication.PrintTemplates;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.PrintTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class PrintTemplatesService
    {
        public static async Task<ListedResourceResponse<PrintTemplates>> GetTemplatesAsync(PrintTemplatesListRequest request)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<PrintTemplates>>(HttpMethod.Get, request,
                $"{ApiEndpoints.PrintTemplates}/");
            apiRequest.SetType(request.Filter?.ToString());
            return (await FortnoxAPIClient.CallAsync(apiRequest));
        }
    }
}