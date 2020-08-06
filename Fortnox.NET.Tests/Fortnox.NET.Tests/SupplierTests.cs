using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Communication.Supplier;
using FortnoxNET.Services;
using System.Linq;
using FortnoxNET.Models.Supplier;
using System.Collections.Generic;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Constants.Search;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class SupplierTests : TestBase
    {
        [TestMethod]
        public void GetSuppliers()
        {
            var request = new SupplierListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var suppliers = SupplierService.GetSuppliersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(suppliers.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetSuppliersPaginationTest()
        {
            const int PAGES = 5;

            var request = new SupplierListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 2;
            request.Page = 1;

            var suppliers = new List<SupplierSubset>();
            ListedResourceResponse<SupplierSubset> response;

            do
            {
                response = SupplierService.GetSuppliersAsync(request).GetAwaiter().GetResult();
                suppliers.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;
            } while (response.MetaInformation.CurrentPage < PAGES);

            Assert.IsTrue(suppliers.Count > 5);
            Assert.IsTrue(response.MetaInformation.CurrentPage == 5);
        }

        [TestMethod]
        public void GetSortedSuppliers()
        {
            var request = new SupplierListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { SortBy = SupplierSortableProperties.Name };
            var suppliers = SupplierService.GetSuppliersAsync(request).GetAwaiter().GetResult().Data.ToList();

            Assert.IsTrue(suppliers.Count() >= 2);

            Assert.IsTrue(suppliers.ElementAt(0).Name.CompareTo(suppliers.ElementAt(1).Name) < 0);
        }

        [TestMethod]
        public void SearchSuppliersTest()
        {
            var request = new SupplierListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<SupplierSearchParameters, object> {{ SupplierSearchParameters.Name, "Leverantör"}}
            };

            var suppliers = SupplierService.GetSuppliersAsync(request).GetAwaiter().GetResult();
            foreach (var supplier in suppliers.Data)
            {
                Assert.IsTrue(supplier.Name.ToLower().Contains("leverantör"));
            }
        }

        [TestMethod]
        public void GetSupplier()
        {
            var request = new SupplierListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = SupplierService.GetSupplierAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.Name.CompareTo("Leverantör 1") == 0);
            Assert.IsTrue(response.Active == true);
        }
    }
}
