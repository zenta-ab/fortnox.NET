using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.PredefinedAccount;
using FortnoxNET.Models.Account;
using FortnoxNET.Models.PredefinedAccounts;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class PredefinedAccountsTest : TestBase
    {
        [TestMethod]
        public async Task ItCanGetPredefinedAccounts()
        {
            var request = new PredefinedAccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await PredefinedAccountsService.GetPredefinedAccountsAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetAPredefinedAccount()
        {
            var accounts = await GetPredefinedAccounts();

            if (!accounts.Any())
            {
                Assert.Inconclusive("No predefined accounts exist in the system");
            }
            
            var request = new PredefinedAccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await PredefinedAccountsService.GetPredefinedAccountAsync(
                request,
                accounts.First().Name    
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(accounts.First().Name, response.Data.Name);
        }

        [TestMethod]
        public async Task ItCanUpdateAnExistingAccountTypeWithAPredefinedAccount()
        {
            var predefinedAccounts = await GetPredefinedAccounts();
            var accounts = await GetAccounts();

            if (!predefinedAccounts.Any())
            {
                Assert.Inconclusive("No predefined accounts exist in the system");
            }

            if (!accounts.Any())
            {
                Assert.Inconclusive("No accounts exist in the system");
            }

            var predefinedAccount = await GetPredefinedAccount(predefinedAccounts.First().Name);
            var initialAccount = predefinedAccount.Account;
            var randomIndex = (new Random()).Next(0, accounts.Count);
            
            var request = new PredefinedAccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await PredefinedAccountsService.UpdateAccountAsync(
                request,
                accounts.ToArray()[randomIndex].Number.Value,
                predefinedAccount.Name
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual((accounts.ToArray())[randomIndex].Number, response.Data.Account);
            Assert.AreNotEqual(initialAccount, response.Data.Account);
        }

        private async Task<List<PredefinedAccounts>> GetPredefinedAccounts()
        {
            var request = new PredefinedAccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await PredefinedAccountsService.GetPredefinedAccountsAsync(request)).Data.ToList();
        }

        private async Task<PredefinedAccount> GetPredefinedAccount(string accountName)
        {
            var request = new PredefinedAccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await PredefinedAccountsService.GetPredefinedAccountAsync(request, accountName)).Data;
        }

        private async Task<List<AccountSubset>> GetAccounts()
        {
            var request = new AccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await AccountService.GetAccountsAsync(request)).Data.ToList();
        }
    }
}