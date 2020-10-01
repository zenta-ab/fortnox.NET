using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Fortnox.NET.WebSockets.Models
{
    public enum WebSocketResponseType
    {
        CommandResponse = 0,
        EventResponse = 1,
    }

    public class WebSocketResponse
    {
        [JsonIgnore]
        public WebSocketResponseType Type;
        
        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "tenantIds")]
        public Dictionary<string, long> TenantIDs { get; set; }

        [JsonProperty(PropertyName = "invalidTokens")]
        public List<string> InvalidTokens { get; set; }

        [JsonProperty(PropertyName = "invalidTopics")]
        public List<string> InvalidTopics { get; set; }

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
        public string EventType { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
