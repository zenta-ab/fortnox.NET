using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.AttendanceTransaction
{
    [JsonPropertyClass("AttendanceTransactions")]
    public class AttendanceTransactionSubset
    {
		/// <summary>
		/// Direct URL to the record
		/// </summary>
		[JsonReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }

		/// <summary>
		/// Unique employee-id
		/// </summary>
		public string EmployeeId { get; set; }

		/// <summary>
		/// Cause code
		/// </summary>
		public string CauseCode { get; set; }

		/// <summary>
		/// Date
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Amount of hours
		/// </summary>
		public decimal Hours { get; set; }

		/// <summary>
		/// Cost Center
		/// </summary>
		public string CostCenter { get; set; }

		/// <summary>
		/// Project
		/// </summary>
		public string Project { get; set; }
	}
}
