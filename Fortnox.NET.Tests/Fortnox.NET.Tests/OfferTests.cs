using FortnoxNET.Communication.Offer;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class OfferTests : TestBase
    {
        [TestMethod]
        public void GetOffers()
        {
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var Offers = OfferService.GetOffersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(Offers.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetFilteredOffers()
        {
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { Filter = OfferFilters.Cancelled };
            var Offers = OfferService.GetOffersAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(Offers.Data.ToList());
            Assert.IsTrue(Offers.Data.Count() > 0);

            foreach (var Offer in Offers.Data)
            {
                Assert.IsTrue(Offer.Cancelled == true);
            }
        }

        [TestMethod]
        public void GetSortedOffers()
        {
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { SortBy = OfferSortableProperties.DocumentNumber };
            var Offers = OfferService.GetOffersAsync(request).GetAwaiter().GetResult().Data.ToList();

            Assert.IsTrue(Offers.Count() >= 2);

            var X = Int32.Parse(Offers.ElementAt(0).DocumentNumber);
            var Y = Int32.Parse(Offers.ElementAt(1).DocumentNumber);

            Assert.IsTrue(X < Y);
        }

        [TestMethod]
        public void SearchOffersTest()
        {
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<OfferSearchParameters, object> { { OfferSearchParameters.CustomerName, "Kund" } }
            };

            var Offers = OfferService.GetOffersAsync(request).GetAwaiter().GetResult();
            foreach (var Offer in Offers.Data)
            {
                Assert.IsTrue(Offer.CustomerName.ToLower().Contains("kund"));
            }
        }

        [TestMethod]
        public void GetOffer()
        {
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = OfferService.GetOfferAsync(request, "2").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber.Equals("2"));
            Assert.IsTrue(response.OfferRows.Count() == 2);
        }

        [TestMethod]
        public void UpdateOfferTest()
        {
            var comment = $"Comment: {DateTime.Now}";
            var request = new OfferListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            
            var response = OfferService.GetOfferAsync(request, "2").GetAwaiter().GetResult();
            response.Comments = comment;

            var updatedOffer = OfferService.UpdateOfferAsync(request, response).GetAwaiter().GetResult();

            Assert.AreEqual(comment, updatedOffer.Comments);
        }
    }
}
