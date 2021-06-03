using System;
using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Assets
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Asset")]
    public class Asset
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
        /// Asset number
        /// </summary>
        public string Number { get; set; }

        /// <summary>	
        /// Description of asset
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonReadOnly]
        public string Status { get; set; }

        /// <summary>
        /// Current status id of asset.
        /// </summary>
        [JsonReadOnly]
        public string StatusId { get; set; }

        /// <summary>
        /// Cost center Id used for asset
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Project Id used for asset
        /// </summary>
        public string Project { get; set; }

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
        /// Depreciation method
        /// </summary>
        public string DepreciationMethod { get; set; }

        /// <summary>
        /// Acquisition value
        /// </summary>
        public decimal? AcquisitionValue { get; set; }

        /// <summary>
        /// Depreciate to residual value
        /// </summary>
        public decimal? DepreciateToResidualValue { get; set; }

        /// <summary>
        /// Acquisition date
        /// </summary>
        public DateTime? AcquisitionDate { get; set; }

        /// <summary>
        /// Depreciations start date
        /// </summary>
        public DateTime? AcquisitionStart { get; set; }

        /// <summary>
        /// Final date when asset became fully depreciated
        /// </summary>
        public DateTime? DepreciationFinal { get; set; }

        /// <summary>
        /// Asset depreciated until that date or null if no deprecations made
        /// </summary>
        [JsonReadOnly]
        public string DepreciatedTo { get; set; }

        /// <summary>
        /// Manual Ob value
        /// </summary>
        [JsonReadOnly]
        public decimal? ManualOb { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string Reference { get; set; }
        
        /// <summary>
        /// Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Insure number
        /// </summary>
        public string InsuredNumber { get; set; }

        /// <summary>
        /// Insured with
        /// </summary>
        public string InsuredWith { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Room
        /// </summary>
        public string Room { get; set; }
        
        /// <summary>
        /// Placement
        /// </summary>
        public string Placement { get; set; }
        
        /// <summary>
        /// Department
        /// </summary>
        public string Department { get; set; }
        
        /// <summary>
        /// History
        /// </summary>
        public List<History> History { get; set; }
    }
}