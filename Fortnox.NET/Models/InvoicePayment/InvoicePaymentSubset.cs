using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.InvoicePayment
{
    [JsonPropertyClass("InvoicePayments")]
    public class InvoicePaymentSubset
    {
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        public int Amount { get; set; }
        public bool Booked { get; set; }
        public string Currency { get; set; }
        public int CurrencyRate { get; set; }
        public int CurrencyUnit { get; set; }
        public int InvoiceNumber { get; set; }
        public int Number { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Source { get; set; }
    }
}
