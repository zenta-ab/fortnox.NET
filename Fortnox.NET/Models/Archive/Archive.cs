using System.Collections.Generic;
using FortnoxNET.Models.Inbox;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Archive
{
    public class Archive
    {
        /// <summary>
        /// An archive folder
        /// </summary>
        public Folder Folder { get; set; }
    }
}