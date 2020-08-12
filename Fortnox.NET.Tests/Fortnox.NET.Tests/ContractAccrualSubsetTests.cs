using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Archive;
using FortnoxNET.Communication.ContractAccrual;
using FortnoxNET.Models.Account;
using FortnoxNET.Models.Archive;
using FortnoxNET.Models.ContractAccruals;
using FortnoxNET.Models.Inbox;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ContractAccrualSubsetTests : TestBase
    {
        [TestMethod]
        public async Task ItCanGetManyContractAccruals()
        {
            var request = new ContractAccrualListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractAccrualService.GetContractAccrualsAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetAContractAccrual()
        {
            var accruals = await GetContractAccruals();

            if (accruals == null || !accruals.Any())
            {
                Assert.Inconclusive("No contract accruals exist in the system");
                return;
            }
            
            var request = new ContractAccrualListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractAccrualService.GetContractAccrualAsync(
                request,
                accruals.First().DocumentNumber
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(accruals.First().DocumentNumber, response.Data.DocumentNumber);
        }

        [TestMethod]
        public async Task ItCanCreateAContractAccrual()
        {
            var accounts = (await GetAccounts()).ToArray();

            if (accounts == null || !accounts.Any() || accounts.Length < 2)
            {
                Assert.Inconclusive("No accounts exist in the system, or less than two accounts exist in the system");
                return;
            }

            var accrual = GenerateAccrual(
                accounts[0].Number, 
                accounts[1].Number, 
                1
            );
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractAccrualService.CreateContractAccrualAsync(
                request,
                accrual
            );

            await DeleteContractAccrual(accrual.DocumentNumber);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(accrual.DocumentNumber, response.Data.DocumentNumber);
        }

        // [TestMethod]
        public async Task ItCanUpdateAContractAccrual()
        {
            var accounts = (await GetAccounts()).ToList();

            if (!accounts.Any() || accounts.Count < 2)
            {
                Assert.Inconclusive("No accounts exist in the system, or less than two accounts exist in the system");
                return;
            }

            // var accrual = await CreateAccrual(accounts);
        }

        public async Task ItCanDeleteAContractAccrual()
        {
            
        }

        private async Task<List<ContractAccrualSubset>> GetContractAccruals()
        {
            var request = new ContractAccrualListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ContractAccrualService.GetContractAccrualsAsync(request)).Data.ToList();
        }

        private async Task<List<AccountSubset>> GetAccounts()
        {
            var request = new AccountListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await AccountService.GetAccountsAsync(request)).Data.ToList();
        }

        private async Task DeleteContractAccrual(int documentNumber)
        {
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            await ContractAccrualService.DeleteContractAccrualAsync(request, documentNumber);
        }

        private ContractAccrual GenerateAccrual(int firstAccountNumber, int secondAccountNumber, int documentNumber)
        {
            return new ContractAccrual()
            {
                AccrualAccount = firstAccountNumber, // Maybe from accounts
                CostAccount = secondAccountNumber,
                AccrualRows = new List<AccrualRow>()
                {
                    new AccrualRow()
                    {
                        Account = firstAccountNumber,
                        Credit = 0,
                        Debit = 2999
                    },
                    new AccrualRow()
                    {
                        Account = secondAccountNumber,
                        Credit = 2999,
                        Debit = 0
                    }
                },
                DocumentNumber = documentNumber,
                Total = 2999,
                Description = $"Test{(new Random()).Next(0, 100000)}"
            };
        }

        private async Task<ContractAccrual> CreateAccrual(List<Account> accounts)
        {
            var accrual = GenerateAccrual(
                accounts[0].Number, 
                accounts[1].Number, 
                1
            );
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ContractAccrualService.CreateContractAccrualAsync(
                request,
                accrual
            )).Data;
        }
    }
}