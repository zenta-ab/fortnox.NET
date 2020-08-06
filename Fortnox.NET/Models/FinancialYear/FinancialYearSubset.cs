using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.FinancialYear
{
    [JsonPropertyClass("FinancialYears")]
    public class FinancialYearSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string accountCharts { get; set; }

        public string AccountingMethod { get; set; }
    }
}
