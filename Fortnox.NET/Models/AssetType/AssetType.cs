
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.AssetType
{
    [JsonPropertyClass("Type")]
    public class Type : AssetType { }

    [JsonPropertyClass("AssetType")]
    public class AssetType
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Id of asset type
        /// </summary>
        [JsonReadOnly]
        public int? Id { get; set; }

        /// <summary>
        /// Number of an asset type
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Description of the asset type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Deprication type of asset type
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// If used by any asset
        /// </summary>
        [JsonReadOnly]
        public bool? InUse { get; set; }

        /// <summary>
        /// Id of asset account
        /// </summary>
        public int? AccountAssetId { get; set; }

        /// <summary>
        /// Id of a value loss account
        /// </summary>
        public int? AccountValueLossId { get; set; }

        /// <summary>
        /// Id of a sale loss account
        /// </summary>
        public int? AccountSaleLossId { get; set; }

        /// <summary>
        /// Id of a sale win account
        /// </summary>
        public int? AccountSaleWinId { get; set; }

        /// <summary>
        /// Id of a revaluation account
        /// </summary>
        public int? AccountRevaluationId { get; set; }

        /// <summary>
        /// Id of an accumulated write-down account
        /// </summary>
        public int? AccountWriteDownAckId { get; set; }

        /// <summary>
        /// Id of a write-down account
        /// </summary>
        public int? AccountWriteDownId { get; set; }

        /// <summary>
        /// Id of a depreciation account
        /// </summary>
        public int? AccountDepreciationId { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountAsset { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountValueLoss { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountSaleLoss { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountSaleWin { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountRevaluation { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountWriteDownAck { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountWriteDown { get; set; }

        /// <summary>
        /// Id and description of used account
        /// </summary>
        [JsonReadOnly]
        public string AccountDepreciation { get; set; }
    }
}
