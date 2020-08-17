using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private List<string> _topics { get; set; }

        private int _bufferSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FortnoxWebSocketClient"/> class with the specified AccessToken, ClientSecret and optional BufferSize.
        /// </summary>
        /// <param name="accessToken">The Fortnox passkey.</param>
        /// <param name="clientSecret">The integrators key for making requests to Fortnox.</param>
        /// <param name="bufferSize">Optional target buffer size when recieving messages from the socket connection.</param>
        public FortnoxWebSocketClient(string accessToken, string clientSecret, int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            this._accessTokens = new List<string>();
            this._accessTokens.Add(accessToken);

            this._clientSecret = clientSecret;
            this._fortnoxWebSocketURI = new Uri(ApiEndpoints.WebSocketURI);

            this._webSocket = new ClientWebSocket();

            this._topics = new List<string>();

            this._bufferSize = bufferSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FortnoxWebSocketClient"/> class with the specified AccessTokens, ClientSecret and optional BufferSize.
        /// </summary>
        /// <param name="accessTokens">List of Fortnox passkeys.</param>
        /// <param name="clientSecret">The integrators key for making requests to Fortnox.</param>
        /// <param name="bufferSize">Optional target buffer size when recieving messages from the socket connection.</param>
        public FortnoxWebSocketClient(List<string> accessTokens, string clientSecret, int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            this._accessTokens = new List<string>(accessTokens);

            this._clientSecret = clientSecret;
            this._fortnoxWebSocketURI = new Uri(ApiEndpoints.WebSocketURI);

            this._webSocket = new ClientWebSocket();

            this._topics = new List<string>();

            this._bufferSize = bufferSize;
        }

        /// <summary>
        /// Sends the specified data on the underlying <see cref="System.Net.WebSockets.ClientWebSocket"/> and then recieves the next message as an asynchronous operation.
        /// Then deserializes the recieved data as the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The .NET type to deserialize the recieved message to.</typeparam>
        /// <param name="message">The data to send.</param>
        /// <returns>The deserialized message.</returns>
        private async Task<T> SendAndRecieveOnce<T>(string message)
        {
            var messageBuffer = new ArraySegment<byte>(Encoding.ASCII.GetBytes(message));
            await _webSocket.SendAsync(messageBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
            
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

            try
            {
                var deserializedResult = JsonConvert.DeserializeObject<T>(resultString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return deserializedResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Helper function that allows the caller to specify a callback function that accepts the underlying <see cref="System.Net.WebSockets.ClientWebSocket"/>.
        /// </summary>
        /// <param name="callback">An asynchronous callback function that accepts a <see cref="System.Net.WebSockets.ClientWebSocket"/> in its parameters.</param>
        /// <returns>An empty <see cref="Task"/></returns>
        public async Task Listen(Func<ClientWebSocket, Task> callback)
        {
            await callback.Invoke(this._webSocket);
        }

        /// <summary>
        /// Initiates the connection to the underlying <see cref="System.Net.WebSockets.ClientWebSocket"/> as well as subscribes to all the specified topics as an asynchronous operation.
        /// </summary>
        /// <returns>The current instance of <see cref="FortnoxWebSocketClient"/> as an asynchronous operation.</returns>
        public async Task<FortnoxWebSocketClient> Connect()
        {
            // TODO(Oskar): Should we keep anonymous objects or create something concrete?
            await _webSocket.ConnectAsync(_fortnoxWebSocketURI, CancellationToken.None);

            var AddTenantsObject = new { command = WebSocketCommands.AddTenants, clientSecret = _clientSecret, accessTokens = new List<string>(_accessTokens) };
            var AddTenantsResult = await SendAndRecieveOnce<WebSocketCommandResponse>(JsonConvert.SerializeObject(AddTenantsObject));

            if (AddTenantsResult.Result.Equals("error"))
            {
                throw new WebSocketException("Unable to add tenants.");
            }

            if (_topics.Count <= 0)
            {
                throw new WebSocketException("No topics specified.");
            }

            var AddTopicObject = new { command = WebSocketCommands.AddTopics, topics = new List<object>() };
            foreach(var topic in _topics)
            {
                AddTopicObject.topics.Add(new { topic = topic });
            }

            var AddTopicResult = await SendAndRecieveOnce<WebSocketCommandResponse>(JsonConvert.SerializeObject(AddTopicObject));
            if (AddTopicResult.Result.Equals("error"))
            {
                throw new WebSocketException($"Error adding topic: {string.Join(",", AddTopicResult.InvalidTopics)}");
            }

            var SubscribeObject = new { command = WebSocketCommands.Subscribe };
            var SubscribeResult = await SendAndRecieveOnce<WebSocketCommandResponse>(JsonConvert.SerializeObject(SubscribeObject));

            if (!SubscribeResult.Result.Equals("ok"))
            {
                throw new WebSocketException("Failed to subscribe.");
            }

            return this;
        }

        /// <summary>
        /// Adds the specified <see cref="WebSocketTopic"/> to the list of topics to subscribe to when calling <see cref="Connect"/>.
        /// </summary>
        /// <param name="topic">The target topic.</param>
        /// <returns>The current instance of <see cref="FortnoxWebSocketClient"/></returns>
        public FortnoxWebSocketClient AddTopic(WebSocketTopic topic)
        {
            Type type = topic.GetType();
            FieldInfo fi = type.GetField(topic.ToString());
            
            WebSocketTopicStringValueAttribute attr = 
                fi.GetCustomAttribute(typeof(WebSocketTopicStringValueAttribute), false) as WebSocketTopicStringValueAttribute;

            this._topics.Add(attr.Value);

            return this;
        }

        /// <summary>
        /// Combines both <see cref="Connect"/> and <see cref="Listen(Func{ClientWebSocket, Task})"/> into a single function.
        /// </summary>
        /// <param name="callback">An asynchronous callback function that accepts a <see cref="System.Net.WebSockets.ClientWebSocket"/> in its parameters.</param>
        /// <returns>An empty <see cref="Task"/></returns>
        public async Task ConnectAndListen(Func<ClientWebSocket, Task> callback)
        {
            await Connect();
            await callback.Invoke(this._webSocket);
        }

        /// <summary>
        /// A helper method that manages recieving buffered data from the underlying <see cref="System.Net.WebSockets.ClientWebSocket"/> and allows the caller
        /// handle the incoming data through the <see cref="IEnumerable{T}"/> interface.
        /// </summary>
        /// <param name="socket"></param>
        /// <returns>A <see cref="WebSocketEvent"/> when successfully read event; null otherwise.</returns>
        /// <example>
        /// <code>
        ///     var client = new FortnoxWebSocketClient("AccessToken", "ClientSecret")
        ///     .AddTopic(WebSocketTopic.Articles);
        ///     
        ///     var task = new Task(async () =>
        ///     {
        ///         try
        ///         {
        ///             (await client.Connect()).Listen(async (socket) =>
        ///             {
        ///                 foreach (var response in client.GetNextEvent(socket))
        ///                 {
        ///                     if (response != null)
        ///                     {
        ///                         // Process messages here.
        ///                         return;
        ///                     }
        ///                 }
        ///             }).GetAwaiter().GetResult();
        ///         }
        ///         catch (Exception e)
        ///         {
        ///             // Handle errors.
        ///             throw e;
        ///         }
        ///     }, TaskCreationOptions.LongRunning);
        ///     task.Start();
        /// </code>
        /// </example>
        public IEnumerable<WebSocketEvent> GetNextEvent(ClientWebSocket socket)
        {
            var finished = false;
            var resultString = "";
            while (!finished)
            {
                if (socket.State == WebSocketState.Open)
                {
                    var buffer = new byte[DEFAULT_BUFFER_SIZE];
                    var result = socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None).GetAwaiter().GetResult();
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).GetAwaiter().GetResult();
                        yield return null;
                    }
                    else
                    {
                        resultString += Encoding.ASCII.GetString(buffer);
                        finished = result.EndOfMessage;
                    }
                }
                else
                {
                    yield return null;
                }
            }

            var response = JsonConvert.DeserializeObject<WebSocketEvent>(resultString);
            yield return response;

        }
    }
}
