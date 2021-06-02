using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ModesOfPayments
{
    [JsonPropertyClass("ModesOfPayments")]
    public class ModesOfPaymentsSubset
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Code for mode of payment
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of mode of payment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public string AccountNumber { get; set; }
    }
}
