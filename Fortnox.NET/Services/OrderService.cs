﻿using FortnoxNET.Communication;
using FortnoxNET.Communication.Order;
using FortnoxNET.Constants;
using FortnoxNET.Models.Order;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class OrderService
    {
        public static async Task<ListedResourceResponse<OrderSubset>> GetOrdersAsync(OrderListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<OrderSubset>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                        ApiEndpoints.Orders);

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

        public static async Task<Order> GetOrderAsync(FortnoxApiRequest request, string orderNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                $"{ApiEndpoints.Orders}/{orderNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Order> UpdateOrderAsync(FortnoxApiRequest request, Order order)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                                                                   $"{ApiEndpoints.Orders}/{order.DocumentNumber}")
                {
                    Data = new SingleResource<Order> { Data = order }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Order> CreateOrderAsync(FortnoxApiRequest request, Order order)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Orders}")
                {
                    Data = new SingleResource<Order> { Data = order }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        /// <summary>
        /// This action is used to set the field Sent as true from an external system without generating a PDF.
        /// </summary>
        /// <param name="request">FortnoxApiRequest object</param>
        /// <param name="orderNumber">Fortnox Order Number</param>
        /// <returns></returns>
        public static async Task<Order> PrintAsync(FortnoxApiRequest request, int orderNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Orders}/{orderNumber}/externalprint");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }


        public static async Task<Order> CancelAsync(FortnoxApiRequest request, int orderNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Orders}/{orderNumber}/cancel");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Order> CreateInvoiceAsync(FortnoxApiRequest request, int orderNumber)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Order>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                    $"{ApiEndpoints.Orders}/{orderNumber}/createinvoice");
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
 }
