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
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        [JsonReadOnly]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        [JsonReadOnly]
        public string Status { get; set; }
        [JsonReadOnly]
        public string StatusId { get; set; }
        public string CostCenter { get; set; }
        public string Project { get; set; }
        [JsonReadOnly]
        public string Type { get; set; }
        public string TypeId { get; set; }
        public string DepreciationMethod { get; set; }
        public double? AcquisitionValue { get; set; }
        public double? DepreciateToResidualValue { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public DateTime? AcquisitionStart { get; set; }
        public DateTime? DepreciationFinal { get; set; }
        [JsonReadOnly]
        public string DepreciatedTo { get; set; }
        [JsonReadOnly]
        public double? ManualOb { get; set; }
        public string Notes { get; set; }
        public string Reference { get; set; }
        public string Brand { get; set; }
        public string InsuredNumber { get; set; }
        public string InsuredWith { get; set; }
        public string Group { get; set; }
        public string Room { get; set; }
        public string Placement { get; set; }
        public string Department { get; set; }
        public List<History> History { get; set; }
    }
}