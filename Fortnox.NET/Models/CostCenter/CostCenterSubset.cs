using FortnoxNET.Utils;
using Newtonsoft.Json;
namespace FortnoxNET.Models.CostCenter
{
    [JsonPropertyClass("CostCenters")]
    public class CostCenterSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The code of the cost center
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The description of the cost center
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The note of the cost center
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// If the cost center is active or not
        /// </summary>
        public bool? Active { get; set; }
    }
}
