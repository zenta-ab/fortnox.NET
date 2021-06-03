using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.WayOfDelivery
{
    [JsonPropertyClass("WayOfDelivery")]
    public class WayOfDelivery
    {
        /// <summary>
        /// Direct URL to the record 
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The code of the way of delivery
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The description of the way of delivery
        /// </summary>
        public string Description { get; set; }
    }
}
