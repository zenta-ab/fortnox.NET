using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TermsOfDelivery
{
    [JsonPropertyClass("TermsOfDeliveries")]
    public class TermsOfDeliverySubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Code of the term of delivery
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of the term of delivery
        /// </summary>
        public string Description { get; set; }
    }
}
