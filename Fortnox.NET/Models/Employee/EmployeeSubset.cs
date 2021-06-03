using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Employee
{
    [JsonPropertyClass("Employees")]
    public class Employees
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool ShouldSerializeUrl() => false;

        /// <summary>
        /// Unique employee-id. Can never be changed once an employee has been created.
        /// </summary>
        public string EmployeeId { get; set; }
        
        /// <summary>
        /// Personal identity number.
        /// </summary>
        public string PersonalIdentityNumber { get; set; }
        
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }
        
        public bool ShouldSerializeFullName() => false;

        /// <summary>
        /// Address
        /// </summary>
        public string Address1 { get; set; }
        
        /// <summary>
        /// Address
        /// </summary>
        public string Address2 { get; set; }
        
        /// <summary>
        /// Post code
        /// </summary>
        public string PostCode { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone1 { get; set; }
        
        /// <summary>
        /// Phone number 2
        /// </summary>
        public string Phone2 { get; set; }
        
        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Startdate of employment
        /// </summary>
        public DateTime? EmploymentDate { get; set; }
        
        /// <summary>
        /// Type of employment.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EmploymentForm? EmploymentForm { get; set; }
        
        /// <summary>
        /// Type of salary form.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SalaryForm? SalaryForm { get; set; }
        
        /// <summary>
        /// Job title
        /// </summary>
        public string JobTitle { get; set; }
        
        /// <summary>
        /// Personel type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonelType? PersonelType { get; set; }
        
        /// <summary>
        /// True if employee is inactive
        /// </summary>
        public bool? Inactive { get; set; }

        /// <summary>
        /// Schedule ID for scheduletimes
        /// </summary>
        public string ScheduleId { get; set; }
        
        /// <summary>
        /// Assigned fora type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ForaType? ForaType { get; set; }
        
        /// <summary>
        /// Monthly salary
        /// </summary>
        public decimal? MonthlySalary { get; set; }
        
        /// <summary>
        /// Hourly pay
        /// </summary>
        public decimal? HourlyPay { get; set; }
        
        /// <summary>
        /// Tax allowance.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxAllowance? TaxAllowance { get; set; }
        
        /// <summary>
        /// Tax table
        /// </summary>
        public decimal? TaxTable { get; set; }
        
        /// <summary>
        /// Tax column
        /// </summary>
        public int? TaxColumn { get; set; }
        
        /// <summary>
        /// Auto non recurring tax
        /// </summary>
        public bool? AutoNonRecurringTax { get; set; }
        
        /// <summary>
        /// Non-recurring tax %
        /// </summary>
        public decimal? NonRecurringTax { get; set; }
        
        /// <summary>
        /// Clearing number
        /// </summary>
        public string ClearingNo { get; set; }
        
         /// <summary>
        /// Bankaccount number
        /// </summary>
        public string BankAccountNo { get; set; }
        
        /// <summary>
        /// Average weekly hours
        /// </summary>
        public decimal? AverageWeeklyHours { get; set; }
        
        /// <summary>
        /// Average hourly wage
        /// </summary>
        public decimal? AverageHourlyWage { get; set; }
        
        /// <summary>
        /// Enddate of employment
        /// </summary>
        public DateTime? EmployedTo { get; set; }
    }
}