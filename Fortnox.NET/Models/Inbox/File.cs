using Newtonsoft.Json;

namespace FortnoxNET.Models.Inbox
{
    public class File
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Id of the file
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Path to the file
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Size(in bytes) of the file
        /// </summary>
        public int Size { get; set; }
    }
}
