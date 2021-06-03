namespace FortnoxNET.Models.Vouchers
{
    public class SupplierInvoiceRow
    {
        /// <summary> 
        /// Account number
        /// </summary>
        public int? Account { get; set; }

        /// <summary>
        /// Article number 
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary> 
        /// Listed below
        /// </summary>
        public string Code { get; set; }

        /// <summary> 
        /// Cost center code 
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary> 
        /// Account Description 
        /// </summary>
        public string AccountDescription { get; set; }

        /// <summary> 
        /// Item Description 
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary> 
        ///  Debit 
        /// </summary>
        public decimal? Debit { get; set; }

        /// <summary> 
        ///  Debit currency 
        /// </summary>
        public decimal? DebitCurrency { get; set; }

        /// <summary> 
        ///  Credit 
        /// </summary>
        public decimal? Credit { get; set; }

        /// <summary> 
        ///  Credit currency 
        /// </summary>
        public decimal? CreditCurrency { get; set; }

        /// <summary>
        /// Project code 
        /// </summary>
        public string Project { get; set; }

        /// <summary> 
        /// Unit price 
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary> 
        /// Quantity 
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary> 
        /// Row amount 
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary> 
        /// Transaction information 
        /// </summary>
        public string TransactionInformation { get; set; }

        /// <summary> 
        /// Code of unit 
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Stock point code
        /// </summary>
        public string StockPointCode { get; set; }

        /// <summary>
        /// Stock location code
        /// </summary>
        public string StockLocationCode { get; set; }
    }
}