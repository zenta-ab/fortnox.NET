using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PrintTemplates
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("PrintTemplates")]
    public class PrintTemplates
    {
        public string Template { get; set; }
        public string Name { get; set; }
    }
}