using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.AttendanceTransaction
{
    [JsonPropertyClass("AttendanceTransactions")]
    public class AttendanceTransactionSubset
    {
		[JsonReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
		public string EmployeeId { get; set; }
		public string CauseCode { get; set; }
		public DateTime Date { get; set; }
		public float Hours { get; set; }
		public string CostCenter { get; set; }
		public string Project { get; set; }
	}
}
