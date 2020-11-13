using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Order
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class OrderRow
    {
        public int AccountNumber { get; set; }

        public string ArticleNumber { get; set; }

        [JsonReadOnly]
        public float ContributionPercent { get; set; }

        [JsonReadOnly]
        public float ContributionValue { get; set; }

        public string CostCenter { get; set; }

        public float DeliveredQuantity { get; set; }

        public string Description { get; set; }

        public float Discount { get; set; }

        public string DiscountType { get; set; }

        public bool HouseWork { get; set; }

        public int HouseWorkHoursToReport { get; set; }

        public string HouseWorkType { get; set; }

        public float OrderedQuantity { get; set; }

        public float Price { get; set; }

        public string Project { get; set; }

        [JsonReadOnly]
        public float Total { get; set; }

        public string Unit { get; set; }

        public float VAT { get; set; }
    }
}
