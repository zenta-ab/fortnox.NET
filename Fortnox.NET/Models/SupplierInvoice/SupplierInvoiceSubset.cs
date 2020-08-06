using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.SupplierInvoice

{
    [JsonPropertyClass("SupplierInvoices")]
    public class SupplierInvoiceSubset
    {
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        public string Balance { get; set; }
        public bool Booked { get; set; }
        public string Cancel { get; set; }
        public string CostCenter { get; set; }
        public bool Credit { get; set; }
        public string Currency { get; set; }
        public string CurrencyRate { get; set; }
        public int CurrencyUnit { get; set; }
        public DateTime DueDate { get; set; }
        public string GivenNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string Project { get; set; }
        public string SupplierNumber { get; set; }
        public string SupplierName { get; set; }
        public string Total { get; set; }
        public string AuthorizerName { get; set; }

    }
}