using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.SupplierInvoice
{
    [JsonPropertyClass("SupplierInvoices")]
    public class SupplierInvoiceSubset
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Balance of invoice
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// If the invoice is bookkept
        /// </summary>
        public bool? Booked { get; set; }

        /// <summary>
        /// If the invoice is cancelled
        /// </summary>
        public bool? Cancelled { get; set; }

        /// <summary>
        /// Cost Center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// If invoice is a Credit invoice
        /// </summary>
        public bool? Credit { get; set; }

        /// <summary>
        /// Currency 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Currency rate
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Currency unit
        /// </summary>
        public decimal? CurrencyUnit { get; set; }

        /// <summary>
        /// Due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Given Number
        /// </summary>
        public string GivenNumber { get; set; }

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime? InvoiceDate { get; set; }

        /// <summary>
        /// Invoice Number
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Supplier number
        /// </summary>
        public string SupplierNumber { get; set; }

        /// <summary>
        /// Supplier name
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        public decimal? Total { get; set; }
    }
}