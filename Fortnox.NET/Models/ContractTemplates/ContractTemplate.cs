using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractTemplates
{
    [JsonPropertyClass("ContractTemplate")]
    public class ContractTemplate 
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public int AdministrationFee { get; set; }
        
        public decimal Freight { get; set; }
        
        public IEnumerable<ContractTemplateInvoiceRow> InvoiceRows { get; set; }
        
        public bool Continuous { get; set; }
        
        public string OurReference { get; set; }
        
        public string PrintTemplate { get; set; }
        
        public string Remarks { get; set; }
        
        public string TemplateName { get; set; }
        public int TemplateNumber { get; set; }
        
        public string TermsOfDelivery { get; set; }
        
        public string TermsOfPayment { get; set; }
        
        public string WayOfDelivery { get; set; }
        
        public string ContractLength { get; set; }
        
        public string ContractTemplateName { get; set; }
        
        public int InvoiceInterval { get; set; }
    }
}