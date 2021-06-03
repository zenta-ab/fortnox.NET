using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Invoice
{
    [JsonPropertyClass("Invoices")]
    public class InvoiceSubset
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Balance of the invoice.
        /// </summary>
        [JsonReadOnly]
        public decimal? Balance { get; set; }

        /// <summary>
        /// If the invoice is bookkept. This value can be changed by using the action “bookkeep”.
        /// </summary>
        [JsonReadOnly]
        public bool? Booked { get; set; }

        /// <summary>
        /// If the invoice is cancelled. This value can be changed by using the action “cancel”.
        /// </summary>
        [JsonReadOnly]
        public bool? Cancelled { get; set; }

        /// <summary>
        /// Code of the cost center. The code must be of an existing cost center.
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Code of the currency. The code must be of an existing currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Currency rate used for the invoice.
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Currency unit used for the invoice.
        /// </summary>
        public decimal? CurrencyUnit { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer number of the customer. The customer number must be of an existing customer.
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// The invoice number. If no document number is provided, the next number in the series will be used.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Due date of the invoice.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// External invoice reference 1.
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference 2.
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Invoice date.
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// The type of invoice. Can be INVOICE AGREEMENTINVOICE INTRESTINVOICE SUMMARYINVOICE or CASHINVOICE.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// If the invoice is managed by NoxFinans
        /// </summary>
        [JsonReadOnly]
        public bool? NoxFinans { get; set; }

        /// <summary>
        /// OCR number of the invoice.
        /// </summary>
        public string OCR { get; set; }

        /// <summary>
        /// Code of the project. The code must be of an existing project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// If the document is printed or sent in any way.
        /// </summary>
        public bool? Sent { get; set; }

        /// <summary>
        /// Code of the terms of payment. The code must be of an existing terms of payment.
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// The total amount of the invoice.
        /// </summary>
        [JsonReadOnly]
        public decimal? Total { get; set; }

        /// <summary>
        /// Code of the way of delivery.
        /// </summary>
        public string WayOfDelivery { get; set; }

        /// <summary>
        /// Number of the voucher
        /// </summary>
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Series of the voucher
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Id of the voucher year
        /// </summary>
        public int? VoucherYear { get; set; }

        /// <summary>
        /// The date when the invoice became fully paid. 
        /// </summary>
        public DateTime? FinalPayDate { get; set; }
    }
}