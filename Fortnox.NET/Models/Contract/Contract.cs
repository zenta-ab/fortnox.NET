using FortnoxNET.Models.Invoice;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.Contract
{
    [JsonPropertyClass("Contract")]
    public class Contract
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public bool? Active { get; set; }

        public decimal? AdministrationFee { get; set; }

        public string Comments { get; set; }

        public bool? Continuous { get; set; }

        public DateTime? ContractDate { get; set; }

        public long? ContractLength { get; set; }

        [JsonReadOnly]
        public decimal? ContributionPercent { get; private set; }

        [JsonReadOnly]
        public decimal? ContributionValue { get; private set; }

        public string CostCenter { get; set; }

        public string Currency { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public long? DocumentNumber { get; set; }

        public ContractEmailInformation EmailInformation { get; set; }

        public string ExternalInvoiceReference1 { get; set; }

        public string ExternalInvoiceReference2 { get; set; }

        public decimal? Freight { get; set; }

        [JsonReadOnly]
        public decimal? Gross { get; private set; }

        [JsonReadOnly]
        public bool? HouseWork { get; private set; }

        [JsonReadOnly]
        public decimal? InvoiceDiscount { get; set; }

        public int? InvoiceInterval { get; set; }

        [JsonReadOnly]
        public int? InvoicesRemaining { get; private set; }

        public List<InvoiceRow> InvoiceRows { get; set; }

        public string Language { get; set; }

        [JsonReadOnly]
        public DateTime? LastInvoiceDate { get; private set; }

        [JsonReadOnly]
        public decimal? Net { get; private set; }

        public string OurReference { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public DateTime? PeriodStart { get; set; }

        public string PriceList { get; set; }

        public string PrintTemplate { get; set; }

        public string Project { get; set; }

        public string Remarks { get; set; }

        [JsonReadOnly]
        public decimal? TaxReduction { get; private set; }

        [JsonReadOnly]
        public string TemplateName { get; private set; }

        public long? TemplateNumber { get; set; }

        public string TermsOfDelivery { get; set; }

        public string TermsOfPayment { get; set; }

        [JsonReadOnly]
        public decimal? Total { get; private set; }

        [JsonReadOnly]
        public decimal? TotalToPay { get; private set; }

        [JsonReadOnly]
        public decimal? TotalVAT { get; private set; }

        public bool? VATIncluded { get; set; }

        public string WayOfDelivery { get; set; }

        public string YourOrderNumber { get; set; }
    }
}
