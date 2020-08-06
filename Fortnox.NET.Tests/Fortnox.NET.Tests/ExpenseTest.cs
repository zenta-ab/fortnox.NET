using System.Linq;
using System.Threading.Tasks;
using FortnoxNET.Communication.Expenses;
using FortnoxNET.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxNET.Tests
{
    [TestClass]
    public class ExpenseTest : TestBase
    {
        [TestMethod]
        public async Task GetExpenses()
        {
            var request = new ExpenseListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var expenses = await ExpenseService.GetExpensesAsync(request);

            Assert.IsTrue(expenses.Data.Any());
        }

        [TestMethod]
        public async Task GetExpense()
        {
            const string expenseTestCode = "Test";
            var request = new ExpenseListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);
            var expense = await ExpenseService.GetExpenseAsync(request, expenseTestCode);

            Assert.IsTrue(expense != null);
            Assert.IsTrue(expense.Code == expenseTestCode);
            Assert.IsFalse(string.IsNullOrEmpty(expense.Text));
        }

        [TestMethod]
        public /* async Task */ void CreateExpense_NotActive()
        {
            // Commented because we don't want to create a new expense each run and there is no delete functionality.

            //var request = new ExpenseListRequest(this.connectionSettings.AccessToken, this.connectionSettings.ClientSecret);

            //var expense = new Expense
            //{
            //    Code = "TestEx",
            //    Text = "This is a test expense.",
            //    Account = 1030
            //};

            //var createdExpense = await ExpenseService.CreateExpenseAsync(request, expense);

            //Assert.IsTrue(createdExpense != null);
        }
    }
}
