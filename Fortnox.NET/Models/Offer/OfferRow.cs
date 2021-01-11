using Fortnox.NET.Models.Common;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Offer
{
    public class OfferRow
    {
        public int? AccountNumber { get; set; }
        
        public string ArticleNumber { get; set; }

        public int? ContributionPercent { internal get; set; }

        public int? ContributionValue { internal get; set; }
        
        public string CostCenter { get; set; }
        
        public string Description { get; set; }
        
        public int? Discount { get; set; }
        
        public string DiscountType { get; set; }
        
        public bool? HouseWork { get; set; }
        
        public int? HouseWorkHoursToReport { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public HouseworkType? HouseWorkType { get; set; }
        
        public int? Price { get; set; }
        
        public string Project { get; set; }
        
        public string Quantity { get; set; }
        
        public int? Total { get; set; }

        public string Unit { internal get; set; }
        
        public int? VAT { get; set; }
    }
}
