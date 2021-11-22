using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.Inbox;

using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class InboxService
    {
        public static async Task<Inbox> GetInboxAsync(FortnoxApiRequest request, string path)
        {
            var apiRequest = new FortnoxApiClientRequest<Inbox>(HttpMethod.Get, request, $"{ApiEndpoints.Inbox}/{path}");
      
            return (await FortnoxAPIClient.CallAsync(apiRequest));
        }

        public static async Task<File> UploadFileAsync(FortnoxApiRequest request, string path, string fileName, byte[] fileData)
        {

            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<File>>(
                    HttpMethod.Post,
                    request,
                    $"{ApiEndpoints.Inbox}?path={path}")
                {
                };

            return (await FortnoxAPIClient.UploadAsync(apiRequest, fileName, fileData)).Data;
        }

    }
}
