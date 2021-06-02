using System.Runtime.Serialization;

namespace FortnoxNET.Models.Project
{
    public enum ProjectStatus
    {
        /// <summary>
        /// NOTSTARTED
        /// </summary>
        [EnumMember(Value = "NOTSTARTED")]
        NOTSTARTED,

        /// <summary>
        /// ONGOING
        /// </summary>
        [EnumMember(Value = "ONGOING")]
        ONGOING,

        /// <summary>
        /// COMPLETED
        /// </summary>
        [EnumMember(Value = "COMPLETED")]
        COMPLETED
    }
}