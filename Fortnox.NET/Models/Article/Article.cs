using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Article
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Article")]
    public class Article : ArticleSubset
    {
        public bool? Active { get; set; }
        public bool? Bulky { get; set; }
        public int? ConstructionAccount { get; set; }
        public int? Depth { get; set; }
        public int? EUAccount { get; set; }
        public int? EUVATAccount { get; set; }
        public int? ExportAccount { get; set; }
        public int? Height { get; set; }
        public string HouseworkType { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerArticleNumber { get; set; }
        public string Note { get; set; }
        public int? PurchaseAccount { get; set; }
        public int? SalesAccount { get; set; }
        public bool? StockGoods { get; set; }
        public decimal? StockWarning { get; set; }
        [JsonReadOnly]
        public string SupplierName { get; set; }
        public string SupplierNumber { get; set; }
        public ArticleType? Type { get; set; }
        public decimal? VAT { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public bool? Expired { get; set; }
        public CostCalculationMethod? CostCalculationMethod { get; set; }
        public int? StockAccount { get; set; }
        public decimal? DirectCost { get; set; }
        public decimal? FreightCost { get; set; }
        public decimal? OtherCost { get; set; }
    }
}