using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("AssetFileConnection")]
    public class AssetFileConnection
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        /// <summary>
        /// Id of the file.
        /// </summary>
        public string FileId { get; set; }
        
        /// <summary>
        /// Name of the file.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Asset number.
        /// </summary>
        public string AssetId { get; set; }
    }
}