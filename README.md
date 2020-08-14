# Fortnox.NET
.NET bindings for the <a href="https://developer.fortnox.se/documentation/">Fortnox</a> API.
 
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
 
## Contributing
Thank you for considering contributing to Fortnox.NET. This part of the document provides information on how to get the project to run and build the project. 

### Developing
The project is using a service oriented structure where you, for example, have `ArticleService.cs` that defines operations that you can perform for the Articles endpoint. For resources that can be filtered, sorted or ordered an additional helper object `ArticleListRequest.cs` is also created.
 
### Testing
Currently the tests are only made to be working for our dataset, hence most of the tests will fail. If you are contributing to this project you are encouraged to make a test that would work for any dataset and not only ours.