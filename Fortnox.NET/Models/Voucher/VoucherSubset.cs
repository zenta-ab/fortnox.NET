using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Vouchers
{
    [JsonPropertyClass("Vouchers")]
    public class VoucherSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        /// <summary>
        /// Reference number, for example an invoice number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Reference type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ReferenceType? ReferenceType { get; set; }

        /// <summary>
        /// Number of the voucher
        /// </summary>
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Code of the voucher series.
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Id of the year of the voucher.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Approval state
        /// </summary>
        public int? ApprovalState { get; set; }
    }
}