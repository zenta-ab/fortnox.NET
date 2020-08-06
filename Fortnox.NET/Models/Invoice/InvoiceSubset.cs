using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Invoice
{
    [JsonPropertyClass("Invoices")]
    public class InvoiceSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        [JsonReadOnly]
        public decimal Balance { get; set; }
        [JsonReadOnly]
        public bool Booked { get; set; }
        [JsonReadOnly]
        public bool Cancelled { get; set; }
        public string CostCenter { get; set; }
        public string Currency { get; set; }
        public decimal CurrencyRate { get; set; }
        public decimal CurrencyUnit { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string ExternalInvoiceReference1 { get; set; }
        public string ExternalInvoiceReference2 { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        [JsonReadOnly]
        public bool NoxFinans { get; set; }
        public string OCR { get; set; }
        public string Project { get; set; }
        public bool Sent { get; set; }
        public string TermsOfPayment { get; set; }
        [JsonReadOnly]
        public decimal Total { get; set; }
        public string WayOfDelivery { get; set; }
    }
}