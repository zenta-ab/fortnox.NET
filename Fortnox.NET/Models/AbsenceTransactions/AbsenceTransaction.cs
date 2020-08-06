using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.AbsenceTransactions
{

	[JsonPropertyClass("AbsenceTransactions")]
	public class AbsenceTransaction
	{
		[JsonReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }

		public string EmployeeId { get; set; }

		public string CauseCode { get; set; }

		public DateTime Date { get; set; }

		public float Extent { get; set; }

		public float Hours { get; set; }

		public bool HolidayEntitling { get; set; }

		public string CostCenter { get; set; }

		public string Project { get; set; }
	}
}
