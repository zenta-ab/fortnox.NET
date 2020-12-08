namespace FortnoxNET.Models.ContractTemplates
{
    public class ContractTemplateInvoiceRow
    {
        /// <summary>
        /// Account number (If empty Fortnox will use setting on article)
        /// </summary>
        public int? AccountNumber { get; set; }

        /// <summary>
        /// Article number
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Delivered quantity
        /// </summary>
        public int? DeliveredQuantity { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Discount amount
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// AMOUNT / PERCENT
        /// </summary>
        public ContractTemplateInvoiceRowDiscountType DiscountType { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Code of unit
        /// </summary>
        public string Unit { get; set; }
    }
}