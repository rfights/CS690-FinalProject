using Xunit;

namespace FamilyReunionAppTests
{
    public class BudgetManagerTestsTest
    {
        [Fact]
        public void Test_AddExpense_ShouldIncreaseTotalExpenses()
        {
            // Arrange
            var budgetManager = new BudgetManager();
            decimal initialExpense = 100m;

            // Act
            budgetManager.AddExpense(initialExpense);

            // Assert
            Assert.Equal(initialExpense, budgetManager.TotalExpenses);
        }

        [Fact]
        public void Test_AddExpense_ShouldThrowExceptionForNegativeValue()
        {
            // Arrange
            var budgetManager = new BudgetManager();
            decimal negativeExpense = -50m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => budgetManager.AddExpense(negativeExpense));
        }

        [Fact]
        public async Task Test_CalculateRemainingBudget_ShouldReturnCorrectValue()
        {
            // Arrange
            var budgetManager = new BudgetManager();
            await budgetManager.SetTotalBudget(500m);
            budgetManager.AddExpense(200m);

            // Act
            var remainingBudget = budgetManager.CalculateRemainingBudget();

            // Assert
            Assert.Equal(300m, remainingBudget);
        }

        [Fact]
        public async Task Test_SetTotalBudget_ShouldUpdateTotalBudget()
        {
            // Arrange
            var budgetManager = new BudgetManager();
            decimal newBudget = 1000m;

            // Act
            await budgetManager.SetTotalBudget(newBudget);

            // Assert
            Assert.Equal(newBudget, budgetManager.TotalBudget);
        }

        [Fact]
        public async Task Test_SetTotalBudget_ShouldThrowExceptionForNegativeValue()
        {
            // Arrange
            var budgetManager = new BudgetManager();
            decimal negativeBudget = -500m;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await budgetManager.SetTotalBudget(negativeBudget));
        }
    }
}

public class BudgetManager
{
    private decimal totalExpenses;
    private decimal totalBudget;

    public decimal TotalExpenses => totalExpenses;
    public decimal TotalBudget => totalBudget;

    public void AddExpense(decimal expense)
    {
        if (expense < 0)
        {
            throw new ArgumentException("Expense cannot be negative.");
        }

        totalExpenses += expense;
    }

    public async Task SetTotalBudget(decimal budget)
    {
        if (budget < 0)
        {
            throw new ArgumentException("Budget cannot be negative.");
        }

        // Simulate asynchronous operation
        await Task.Delay(1);
        totalBudget = budget;
    }

    public decimal CalculateRemainingBudget()
    {
        return totalBudget - totalExpenses;
    }
}