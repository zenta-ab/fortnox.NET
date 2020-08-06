using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FortnoxNET.Communication;
using FortnoxNET.Communication.Unit;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Unit;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class UnitTests : TestBase
    {
        [TestMethod]
        public void GetUnits()
        {
            var request = new UnitListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var units = UnitService.GetUnitsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(units.Data.ToList().Count > 0);
        }
        
        [TestMethod]
        public void GetUnitsPaginationTest()
        {
            var request = new UnitListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 50;
            request.Page = 1;
            
            var units = new List<Unit>();  
            ListedResourceResponse<Unit> response;
            var pages = 0;
            do
            {
                pages++;
                response = UnitService.GetUnitsAsync(request).GetAwaiter().GetResult();
                units.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;

            } while (response.MetaInformation.CurrentPage != response.MetaInformation.TotalPages);

            Assert.IsTrue(units.Count > 0);
        }

        [TestMethod]
        public void GetSortedUnits()
        {
            var request = new UnitListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) {SortBy = UnitSortableProperties.Code};
            var units = UnitService.GetUnitsAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(units.Data.ToList().First().Code.StartsWith("förp"));
        }

        [TestMethod]
        public void SearchUnits()
        {
            var request = new UnitListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
                          {
                              SearchParameters = new Dictionary<UnitSearchParameters, object> {{UnitSearchParameters.LastModified, DateTime.Today.ToShortDateString()}}
                          };

            var units = UnitService.GetUnitsAsync(request).GetAwaiter().GetResult();

            Assert.IsFalse(units.Data.Any());
        }

        [TestMethod]
        public void GetUnit()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = UnitService.GetUnitAsync(request, "st").GetAwaiter().GetResult();

            Assert.IsTrue(response.Code == "st");
        }
    }
}