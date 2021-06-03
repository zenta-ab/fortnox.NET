using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.LockedPeriod
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("LockedPeriod")]
    public class LockedPeriod
    {
        /// <summary>
        /// End date of the locked period
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}