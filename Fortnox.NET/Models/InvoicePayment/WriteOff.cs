namespace FortnoxNET.Models.InvoicePayment
{
    public class WriteOff
    {
        public int Amount { get; set; }
        public int AccountNumber { get; set; }
        public string CostCenter { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string TransactionInformation { get; set; }
        public string Project { get; set; }
    }
}