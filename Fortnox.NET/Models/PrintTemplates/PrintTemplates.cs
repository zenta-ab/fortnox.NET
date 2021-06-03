using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PrintTemplates
{
    [JsonPropertyClass("PrintTemplates")]
    public class PrintTemplates
    {
        /// <summary>
        /// Code of the template
        /// </summary>
        public string Template { get; set; }
        
        /// <summary>
        /// Name of the template
        /// </summary>
        public string Name { get; set; }
    }
}