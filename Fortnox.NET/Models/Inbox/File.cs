using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Size { get; set; }

    }
}
