using System.ComponentModel;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Article
{
    [JsonPropertyClass("Articles")]
    public class ArticleSubset
    {  
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        
        [JsonReadOnly]
        public decimal DisposableQuantity { get; set; }
        public string EAN { get; set; }
        public bool? Housework { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? QuantityInStock { get; set; }
        [JsonReadOnly]
        public decimal? ReservedQuantity { get; set; }
        [JsonReadOnly]
        public decimal? SalesPrice { get; set; }
        public string StockPlace { get; set; }
        [JsonReadOnly]
        public decimal? StockValue { get; set; }    
        public string Unit { get; set; }
        public bool? WebshopArticle { get; set; }
    }
}