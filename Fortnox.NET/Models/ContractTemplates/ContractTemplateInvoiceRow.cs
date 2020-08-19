namespace FortnoxNET.Models.ContractTemplates
{
    public class ContractTemplateInvoiceRow
    {
        public int AccountNumber { get; set; }
        
        public string ArticleNumber { get; set; }
        
        public string CostCenter { get; set; }
        
        public int DeliveredQuantity { get; set; }
        
        public string Description { get; set; }
        
        public decimal Discount { get; set; }
        
        public ContractTemplateInvoiceRowDiscountType DiscountType { get; set; }
        
        public decimal Price { get; set; }
        
        public string Project { get; set; }
        
        public string Unit { get; set; }
    }
}