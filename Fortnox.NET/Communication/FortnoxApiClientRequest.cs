using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace FortnoxNET.Communication
{
    internal class FortnoxApiClientRequest<T>
    {
        public FortnoxApiClientRequest(HttpMethod httpMethod, FortnoxApiRequest request, string endpoint)
        {
            HttpMethod = httpMethod;
            _endpoint = endpoint;
            QueryStringParameters = new Dictionary<string, object>();
            Request = request;
        }

        private string _endpoint { get; set; }
        public HttpMethod HttpMethod { get; private set; }
        private Dictionary<string, object> QueryStringParameters { get; set; }
        public T Data { private get; set; }

        private FortnoxApiRequest Request;

        public bool UsesOAuth()
        {
            return Request.UsesOAuth();
        }

        public string GetAccessToken()
        {
            if (UsesOAuth())
            {
                return Request.OAuthToken.AccessToken;
            }
            else
            {
                return Request.AccessToken;
            }
        }

        public string GetClientSecret()
        {
            return Request.ClientSecret;
        }

        public StringContent GetStringContent()
        {
            var serializedString = JsonConvert.SerializeObject(Data, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd"});

            return new StringContent(serializedString, Encoding.UTF8, "application/json");
        }

        public string GetEndpoint()
        {
            return _endpoint += GetQueryString();
        }

        public void SetFilter(string filter)
        {
            if (filter != null)
            {
                QueryStringParameters.Add("filter", filter.ToLower());
            }
        }

        public void SetType(string filter)
        {
            if (filter != null)
            {
                QueryStringParameters.Add("type", filter.ToLower());
            }
        }

        public void SetSortOrder(string sortBy, string sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy) || string.IsNullOrEmpty(sortOrder))
            {
                return;
            }

            QueryStringParameters.Add("sortby", sortBy.ToLower());
            QueryStringParameters.Add("sortorder", sortOrder.ToLower());
        }

        public void SetPageAndLimit(int page, int limit)
        {
            QueryStringParameters.Add("page", page);
            QueryStringParameters.Add("limit", limit);
        }

        public void AddSearchParam(string key, object value)
        {
            if (string.IsNullOrEmpty(key) || value == null)
            {
                return;
            }

            QueryStringParameters.Add(key, value);
        }

        private string GetQueryString()
        {
            if (QueryStringParameters.Count > 0)
            {
                return "?" + string.Join("&", QueryStringParameters.Select(kvp => $"{kvp.Key.ToLower()}={kvp.Value}"));
            }

            return string.Empty;
        }
    }
}