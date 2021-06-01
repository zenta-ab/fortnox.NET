using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.InvoicePayment
{
    [JsonPropertyClass("InvoicePayment")]
    public class InvoicePayment
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        /// <summary>
        /// Amount of the payment
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Amount in the specified currency of the payment. Required if Currency is other than SEK
        /// </summary>
        public decimal? AmountCurrency { get; set; }

        /// <summary>
        /// If the payment is booked or not
        /// </summary>
        public bool? Booked { get; set; }

        /// <summary>
        /// Currency of the payment
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The currency rate
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// The currency unit
        /// </summary>
        public decimal? CurrencyUnit { get; set; }

        /// <summary>
        /// Invoice number
        /// </summary>
        public int InvoiceNumber { get; set; }

        /// <summary>
        /// Payment number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Date of the payment
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Payment source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// External invoice reference
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Customer name of the invoice
        /// </summary>
        public string InvoiceCustomerName { get; set; }

        /// <summary>
        /// Customer number of the invoice
        /// </summary>
        public string InvoiceCustomerNumber { get; set; }

        /// <summary>
        /// Due date of the invoice
        /// </summary>
        public DateTime? InvoiceDueDate { get; set; }

        /// <summary>
        /// OCR of the invoice
        /// </summary>
        public string InvoiceOCR { get; set; }

        /// <summary>
        /// Invoice total
        /// </summary>
        public string InvoiceTotal { get; set; }

        /// <summary>
        /// Code of the mode of payment
        /// </summary>
        public string ModeOfPayment { get; set; }

        /// <summary>
        /// Account for the mode of payment
        /// </summary>
        public int? ModeOfPaymentAccount { get; set; }

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
        /// WriteOffs of the invoice
        /// </summary>
        public List<WriteOff> WriteOffs { get; set; }
    }
}