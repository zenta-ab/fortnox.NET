using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Unit
{
    [JsonPropertyClass("Units")]
    public class Unit
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The code of the unit
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The description of the unit
        /// </summary>
        public string Description { get; set; }
    }
}