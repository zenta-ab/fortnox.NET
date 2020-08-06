using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.FinancialYear
{
    [JsonPropertyClass("FinancialYears")]
    public class FinancialYear
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string AccountChartType { get; set; }

        public string AccountingMethod { get; set; }
    }
}
