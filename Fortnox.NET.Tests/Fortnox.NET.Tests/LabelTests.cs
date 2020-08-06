using FortnoxNET.Communication.Label;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class LabelTests : TestBase
    {
        [TestMethod]
        public void GetLabels()
        {
            var request = new LabelListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var labels = LabelService.GetLabelsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(labels.Data.Count() > 0);
        }
    }
}
