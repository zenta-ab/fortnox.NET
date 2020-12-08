using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Communication.ContractTemplates;
using FortnoxNET.Models.ContractTemplates;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ContractTemplateTests : TestBase
    {
        [TestMethod]
        public async Task ItCanGetContractTemplates()
        {
            var request = new ContractTemplateListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractTemplateService.GetContractTemplatesAsync(request);
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task ItCanGetAContractTemplate()
        {
            var templates = await GetTemplates();

            if (!templates.Any())
            {
                Assert.Inconclusive("No contract templates exist in the system");
            }
            
            var request = new ContractTemplateListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractTemplateService.GetContractTemplateAsync(
                request,
                templates.First().ContractTemplate.Value
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(templates.First().ContractTemplate, response.Data.TemplateNumber);
        }

        //WARNING: Contract Templates have no DELETE endpoint, so running this can add extraneous data to the system
        [TestMethod]
        public async Task ItCanCreateAContractTemplate()
        {
            Assert.Inconclusive("Skipping this test as it can add extraneous data to the system");
            var template = GenerateTemplate();
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractTemplateService.CreateContractTemplateAsync(
                request,
                template
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(template.TemplateName, response.Data.TemplateName);
        }

        [TestMethod]
        public async Task ItCanUpdateAContractTemplate()
        {
            var templates = await GetTemplates();

            if (!templates.Any())
            {
                Assert.Inconclusive("No contract templates exist in the system");
                return;
            }

            var template = await GetTemplate(templates.First().ContractTemplate.Value);
            var initialRemarks = template.Remarks;
            template.Remarks = $"CHANGED{(new Random()).Next(0, 1000000)}";
            
            var request = new FortnoxApiRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            var response = await ContractTemplateService.UpdateContractTemplateAsync(
                request,
                template
            );
            
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(template.Remarks, response.Data.Remarks);
            Assert.AreNotEqual(initialRemarks, response.Data.Remarks);
        }

        private async Task<List<ContractTemplates>> GetTemplates()
        {
            var request = new ContractTemplateListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ContractTemplateService.GetContractTemplatesAsync(request)).Data.ToList();
        }

        private async Task<ContractTemplate> GetTemplate(int templateNumber)
        {
            var request = new ContractTemplateListRequest(connectionSettings.AccessToken, connectionSettings.ClientSecret);
            return (await ContractTemplateService.GetContractTemplateAsync(
                request,
                templateNumber
            )).Data;
        }

        private ContractTemplate GenerateTemplate()
        {
            return new ContractTemplate()
            {
                ContractLength = "6",
                Continuous = false,
                InvoiceInterval = 3,
                TemplateName = $"Test{(new Random()).Next(0, 100000)}",
                InvoiceRows = new List<ContractTemplateInvoiceRow>()
                {
                    new ContractTemplateInvoiceRow()
                    {
                        ArticleNumber = "1",
                        DeliveredQuantity = 1,
                    }
                },
            };
        }
    }
}