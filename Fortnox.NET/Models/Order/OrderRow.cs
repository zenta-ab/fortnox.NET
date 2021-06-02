using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Order
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class OrderRow
    {
        /// <summary>
        /// Account number
        /// </summary>
        public int? AccountNumber { get; set; }

        /// <summary>
        /// Article number
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Contribution Percent
        /// </summary>
        [JsonReadOnly]
        public decimal? ContributionPercent { get; set; }

        /// <summary>
        /// Contribution Value
        /// </summary>
        [JsonReadOnly]
        public decimal? ContributionValue { get; set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Delivered quantity
        /// </summary>
        public decimal? DeliveredQuantity { get; set; }

        /// <summary>
        /// Reserved quantity
        /// </summary>
        public decimal? ReservedQuantity { get; set; }

        /// <summary>
        /// Description  
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Discount amount
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Type of discount
        /// </summary>
        public string DiscountType { get; set; }

        /// <summary>
        /// If the row is housework
        /// </summary>
        public bool? HouseWork { get; set; }

        /// <summary>
        /// Hours to be reported
        /// </summary>
        public int? HouseWorkHoursToReport { get; set; }

        /// <summary>
        /// The type of house work
        /// </summary>
        public string HouseWorkType { get; set; }

        /// <summary>
        /// Ordered quantity
        /// </summary>
        public decimal? OrderedQuantity { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Total row amount
        /// </summary>
        [JsonReadOnly]
        public decimal? Total { get; set; }

        /// <summary>
        /// Code of unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// VAT percent code
        /// </summary>
        public decimal? VAT { get; set; }

        /// <summary>
        /// Stock point id
        /// </summary>
        public string StockPointId { get; set; }

        /// <summary>
        /// Stock point code
        /// </summary>
        public string StockPointCode { get; set; }
    }
}
