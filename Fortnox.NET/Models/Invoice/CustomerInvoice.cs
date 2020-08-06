using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Invoice
{
    public class CustomerInvoice : InvoiceSubset
    {
        public CustomerInvoice()
        {
            Labels = new List<Label>();
            InvoiceRows = new List<InvoiceRow>();
        }

        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public decimal AdministrationFee { get; set; }
        public decimal AdministrationFeeVAT { get; set; }
        public decimal BasisTaxReduction { get; set; }
        public string City { get; set; }
        public string Comments { get; set; }
        public int ContractReference { get; set; }
        public decimal ContributionPercent { get; set; }
        public decimal ContributionValue { get; set; }
        public string Country { get; set; }
        public string Credit { get; set; }
        public string CreditInvoiceReference { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountry { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryZipCode { get; set; }
        public EDIInformation EDIInformation { get; set; }
        public bool EUQuarterlyReport { get; set; }
        public EmailInformation EmailInformation { get; set; }
        public decimal Freight { get; set; }
        public decimal FreightVAT { get; set; }
        public decimal Gross { get; set; }
        public bool HouseWork { get; set; }
        public DateTime? InvoicePeriodEnd { get; set; }
        public DateTime? InvoicePeriodStart { get; set; }
        public string InvoiceReference { get; set; }
        public IEnumerable<InvoiceRow> InvoiceRows { get; set; }
        public IEnumerable<Label> Labels { get; set; }
        public string Language { get; set; }
        public DateTime? LastRemindDate { get; set; }
        public decimal Net { get; set; }
        public bool NotCompleted { get; set; }
        public string OfferReference { get; set; }
        public string OrderReference { get; set; }
        public string OrganisationNumber { get; set; }
        public string OurReference { get; set; }
        public string PaymentWay { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PriceList { get; set; }
        public string PrintTemplate { get; set; }
        public string Remarks { get; set; }
        public bool WarehouseReady { get; set; }
        public DateTime? OutboundDate { get; set; }
        public int Reminders { get; set; }
        public decimal RoundOff { get; set; }
        public int? TaxReduction { get; set; }
        public string TermsOfDelivery { get; set; }
        public decimal TotalToPay { get; set; }
        public decimal TotalVAT { get; set; }
        public bool VATIncluded { get; set; }
        public int? VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public int? VoucherYear { get; set; }
        public string YourOrderNumber { get; set; }
        public string YourReference { get; set; }
        public string ZipCode { get; set; }
        public string AccountingMethod { get; set; }
        public DateTime? FinalPayDate { get; set; }
    }
}