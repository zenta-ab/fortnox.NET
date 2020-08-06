
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.AssetType
{
    [JsonPropertyClass("Types")]
    public class AssetTypeSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public int Id { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public int Type { get; set; }

        public bool InUse { get; set; }
    }
}
