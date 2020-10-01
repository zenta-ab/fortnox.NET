using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fortnox.NET.WebSockets.Models;
using FortnoxNET.Constants;
using FortnoxNET.WebSockets.Models;
using Newtonsoft.Json;

namespace FortnoxNET.WebSockets
{
    public class FortnoxWebSocketClient
    {
        private const int DEFAULT_BUFFER_SIZE = 2048;

        private ClientWebSocket _webSocket;

        private Uri _fortnoxWebSocketURI;
        
        private List<string> _accessTokens { get; set; }

        private string _clientSecret { get; set; }

        private int _bufferSize { get; set; }

        public List<string> Topics { get; private set; }

        public Dictionary<string, long> AccessTokenTenantId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FortnoxWebSocketClient"/> class with the specified AccessToken, ClientSecret and optional BufferSize.
        /// </summary>
        /// <param name="accessToken">The Fortnox passkey.</param>
        /// <param name="clientSecret">The integrators key for making requests to Fortnox.</param>
        /// <param name="bufferSize">Optional target buffer size when recieving messages from the socket connection.</param>
        public FortnoxWebSocketClient(string clientSecret, int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            this._accessTokens = new List<string>();
            
            this._clientSecret = clientSecret;
            this._fortnoxWebSocketURI = new Uri(ApiEndpoints.WebSocketURI);

            this._webSocket = new ClientWebSocket();

            this.Topics = new List<string>();

            this._bufferSize = bufferSize;

            this.AccessTokenTenantId = new Dictionary<string, long>();
        }

        public async Task Connect()
        {
            await _webSocket.ConnectAsync(_fortnoxWebSocketURI, CancellationToken.None);
        }

        private async Task Send(string message)
        {
            var messageBuffer = new ArraySegment<byte>(Encoding.ASCII.GetBytes(message));
            await _webSocket.SendAsync(messageBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task<WebSocketResponse> Recieve()
        {
            var finished = false;
            var resultString = "";

            while (!finished)
            {
                if (_webSocket.State == WebSocketState.Open)
                {
                    var resultBuffer = new byte[this._bufferSize];
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(resultBuffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        throw new WebSocketException($"Websocket connection closed unexpectedly. Reason: {result.CloseStatus}");
                    }
                    else
                    {
                        resultString += Encoding.ASCII.GetString(resultBuffer);
                        finished = result.EndOfMessage;
                    }
                }
                else
                {
                    throw new WebSocketException("Unable to recieve as Websocket is closed.");
                }
            }

            var deserializedResult = JsonConvert.DeserializeObject<WebSocketResponse>(resultString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            if (deserializedResult.TenantId.HasValue)
            {
                deserializedResult.Type = WebSocketResponseType.EventResponse;
            }

            if (deserializedResult.Type == WebSocketResponseType.CommandResponse)
            {
                if (deserializedResult.Result.Equals("ok") && deserializedResult.Response.Equals(WebSocketCommands.AddTenants))
                {
                    foreach (var item in deserializedResult.TenantIDs)
                    {
                        AccessTokenTenantId.Add(item.Key, item.Value);
                    }
                }
            }

            return deserializedResult;
        }

        public async Task AddTenant(string accessToken)
        {
            var AddTenantsObject = new 
            { 
                command = WebSocketCommands.AddTenants, 
                clientSecret = _clientSecret, 
                accessTokens = new List<string>() 
            };
            AddTenantsObject.accessTokens.Add(accessToken);

            await Send(JsonConvert.SerializeObject(AddTenantsObject));
        }

        public async Task AddTenant(List<string> accessTokens)
        {
            var AddTenantsObject = new
            {
                command = WebSocketCommands.AddTenants,
                clientSecret = _clientSecret,
                accessTokens = new List<string>(accessTokens)
            };

            await Send(JsonConvert.SerializeObject(AddTenantsObject));
        }

        public async Task AddTopic(WebSocketTopic topic)
        {
            var type = topic.GetType();
            var fieldInfo = type.GetField(topic.ToString());

            var attribute =
                fieldInfo.GetCustomAttribute(typeof(WebSocketTopicStringValueAttribute), false) as WebSocketTopicStringValueAttribute;

            Topics.Add(attribute.Value);

            var AddTopicObject = new { command = WebSocketCommands.AddTopics, topics = new List<object>() };
            AddTopicObject.topics.Add(new { topic = attribute.Value });

            await Send(JsonConvert.SerializeObject(AddTopicObject));
        }

        public async Task AddTopic(List<WebSocketTopic> topics)
        {
            var AddTopicObject = new { command = WebSocketCommands.AddTopics, topics = new List<object>() };
            foreach (var topic in topics)
            {
                var type = topic.GetType();
                var fieldInfo = type.GetField(topic.ToString());

                var attribute =
                    fieldInfo.GetCustomAttribute(typeof(WebSocketTopicStringValueAttribute), false) as WebSocketTopicStringValueAttribute;

                Topics.Add(attribute.Value);
                AddTopicObject.topics.Add(new { topic = attribute.Value });
            }

            await Send(JsonConvert.SerializeObject(AddTopicObject));
        }

        public async Task Subscribe()
        {
            var SubscribeObject = new { command = WebSocketCommands.Subscribe };
            await Send(JsonConvert.SerializeObject(SubscribeObject));
        }
    }
}
