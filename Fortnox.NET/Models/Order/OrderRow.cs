using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Order
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class OrderRow
    {
        public int? AccountNumber { get; set; }

        public string ArticleNumber { get; set; }

        [JsonReadOnly]
        public decimal? ContributionPercent { get; set; }

        [JsonReadOnly]
        public decimal? ContributionValue { get; set; }

        public string CostCenter { get; set; }

        public decimal? DeliveredQuantity { get; set; }

        public string Description { get; set; }

        public decimal? Discount { get; set; }

        public string DiscountType { get; set; }

        public bool? HouseWork { get; set; }

        public int? HouseWorkHoursToReport { get; set; }

        public string HouseWorkType { get; set; }

        public decimal? OrderedQuantity { get; set; }

        public decimal? Price { get; set; }

        public string Project { get; set; }

        [JsonReadOnly]
        public decimal? Total { get; set; }

        public string Unit { get; set; }

        public decimal? VAT { get; set; }
    }
}
