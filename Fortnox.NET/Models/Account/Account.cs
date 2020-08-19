using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.Account
{
    public class Account : AccountSubset
    {
        public bool Active { get; set; }
        public decimal BalanceBroughtForward { get; set; }
        public string Description { get; set; }
        public int SRU { get; set; }
    }
}