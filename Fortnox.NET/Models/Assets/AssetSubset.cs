using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.Assets
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Assets")]
    public class AssetSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Id of the asset
        /// </summary>
        [JsonReadOnly]
        public int Id { get; set; }

        /// <summary>	
        /// Description of asset
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Current status of asset
        /// </summary>
        [JsonReadOnly]
        public string Status { get; set; }

        /// <summary>
        /// Current status id of asset.
        /// </summary>
        [JsonReadOnly]
        public string StatusId { get; set; }

        /// <summary>
        /// Type of asset
        /// </summary>
        [JsonReadOnly]
        public string Type { get; set; }

        /// <summary>
        /// Id of asset type used for asset
        /// </summary>
        public string TypeId { get; set; }

        /// <summary>
        /// Acquisition value
        /// </summary>
        public decimal? AcquisitionValue { get; set; }

        /// <summary>
        /// Acquisition date
        /// </summary>
        public DateTime? AcquisitionDate { get; set; }

        /// <summary>
        /// Final date when asset became fully depreciated
        /// </summary>
        [JsonReadOnly]
        public DateTime? DepreciationFinal { get; set; }

        /// <summary>
        /// Asset depreciated until that date or null if no deprecations made
        /// </summary>
        [JsonReadOnly]
        public DateTime? DepreciatedTo { get; set; }
    }
}
