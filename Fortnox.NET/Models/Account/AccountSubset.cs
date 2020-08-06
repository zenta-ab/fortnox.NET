using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Account
{
    [JsonPropertyClass("Accounts")]
    public class AccountSubset
    {
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        public int BalanceCarriedForward { get; set; }
        public string CostCenter { get; set; }
        public string CostCenterSettings { get; set; }
        public string Project { get; set; }
        public string ProjectSettings { get; set; }
        public string TransactionInformation { get; set; }
        public string TransactionInformationSettings { get; set; }
        public string VATCode { get; set; }
        public int Year { get; set; }
    }
}
