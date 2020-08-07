using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.Account;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class AccountTests : TestBase
    {
        [TestMethod]
        public async Task GetAccountsTest()
        {
            var request = new AccountListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var accountList = await AccountService.GetAccountsAsync(request);

            Assert.IsTrue(accountList.Data.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetAccountsFromDateToDateTest()
        {
            var request = new AccountListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                          {
                              SearchParameters = new Dictionary<AccountSearchParameters, object>() {{AccountSearchParameters.SRU, 1}}
                          };
            
            request.SearchParameters.Add(AccountSearchParameters.FinancialYearDate, DateTime.Parse("2016-01-01").ToString("yyyy-MM-dd"));

            var accountList = await AccountService.GetAccountsAsync(request);

            Assert.IsNotNull(accountList);
        }
        
        [TestMethod]
        public void GetCustomerInvoicesPaginationTest()
        {
            var request = new AccountListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.SearchParameters.Add(AccountSearchParameters.FinancialYearDate, DateTime.UtcNow.ToString("yyyy-MM-dd"));
            request.Limit = 50;
            request.Page = 1;
            
            var accounts = new List<AccountSubset>();  
            ListedResourceResponse<AccountSubset> response;

            do
            {
                response = AccountService.GetAccountsAsync(request).GetAwaiter().GetResult();
                accounts.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;

            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(accounts.Count > 10);
        }

        [TestMethod]
        public async Task GetAccount()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = await AccountService.GetAccountAsync(request, 2, 2641);

            Assert.IsNotNull(response);
        }
    }
}