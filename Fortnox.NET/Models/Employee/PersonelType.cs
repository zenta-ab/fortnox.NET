using System.Runtime.Serialization;

namespace FortnoxNET.Models.Employee
{
    public enum PersonelType
    {
        /// <summary>
        /// Salaried employee
        /// </summary>
        [EnumMember(Value = "TJM")]
        TJM,

        /// <summary>
        /// Worker
        /// </summary>
        [EnumMember(Value = "ARB")]
        ARB,
    }
}