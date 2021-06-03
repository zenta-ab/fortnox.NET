
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.VoucherSeries
{
    [JsonPropertyClass("VoucherSeriesCollection")]
    public class VoucherSeriesSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        /// <summary>
        /// The code of the voucher series
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of the voucher series
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If manual
        /// </summary>
        public bool? Manual { get; set; }

        /// <summary>
        /// Id of the financial year
        /// </summary>
        public int? Year { get; set; }
        
        /// <summary>
        /// Approver
        /// </summary>
        public Approver Approver { get; set; }
    }
}
