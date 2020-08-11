using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FortnoxNET.Models.Authorization;
using Newtonsoft.Json;
using static System.Net.Http.HttpMethod;

namespace FortnoxNET.Communication
{
    public class FortnoxAPIClient
    {
        internal static async Task<AuthorizationResponse> GetAccessTokenAsync(string authorizationCode, string clientSecret, string apiEndpoint)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-Secret", clientSecret);
                client.DefaultRequestHeaders.Add("Authorization-Code", authorizationCode);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(apiEndpoint);

                return await GetResponseAsync<AuthorizationResponse>(response);
            }
        }

        internal static async Task<T> CallAsync<T>(FortnoxApiClientRequest<T> request) where T : class
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Access-Token", request.AccessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", request.ClientSecret);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                switch (request.HttpMethod)
                {
                    case HttpMethod m when m == Get:
                        response = await client.GetAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == Delete:
                        response = await client.DeleteAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == Post:
                        response = await client.PostAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    case HttpMethod m when m == Put:
                        response = await client.PutAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    default:
                        throw new NotSupportedException();
                }

                return await GetResponseAsync<T>(response);
            }
        }
        
        internal static async Task<TResponse> CallAsync<T, TResponse>(FortnoxApiClientRequest<T> request) 
            where T : class
            where TResponse: class
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Access-Token", request.AccessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", request.ClientSecret);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                switch (request.HttpMethod)
                {
                    case HttpMethod m when m == Get:
                        response = await client.GetAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == Delete:
                        response = await client.DeleteAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == Post:
                        response = await client.PostAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    case HttpMethod m when m == Put:
                        response = await client.PutAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    default:
                        throw new NotSupportedException();
                }

                return await GetResponseAsync<TResponse>(response);
            }
        }

        internal static async Task<T> UploadAsync<T>(FortnoxApiClientRequest<T> request, string fileName, byte[] filedata) where T : class
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Access-Token", request.AccessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", request.ClientSecret);

                var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                content.Add(new StreamContent(new MemoryStream(filedata)), "file", fileName);

                var response = await client.PostAsync(request.GetEndpoint(), content);

                return await GetResponseAsync<T>(response);
            }
        }

        private static async Task<T> GetResponseAsync<T>(HttpResponseMessage response) where T : class
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>((await response.Content.ReadAsStringAsync()),
                                                                                     new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    throw new
                        Exception($"Error: {errorResponse.ErrorInformation.Error} Message: {errorResponse.ErrorInformation.Message}, Code: {errorResponse.ErrorInformation.Code}");
                }
                catch (Exception e)
                {
                    throw new Exception($"Could not get resource. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, {e.Message}");
                }
            }

            if (typeof(T) == typeof(byte[]))
            {
                var responseBytes = await response.Content.ReadAsByteArrayAsync();

                return responseBytes as T;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string))
                {
                    return responseContent as T;
                }

                return JsonConvert.DeserializeObject<T>(responseContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}