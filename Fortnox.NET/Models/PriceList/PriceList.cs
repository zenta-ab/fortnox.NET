using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PriceList
{
    [JsonPropertyClass("PriceList")]
    public class PriceList
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        [JsonReadOnly]
        public bool? PreSelected { get; set; }
    }
}
