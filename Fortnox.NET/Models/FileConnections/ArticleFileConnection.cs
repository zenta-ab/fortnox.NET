using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("ArticleFileConnection")]
    public class ArticleFileConnection
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string FileId { get; set; }
        
        public string ArticleNumber { get; set; } 
    }
}