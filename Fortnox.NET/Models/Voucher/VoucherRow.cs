namespace FortnoxNET.Models.Vouchers
{
    public class VoucherInvoiceRow
    {
        /// <summary>
        /// Account number
        /// </summary>
        public int? Account { get; set; }

        /// <summary>
        /// Code of the cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Amount of credit
        /// </summary>
        public decimal? Credit { get; set; }

        /// <summary>
        /// Amount of debit
        /// </summary>
        public decimal? Debit { get; set; }

        /// <summary>
        /// The description of the account
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Code of the project
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// If the row is marked as removed
        /// </summary>
        public bool? Removed { get; set; }

        /// <summary>
        /// Transaction information regarding the row
        /// </summary>
        public string TransactionInformation { get; set; }
    }
}