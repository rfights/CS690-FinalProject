using System;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionAppTests
{
    public class BudgetManagerTests
    {
        [Fact]
        public void Test_SetBudget_UpdatesBudget()
        {
            var budgetManager = new BudgetManager();
            decimal newBudget = 1000m;

            budgetManager.SetBudget(newBudget);

            Assert.Equal(newBudget, budgetManager.GetBudget());
        }

        [Fact]
        public void Test_AddExpense_UpdatesExpenses()
        {
            var budgetManager = new BudgetManager();
            string description = "Food";
            decimal amount = 200m;

            budgetManager.AddExpense(description, amount);

            Assert.Contains((description, amount), budgetManager.GetExpenses());
            Assert.Equal(amount, budgetManager.GetTotalExpenses());
        }
    }
}