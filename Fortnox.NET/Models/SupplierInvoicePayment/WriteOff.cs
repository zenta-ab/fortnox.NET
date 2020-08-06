namespace FortnoxNET.Models.SupplierInvoicePayment
{

    public class WriteOff
    {
        public float Amount { get; set; }

        public int AccountNumber { get; set; }

        public string CostCenter { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public int TransactionInformationCode { get; set; }

        public string Project { get; set; }
    }
}
