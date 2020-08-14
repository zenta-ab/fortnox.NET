using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Archive;
using FortnoxNET.Communication.Article;
using FortnoxNET.Models.Article;
using FortnoxNET.Services;
using System.Drawing;

namespace FortnoxNET.Tests
{
    public class BaseFileConnectionTest : TestBase
    {
        protected async Task<List<Models.Inbox.File>> GetFiles()
        {
            var request = new ArchiveListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ArchiveService.GetArchiveAsync(request, "root"))
                .Folder
                .Files
                .ToList();
        }

        protected async Task<string> CreateFile()
        {
            var tempFile = CreateTempFile(out var tempFileName);
            var fileBytes = await File.ReadAllBytesAsync(tempFile);
            File.Delete(tempFile);
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ArchiveService.CreateFileAsync(request, fileBytes, tempFileName, "root");

            return response.Id;
        }
        
        protected string CreateTempFile(out string tempFileName)
        {
            tempFileName = $"{Guid.NewGuid().ToString()}.png";
            var tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);
            
            var image = new Bitmap(1, 1);
            image.Save(tempFilePath);

            return tempFilePath;
        }

        protected async Task DeleteFile(string fileId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArchiveService.DeleteArchiveAsync(request, fileId);
        }

        protected async Task<List<ArticleSubset>> GetArticles()
        {
            var request = new ArticleListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var articles = await ArticleService.GetArticlesAsync(request);

            return articles.Data.ToList();
        }

        protected async Task<ArticleSubset> CreateArticle()
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return await ArticleService.CreateArticleAsync(
                request, 
                new Article {Description = $"Test{(new Random()).Next(0, 100000)}"}
            );
        }

        protected async Task DeleteArticle(string articleId)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ArticleService.DeleteArticleAsync(request, articleId);
        }
    }
}