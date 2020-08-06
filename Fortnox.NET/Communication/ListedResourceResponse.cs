using System.Collections.Generic;
using FortnoxNET.Models;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Communication
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class ListedResourceResponse<T> where T : class
    {
        public MetaInformation MetaInformation { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}