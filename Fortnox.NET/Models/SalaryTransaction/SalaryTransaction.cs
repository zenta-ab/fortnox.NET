using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.SalaryTransaction
{
    [JsonPropertyClass("SalaryTransaction")]
    public class SalaryTransaction
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public bool ShouldSerializeUrl() => false;

        /// <summary>
        /// Unique employee-id
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Salary code
        /// </summary>
        public string SalaryCode { get; set; }

        /// <summary>
        /// Unique row ID
        /// </summary>
        public int? SalaryRow { get; set; }
        public bool ShouldSerializeSalaryRow() => false;

        /// <summary>
        /// Date 
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Number of # 
        /// </summary>
        public decimal? Number { get; set; }

        /// <summary>
        /// Cost per # in SEK
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Sum in SEK
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// Expense code from the expense registry
        /// </summary>
        public string Expense { get; set; }

        /// <summary>
        /// Sum VAT
        /// </summary>
        public string VAT { get; set; }

        /// <summary>
        /// Optional additional text relating to the salary transaction
        /// </summary>
        public string TextRow { get; set; }

        /// <summary>
        /// Cost Center
        /// </summary>
        public string ConstCenter { get; set; }

        /// <summary>
        /// Project 
        /// </summary>
        public string Project { get; set; }
    }
}
