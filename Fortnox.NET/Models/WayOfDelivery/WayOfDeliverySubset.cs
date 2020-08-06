using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.WayOfDelivery
{
    [JsonPropertyClass("WayOfDeliveries")]
    public class WayOfDeliverySubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
