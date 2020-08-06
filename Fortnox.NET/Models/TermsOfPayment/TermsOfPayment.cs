using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TermsOfPayment
{
    [JsonPropertyClass("TermsOfPayment")]
    public class TermsOfPayment
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
