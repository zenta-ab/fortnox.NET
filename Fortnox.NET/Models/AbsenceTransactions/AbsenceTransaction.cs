using Fortnox.NET.Models.AbsenceTransactions;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FortnoxNET.Models.AbsenceTransactions
{
	[JsonPropertyClass("AbsenceTransaction")]
	public class AbsenceTransaction
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
		[JsonConverter(typeof(StringEnumConverter))]
		public CauseCode CauseCode { get; set; }

		/// <summary>
		/// Date
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// Extent in percent
		/// </summary>
		public decimal? Extent { get; set; }

		/// <summary>
		/// Amount of hours
		/// </summary>
		public decimal? Hours { get; set; }

		/// <summary>
		/// Determiens whether or not the registrations is holiday entitling
		/// </summary>
		public bool? HolidayEntitling { get; set; }

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
