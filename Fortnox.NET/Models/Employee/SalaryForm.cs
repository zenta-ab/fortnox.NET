using System.Runtime.Serialization;

namespace FortnoxNET.Models.Employee
{
    public enum SalaryForm
    {
        /// <summary>
        /// Monthly salary
        /// </summary>
        [EnumMember(Value = "MAN")]
        MAN,

        /// <summary>
        /// Hourly pay
        /// </summary>
        [EnumMember(Value = "TIM")]
        TIM,
    }
}