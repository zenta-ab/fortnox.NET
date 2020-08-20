<img src=".github/Banner.png" style="width:100%;">

# Fortnox.NET

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
You start by creating a FortnoxWebSocketClient with your AccessToken and ClientSecret. You can then add the desired topics to your connection and once you're ready call `Connect` to initiate the connection.

```CSharp
var client = await new FortnoxWebSocketClient(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret)
    .AddTopic(WebSocketTopic.Articles);
```

Once you're connected you can call `Listen` and specify your callback function, in order for this to not block your current thread you can run this within a Task like in the following snippet. Inside your listener callback you can make use of the `GetNextEvent` helper method to process messages as they come.

```CSharp
var task = new Task(async () =>
{
    try
    {
        (await client.Connect()).Listen(async (socket) =>
        {
            // GetNextEvent returns an enumeration and is iterated asyncrounusly as new events are yielded
            foreach (var response in client.GetNextEvent(socket))
            {
                if (response != null)
                {
                    // Process messages here.
                    return;
                }
            }
        }).GetAwaiter().GetResult();
    }
    catch (Exception e)
    {
        // Handle errors.
        throw e;
    }
}, TaskCreationOptions.LongRunning);
task.Start();
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
* Assert Types
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