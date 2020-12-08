
using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Contract
{
    [JsonPropertyClass("Contracts")]
    public class ContractSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// If the contract is continuous
        /// </summary>
        public bool? Continuous { get; set; }

        /// <summary>
        /// ContractLength
        /// </summary>
        [JsonReadOnly]
        public int? ContractLength { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer number
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Document number
        /// </summary>
        public int? DocumentNumber { get; set; }

        /// <summary>
        /// Invoice interval
        /// </summary>
        public long? InvoiceInterval { get; set; }

        /// <summary>
        /// Invoices remaining
        /// </summary>
        [JsonReadOnly]
        public long? InvoicesRemaining { get; set; }

        /// <summary>
        /// Last invoice date
        /// </summary>
        public DateTime? LastInvoiceDate { get; set; }

        /// <summary>
        /// 	Start of the period
        /// </summary>
        public DateTime? PeriodStart { get; set; }

        /// <summary>
        /// End of the period
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Template number
        /// </summary>
        public string TemplateNumber { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal? Total { get; set; }
    }
}
