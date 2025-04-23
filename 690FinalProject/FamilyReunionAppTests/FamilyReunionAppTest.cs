// filepath: c:\Users\gamer\Desktop\690FinalProject\690FinalProject\FamilyReunionApp\FamilyReunionAppTest.cs
using System;
using System.Collections.Generic;
using Xunit;

public class BudgetManagerTests
{
    [Fact]
    public void Test_SetBudget_UpdatesBudgetCorrectly()
    {
        // Arrange
        var budgetManager = new BudgetManager();
        decimal expectedBudget = 1000m;

        // Act
        budgetManager.SetBudget(expectedBudget);

        // Assert
        Assert.Equal(expectedBudget, budgetManager.GetBudget());
    }

    [Fact]
    public void Test_AddExpense_UpdatesExpensesCorrectly()
    {
        // Arrange
        var budgetManager = new BudgetManager();
        budgetManager.SetBudget(1000m);
        string description = "Food";
        decimal amount = 200m;

        // Act
        budgetManager.AddExpense(description, amount);

        // Assert
        Assert.Equal(amount, budgetManager.GetTotalExpenses());
        Assert.Contains((description, amount), budgetManager.GetExpenseList());
    }

    [Fact]
    public void Test_RemainingBudget_CalculatesCorrectly()
    {
        // Arrange
        var budgetManager = new BudgetManager();
        budgetManager.SetBudget(1000m);
        budgetManager.AddExpense("Food", 200m);
        budgetManager.AddExpense("Decorations", 300m);

        // Act
        decimal remainingBudget = budgetManager.GetRemainingBudget();

        // Assert
        Assert.Equal(500m, remainingBudget);
    }

    [Fact]
    public void Test_ExpenseList_AddsCorrectly()
    {
        // Arrange
        var budgetManager = new BudgetManager();
        budgetManager.SetBudget(1000m);
        budgetManager.AddExpense("Food", 200m);
        budgetManager.AddExpense("Decorations", 300m);

        // Act
        var expenseList = budgetManager.GetExpenseList();

        // Assert
        Assert.Equal(2, expenseList.Count);
        Assert.Contains(("Food", 200m), expenseList);
        Assert.Contains(("Decorations", 300m), expenseList);
    }
}

// Mocked BudgetManager class for testing purposes
public class BudgetManager
{
    private decimal budget = 0;
    private decimal expenses = 0;
    private List<(string Description, decimal Amount)> expenseList = new List<(string, decimal)>();

    public void SetBudget(decimal totalBudget)
    {
        budget = totalBudget;
    }

    public decimal GetBudget()
    {
        return budget;
    }

    public void AddExpense(string description, decimal amount)
    {
        expenseList.Add((description, amount));
        expenses += amount;
    }

    public decimal GetTotalExpenses()
    {
        return expenses;
    }

    public decimal GetRemainingBudget()
    {
        return budget - expenses;
    }

    public List<(string Description, decimal Amount)> GetExpenseList()
    {
        return expenseList;
    }
}