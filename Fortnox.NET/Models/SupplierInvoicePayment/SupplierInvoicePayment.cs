using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.SupplierInvoicePayment
{
    [JsonPropertyClass("SupplierInvoicePayment")]
    public class SupplierInvoicePayment
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public float Amount { get; set; }

        public float AmountCurrency { get; set; }

        [JsonReadOnly]
        public bool? Booked { get; set; }

        [JsonReadOnly]
        public string Currency { get; set; }

        public int CurrencyRate { get; set; }

        [JsonReadOnly]
        public int? CurrencyUnit { get; set; }

        public string Information { get; set; }

        public string InvoiceNumber { get; set; }

        [JsonReadOnly]
        public DateTime? InvoiceDueDate { get; set; }

        public string InvoiceOCR { get; set; }

        [JsonReadOnly]
        public string InvoiceSupplierName { get; set; }

        [JsonReadOnly]
        public string InvoiceSupplierNumber { get; set; }

        [JsonReadOnly]
        public string InvoiceTotal { get; set; }

        public string ModeOfPayment { get; set; }

        [JsonReadOnly]
        public int? Number { get; set; }

        public DateTime? PaymentDate { get; set; }

        [JsonReadOnly]
        public string Source { get; set; }

        [JsonReadOnly]
        public int? VoucherNumber { get; set; }

        [JsonReadOnly]
        public string VoucherSeries { get; set; }

        [JsonReadOnly]
        public int? VoucherYear { get; set; }

        public List<WriteOff> WriteOffs { get; set; }
    }
}
