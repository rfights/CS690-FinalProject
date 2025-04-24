using System;
using System.Collections.Generic;
using Xunit;

namespace FamilyReunionAppTests
{
    public class MealMenuManagerTestsTest
    {
        [Fact]
        public void AddMeal_ShouldAddMealToMenu()
        {
            // Arrange
            var mealMenuManager = new MealMenuManager();
            var meal = new Meal { Name = "Pasta", Description = "Delicious pasta with marinara sauce" };

            // Act
            mealMenuManager.AddMeal(meal);

            // Assert
            Assert.Contains(meal, mealMenuManager.GetMeals());
        }

        [Fact]
        public void RemoveMeal_ShouldRemoveMealFromMenu()
        {
            // Arrange
            var mealMenuManager = new MealMenuManager();
            var meal = new Meal { Name = "Salad", Description = "Fresh garden salad" };
            mealMenuManager.AddMeal(meal);

            // Act
            mealMenuManager.RemoveMeal(meal);

            // Assert
            Assert.DoesNotContain(meal, mealMenuManager.GetMeals());
        }

        [Fact]
        public void GetMeals_ShouldReturnAllMeals()
        {
            // Arrange
            var mealMenuManager = new MealMenuManager();
            var meal1 = new Meal { Name = "Burger", Description = "Juicy beef burger" };
            var meal2 = new Meal { Name = "Pizza", Description = "Cheese pizza with toppings" };
            mealMenuManager.AddMeal(meal1);
            mealMenuManager.AddMeal(meal2);

            // Act
            var meals = mealMenuManager.GetMeals();

            // Assert
            Assert.Contains(meal1, meals);
            Assert.Contains(meal2, meals);
        }

        [Fact]
        public void AddMeal_ShouldThrowExceptionForNullMeal()
        {
            // Arrange
            var mealMenuManager = new MealMenuManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => mealMenuManager.AddMeal(null));
        }
    }

    // Mock classes for testing
    public class MealMenuManager
    {
        private readonly List<Meal> _meals = new List<Meal>();

        public void AddMeal(Meal? meal)
        {
            if (meal == null) throw new ArgumentNullException(nameof(meal));
            _meals.Add(meal);
        }

        public void RemoveMeal(Meal meal)
        {
            _meals.Remove(meal);
        }

        public List<Meal> GetMeals()
        {
            return _meals;
        }
    }

    public class Meal
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}