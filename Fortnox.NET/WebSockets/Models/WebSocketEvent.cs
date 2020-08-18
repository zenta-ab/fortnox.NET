using Newtonsoft.Json;
using System;

namespace FortnoxNET.WebSockets.Models
{
    public class WebSocketEvent
    {
        [JsonProperty(PropertyName = "offset")]
        public string Offset { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public long? TenantId { get; set; }

        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        [JsonProperty(PropertyName = "entityId")]
        public string EntityId { get; set; }

        // TODO(Oskar): Make this some sort of enum type users can do something with.
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
