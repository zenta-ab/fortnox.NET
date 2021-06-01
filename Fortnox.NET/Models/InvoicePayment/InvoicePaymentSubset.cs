using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.InvoicePayment
{
    [JsonPropertyClass("InvoicePayments")]
    public class InvoicePaymentSubset
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
    }
}
