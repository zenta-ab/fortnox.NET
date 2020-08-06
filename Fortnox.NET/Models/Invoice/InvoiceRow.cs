using FortnoxNET.Utils;

namespace FortnoxNET.Models.Invoice
{
    public class InvoiceRow
    {
        public int AccountNumber { get; set; }
        public string ArticleNumber { get; set; }
        [JsonReadOnly]
        public string ContributionPercent { get; set; }
        [JsonReadOnly]
        public string ContributionValue { get; set; }
        public string CostCenter { get; set; }
        public string DeliveredQuantity { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public string DiscountType { get; set; }
        public bool HouseWork { get; set; }
        public int? HouseWorkHoursToReport { get; set; }
        public string HouseWorkType { get; set; }
        public decimal Price { get; set; }
        
        [JsonReadOnly]
        public decimal? PriceExcludingVAT { get; set; }
        
        public string Project { get; set; }
        
        public string StockPointCode { get; set; }
        
        [JsonReadOnly]
        public decimal? Total { get; set; }
        
        [JsonReadOnly]
        public decimal? TotalExcludingVAT { get; set; }
        
        public string Unit { get; set; }
        
        public decimal VAT { get; set; }
    }
}