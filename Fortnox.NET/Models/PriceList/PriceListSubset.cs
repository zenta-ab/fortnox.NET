using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PriceList
{
    [JsonPropertyClass("PriceLists")]
    public class PriceListSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public bool PreSelected { get; set; }
    }
}
