using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TermsOfDelivery
{
    [JsonPropertyClass("TermsOfDeliveries")]
    public class TermsOfDeliverySubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
