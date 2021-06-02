using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.SupplierInvoicePayment
{
    [JsonPropertyClass("SupplierInvoicePayment")]
    public class SupplierInvoicePayment
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        /// <summary>
        /// Amount of the payment
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Amount in the specified currency of the payment
        /// </summary>
        public decimal? AmountCurrency { get; set; }

        /// <summary>
        /// If the payment is booked or not
        /// </summary>
        [JsonReadOnly]
        public bool? Booked { get; set; }

        /// <summary>
        /// Currency of the payment
        /// </summary>
        [JsonReadOnly]
        public string Currency { get; set; }

        /// <summary>
        /// The currency rate
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// The currency unit
        /// </summary>
        [JsonReadOnly]
        public decimal? CurrencyUnit { get; set; }

        /// <summary>
        /// Information about the payment
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Invoice number
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Due date of the invoice
        /// </summary>
        [JsonReadOnly]
        public DateTime? InvoiceDueDate { get; set; }

        /// <summary>
        /// OCR of the invoice
        /// </summary>
        public string InvoiceOCR { get; set; }

        /// <summary>
        /// Name of the supplier
        /// </summary>
        [JsonReadOnly]
        public string InvoiceSupplierName { get; set; }

        /// <summary>
        /// Number of the supplier
        /// </summary>
        [JsonReadOnly]
        public string InvoiceSupplierNumber { get; set; }

        /// <summary>
        /// Invoice total
        /// </summary>
        [JsonReadOnly]
        public decimal? InvoiceTotal { get; set; }

        /// <summary>
        /// Code of the mode of payment
        /// </summary>
        public string ModeOfPayment { get; set; }

        /// <summary>
        /// Payment number
        /// </summary>
        [JsonReadOnly]
        public int? Number { get; set; }

        /// <summary>
        /// Date of the payment
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Payment source
        /// </summary>
        [JsonReadOnly]
        public string Source { get; set; }

        /// <summary>
        /// Number of the voucher 
        /// </summary>
        [JsonReadOnly]
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Series of the voucher
        /// </summary>
        [JsonReadOnly]
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Id of the voucher year
        /// </summary>
        [JsonReadOnly]
        public int? VoucherYear { get; set; }

        /// <summary>
        /// Write offs
        /// </summary>
        public List<WriteOff> WriteOffs { get; set; }
    }
}
