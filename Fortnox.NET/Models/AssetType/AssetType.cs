
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.AssetType
{
    [JsonPropertyClass("Type")]
    public class Type : AssetType { }

    [JsonPropertyClass("AssetType")]
    public class AssetType
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        public int? Id { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public int Type { get; set; }

        [JsonReadOnly]
        public bool? InUse { get; set; }

        public int AccountAssetId { get; set; }

        public int AccountValueLossId { get; set; }

        public int AccountSaleLossId { get; set; }

        public int AccountSaleWinId { get; set; }

        public int AccountRevaluationId { get; set; }

        public int AccountWriteDownAckId { get; set; }

        public int AccountWriteDownId { get; set; }

        public int AccountDepreciationId { get; set; }

        [JsonReadOnly]
        public string AccountAsset { get; set; }

        [JsonReadOnly]
        public string AccountValueLoss { get; set; }

        [JsonReadOnly]
        public string AccountSaleLoss { get; set; }

        [JsonReadOnly]
        public string AccountSaleWin { get; set; }

        [JsonReadOnly]
        public string AccountRevaluation { get; set; }

        [JsonReadOnly]
        public string AccountWriteDownAck { get; set; }

        [JsonReadOnly]
        public string AccountWriteDown { get; set; }
        
        [JsonReadOnly]
        public string AccountDepreciation { get; set; }
    }
}
