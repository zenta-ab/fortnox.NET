using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TrustedEmailDomains
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("TrustedDomain")]
    public class TrustedEmailDomain
    {
        /// <summary>
        /// Id of the record
        /// </summary>
        [JsonReadOnly]
        public int? Id { get; set; }

        /// <summary>
        /// Domain address of trusted
        /// </summary>
        public string Domain { get; set; }
    }
}