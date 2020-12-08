using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractTemplates
{
    [JsonPropertyClass("ContractTemplates")]
    public class ContractTemplates
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Length of the contract
        /// </summary>
        public string ContractLength { get; set; }
        
        /// <summary>
        /// Contract template
        /// </summary>
        public int? ContractTemplate { get; set; }

        /// <summary>
        /// Contract template name
        /// </summary>
        public string ContractTemplateName { get; set; }

        /// <summary>
        /// Invoice interval
        /// </summary>
        public int? InvoiceInterval { get; set; }
    }
}