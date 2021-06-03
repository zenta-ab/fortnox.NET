<img src=".github/Banner.png" style="width:100%;">

# Fortnox.NET

![Tests](https://github.com/zenta-ab/fortnox.NET/workflows/Tests/badge.svg?branch=master)
![Nuget](https://img.shields.io/nuget/v/Fortnox.NET)

.NET bindings for the <a href="https://developer.fortnox.se/documentation/">Fortnox</a> API.

We at Zenta have worked with Fortnox integrations since 2017. During this time we have helped several companies connect their systems with Fortnox and their API. During this time we've gathered a lot of knowledge and established a good relation with Fortnox. Because of our good relaiton with Fortnox we have the opportunity to be first out with the latest technology and updates that Fortnox offers.

This SDK makes working with the Fortnox API much easier and allows the community to work together to help improve it.

## Usage

To access the Fortnox API you need an Access Token and Client Secret: <a href="https://developer.fortnox.se/general/authentication/">https://developer.fortnox.se/general/authentication/</a>.

The unit tests in this repository serves as a way for us to make sure our code works as well as examples of how to call the different routes that the Fortnox API provides. There are mainly two ways to make a request using this SDK, one for requesting a list of resources and one for requesting a single resource.

### Listed resource

When requesting a list of resources you create a ListRequest object of the type of resource you are interested in.

```CSharp
var request = new OrderListRequest("ACCESS-TOKEN", "CLIENT-SECRET");
var orders = await OrderService.GetOrdersAsync(request);
```

You can also add filters and ordering to routes that accepts it, for example:

```CSharp
var request = new EmployeeListRequest("ACCESS-TOKEN", "CLIENT-SECRET")
{
    Filter = EmployeeFilters.Active
};
var employeeList = await EmployeeService.GetEmployeesAsync(request);
```

### Single resource

When requesting a single resource you create a FortnoxApiRequest object and pass that into the service to make your request.

```CSharp
var request = new FortnoxApiRequest("ACCESS-TOKEN", "CLIENT-SECRET");
var response = await ArticleService.GetArticleAsync(request, "100370");
```

### WebSocket

If you want to subscribe to changes instead of having to poll for new information you can use the Fortnox WebSocket API.
You start by creating a FortnoxWebSocketClient with your ClientSecret. Proceed with calling `Connect` to initiate the connection with Fortnox followed by adding the desired topics and tenants to your connection and once you're ready call `Subscribe` to start receiving events.

```CSharp
var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
await client.Connect();
await client.AddTenant(this.connectionSettings.AccessToken);
await client.AddTopic(WebSocketTopic.Articles);
await client.Subscribe();
```

Once you're subscribed you can call `Receive` to receive incoming messages. Performing actions such as `AddTenant`, `AddTopic` and `Subscribe` also results in a message being returned, if you wish you can handle those as well. In the following snippet we see an example which stores all action responses in their own variables followed by a while loop listening for incoming events.

```CSharp
var client = new FortnoxWebSocketClient(this.connectionSettings.ClientSecret);
await client.Connect();

await client.AddTenant(this.connectionSettings.AccessToken);
var addTenantResponse = await client.Receive();

await client.AddTopic(WebSocketTopic.Articles);
var addTopicResponse = await client.Receive();

await client.Subscribe();
var subscribeResponse = await client.Receive();

while (ListenToIncomingEvents)
{
    var response = await client.Receive();
    if (response.Type == WebSocketResponseType.EventResponse)
    {
        // Handle events
    }

    if (response.Type == WebSocketResponseType.CommandResponse)
    {
        // Handle commands
    }
}

await client.Close();
```

More examples of how to use the Fortnox WebSocket API exists within the unit tests for the `FortnoxWebSocketClient` class.

## Features

Bellow is a list of the supported API endpoints within the SDK.

* Absence Transactions
* Account Charts
* Accounts
* Archive
* Article File Connections
* Articles
* Asset File Connections
* Asset Types
* Assets
* Attendance Transactions
* Company Information
* Company Settings
* Contracts
* Contract Templates
* Cost Centers
* Currencies
* Customers
* Employees
* Expenses
* Finnancial Years
* Inbox
* Invoice Payments
* Invoices
* Labels
* Locked Period
* Modes of Payments
* Offers
* Orders
* Predefined Accounts
* Price Lists
* Prices
* Print Templates
* Projects
* Salary Transactions
* SIE
* Supplier Invoice External URL Connections
* Supplier Invoice File Connections
* Supplier Invoice Payments
* Supplier Invoices
* Suppliers
* Tax Reductions
* Terms of Deliveries
* Terms of Payments
* Trusted Email Domains
* Units
* Voucher Series
* Vouchers
* Way of Deliveries

### WebSockets

This library also supports the Fortnox WebSocket API which allows the user to get notifications about changes instead of having to poll using the above API endpoints.

The supported topics to subscribe to for changes are the following:

* Invoices
* Customers
* Orders
* Offers
* Articles
* Currencies
* TermsOfDeliveries
* WaysOfDeliveries
* TermsOfPayments

## Contributing

Thank you for considering contributing to Fortnox.NET. This part of the document provides information on how to get the project to run and build the project.

### Developing

The project is using a service oriented structure where you, for example, have `ArticleService.cs` that defines operations that you can perform for the Articles endpoint. For resources that can be filtered, sorted or ordered an additional helper object `ArticleListRequest.cs` is also created.

### Testing

Currently the tests are only made to be working for our dataset, hence most of the tests will fail. If you are contributing to this project you are encouraged to make a test that would work for any dataset and not only ours.

## License

MIT License

Copyright (c) 2021 Zenta AB

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
