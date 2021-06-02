using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TermsOfPayment
{
    [JsonPropertyClass("TermsOfPayment")]
    public class TermsOfPayment
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The code of the term of payment
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The description of the term of payment 
        /// </summary>
        public string Description { get; set; }
    }
}
