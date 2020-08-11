using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.FileConnection;
using FortnoxNET.Models.FileConnections;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ArticleFileConnectionsTest : BaseFileConnectionTest
    {
        [TestMethod]
        public async Task ItCanGetConnectionsForManyFiles()
        {
            var request = new ArticleFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArticleFileConnectionService.GetArticleFileConnectionsAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetConnectionsForAFile()
        {
            var fileConnections = await GetConnections();

            if (fileConnections == null || !fileConnections.Any())
            {
                Assert.Inconclusive("No connection exist between any article to any file in the system");
                return;
            } 
            
            var request = new ArticleFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArticleFileConnectionService.GetArticleFileConnectionAsync(
                request,
                fileConnections.First().FileId
            );
            
            Assert.IsNotNull(response);
            Assert.AreEqual(fileConnections.First().FileId, response.FileId);
        }

        [TestMethod]
        public async Task ItCanCreateAConnectionForAFile()
        {
            var fileId = await CreateFile();
            var articles = await GetArticles();
            var article = !articles.Any() ? await CreateArticle() : articles.First();
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);

            try
            {
                var response = await ArticleFileConnectionService.CreateArticleFileConnection(
                    request,
                    article.ArticleNumber,
                    fileId
                );
                
                await DeleteConnection(fileId);
            
                Assert.IsNotNull(response);
                Assert.AreEqual(fileId, response.FileId);
                Assert.AreEqual(article.ArticleNumber, response.ArticleNumber);
            }
            finally
            {
                await DeleteFile(fileId);
                
                if (!articles.Any())
                {
                    await DeleteArticle(article.ArticleNumber);
                }
            }
        }

        [TestMethod]
        public async Task ItCanDeleteAConnectionForAFile()
        {
            var articleFileConnection = await CreateConnection();

            try
            {
                var deleteRequest = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
                await ArticleFileConnectionService.DeleteArticleFileConnection(deleteRequest, articleFileConnection.FileId);
            
                var getConnectionRequest = new ArticleFileConnectionListRequest(
                    connectionSettings.AccessToken, 
                    connectionSettings.ClientSecret
                );
                await Assert.ThrowsExceptionAsync<Exception>(async () =>
                    await ArticleFileConnectionService.GetArticleFileConnectionAsync(getConnectionRequest, articleFileConnection.FileId)
                );
            }
            finally
            {
                await DeleteFile(articleFileConnection.FileId);
            }
            
        }

        private async Task<List<ArticleFileConnections>> GetConnections()
        {
            var request = new ArticleFileConnectionListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ArticleFileConnectionService.GetArticleFileConnectionsAsync(request)).Data.ToList();
        }

        private async Task DeleteConnection(string fileId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArticleFileConnectionService.DeleteArticleFileConnection(request, fileId);
        }

        private async Task<ArticleFileConnection> CreateConnection()
        {
            var fileId = await CreateFile();
            var articles = await GetArticles();
            var article = !articles.Any() ? await CreateArticle() : articles.First();
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            
            return await ArticleFileConnectionService.CreateArticleFileConnection(
                request,
                article.ArticleNumber,
                fileId
            );
        }
    }
}