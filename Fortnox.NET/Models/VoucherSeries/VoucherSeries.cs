using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.VoucherSeries
{
    [JsonPropertyClass("VoucherSeries")]
    public class VoucherSeries
    {
        /// <summary>
        /// 
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
        /// Next number in the series
        /// </summary>
        [JsonReadOnly]
        public int? NextVoucherNumber { get; set; }

        /// <summary>
        /// Id of the financial year
        /// </summary>
        [JsonReadOnly]
        public int? Year { get; set; }

        /// <summary>
        /// Approver
        /// </summary>
        public Approver Approver { get; set; }
    }
}
