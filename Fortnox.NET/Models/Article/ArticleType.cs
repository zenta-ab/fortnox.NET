using System.Runtime.Serialization;

namespace FortnoxNET.Models.Article
{
    public enum ArticleType
    {
        /// <summary>
        /// Stock article
        /// </summary>
        [EnumMember(Value = "STOCK")]
        STOCK,

        /// <summary>
        /// Service article
        /// </summary>
        [EnumMember(Value = "SERVICE")]
        SERVICE
    }
}