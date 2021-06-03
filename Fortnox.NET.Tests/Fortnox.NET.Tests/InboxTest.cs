using FortnoxNET.Communication;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class InboxTest : TestBase
    {
        [TestMethod]
        public void GetInbox()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var articles = InboxService.GetInboxAsync(request, "inbox_d").GetAwaiter().GetResult();

            Assert.IsNotNull(articles);
            Assert.AreEqual(articles.Folder.Files.First().Name, "WebSocket Fortnox API.pdf");
            Assert.AreEqual(articles.Folder.Files.First().Size, 101902);
        }

        //[TestMethod]
        //public void UploadFile()
        //{
        //    // NOTE: Avoid cluttering fortnox with dat
        //    var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

        //    var fileName = "UploadedFile.jpg";
        //    var fileContents = System.IO.File.ReadAllBytes("C:\\Path\\To\\My\\File.jpg");

        //    var response = InboxService.UploadFileAsync(request, "inbox_kf", fileName, fileContents).GetAwaiter().GetResult();

        //    Assert.IsTrue(response.Name == fileName);
        //    Assert.IsTrue(response.Path == "inbox_kf");

        //}
    }
}
