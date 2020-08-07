using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxNET.Communication;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using FortnoxNET.Models.Employee;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class EmployeeTests : TestBase
    {
        [TestMethod]
        public void GetEmployees()
        {
            var request = new EmployeeListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var employeeList = EmployeeService.GetEmployeesAsync(request).GetAwaiter().GetResult();

            Assert.IsTrue(employeeList.Data.ToList().Count >= 0);
        }

        [TestMethod]
        public void GetFilteredEmployees()
        {
            var request = new EmployeeListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret) 
            { 
                Filter = EmployeeFilters.Active 
            };
            var employeeList = EmployeeService.GetEmployeesAsync(request).GetAwaiter().GetResult();

            Assert.IsNotNull(employeeList.Data.ToList().First());
        }

        [TestMethod]
        public void GetEmployee()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var response = EmployeeService.GetEmployeeAsync(request, "1").GetAwaiter().GetResult();

            Assert.IsTrue(response.EmployeeId == "1");
        }

        [TestMethod]
        public void CreateEmployee()
        {
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var employeeName = $"TestAnställd {DateTime.Now.ToString("yyyy-MM-dd")}";
            
            var response = EmployeeService.CreateEmployeeAsync(request, 
                new Employee 
                { 
                    EmployeeId = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                    FirstName = employeeName
                }).GetAwaiter().GetResult();

            Assert.AreEqual(employeeName, response.FirstName);
        }

        [TestMethod]
        public void UpdateEmployee()
        {
            var Employee = new Employee { FirstName = "TestAnställd", EmployeeId = "4" };
            var newEmployeeName = $"TestAnställd {DateTime.UtcNow}";

            Employee.FirstName = newEmployeeName;
            var request = new FortnoxApiRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            var updatedEmployee = EmployeeService.UpdateEmployeeAsync(request, Employee).GetAwaiter().GetResult();

            Assert.AreEqual(newEmployeeName, updatedEmployee.FirstName);
        }
    }
}