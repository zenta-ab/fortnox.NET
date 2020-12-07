using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Account
{
    [JsonPropertyClass("Accounts")]
    public class AccountSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        /// <summary>
        /// Closing balance of the account
        /// </summary>
        [JsonReadOnly]
        public decimal? BalanceCarriedForward { get; set; }

        /// <summary>
        /// Code of the proposed cost center. The code must be of an existing cost center.
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Cost center settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED
        /// </summary>
        public string CostCenterSettings { get; set; }

        /// <summary>
        /// Number of the proposed project. The number must be of an existing project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Project settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED
        /// </summary>
        public string ProjectSettings { get; set; }

        /// <summary>
        /// Proposed transaction information
        /// </summary>
        public string TransactionInformation { get; set; }

        /// <summary>
        /// Transaction information settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED
        /// </summary>
        public string TransactionInformationSettings { get; set; }

        /// <summary>
        /// VAT code
        /// </summary>
        public string VATCode { get; set; }

        /// <summary>
        /// Id of the financial year.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public int? Number { get; set; }
    }
}
