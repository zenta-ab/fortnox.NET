using Fortnox.NET.WebSockets.Models;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Order;
using FortnoxNET.Models.Article;
using FortnoxNET.Models.Order;
using FortnoxNET.Services;
using FortnoxNET.WebSockets;
using FortnoxNET.WebSockets.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace FortnoxNET.Tests.WebSocket
{
    [TestClass]
    public class FortnoxWebSocketClientTest : TestBase
    {

        [TestMethod]
        public async Task CanHandleCommandResponses()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            
            await client.AddTenant(this.connectionSettings.AccessToken);
            var addTenantResponse = await client.Receive();
            Assert.IsTrue(addTenantResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(addTenantResponse.Result.Equals("ok"));
            Assert.IsTrue(addTenantResponse.Response == WebSocketCommands.AddTenants);


            await client.AddTopic(WebSocketTopic.Articles);
            var addTopicResponse = await client.Receive();
            Assert.IsTrue(addTopicResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(addTopicResponse.Result.Equals("ok"));
            Assert.IsTrue(addTopicResponse.Response == WebSocketCommands.AddTopics);
            
            await client.Subscribe();
            var subscribeResponse = await client.Receive();
            Assert.IsTrue(subscribeResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(subscribeResponse.Result.Equals("ok"));
            Assert.IsTrue(subscribeResponse.Response == WebSocketCommands.Subscribe);

            await client.Close();
        }

        [TestMethod]
        public async Task CanConnectAndListen()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            await client.AddTenant(this.connectionSettings.AccessToken);
            await client.AddTopic(WebSocketTopic.Articles);
            await client.Subscribe();

            var updatedDescription = $"TestArtikel {DateTime.UtcNow}";
            var article = new Article { Description = updatedDescription, ArticleNumber = "100370" };
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var updatedArticle = ArticleService.UpdateArticleAsync(request, article).GetAwaiter().GetResult();
            Assert.AreEqual(updatedDescription, updatedArticle.Description);

            var response = await client.Receive();
            while (response.Type != WebSocketResponseType.EventResponse)
            {
                response = await client.Receive();
            }

            Assert.IsTrue(response.Topic == WebSocketTopic.Articles.ToString());
            Assert.IsTrue(response.EventType == WebSocketEventType.ArticleUpdated);
            Assert.IsTrue(response.EntityId == "100370");

            await client.Close();
        }

        [TestMethod]
        public async Task CannotConnectTwice()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => client.Connect());
            await client.Close();
        }

        [TestMethod]
        public async Task CancellationTokenTest()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            await client.AddTenant(this.connectionSettings.AccessToken);
            await client.Receive();
            await client.AddTopic(WebSocketTopic.Articles);
            await client.Receive();
            await client.Subscribe();
            await client.Receive();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(2500);
            CancellationToken token = cancellationTokenSource.Token;
            
            // Recieve that will be cancelled after 2,5 seconds.
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(() => client.Receive(token));

            // Underlying ClientWebSocket state will be set to "Aborted" once cancelled so we cannot re-use the socket now.
            await Assert.ThrowsExceptionAsync<WebSocketException>(() => client.Receive(token));

            await client.Close();
        }

        [TestMethod]
        public async Task CanSubscribeToMultipleTopics()
        {
            var listeningTask = new Task(async () =>
            {
                var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
                await client.Connect();
                await client.AddTenant(this.connectionSettings.AccessToken);
                await client.AddTopic(WebSocketTopic.Articles);
                await client.AddTopic(WebSocketTopic.Orders);
                await client.Subscribe();

                var recievedArticleUpdate = false;
                var recievedOrderUpdate = false;

                while (!recievedArticleUpdate && !recievedOrderUpdate)
                {
                    var response = await client.Receive();
                    if (response.Type == WebSocketResponseType.EventResponse)
                    {
                        Assert.IsTrue(response.Topic == WebSocketTopic.Articles.ToString() || response.Topic == WebSocketTopic.Orders.ToString());

                        if (response.Topic == WebSocketTopic.Articles.ToString())
                        {
                            recievedArticleUpdate = true;
                        }
                        else if (response.Topic == WebSocketTopic.Orders.ToString())
                        {
                            recievedOrderUpdate = true;
                        }

                        Assert.IsTrue(response.EventType == WebSocketEventType.ArticleUpdated || response.EventType == WebSocketEventType.OrderUpdated);
                        Assert.IsTrue(response.EntityId == "100370" || response.EntityId == "1");

                        if (recievedArticleUpdate && recievedOrderUpdate)
                        {
                            return;
                        }
                    }
                }

                await client.Close();
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
