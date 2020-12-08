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
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Direct URL to the tax reduction list for the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        /// <summary>
        /// If the contract is active
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Administration Fee
        /// </summary>
        public decimal? AdministrationFee { get; set; }

        /// <summary>
        /// Basis for Tax Reductions
        /// </summary>
        public decimal? BasisTaxReduction { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// If the contract is continuous
        /// </summary>
        public bool? Continuous { get; set; }

        /// <summary>
        /// Contract date
        /// </summary>
        public DateTime? ContractDate { get; set; }

        /// <summary>
        /// Contract length
        /// </summary>
        public int? ContractLength { get; set; }

        /// <summary>
        /// Contribution percent
        /// </summary>
        [JsonReadOnly]
        public decimal? ContributionPercent { get; private set; }

        /// <summary>
        /// Contribution value
        /// </summary>
        [JsonReadOnly]
        public decimal? ContributionValue { get; private set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

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
        /// Email information
        /// </summary>
        public ContractEmailInformation EmailInformation { get; set; }

        /// <summary>
        /// External invoice reference
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Freight
        /// </summary>
        public decimal? Freight { get; set; }

        /// <summary>
        /// Gross
        /// </summary>
        [JsonReadOnly]
        public decimal? Gross { get; private set; }

        /// <summary>
        /// If house work
        /// </summary>
        [JsonReadOnly]
        public bool? HouseWork { get; private set; }

        /// <summary>
        /// Invoice discount
        /// </summary>
        [JsonReadOnly]
        public decimal? InvoiceDiscount { get; set; }

        /// <summary>
        /// Invoice interval
        /// </summary>
        public int? InvoiceInterval { get; set; }

        /// <summary>
        /// Invoices remaining	
        /// </summary>
        [JsonReadOnly]
        public int? InvoicesRemaining { get; private set; }

        /// <summary>
        /// Invoice rows
        /// </summary>
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <summary>
        /// Language	
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Last invoice date
        /// </summary>
        [JsonReadOnly]
        public DateTime? LastInvoiceDate { get; private set; }

        /// <summary>
        /// Net
        /// </summary>
        [JsonReadOnly]
        public decimal? Net { get; private set; }

        /// <summary>
        /// Our reference
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// End of the period
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Start of the period
        /// </summary>
        public DateTime? PeriodStart { get; set; }

        /// <summary>
        /// Price list
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// Print template
        /// </summary>
        public string PrintTemplate { get; set; }

        /// <summary>
        /// Project number
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Round Off value
        /// </summary>
        [JsonReadOnly]
        public decimal? RoundOff { get; set; }

        /// <summary>
        /// Tax reduction
        /// </summary>
        [JsonReadOnly]
        public decimal? TaxReduction { get; private set; }

        /// <summary>
        /// Tax Reduction Type
        /// </summary>
        public string TaxReductionType { get; set; }

        /// <summary>
        /// Template name
        /// </summary>
        [JsonReadOnly]
        public string TemplateName { get; private set; }

        /// <summary>
        /// Template number
        /// </summary>
        public long? TemplateNumber { get; set; }

        /// <summary>
        /// Terms of delivery code
        /// </summary>
        public string TermsOfDelivery { get; set; }

        /// <summary>
        /// Terms of payment code
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        [JsonReadOnly]
        public decimal? Total { get; private set; }

        /// <summary>
        /// Total to pay
        /// </summary>
        [JsonReadOnly]
        public decimal? TotalToPay { get; private set; }

        /// <summary>
        /// Total VAT
        /// </summary>
        [JsonReadOnly]
        public decimal? TotalVAT { get; private set; }

        /// <summary>
        /// If VAT is included
        /// </summary>
        public bool? VATIncluded { get; set; }

        /// <summary>
        /// Way of delivery code
        /// </summary>
        public string WayOfDelivery { get; set; }

        /// <summary>
        /// Your order number
        /// </summary>
        public string YourOrderNumber { get; set; }

        /// <summary>
        /// Your reference
        /// </summary>
        public string YourReference { get; set; }
    }
}
