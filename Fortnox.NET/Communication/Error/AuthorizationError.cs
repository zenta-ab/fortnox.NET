using Newtonsoft.Json;

namespace Fortnox.NET.Communication.Error
{
    public class AuthorizationError
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string Description { get; set; }
    }
}
