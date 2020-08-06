using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TrustedEmailDomains
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("TrustedDomain")]
    public class TrustedEmailDomain
    {
        [JsonReadOnly]
        public int? Id { get; set; }

        public string Domain { get; set; }
    }
}