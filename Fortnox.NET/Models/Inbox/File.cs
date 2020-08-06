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
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Comments { get; set; }

        public string Id { get; set; }

        public string ArchiveId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Size { get; set; }

    }
}
