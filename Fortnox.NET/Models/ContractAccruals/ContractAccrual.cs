using System.Collections.Generic;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractAccruals
{
    [JsonPropertyClass("ContractAccrual")]
    public class ContractAccrual : ContractAccrualSubset
    {
        public int AccrualAccount { get; set; }
        
        public int CostAccount { get; set; }
        
        public List<AccrualRow> AccrualRows { get; set; }
        
        [JsonReadOnly]
        public int? Times { get; set; }
        
        public decimal Total { get; set; }
        
        [JsonProperty(PropertyName = "VATIncluded")]
        public bool VatIncluded { get; set; }
    }

    public class AccrualRow
    {
        public int Account { get; set; }
        
        public string ConstCenter { get; set; }
        
        public decimal Credit { get; set; }
        
        public decimal Debit { get; set; }
        
        public string Project { get; set; }
        
        public string TransactionInformation { get; set; }
    }
}