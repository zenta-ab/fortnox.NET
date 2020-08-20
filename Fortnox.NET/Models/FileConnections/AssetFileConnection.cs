using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("AssetFileConnection")]
    public class AssetFileConnection
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string FileId { get; set; }
        
        public string Name { get; set; }
        
        public string AssetId { get; set; }
    }
}