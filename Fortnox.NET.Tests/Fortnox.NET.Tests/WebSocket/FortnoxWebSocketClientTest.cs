using Fortnox.NET.WebSockets.Models;
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
        public async Task CanHandleCommandResponses()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            
            await client.AddTenant(this.connectionSettings.AccessToken);
            var addTenantResponse = await client.Recieve();
            Assert.IsTrue(addTenantResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(addTenantResponse.Result.Equals("ok"));
            Assert.IsTrue(addTenantResponse.Response == WebSocketCommands.AddTenants);


            await client.AddTopic(WebSocketTopic.Articles);
            var addTopicResponse = await client.Recieve();
            Assert.IsTrue(addTopicResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(addTopicResponse.Result.Equals("ok"));
            Assert.IsTrue(addTopicResponse.Response == WebSocketCommands.AddTopics);
            
            await client.Subscribe();
            var subscribeResponse = await client.Recieve();
            Assert.IsTrue(subscribeResponse.Type == WebSocketResponseType.CommandResponse);
            Assert.IsTrue(subscribeResponse.Result.Equals("ok"));
            Assert.IsTrue(subscribeResponse.Response == WebSocketCommands.Subscribe);
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

            var response = await client.Recieve();
            while (response.Type != WebSocketResponseType.EventResponse)
            {
                response = await client.Recieve();
            }

            Assert.IsTrue(response.Topic == "articles");
            Assert.IsTrue(response.EventType == "article-updated-v1");
            Assert.IsTrue(response.EntityId == "100370");   
        }

        [TestMethod]
        public async Task CannotConnectTwice()
        {
            var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
            await client.Connect();
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => client.Connect());
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
                    var response = await client.Recieve();
                    if (response.Type == WebSocketResponseType.EventResponse)
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

                        Assert.IsTrue(response.EventType == "article-updated-v1" || response.EventType == "order-updated-v1");
                        Assert.IsTrue(response.EntityId == "100370" || response.EntityId == "1");

                        if (recievedArticleUpdate && recievedOrderUpdate)
                        {
                            return;
                        }
                    }
                }
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
