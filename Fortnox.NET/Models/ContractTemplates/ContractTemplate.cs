using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractTemplates
{
    [JsonPropertyClass("ContractTemplate")]
    public class ContractTemplate 
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Administration fee
        /// </summary>
        public int? AdministrationFee { get; set; }

        /// <summary>
        /// Freight
        /// </summary>
        public decimal? Freight { get; set; }

        /// <summary>
        /// Invoice rows
        /// </summary>
        public IEnumerable<ContractTemplateInvoiceRow> InvoiceRows { get; set; }

        /// <summary>
        /// If the contract is continuous
        /// </summary>
        public bool? Continuous { get; set; }

        /// <summary>
        /// Our reference
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// Print template code
        /// </summary>
        public string PrintTemplate { get; set; }

        /// <summary>
        /// Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Name of the template
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// Number of the template
        /// </summary>
        public int? TemplateNumber { get; set; }

        /// <summary>
        /// Terms of delivery code
        /// </summary>
        public string TermsOfDelivery { get; set; }

        /// <summary>
        /// Terms of payment code
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// Way of delivery code
        /// </summary>
        public string WayOfDelivery { get; set; }

        /// <summary>
        /// Length of the contract
        /// </summary>
        public string ContractLength { get; set; }

        /// <summary>
        /// Invoice interval
        /// </summary>
        public int? InvoiceInterval { get; set; }
    }
}