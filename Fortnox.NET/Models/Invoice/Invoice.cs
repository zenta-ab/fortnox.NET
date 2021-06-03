using System;
using System.Collections.Generic;
using Fortnox.NET.Models.Common;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Invoice
{
    [JsonPropertyClass("Invoice")]
    public class Invoice
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool ShouldSerializeUrl() => false;
        
        /// <summary>
        /// Direct url to the tax reduction for the invoice. This is visible even if no tax reduction exists
        /// </summary>
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public bool ShouldSerializeUrlTaxReductionList() => false;

        /// <summary>
        /// Invoice address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Invoice address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The invoice administration fee
        /// </summary>
        public decimal AdministrationFee { get; set; }

        /// <summary>
        /// VAT of the invoice administration fee
        /// </summary>
        public decimal? AdministrationFeeVAT { get; set; }

        public bool ShouldSerializeAdministrationFeeVAT() => false;

        /// <summary>
        /// Balance of the invoice
        /// </summary>
        public decimal Balance { get; set; }

        public bool ShouldSerializeBalance() => false;

        /// <summary>
        /// Basis of tax reduction
        /// </summary>
        public decimal BasisTaxReduction { get; set; }

        public bool ShouldSerializeBasisTaxReduction() => false;

        /// <summary>
        /// If the invoice is bookkept. This value can be changed by using the action "bookkeep"
        /// </summary>
        public bool Booked { get; set; }

        public bool ShouldSerializeBooked() => false;

        /// <summary>
        /// If the invoice is cancelled. This value can be changed by using the action "cancel"
        /// </summary>
        public bool Cancelled { get; set; }

        public bool ShouldSerializeCancelled() => false;

        /// <summary>
        /// City for the invoice address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Comments of the invoice
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Reference to the contract, if one exists
        /// </summary>
        public int ContractReference { get; set; }

        public bool ShouldSerializeContractReference() => false;

        /// <summary>
        /// Invoice contribution in percent
        /// </summary>
        public decimal ContributionPercent { get; set; }

        public bool ShouldSerializeContributionPercent() => false;

        /// <summary>
        /// Invoice contribution in amount
        /// </summary>
        public decimal ContributionValue { get; set; }

        public bool ShouldSerializeContributionValue() => false;

        /// <summary>
        /// Code of the cost center. The code must be of an existing cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Country for the invoice address. Must be a name of an existing country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// If the invoice is a credit invoice
        /// </summary>
        public bool Credit { get; set; }

        public bool ShouldSerializeCredit() => false;

        /// <summary>
        /// Reference to the credit invoice, if one exits. The reference must be a document number for an existing credit invoice
        /// </summary>
        public int? CreditInvoiceReference { get; set; }

        public bool ShouldSerializeCreditInvoiceReference() => false;

        /// <summary>
        /// Code of the currency. The code must be of an existing currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Currency rate used for the invoice
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Currency unit used for the invoice
        /// </summary>
        public int? CurrencyUnit { get; set; }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer number of the customer. The customer number must be of an existing customer
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Delivery address line 1
        /// </summary>
        public string DeliveryAddress1 { get; set; }

        /// <summary>
        /// Delivery address line 2
        /// </summary>
        public string DeliveryAddress2 { get; set; }
        
        /// <summary>
        /// Delivery address city
        /// </summary>
        public string DeliveryCity { get; set; }

        /// <summary>
        /// Country for the invoice delivery address. Must be a name of an existing country
        /// </summary>
        public string DeliveryCountry { get; set; }

        /// <summary>
        /// Date of delivery
        /// </summary>
        public string DeliveryDate { get; set; }

        /// <summary>
        /// Name of the recipient of the delivery
        /// </summary>
        public string DeliveryName { get; set; }

        /// <summary>
        /// ZipCode for the invoice delivery address
        /// </summary>
        public string DeliveryZipCode { get; set; }

        /// <summary>
        /// The invoice number. If no document number is provided, the next number in the series will be used
        /// </summary>
        public int DocumentNumber { get; set; }

        /// <summary>
        /// Due date of the invoice
        /// </summary>
        public DateTime? DueDate { get; set; }
        
        public EDIInformation EDIInformation { get; set; }

        /// <summary>
        /// EU Quarterly Report On / Off
        /// </summary>
        public bool EUQuarterlyReport { get; set; }
        
        public EmailInformation EmailInformation { get; set; }

        /// <summary>
        /// External invoice reference 1
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference 2
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// The date when the invoice became fully paid. Only available if the invoice is fully paid
        /// </summary>
        public DateTime? FinalPayDate { get; set; }

        public bool ShouldSerializeFinalPayDate() => false;

        /// <summary>
        /// Freight cost of the invoice
        /// </summary>
        public decimal Freight { get; set; }

        /// <summary>
        /// VAT of the freight cost
        /// </summary>
        public decimal FreightVAT { get; set; }

        public bool ShouldSerializeFreightVAT() => false;

        /// <summary>
        /// Gross value of the invoice
        /// </summary>
        public decimal Gross { get; set; }

        public bool ShouldSerializeGross() => false;

        public bool HouseWork { get; set; }

        public bool ShouldSerializeHouseWork() => false;

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// Start date of the invoice period, only applicable for contract invoices
        /// </summary>
        public DateTime? InvoicePeriodEnd { get; set; }

        public bool ShouldSerializeInvoicePeriodEnd() => false;

        /// <summary>
        /// End date of the invoice period, only applicable for contract invoices
        /// </summary>
        public DateTime? InvoicePeriodStart { get; set; }

        public bool ShouldSerializeInvoicePeriodStart() => false;

        /// <summary>
        /// 
        /// </summary>
        public string InvoiceReference { get; set; }
        
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <summary>
        /// The type of invoice.
        /// Can be INVOICE AGREEMENTINVOICE INTRESTINVOICE SUMMARYINVOICE or CASHINVOICE
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public InvoiceType? InvoiceType { get; set; }

        /// <summary>
        /// The properties for the object in this array is listed in the table “Labels”
        /// </summary>
        public List<Label> Labels { get; set; }

        /// <summary>
        /// Language code.
        /// Can be SV or EN
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Date of last reminder
        /// </summary>
        public DateTime? LastRemindDate { get; set; }

        public bool ShouldSerializeLastRemindDate() => false;

        /// <summary>
        /// Net amount
        /// </summary>
        public decimal Net { get; set; }

        public bool ShouldSerializeNet() => false;

        /// <summary>
        /// If the invoice is set as not completed
        /// </summary>
        public bool NotCompleted { get; set; }

        /// <summary>
        /// If the invoice is managed by NoxFinans
        /// </summary>
        public bool NoxFinans { get; set; }

        public bool ShouldSerializeNoxFinans() => false;

        /// <summary>
        /// OCR number of the invoice
        /// </summary>
        public string OCR { get; set; }

        /// <summary>
        /// Reference to the offer, if one exists
        /// </summary>
        public string OfferReference { get; set; }

        public bool ShouldSerializeOfferReference() => false;

        /// <summary>
        /// Reference to the order, if one exists
        /// </summary>
        public string OrderReference { get; set; }

        public bool ShouldSerializeOrderReference() => false;

        /// <summary>
        /// Organisation number of the customer for the invoice
        /// </summary>
        public string OrganisationNumber { get; set; }

        public bool ShouldSerializeOrganisationNumber() => false;

        /// <summary>
        /// Our reference
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// CASH, CARD, AG
        /// </summary>
        public string PaymentWay { get; set; }

        /// <summary>
        /// Phone number 1 of the customer for the invoice
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone number 2 of the customer for the invoice
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Code of the price list. The code must be of an existing price list
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// Print template of the invoice. Must be an existing print template.
        /// </summary>
        public string PrintTemplate { get; set; }

        /// <summary>
        /// Code of the project. The code must be of an existing project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Remarks of the invoice. This is the invoice text shown on the invoice.
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Number of reminders sent to the customer.
        /// </summary>
        public int Reminders { get; set; }

        public bool ShouldSerializeReminders() => false;

        /// <summary>
        /// Round off amount for the invoice.
        /// </summary>
        public decimal RoundOff { get; set; }

        public bool ShouldSerializeRoundOff() => false;

        /// <summary>
        /// If the document is printed or sent in any way.
        /// </summary>
        public bool Sent { get; set; }

        public bool ShouldSerializeSent() => false;

        /// <summary>
        /// The amount of tax reduction.
        /// </summary>
        public int? TaxReduction { get; set; }

        public bool ShouldSerializeTaxReduction() => false;

        /// <summary>
        /// Tax Reduction Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxReductionType? TaxReductionType { get; set; }

        /// <summary>
        /// Code of the terms of delivery. The code must be of an existing terms of delivery.
        /// </summary>
        public string TermsOfDelivery { get; set; }

        /// <summary>
        /// Code of the terms of payment. The code must be of an existing terms of payment.
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// The total amount of the invoice.
        /// </summary>
        public decimal Total { get; set; }

        public bool ShouldSerializeTotal() => false;

        /// <summary>
        /// The total amount to pay of the invoice.
        /// </summary>
        public decimal TotalToPay { get; set; }

        public bool ShouldSerializeTotalToPay() => false;

        /// <summary>
        /// The total VAT amount of the invoice.
        /// </summary>
        public decimal TotalVAT { get; set; }

        public bool ShouldSerializeTotalVAT() => false;

        /// <summary>
        /// If the price of the invoice is including VAT
        /// </summary>
        public bool VATIncluded { get; set; }

        /// <summary>
        /// Voucher number for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        public int? VoucherNumber { get; set; }

        public bool ShouldSerializeVoucherNumber() => false;

        /// <summary>
        /// Voucher series for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        public string VoucherSeries { get; set; }

        public bool ShouldSerializeVoucherSeries() => false;

        /// <summary>
        /// Voucher year for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        public int? VoucherYear { get; set; }

        public bool ShouldSerializeVoucherYear() => false;

        /// <summary>
        /// Code of the way of delivery. The code must be of an existing way of delivery.
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

        /// <summary>
        /// Zip code of the invoice
        /// </summary>
        public string ZipCode { get; set; }
    }
}