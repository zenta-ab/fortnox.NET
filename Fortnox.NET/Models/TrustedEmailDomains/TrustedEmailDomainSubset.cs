using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.TrustedEmailDomains
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("TrustedDomains")]
    public class TrustedEmailDomainSubset
    {
        /// <summary>
        /// Id of the record
        /// </summary>
        [JsonReadOnly]
        public int? Id { get; set; }

        /// <summary>
        /// Domain address of trusted
        /// </summary>
        public string Domain { get; set; }
    }
}
