namespace FortnoxNET.Models.Vouchers
{
    public class SupplierInvoiceRow
    {
        public int Account { get; set; }
        public string Code { get; set; }
        public string AccountDescription { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}