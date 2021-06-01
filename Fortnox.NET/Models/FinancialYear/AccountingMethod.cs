using System.Runtime.Serialization;

namespace Fortnox.NET.Models.FinancialYear
{
    public enum AccountingMethod
    {
        /// <summary>
        /// Accrual
        /// </summary>
        [EnumMember(Value = "ACCRUAL")]
        ACCRUAL,

        /// <summary>
        /// Cash
        /// </summary>
        [EnumMember(Value = "CASH")]
        CASH,
    }
}
