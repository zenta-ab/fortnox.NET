using System.Runtime.Serialization;

namespace FortnoxNET.Models.SupplierInvoice
{
    public enum VATType
    {
        /// <summary>
        /// Normal
        /// </summary>
        [EnumMember(Value = "NORMAL")]
        Normal,
        
        /// <summary>
        /// Eu internal
        /// </summary>
        [EnumMember(Value = "EUINTERNAL")]
        EUInternal,
        
        /// <summary>
        /// Reverse
        /// </summary>
        [EnumMember(Value = "REVERSE")]
        Reverse,
    }
}
