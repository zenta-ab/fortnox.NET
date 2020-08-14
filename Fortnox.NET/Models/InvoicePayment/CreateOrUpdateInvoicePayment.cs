using FortnoxNET.Utils;

namespace Fortnox.NET.Models.InvoicePayment
{
    [JsonPropertyClass("InvoicePayment")]
    public class CreateOrUpdateInvoicePayment
    {
        public int Amount { get; set; }

        public int AmountCurrency { get; set; }

        public int InvoiceNumber { get; set; }
    }
}
