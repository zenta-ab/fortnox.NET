using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Project;
using FortnoxNET.Constants.Search;
using FortnoxNET.Models.Project;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ProjectTests : TestBase
    {
        [TestMethod]
        public void GetProjects()
        {
            var request = new ProjectListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var projects = ProjectService.GetProjectsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(projects.Data.ToList().Count > 0);
        }
        
        [TestMethod]
        public void GetProjectsPaginationTest()
        {
            var request = new ProjectListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 100;
            request.Page = 1;
            
            var projects = new List<Project>();  
            ListedResourceResponse<Project> response;
            var pages = 0;
            do
            {
                pages++;
                response = ProjectService.GetProjectsAsync(request).GetAwaiter().GetResult();
                projects.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;

            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(projects.Count > 0);
        }

        [TestMethod]
        public void SearchProjects()
        {
            var request = new ProjectListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<ProjectSearchParameters, object> {{ProjectSearchParameters.LastModified, DateTime.UtcNow.ToShortDateString()}}
            };

            var projects = ProjectService.GetProjectsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(projects.Data.Count() >= 0);
        }

        [TestMethod]
        public void GetProject()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = ProjectService.GetProjectAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.ProjectNumber == "1");
        }
    }
}