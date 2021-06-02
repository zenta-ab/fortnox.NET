using Fortnox.NET.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Offer
{
    public class OfferRow
    {
        /// <summary>
        /// Account number
        /// </summary>
        public long? AccountNumber { get; set; }

        /// <summary>
        /// Article number
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Contribution Percent
        /// </summary>
        public decimal? ContributionPercent { internal get; set; }

        /// <summary>
        /// Contribution Value
        /// </summary>
        public decimal? ContributionValue { internal get; set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

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
        [JsonConverter(typeof(StringEnumConverter))]
        public DiscountType? DiscountType { get; set; }

        /// <summary>
        /// If the row is housework
        /// </summary>
        public bool? HouseWork { get; set; }

        /// <summary>
        /// Hours to be reported if the quantity of the row should not be used as hours.
        /// </summary>
        public long? HouseWorkHoursToReport { get; set; }

        /// <summary>
        /// The type of house work
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HouseworkType? HouseWorkType { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Delivered quantity
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Total row amount
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// Code of unit	
        /// </summary>
        public string Unit { internal get; set; }

        /// <summary>
        /// Vat percent code
        /// </summary>
        public decimal? VAT { get; set; }
    }
}
