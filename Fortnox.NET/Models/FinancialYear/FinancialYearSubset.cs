using Fortnox.NET.Models.FinancialYear;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FortnoxNET.Models.FinancialYear
{
    [JsonPropertyClass("FinancialYears")]
    public class FinancialYearSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The ID of the financial year
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Start date of the financial year
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// End date of the financial year
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Type of the account chart
        /// </summary>
        public string accountCharts { get; set; }

        /// <summary>
        /// Accounting Method
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountingMethod AccountingMethod { get; set; }
    }
}
