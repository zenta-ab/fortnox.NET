﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace FortnoxNET.WebSockets.Models
{
    public class WebSocketCommandResponse
    {
        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "tenantIds")]
        public dynamic TenantIDs { get; set; } // TODO(Oskar): Don't use dynamic.

        [JsonProperty(PropertyName = "invalidTokens")]
        public List<string> InvalidTokens { get; set; }

        [JsonProperty(PropertyName = "invalidTopics")]
        public List<string> InvalidTopics { get; set; }
    }
}
