using FortnoxNET.Utils;

namespace FortnoxNET.Models.Offer
{
    public class OfferRow
    {
        public int AccountNumber { get; set; }
        
        public string ArticleNumber { get; set; }

        [JsonReadOnly]
        public int ContributionPercent { get; set; }

        [JsonReadOnly]
        public int ContributionValue { get; set; }
        
        public string CostCenter { get; set; }
        
        public string Description { get; set; }
        
        public int Discount { get; set; }
        
        public string DiscountType { get; set; }
        
        public bool HouseWork { get; set; }
        
        public int? HouseWorkHoursToReport { get; set; }
        
        public string HouseWorkType { get; set; }
        
        public int Price { get; set; }
        
        public string Project { get; set; }
        
        public string Quantity { get; set; }
        
        public int Total { get; set; }

        [JsonReadOnly]
        public string Unit { get; set; }
        
        public int VAT { get; set; }
    }
}
