
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.AssetType
{
    [JsonPropertyClass("Types")]
    public class AssetTypeSubset
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
        public bool? InUse { get; set; }
    }
}
