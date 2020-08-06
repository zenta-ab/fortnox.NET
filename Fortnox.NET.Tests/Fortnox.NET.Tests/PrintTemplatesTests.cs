using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Communication.PrintTemplates;
using FortnoxNET.Services;
using System.Linq;
using System.Collections.Generic;
using FortnoxNET.Models.Order;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Filter;

using System;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class PrintTemplatesTests : TestBase
    {
        [TestMethod]
        public void GetTemplatesAsync()
        {
            var request = new PrintTemplatesListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var printTemplates = PrintTemplatesService.GetTemplatesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(printTemplates.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetFilteredTemplates()
        {
            var request = new PrintTemplatesListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { Filter = PrintTemplatesFilter.Order };
            var printTemplates = PrintTemplatesService.GetTemplatesAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(printTemplates.Data.ToList());
            Assert.IsTrue(printTemplates.Data.Count() > 0);

            foreach (var order in printTemplates.Data)
            {
                Assert.IsTrue(order.Name == "Följesedel" || order.Name == "Orderbekräftelse - Levererat antal" || order.Name == "Orderbekräftelse - Beställt antal" || order.Name == "Plocklista - Reserverat antal");
            }
        }
    }
}
