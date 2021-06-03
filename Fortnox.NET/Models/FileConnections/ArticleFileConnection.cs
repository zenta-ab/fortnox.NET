using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("ArticleFileConnection")]
    public class ArticleFileConnection
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
        /// Article number.
        /// </summary>
        public string ArticleNumber { get; set; } 
    }
}