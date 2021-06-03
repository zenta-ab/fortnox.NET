using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Article;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Article;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ArticleTests : TestBase
    {
        [TestMethod]
        public void GetArticles()
        {
            var request = new ArticleListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var articles = ArticleService.GetArticlesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(articles.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetArticlesPaginationTest()
        {
            var request = new ArticleListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 50;
            request.Page = 1;

            var articles = new List<ArticleSubset>();
            ListedResourceResponse<ArticleSubset> response;

            do
            {
                response = ArticleService.GetArticlesAsync(request).GetAwaiter().GetResult();
                articles.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;
            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(articles.Count > 10);
        }

        [TestMethod]
        public void GetFilteredArticles()
        {
            var request = new ArticleListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) {Filter = ArticleFilters.Active};
            var invoiceList = ArticleService.GetArticlesAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(invoiceList.Data.ToList().First());
        }

        [TestMethod]
        public void GetSortedArticles()
        {
            var request = new ArticleListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                {SortBy = ArticleSortableProperties.ArticleNumber};
            var invoiceList = ArticleService.GetArticlesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().ArticleNumber.StartsWith("1"));
        }

        [TestMethod]
        public void SearchArticles()
        {
            var request = new ArticleListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<ArticleSearchParameters, object>
                    {{ArticleSearchParameters.ArticleNumber, "100370"}}
            };

            var invoiceList = ArticleService.GetArticlesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(invoiceList.Data.ToList().First().ArticleNumber == "100370");
        }

        [TestMethod]
        public void GetArticle()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ArticleService.GetArticleAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.ArticleNumber == "1");
            Assert.AreEqual(response.Type, ArticleType.STOCK);
        }

        [TestMethod]
        public async Task CreateArticle()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await ArticleService.CreateArticleAsync(request, new Article { Description = "TestArtikel" });

            Assert.AreEqual("TestArtikel", response.Description);

            await ArticleService.DeleteArticleAsync(request, response.ArticleNumber);
        }

        [TestMethod]
        public void UpdateArticle()
        {
            var article = new Article { Description = "TestArtikel", ArticleNumber = "100000" };
            var newArticleName = $"TestArtikel {DateTime.UtcNow}";

            article.Description = newArticleName;
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var updatedArticle = ArticleService.UpdateArticleAsync(request, article).GetAwaiter().GetResult();

            Assert.AreEqual(newArticleName, updatedArticle.Description);
        }
    }
}