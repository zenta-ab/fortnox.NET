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

        public async Task Connect(CancellationToken cancellationToken = default)
        {
            await _webSocket.ConnectAsync(_fortnoxWebSocketURI, cancellationToken);
        }

        public async Task Close(CancellationToken cancellationToken = default)
        {
            var validStates = new List<WebSocketState> 
            { 
                WebSocketState.Open, 
                WebSocketState.CloseReceived, 
                WebSocketState.CloseSent 
            };

            if (validStates.Contains(_webSocket.State))
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.Empty, null, cancellationToken);
            }

            _webSocket.Dispose();
        }

        private async Task Send(string message, CancellationToken cancellationToken = default)
        {
            var messageBuffer = new ArraySegment<byte>(Encoding.ASCII.GetBytes(message));
            await _webSocket.SendAsync(messageBuffer, WebSocketMessageType.Text, true, cancellationToken);
        }

        public async Task<WebSocketResponse> Recieve(CancellationToken cancellationToken = default)
        {
            var finished = false;
            var resultString = "";

            while (!finished)
            {
                if (_webSocket.State == WebSocketState.Open)
                {
                    var resultBuffer = new byte[this._bufferSize];
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(resultBuffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken);
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
            if (deserializedResult.TenantId != null)
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

        public async Task AddTenant(string accessToken, CancellationToken cancellationToken = default)
        {
            var addTenantsObject = new 
            { 
                command = WebSocketCommands.AddTenants, 
                clientSecret = _clientSecret, 
                accessTokens = new List<string>() { accessToken }
            };

            await Send(JsonConvert.SerializeObject(addTenantsObject), cancellationToken);
        }

        public async Task AddTenant(List<string> accessTokens, CancellationToken cancellationToken = default)
        {
            var addTenantsObject = new
            {
                command = WebSocketCommands.AddTenants,
                clientSecret = _clientSecret,
                accessTokens
            };

            await Send(JsonConvert.SerializeObject(addTenantsObject), cancellationToken);
        }

        public async Task AddTopic(WebSocketTopic topic, CancellationToken cancellationToken = default)
        {
            var type = topic.GetType();
            var fieldInfo = type.GetField(topic.ToString());

            var attribute =
                fieldInfo.GetCustomAttribute(typeof(WebSocketTopicStringValueAttribute), false) as WebSocketTopicStringValueAttribute;

            Topics.Add(attribute.Value);

            var addTopicObject = new 
            { 
                command = WebSocketCommands.AddTopics, 
                topics = new List<object>() { new { topic = attribute.Value } } 
            };

            await Send(JsonConvert.SerializeObject(addTopicObject), cancellationToken);
        }

        public async Task AddTopic(List<WebSocketTopic> topics, CancellationToken cancellationToken = default)
        {
            var addTopicObject = new { command = WebSocketCommands.AddTopics, topics = new List<object>() };
            foreach (var topic in topics)
            {
                var type = topic.GetType();
                var fieldInfo = type.GetField(topic.ToString());

                var attribute =
                    fieldInfo.GetCustomAttribute(typeof(WebSocketTopicStringValueAttribute), false) as WebSocketTopicStringValueAttribute;

                Topics.Add(attribute.Value);
                addTopicObject.topics.Add(new { topic = attribute.Value });
            }

            await Send(JsonConvert.SerializeObject(addTopicObject), cancellationToken);
        }

        public async Task Subscribe(CancellationToken cancellationToken = default)
        {
            var subscribeObject = new { command = WebSocketCommands.Subscribe };
            await Send(JsonConvert.SerializeObject(subscribeObject), cancellationToken);
        }
    }
}
