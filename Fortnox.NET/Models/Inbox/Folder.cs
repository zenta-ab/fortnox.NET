using FortnoxNET.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace FortnoxNET.Models.Inbox
{
   public class Folder
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Unique email for the folder
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Id of the folder
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the folder
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of files
        /// </summary>
        public IEnumerable<File> Files { get; set; }

        /// <summary>
        /// List of folders
        /// </summary>
        public IEnumerable<Folder> Folders { get; set; }
    }
}
