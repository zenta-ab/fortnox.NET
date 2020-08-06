using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Assets
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Assets")]
    public class AssetSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        public int Id { get; set; }

        public string Description { get; set; }
        
        [JsonReadOnly]
        public string Status { get; set; }
        
        [JsonReadOnly]
        public string StatusId { get; set; }

        [JsonReadOnly]
        public string Type { get; set; }

        public string TypeId { get; set; }

        public double? AcquisitionValue { get; set; }

        public string AcquisitionDate { get; set; }

        [JsonReadOnly]
        public string DepreciationFinal { get; set; }

        [JsonReadOnly]
        public string DepreciatedTo { get; set; }
    }
}
