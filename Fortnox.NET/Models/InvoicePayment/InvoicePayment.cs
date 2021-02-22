using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.InvoicePayment
{
    [JsonPropertyClass("InvoicePayment")]
    public class InvoicePayment
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
        public int AmountCurrency { get; set; }
        public string ExternalInvoiceReference1 { get; set; }
        public string ExternalInvoiceReference2 { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNumber { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string InvoiceOCR { get; set; }
        public string InvoiceTotal { get; set; }
        public string ModeOfPayment { get; set; }
        public int ModeOfPaymentAccount { get; set; }
        public int? VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public int? VoucherYear { get; set; }
        public List<WriteOff> WriteOffs { get; set; }
    }
}