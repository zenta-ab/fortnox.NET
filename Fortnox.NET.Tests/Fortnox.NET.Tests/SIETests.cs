using FortnoxNET.Communication;
using FortnoxNET.Models.SIE;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SIETests : TestBase
    {
        [TestMethod]
        public void GetSIEYearBalance()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SIEService.GetSIEAsync(request, SIETypes.YearBalance).GetAwaiter().GetResult();

            Assert.IsTrue(response.Length > 0);
        }

        [TestMethod]
        public void GetSIEYearBalanceForFirstFinnancialYear()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SIEService.GetSIEAsync(request, SIETypes.YearBalance, 1).GetAwaiter().GetResult();

            Assert.IsTrue(response.Length > 0);
        }

        [TestMethod]
        public async Task GetSIEAsFileAsync()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var filePath = Path.GetTempFileName();
            
            SIEService.GetAndSaveSIEToDiskAsync(request, SIETypes.YearBalance, filePath, 1).GetAwaiter().GetResult();

            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue((await File.ReadAllBytesAsync(filePath)).Length > 0);
            File.Delete(filePath);
        }
    }
}
