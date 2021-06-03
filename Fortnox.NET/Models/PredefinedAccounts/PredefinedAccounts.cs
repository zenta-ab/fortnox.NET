using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PredefinedAccounts
{
    [JsonPropertyClass("PreDefinedAccounts")]
    public class PredefinedAccounts
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Name of account type
        /// </summary>
        public int? Account { get; set; }

        /// <summary>
        /// Predefined account
        /// </summary>
        public string Name { get; set; }
    }
}