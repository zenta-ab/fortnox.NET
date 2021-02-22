using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractTemplates
{
    [JsonPropertyClass("ContractTemplates")]
    public class ContractTemplates
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string ContractLength { get; set; }
        
        public int ContractTemplate { get; set; }
        
        public string ContractTemplateName { get; set; }
        
        public int InvoiceInterval { get; set; }
    }
}