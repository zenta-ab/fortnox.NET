﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FortnoxNET.Communication.Order;
using FortnoxNET.Services;
using System.Linq;
using System.Collections.Generic;
using FortnoxNET.Models.Order;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Sort;
using System;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class OrderTests : TestBase
    {
        [TestMethod]
        public void GetOrders()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(orders.Data.ToList().Count > 0);
        }

        [TestMethod]
        public void GetOrdersPaginationTest()
        {
            const int PAGES = 5;

            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            request.Limit = 10;
            request.Page = 1;

            var orders = new List<OrderSubset>();
            ListedResourceResponse<OrderSubset> response;

            do
            {
                response = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();
                orders.AddRange(response.Data);
                request.Page = response.MetaInformation.CurrentPage + 1;
            } while (response.MetaInformation.CurrentPage < PAGES);

            Assert.IsTrue(orders.Count() > 10);
            Assert.IsTrue(response.MetaInformation.CurrentPage == 5);
        }

        [TestMethod]
        public void GetFilteredOrders()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { Filter = OrderFilters.Cancelled };
            var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(orders.Data.ToList());
            Assert.IsTrue(orders.Data.Count() > 0);

            foreach (var order in orders.Data)
            {
                Assert.IsTrue(order.Cancelled == true);
            }
        }

        [TestMethod]
        public void GetSortedOrders()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) { SortBy = OrdersSortableProperties.DocumentNumber };
            var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult().Data.ToList();

            Assert.IsTrue(orders.Count() >= 2);

            var X = Int32.Parse(orders.ElementAt(0).DocumentNumber);
            var Y = Int32.Parse(orders.ElementAt(1).DocumentNumber);

            Assert.IsTrue(X < Y);
        }

        [TestMethod]
        public void SearchOrdersTest()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<OrderSearchParameters, object> {{OrderSearchParameters.CustomerName, "Kund" }}
            };

            var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();
            foreach (var order in orders.Data)
            {
                Assert.IsTrue(order.CustomerName.ToLower().Contains("kund"));
            }
        }

        [TestMethod]
        public void SearchOrdersLastModifiedTest()
        {
            var dateOfThisTest = DateTime.Parse("2019-10-09 15:25:31");
            var halfYearPriorToWhenThisTestWasMade = dateOfThisTest.AddDays(-180);

            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
            {
                SearchParameters = new Dictionary<OrderSearchParameters, object> { { OrderSearchParameters.LastModified, halfYearPriorToWhenThisTestWasMade } }
            };

            var orders = OrderService.GetOrdersAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(orders.Data.Any());
        }

        [TestMethod]
        public void GetOrder()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = OrderService.GetOrderAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == 1);
            Assert.IsTrue(response.OrderRows.Count() == 2);
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            var comment = $"Comment: {DateTime.Now}";
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var order = new Order { DocumentNumber = 1, Comments = comment };
            var updatedOrder = OrderService.UpdateOrderAsync(request, order).GetAwaiter().GetResult();

            Assert.AreEqual(comment, updatedOrder.Comments);
        }

        [TestMethod]
        public void GetOrderWithLabel()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = OrderService.GetOrderAsync(request, "56503").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == 56503);
            Assert.IsTrue(response.Labels.Count == 1);
            Assert.IsTrue(response.Labels.ElementAt(0).Id == 5);
        }

        [TestMethod]
        public void GetOrderWithMultipleLabels()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = OrderService.GetOrderAsync(request, "56077").GetAwaiter().GetResult();

            Assert.IsTrue(response.DocumentNumber == 56077);
            Assert.IsTrue(response.Labels.Count > 1);
        }

        [TestMethod]
        public void SetOrderLabel()
        {
            var request = new OrderListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var order = new Order { DocumentNumber = 1, Labels = new List<OrderLabel> { } };
            OrderService.UpdateOrderAsync(request, order).GetAwaiter().GetResult();

            var response = OrderService.GetOrderAsync(request, "1").GetAwaiter().GetResult();
            Assert.IsTrue(response.DocumentNumber == 1);
            Assert.IsTrue(!response.Labels.Any());

            var orderLabel = new OrderLabel { Id = 1 };
            order.Labels = new List<OrderLabel>();
            order.Labels.Add(orderLabel);
            OrderService.UpdateOrderAsync(request, order).GetAwaiter().GetResult();

            response = OrderService.GetOrderAsync(request, "1").GetAwaiter().GetResult();
            Assert.IsTrue(response.DocumentNumber == 1);
            Assert.IsTrue(response.Labels.Count() == 1);
            Assert.IsTrue(response.Labels.ElementAt(0).Id == 1);
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 10
                            }
                        }
                }).GetAwaiter().GetResult();

            Assert.AreEqual(1, response.OrderRows.Count);
        }

        [TestMethod]
        public void CreateInvoiceTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var createOrderResponse = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 1,
                                AccountNumber = 3001
                            }
                        }
                }).GetAwaiter().GetResult();

            var createInvoiceResponse = OrderService.CreateInvoiceAsync(request, createOrderResponse.DocumentNumber).GetAwaiter().GetResult();
            var invoicedOrder = OrderService.GetOrderAsync(request, createOrderResponse.DocumentNumber.ToString()).GetAwaiter().GetResult();

            Assert.IsTrue(invoicedOrder.InvoiceReference > 0);
            Assert.AreEqual("1", createInvoiceResponse.CustomerNumber);
            Assert.AreEqual(1, createInvoiceResponse.OrderRows.Count);
        }

        [TestMethod]
        public void ExternalPrintTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var createOrderResponse = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 1
                            }
                        }
                }).GetAwaiter().GetResult();

            Assert.AreEqual(false, createOrderResponse.Sent);

            var cancelResponse = OrderService.ExternalPrintAsync(request, createOrderResponse.DocumentNumber).GetAwaiter().GetResult();

            Assert.AreEqual(true, cancelResponse.Sent);
        }

        [TestMethod]
        public void CancelTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var createOrderResponse = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 1
                            }
                        }
                }).GetAwaiter().GetResult();

            Assert.AreEqual(false, createOrderResponse.Cancelled);

            var cancelResponse = OrderService.CancelAsync(request, createOrderResponse.DocumentNumber).GetAwaiter().GetResult();

            Assert.AreEqual(true, cancelResponse.Cancelled);
        }

        // Warehouse Resource specific tests

        [TestMethod]
        public void UpdateDeliveryStateTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var order = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 1
                            }
                        }
                }).GetAwaiter().GetResult();

            Assert.AreEqual("reservation", order.DeliveryState.ToLower());

            order.DeliveryState = "delivery";

            var updatedOrder = OrderService.UpdateOrderAsync(request, order).GetAwaiter().GetResult();

            Assert.AreEqual("delivery", updatedOrder.DeliveryState.ToLower());
        }


        [TestMethod]
        public void WarehouseReadyTest()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var order = OrderService.CreateOrderAsync(request,
                new Order
                {
                    CustomerNumber = "1",
                    DeliveryState = "delivery",
                    OrderRows =
                        new List<OrderRow>
                        {
                            new OrderRow
                            {
                                ArticleNumber = "1",
                                OrderedQuantity = 1
                            }
                        }
                }).GetAwaiter().GetResult();

            Assert.IsTrue(order.WarehouseReady.HasValue);
            Assert.IsTrue(!order.WarehouseReady.Value);

            var updatedOrder = OrderService.WarehouseReadyAsync(request, order.DocumentNumber).GetAwaiter().GetResult();

            Assert.IsTrue(updatedOrder.WarehouseReady.HasValue);
            Assert.IsTrue(updatedOrder.WarehouseReady.Value);
        }
    }
}
