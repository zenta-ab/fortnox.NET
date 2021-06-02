using System.Runtime.Serialization;

namespace FortnoxNET.Models.Supplier
{
    public enum VATType
    {
        /// <summary>
        /// 25
        /// </summary>
        [EnumMember(Value = "25")]
        VAT25,
        
        /// <summary>
        /// 12
        /// </summary>
        [EnumMember(Value = "12")]
        VAT12,
        
        /// <summary>
        /// 6
        /// </summary>
        [EnumMember(Value = "6")]
        VAT6,
        
        /// <summary>
        /// 0
        /// </summary>
        [EnumMember(Value = "0")]
        VAT0,
        
        /// <summary>
        /// Reverse
        /// </summary>
        [EnumMember(Value = "REVERSE")]
        Reverse,
        
        /// <summary>
        /// Normal
        /// </summary>
        [EnumMember(Value = "NORMAL")]
        Normal,
        
        /// <summary> 
        /// Unionsinternt förvärv 
        /// </summary>
        [EnumMember(Value = "UIF")]
        UIF
    }
}
