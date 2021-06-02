using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.Offer
{
    [JsonPropertyClass("Offers")]
    public class OfferSubset
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// If the offer is cancelled
        /// </summary>
        public bool? Cancelled { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer number
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Document Number
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Date of order
        /// </summary>
        public DateTime? OfferDate { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// If document is printed or e-mailed to customer
        /// </summary>
        public bool? Sent { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        public decimal? Total { get; set; }
    }
}
