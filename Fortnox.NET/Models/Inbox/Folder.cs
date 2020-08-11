using FortnoxNET.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace FortnoxNET.Models.Inbox
{
   public class Folder
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string Email { get; set; }
        
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<File> Files { get; set; }
        
        public IEnumerable<Folder> Folders { get; set; }
    }
}
