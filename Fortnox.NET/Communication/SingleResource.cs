using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Communication
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class SingleResource<T> where T : class
    {
        public T Data { get; set; }
    }
}