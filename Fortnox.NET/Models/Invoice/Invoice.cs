using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Invoice
{
    [JsonPropertyClass("Invoice")]
    [JsonConverter(typeof(CustomJsonConverter))]
    public class Invoice
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        public int AdministrationFee { get; set; }
        
        [JsonReadOnly]
        public int AdministrationFeeVAT { get; set; }
        
        [JsonReadOnly]
        public int Balance { get; set; }
        
        [JsonReadOnly]
        public int BasisTaxReduction { get; set; }
        
        [JsonReadOnly]
        public bool Booked { get; set; }
        
        [JsonReadOnly]
        public bool Cancelled { get; set; }
        
        public string City { get; set; }
        
        public string Comments { get; set; }
        
        [JsonReadOnly]
        public int ContractReference { get; set; }
        
        [JsonReadOnly]
        public double ContributionPercent { get; set; }
        
        [JsonReadOnly]
        public int ContributionValue { get; set; }
        
        public string CostCenter { get; set; }
        
        public string Country { get; set; }
        
        [JsonReadOnly]
        public string Credit { get; set; }
        
        [JsonReadOnly]
        public string CreditInvoiceReference { get; set; }
        
        public string Currency { get; set; }
        
        public int? CurrencyRate { get; set; }
        
        public int? CurrencyUnit { get; set; }
        
        public string CustomerName { get; set; }
        
        public string CustomerNumber { get; set; }
        
        public string DeliveryAddress1 { get; set; }
        
        public string DeliveryAddress2 { get; set; }
        
        public string DeliveryCity { get; set; }
        
        public string DeliveryCountry { get; set; }
        
        public string DeliveryDate { get; set; }
        
        public string DeliveryName { get; set; }
        
        public string DeliveryZipCode { get; set; }
        
        public string DocumentNumber { get; set; }
        
        public string DueDate { get; set; }
        
        public EDIInformation EDIInformation { get; set; }
        
        public bool EUQuarterlyReport { get; set; }
        
        public EmailInformation EmailInformation { get; set; }
        
        public string ExternalInvoiceReference1 { get; set; }
        
        public string ExternalInvoiceReference2 { get; set; }
        
        [JsonReadOnly]
        public DateTime? FinalPayDate { get; set; }
        
        public int Freight { get; set; }
        
        [JsonReadOnly]
        public double FreightVAT { get; set; }
        
        [JsonReadOnly]
        public int Gross { get; set; }
        
        [JsonReadOnly]
        public bool HouseWork { get; set; }
        
        public string InvoiceDate { get; set; }
        
        [JsonReadOnly]
        public DateTime? InvoicePeriodEnd { get; set; }
        
        [JsonReadOnly]
        public DateTime? InvoicePeriodStart { get; set; }
        
        public string InvoiceReference { get; set; }
        
        public List<InvoiceRow> InvoiceRows { get; set; }
        
        public string InvoiceType { get; set; }
        
        public List<Label> Labels { get; set; }
        
        public string Language { get; set; }
        
        [JsonReadOnly]
        public DateTime? LastRemindDate { get; set; }
        
        [JsonReadOnly]
        public int Net { get; set; }
        
        public bool NotCompleted { get; set; }
        
        [JsonReadOnly]
        public bool NoxFinans { get; set; }
        
        public string OCR { get; set; }
        
        [JsonReadOnly]
        public string OfferReference { get; set; }
        
        [JsonReadOnly]
        public string OrderReference { get; set; }
        
        [JsonReadOnly]
        public string OrganisationNumber { get; set; }
        
        public string OurReference { get; set; }
        
        public string PaymentWay { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string PriceList { get; set; }
        
        public string PrintTemplate { get; set; }
        
        public string Project { get; set; }
        
        public string Remarks { get; set; }
        
        [JsonReadOnly]
        public int Reminders { get; set; }
        
        [JsonReadOnly]
        public double RoundOff { get; set; }
        
        [JsonReadOnly]
        public bool Sent { get; set; }
        
        [JsonReadOnly]
        public object TaxReduction { get; set; }
        
        public string TermsOfDelivery { get; set; }
        
        public string TermsOfPayment { get; set; }
        
        [JsonReadOnly]
        public int Total { get; set; }
        
        [JsonReadOnly]
        public int TotalToPay { get; set; }
        
        [JsonReadOnly]
        public double TotalVAT { get; set; }
        
        public bool VATIncluded { get; set; }
        
        [JsonReadOnly]
        public object VoucherNumber { get; set; }
        
        [JsonReadOnly]
        public object VoucherSeries { get; set; }
        
        [JsonReadOnly]
        public object VoucherYear { get; set; }
        
        public string WayOfDelivery { get; set; }
        
        public string YourOrderNumber { get; set; }
        
        public string YourReference { get; set; }
        
        public string ZipCode { get; set; }
    }
}