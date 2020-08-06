using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Employee
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Employees")]
    public class Employees
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string EmployeeId { get; set; }
        public string PersonalIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonReadOnly]
        public string FullName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string EmploymentForm { get; set; }
        public string SalaryForm { get; set; }
        public string JobTitle { get; set; }
        public string PersonelType { get; set; }
        public string ScheduleId { get; set; }
        public string ForaType { get; set; }
        public float? MonthlySalary { get; set; }
        public float? HourlyPay { get; set; }
        public string TaxAllowance { get; set; }
        public float? TaxTable { get; set; }
        public int? TaxColumn { get; set; }
        public bool? AutoNonRecurringTax { get; set; }
        public float? NonRecurringTax { get; set; }
        public bool? Inactive { get; set; }
        public string ClearingNo { get; set; }
        public string BankAccountNo { get; set; }
        public float? AverageWeeklyHours { get; set; }
        public float? AverageHourlyWage { get; set; }
        public DateTime? EmployedTo { get; set; }

    }
}