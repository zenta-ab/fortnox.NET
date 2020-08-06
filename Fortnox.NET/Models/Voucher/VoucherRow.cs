namespace FortnoxNET.Models.Vouchers
{
    public class VoucherInvoiceRow
    {
        public int Account { get; set; }
        public string CostCenter { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string Description { get; set; }
        public string Project { get; set; }
        public bool Removed { get; set; }
        public string TransactionInformation { get; set; }
    }
}