using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class VoucherTests : TestBase
    {
        [TestMethod]
        public async Task GetVouchersTest()
        {
            var request = new VoucherListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.SearchParameters[VoucherSearchParameters.FinancialYearDate] = DateTime.UtcNow.ToShortDateString();
            var voucherList = await VoucherService.GetVouchersAsync(request);

            Assert.IsTrue(voucherList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetVouchersFromDateToDateTest()
        {
            var request = new VoucherListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.SearchParameters[VoucherSearchParameters.FinancialYearDate] = DateTime.UtcNow.ToShortDateString();

            var voucherList = await VoucherService.GetVouchersAsync(request);

            Assert.IsTrue(voucherList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetVoucher()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await VoucherService.GetVoucherAsync(request, 2, "B", 2);

            Assert.IsNotNull(response);
        }
    }
}