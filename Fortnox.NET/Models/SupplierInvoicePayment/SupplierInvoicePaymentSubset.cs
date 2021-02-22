using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.SupplierInvoicePayment
{
    
    [JsonPropertyClass("SupplierInvoicePayments")]
    public class SupplierInvoicePaymentSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public decimal Amount { get; set; }
        
        public bool Booked { get; set; }

        public string Currency { get; set; }
        
        public int CurrencyRate { get; set; }
        
        public int CurrencyUnit { get; set; }

        public string InvoiceNumber { get; set; }

        public int Number { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Source { get; set; }
    }
}
