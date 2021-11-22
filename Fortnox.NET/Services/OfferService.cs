using FortnoxNET.Communication;
using FortnoxNET.Communication.Offer;
using FortnoxNET.Constants;
using FortnoxNET.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class OfferService
    {
        public static async Task<ListedResourceResponse<OfferSubset>> GetOffersAsync(OfferListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<OfferSubset>>(HttpMethod.Get, listRequest,
                                                                                        ApiEndpoints.Offers);

            apiRequest.SetFilter(listRequest.Filter?.ToString());
            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            if (listRequest.SearchParameters == null)
            {
                return await FortnoxAPIClient.CallAsync(apiRequest);
            }

            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Offer> GetOfferAsync(FortnoxApiRequest request, string offerNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Offer>>(HttpMethod.Get, request,
                                                                                $"{ApiEndpoints.Offers}/{offerNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Offer> CreateOfferAsync(FortnoxApiRequest request, Offer offer)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Offer>>(HttpMethod.Post, request, $"{ApiEndpoints.Offers}")
                {
                    Data = new SingleResource<Offer> { Data = offer }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Offer> UpdateOfferAsync(FortnoxApiRequest request, Offer offer)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Offer>>(HttpMethod.Put, request,
                                                                   $"{ApiEndpoints.Offers}/{offer.DocumentNumber}")
                {
                    Data = new SingleResource<Offer> { Data = offer }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
