using FortnoxNET.Communication;
using FortnoxNET.Communication.Order;
using FortnoxNET.Models.Article;
using FortnoxNET.Models.Order;
using FortnoxNET.Services;
using FortnoxNET.WebSockets;
using FortnoxNET.WebSockets.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FortnoxNET.Tests.WebSocket
{
    [TestClass]
    public class FortnoxWebSocketClientTest : TestBase
    {
        private const int DEFAULT_BUFFER_SIZE = 2048;

        [TestMethod]
        public async Task CanListenUsingEnumerable()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                .AddTopic(WebSocketTopic.Articles);

            var listeningTask = new Task(async () =>
            {
                try
                {
                    (await client.Connect()).Listen(async (socket) =>
                    {
                        foreach (var response in client.GetNextEvent(socket))
                        {
                            if (response != null)
                            {
                                Assert.IsTrue(response.Topic == "articles");
                                Assert.IsTrue(response.Type == "article-updated-v1");
                                Assert.IsTrue(response.EntityId == "100370");

                                return;
                            }
                        }
                    }).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);
                }
            }, TaskCreationOptions.LongRunning);
            listeningTask.Start();

            var updatedDescription = $"TestArtikel {DateTime.UtcNow}";
            var article = new Article { Description = updatedDescription, ArticleNumber = "100370" };
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var updatedArticle = ArticleService.UpdateArticleAsync(request, article).GetAwaiter().GetResult();
            Assert.AreEqual(updatedDescription, updatedArticle.Description);

            await listeningTask;
        }

        [TestMethod]
        public async Task CanConnectAndListen()
        {
            var client = await new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                .AddTopic(WebSocketTopic.Articles)
                .Connect();

            var updatedDescription = $"TestArtikel {DateTime.UtcNow}";
            var article = new Article { Description = updatedDescription, ArticleNumber = "100370" };
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var updatedArticle = ArticleService.UpdateArticleAsync(request, article).GetAwaiter().GetResult();
            Assert.AreEqual(updatedDescription, updatedArticle.Description);

            await client.Listen(async (socket) =>
            {
                var finished = false;
                var resultString = "";
                while (!finished)
                {
                    if (socket.State == WebSocketState.Open)
                    {
                        var buffer = new byte[DEFAULT_BUFFER_SIZE];
                        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                            Assert.Fail("Socket closed unexpectedly.");
                            return;
                        }
                        else
                        {
                            resultString += Encoding.ASCII.GetString(buffer);
                            finished = result.EndOfMessage;
                        }
                    }
                    else
                    {
                        Assert.Fail("Socket unexpectedly closed.");
                    }
                }

                try
                {
                    var response = JsonConvert.DeserializeObject<WebSocketEvent>(resultString);
                    Assert.IsTrue(response.Topic == "articles");
                    Assert.IsTrue(response.Type == "article-updated-v1");
                    Assert.IsTrue(response.EntityId == "100370");
                }
                catch (Exception e)
                {
                    throw e;
                }

                return;
            });
        }

        [TestMethod]
        public async Task CanListenInNonblockingThread()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                .AddTopic(WebSocketTopic.Articles);

            var listeningTask = new Task(() => { WebsocketListenerHelper(client); }, TaskCreationOptions.LongRunning);
            listeningTask.Start();

            var updatedDescription = $"TestArtikel {DateTime.UtcNow}";
            var article = new Article { Description = updatedDescription, ArticleNumber = "100370" };
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var updatedArticle = ArticleService.UpdateArticleAsync(request, article).GetAwaiter().GetResult();
            Assert.AreEqual(updatedDescription, updatedArticle.Description);

            await listeningTask;
        }

        public void WebsocketListenerHelper(FortnoxWebSocketClient client)
        {
            var task = new Task(async () =>
            {
                try
                {
                    (await client.Connect()).Listen(async (socket) =>
                    {
                        var buffer = new byte[DEFAULT_BUFFER_SIZE];
                        while (socket.State == WebSocketState.Open)
                        {
                            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                            if (result.MessageType == WebSocketMessageType.Close)
                            {
                                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                                Assert.Fail("Socket closed unexpectedly.");
                                return;
                            }
                            else
                            {
                                var response = JsonConvert.DeserializeObject<WebSocketEvent>(Encoding.ASCII.GetString(buffer));

                                Assert.IsTrue(response.Topic == "articles");
                                Assert.IsTrue(response.Type == "article-updated-v1");
                                Assert.IsTrue(response.EntityId == "100370");

                                return;
                            }
                        }
                    }).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Assert.Fail("");
                }
            }, TaskCreationOptions.LongRunning);

            task.RunSynchronously();
        }

        [TestMethod]
        public async Task CannotConnectTwice()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                .AddTopic(WebSocketTopic.Articles);

            await client.Connect();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => client.Connect());
        }

        [TestMethod]
        [ExpectedException(typeof(WebSocketException))]
        public async Task UserHasToSpecifyTopicsOrThrowsException()
        {
            var client = await new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                .Connect();
        }

        [TestMethod]
        [ExpectedException(typeof(WebSocketException))]
        public async Task InvalidCredentialsThrowsException()
        {
            var client = await new FortnoxWebSocketClient("NotAnAccessToken", "NotASecret")
                .Connect();
        }

        [TestMethod]
        public async Task CanSubscribeToMultipleTopics()
        {
            var listeningTask = new Task(async () =>
            {
                var client = new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                    .AddTopic(WebSocketTopic.Articles)
                    .AddTopic(WebSocketTopic.Orders);

                await client.ConnectAndListen(async (socket) =>
                {
                    var recievedArticleUpdate = false;
                    var recievedOrderUpdate = false;

                    foreach (var response in client.GetNextEvent(socket))
                    {
                        if (response != null)
                        {
                            Assert.IsTrue(response.Topic == "articles" || response.Topic == "orders");
                            
                            if (response.Topic == "articles")
                            {
                                recievedArticleUpdate = true;
                            }
                            else if (response.Topic == "orders")
                            {
                                recievedOrderUpdate = true;
                            }

                            Assert.IsTrue(response.Type == "article-updated-v1" || response.Type == "order-updated-v1");
                            Assert.IsTrue(response.EntityId == "100370" || response.EntityId == "1");

                            if (recievedArticleUpdate && recievedOrderUpdate)
                            {
                                return;
                            }
                        }
                    }
                });
            }, TaskCreationOptions.LongRunning);
            listeningTask.Start();

            var comment = $"Comment: {DateTime.Now}";
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var order = new Order { DocumentNumber = 1, Comments = comment };
            var updatedOrder = OrderService.UpdateOrderAsync(request, order).GetAwaiter().GetResult();
            Assert.AreEqual(comment, updatedOrder.Comments);
            
            var updatedDescription = $"TestArtikel {DateTime.UtcNow}";
            var article = new Article { Description = updatedDescription, ArticleNumber = "100370" };
            var articleRequest = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var updatedArticle = ArticleService.UpdateArticleAsync(articleRequest, article).GetAwaiter().GetResult();
            Assert.AreEqual(updatedDescription, updatedArticle.Description);

            await listeningTask;
        }
    }
}
