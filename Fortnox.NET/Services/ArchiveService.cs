using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Archive;
using FortnoxNET.Constants;
using FortnoxNET.Models.Archive;
using FortnoxNET.Models.Inbox;
using File = FortnoxNET.Models.Inbox.File;

namespace FortnoxNET.Services
{
    public class ArchiveService
    {
        public static async Task<Archive> GetArchiveAsync(ArchiveListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<Archive>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                ApiEndpoints.Archive
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Archive> GetArchiveAsync(ArchiveListRequest listRequest, string id)
        {
            var apiRequest = new FortnoxApiClientRequest<Archive>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                $"{ApiEndpoints.Archive}/{id}"
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<byte[]> GetFileAsync(ArchiveListRequest listRequest, string id)
        {
            var apiRequest = new FortnoxApiClientRequest<byte[]>(
                HttpMethod.Get, 
                listRequest.AccessToken, 
                listRequest.ClientSecret,
                $"{ApiEndpoints.Archive}/{id}"
            );

            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<Archive> CreateFolderAsync(FortnoxApiRequest request, string folderName)
        {
            var apiRequest =
                new FortnoxApiClientRequest<Archive>(
                    HttpMethod.Post, 
                    request.AccessToken, 
                    request.ClientSecret, 
                    $"{ApiEndpoints.Archive}")
                {
                    Data = new Archive
                    {
                        Folder = new Folder()
                        {
                            Name = folderName
                        }
                    }
                };

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
        
        public static async Task<File> CreateFileAsync(
            FortnoxApiRequest request, 
            byte[] fileData, 
            string fileName, 
            string folderId)
        {

            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<File>>(
                    HttpMethod.Post,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Archive}/?folderid={folderId}");

            return (await FortnoxAPIClient.UploadAsync(apiRequest, fileName, fileData)).Data;
        }
        
        public static async Task DeleteArchiveAsync(FortnoxApiRequest request, string archiveId)
        {
            var apiRequest =
                new FortnoxApiClientRequest<object>(
                    HttpMethod.Delete,
                    request.AccessToken,
                    request.ClientSecret,
                    $"{ApiEndpoints.Archive}/{archiveId}");

            await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}