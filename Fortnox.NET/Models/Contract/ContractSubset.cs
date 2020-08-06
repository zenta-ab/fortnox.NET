
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
        public int? ContractLength { get; set; }

        public string Currency { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string DocumentNumber { get; set; }

        public int? InvoiceInterval { get; set; }

        [JsonReadOnly]
        public int? InvoicesRemaining { get; set; }

        public string LastInvoiceDate { get; set; }

        public string PeriodStart { get; set; }

        public string PeriodEnd { get; set; }

        public string Status { get; set; }

        public string TemplateNumber { get; set; }

        public decimal? Total { get; set; }
    }
}
