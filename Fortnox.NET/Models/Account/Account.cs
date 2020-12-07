using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.Account
{
    public class Account : AccountSubset
    {
        /// <summary>
        /// If the account is actve
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Opening balance of the account
        /// </summary>
        public decimal? BalanceBroughtForward { get; set; }

        /// <summary>
        /// Account description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// SRU code
        /// </summary>
        public int? SRU { get; set; }
    }
}