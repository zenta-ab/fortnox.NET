
using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Contract
{
    [JsonPropertyClass("Contracts")]
    public class ContractSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool? Continuous { get; set; }

        [JsonReadOnly]
        public long? ContractLength { get; set; }

        public string Currency { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public long? DocumentNumber { get; set; }

        public long? InvoiceInterval { get; set; }

        [JsonReadOnly]
        public long? InvoicesRemaining { get; set; }

        public DateTime? LastInvoiceDate { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public string Status { get; set; }

        public string TemplateNumber { get; set; }

        public decimal? Total { get; set; }
    }
}
