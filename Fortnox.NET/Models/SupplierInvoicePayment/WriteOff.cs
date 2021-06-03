namespace FortnoxNET.Models.SupplierInvoicePayment
{
    public class WriteOff
    {
        /// <summary>
        /// Amount of the writeoff
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Account number of the write off
        /// </summary>
        public int? AccountNumber { get; set; }

        /// <summary>
        /// Code of the cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Currency of the payment
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// 	Description of the write off
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The transaction information
        /// </summary>
        public string TransactionInformation { get; set; }

        /// <summary>
        /// Project number of the write off
        /// </summary>
        public string Project { get; set; }
    }
}
