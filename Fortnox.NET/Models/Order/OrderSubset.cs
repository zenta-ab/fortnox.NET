
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FortnoxNET.Models.Order
{
    [JsonPropertyClass("Orders")]
    public class OrderSubset
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// If Order is cancelled
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
        /// Delivery date
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Document number
        /// </summary>
        public int? DocumentNumber { get; set; }

        /// <summary>
        /// External invoice reference 1
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference 2
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Date of order
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Type of the Order
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderType? OrderType { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// If document is printed or e-mailed
        /// </summary>
        public bool? Sent { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        public int? Total { get; set; }
    }
}
