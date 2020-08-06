using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FortnoxNET.Models
{
    public class MetaInformation
    {
        [JsonProperty(PropertyName = "@CurrentPage")]
        public int CurrentPage { get; set; }
        
        [JsonProperty(PropertyName = "@TotalPages")]
        public int TotalPages { get; set; }
        
        [JsonProperty(PropertyName = "@TotalResources")]
        public int TotalResources { get; set; }
    }
}