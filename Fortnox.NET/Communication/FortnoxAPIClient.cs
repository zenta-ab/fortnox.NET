using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Fortnox.NET.Communication.Error;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants;
using FortnoxNET.Models.Authorization;
using Newtonsoft.Json;

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

        internal static async Task<OAuthToken> GetAccessTokenAsync(string authorizationCode, string clientId, string clientSecret, string redirectUri = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);


                var urlContent = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", authorizationCode),
                };

                if (redirectUri != null)
                {
                    urlContent.Add(new KeyValuePair<string, string>("redirect_uri", redirectUri));
                }

                var content = new FormUrlEncodedContent(urlContent);

                var response = await client.PostAsync(ApiEndpoints.OAuthToken, content);
                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<AuthorizationError>((await response.Content.ReadAsStringAsync()),
                                                                                         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        throw new Exception($"Error: {errorResponse.Error} Message: {errorResponse.Description}");
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Could not get resource. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, {e.Message}");
                    }
                }

                return await GetResponseAsync<OAuthToken>(response);
            }
        }

        internal static async Task<OAuthToken> RefreshAccessToken(string clientId, string clientSecret, string refreshToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);


                var urlContent = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken),
                };

                var content = new FormUrlEncodedContent(urlContent);

                var response = await client.PostAsync(ApiEndpoints.OAuthToken, content);
                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<AuthorizationError>((await response.Content.ReadAsStringAsync()),
                                                                                         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        throw new Exception($"Error: {errorResponse.Error} Message: {errorResponse.Description}");
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Could not get resource. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, {e.Message}");
                    }
                }

                return await GetResponseAsync<OAuthToken>(response);
            }
        }

        /// <summary>
        /// Gets an access token using Client Credentials Flow for service accounts.
        /// </summary>
        internal static async Task<ServiceAccountToken> GetServiceAccountTokenAsync(string clientId, string clientSecret, long tenantId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                var urlContent = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("tenant_id", tenantId.ToString()),
                };

                var content = new FormUrlEncodedContent(urlContent);

                var response = await client.PostAsync(ApiEndpoints.OAuthToken, content);
                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<AuthorizationError>(await response.Content.ReadAsStringAsync(),
                                                                                         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                        throw new Exception($"Error: {errorResponse.Error} Message: {errorResponse.Description}");
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Could not get resource. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, {e.Message}");
                    }
                }

                return await GetResponseAsync<ServiceAccountToken>(response);
            }
        }

        internal static async Task<T> CallAsync<T>(FortnoxApiClientRequest<T> request) where T : class
        {
            using (var client = new HttpClient())
            {
                if (request.UsesOAuth())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.GetAccessToken());
                }
                else
                {
                    client.DefaultRequestHeaders.Add("Access-Token", request.GetAccessToken());
                    client.DefaultRequestHeaders.Add("Client-Secret", request.GetClientSecret());
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                switch (request.HttpMethod)
                {
                    case HttpMethod m when m == HttpMethod.Get:
                        response = await client.GetAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == HttpMethod.Delete:
                        response = await client.DeleteAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == HttpMethod.Post:
                        response = await client.PostAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    case HttpMethod m when m == HttpMethod.Put:
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
            where TResponse : class
        {
            using (var client = new HttpClient())
            {
                if (request.UsesOAuth())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.GetAccessToken());
                }
                else
                {
                    client.DefaultRequestHeaders.Add("Access-Token", request.GetAccessToken());
                    client.DefaultRequestHeaders.Add("Client-Secret", request.GetClientSecret());
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                switch (request.HttpMethod)
                {
                    case HttpMethod m when m == HttpMethod.Get:
                        response = await client.GetAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == HttpMethod.Delete:
                        response = await client.DeleteAsync(request.GetEndpoint());
                        break;

                    case HttpMethod m when m == HttpMethod.Post:
                        response = await client.PostAsync(request.GetEndpoint(), request.GetStringContent());
                        break;

                    case HttpMethod m when m == HttpMethod.Put:
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
                if (request.UsesOAuth())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.GetAccessToken());
                }
                else
                {
                    client.DefaultRequestHeaders.Add("Access-Token", request.GetAccessToken());
                    client.DefaultRequestHeaders.Add("Client-Secret", request.GetClientSecret());
                }

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