using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TermsOfPayment
{
    [JsonPropertyClass("TermsOfPayments")]
    public class TermsOfPaymentSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
