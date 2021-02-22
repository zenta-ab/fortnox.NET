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
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Direct url to the tax reduction for the invoice. This is visible even if no tax reduction exists
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

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
        [JsonReadOnly]
        public decimal AdministrationFeeVAT { get; set; }

        /// <summary>
        /// Balance of the invoice
        /// </summary>
        [JsonReadOnly]
        public decimal Balance { get; set; }

        /// <summary>
        /// Basis of tax reduction
        /// </summary>
        [JsonReadOnly]
        public decimal BasisTaxReduction { get; set; }

        /// <summary>
        /// If the invoice is bookkept. This value can be changed by using the action "bookkeep"
        /// </summary>
        [JsonReadOnly]
        public bool Booked { get; set; }

        /// <summary>
        /// If the invoice is cancelled. This value can be changed by using the action "cancel"
        /// </summary>
        [JsonReadOnly]
        public bool Cancelled { get; set; }
        
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
        [JsonReadOnly]
        public int ContractReference { get; set; }

        /// <summary>
        /// Invoice contribution in percent
        /// </summary>
        [JsonReadOnly]
        public decimal ContributionPercent { get; set; }

        /// <summary>
        /// Invoice contribution in amount
        /// </summary>
        [JsonReadOnly]
        public decimal ContributionValue { get; set; }

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
        [JsonReadOnly]
        public bool Credit { get; set; }

        /// <summary>
        /// Reference to the credit invoice, if one exits. The reference must be a document number for an existing credit invoice
        /// </summary>
        [JsonReadOnly]
        public int? CreditInvoiceReference { get; set; }

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
        [JsonReadOnly]
        public DateTime? FinalPayDate { get; set; }

        /// <summary>
        /// Freight cost of the invoice
        /// </summary>
        public decimal Freight { get; set; }

        /// <summary>
        /// VAT of the freight cost
        /// </summary>
        [JsonReadOnly]
        public decimal FreightVAT { get; set; }

        /// <summary>
        /// Gross value of the invoice
        /// </summary>
        [JsonReadOnly]
        public decimal Gross { get; set; }
        
        [JsonReadOnly]
        public bool HouseWork { get; set; }

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// Start date of the invoice period, only applicable for contract invoices
        /// </summary>
        [JsonReadOnly]
        public DateTime? InvoicePeriodEnd { get; set; }

        /// <summary>
        /// End date of the invoice period, only applicable for contract invoices
        /// </summary>
        [JsonReadOnly]
        public DateTime? InvoicePeriodStart { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceReference { get; set; }
        
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <summary>
        /// The type of invoice.
        /// Can be INVOICE AGREEMENTINVOICE INTRESTINVOICE SUMMARYINVOICE or CASHINVOICE
        /// </summary>
        public string InvoiceType { get; set; }
        
        public List<Label> Labels { get; set; }

        /// <summary>
        /// Language code.
        /// Can be SV or EN
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Date of last reminder
        /// </summary>
        [JsonReadOnly]
        public DateTime? LastRemindDate { get; set; }

        /// <summary>
        /// Net amount
        /// </summary>
        [JsonReadOnly]
        public decimal Net { get; set; }

        /// <summary>
        /// If the invoice is set as not completed
        /// </summary>
        public bool NotCompleted { get; set; }

        /// <summary>
        /// If the invoice is managed by NoxFinans
        /// </summary>
        [JsonReadOnly]
        public bool NoxFinans { get; set; }

        /// <summary>
        /// OCR number of the invoice
        /// </summary>
        public string OCR { get; set; }

        /// <summary>
        /// Reference to the offer, if one exists
        /// </summary>
        [JsonReadOnly]
        public string OfferReference { get; set; }

        /// <summary>
        /// Reference to the order, if one exists
        /// </summary>
        [JsonReadOnly]
        public string OrderReference { get; set; }

        /// <summary>
        /// Organisation number of the customer for the invoice
        /// </summary>
        [JsonReadOnly]
        public string OrganisationNumber { get; set; }

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
        [JsonReadOnly]
        public int Reminders { get; set; }

        /// <summary>
        /// Round off amount for the invoice.
        /// </summary>
        [JsonReadOnly]
        public decimal RoundOff { get; set; }

        /// <summary>
        /// If the document is printed or sent in any way.
        /// </summary>
        [JsonReadOnly]
        public bool Sent { get; set; }

        /// <summary>
        /// The amount of tax reduction.
        /// </summary>
        [JsonReadOnly]
        public int? TaxReduction { get; set; }

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
        [JsonReadOnly]
        public decimal Total { get; set; }

        /// <summary>
        /// The total amount to pay of the invoice.
        /// </summary>
        [JsonReadOnly]
        public decimal TotalToPay { get; set; }

        /// <summary>
        /// The total VAT amount of the invoice.
        /// </summary>
        [JsonReadOnly]
        public decimal TotalVAT { get; set; }

        /// <summary>
        /// If the price of the invoice is including VAT
        /// </summary>
        public bool VATIncluded { get; set; }

        /// <summary>
        /// Voucher number for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        [JsonReadOnly]
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Voucher series for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        [JsonReadOnly]
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Voucher year for the invoice. This is created when the invoice is bookkept.
        /// </summary>
        [JsonReadOnly]
        public int? VoucherYear { get; set; }

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