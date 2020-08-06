using FortnoxNET.Utils;

namespace FortnoxNET.Models.Assets
{
    public class History
    {
        [JsonReadOnly]
        public int Id { get; set; }
        [JsonReadOnly]
        public string Date { get; set; }
        [JsonReadOnly]
        public int EventId { get; set; }
        [JsonReadOnly]
        public string Amount { get; set; }
        [JsonReadOnly]
        public int UserId { get; set; }
        [JsonReadOnly]
        public string UserName { get; set; }
        [JsonReadOnly]
        public string Notes { get; set; }
        [JsonReadOnly]
        public int? VoucherNumber { get; set; }
        [JsonReadOnly]
        public string VoucherSeries { get; set; }
        [JsonReadOnly]
        public int? VoucherYear { get; set; }
        [JsonReadOnly]
        public int SupplierInvoice { get; set; }
    }
}