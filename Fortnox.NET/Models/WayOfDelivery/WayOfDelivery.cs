using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.WayOfDelivery
{
    [JsonPropertyClass("WayOfDelivery")]
    public class WayOfDelivery
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
