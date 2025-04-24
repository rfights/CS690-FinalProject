using System;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionAppTests
{
    public class MenuManagerTests
    {
        [Fact]
        public void Test_AddDish_AddsDishToMenu()
        {
            var menuManager = new MenuManager();
            string dishName = "Pasta";
            string person = "Alice";

            menuManager.AddDish(dishName, person);

            Assert.Contains(dishName, menuManager.GetMenu());
        }

        [Fact]
        public void Test_ViewAllergies_ReturnsCorrectAllergyInfo()
        {
            var menuManager = new MenuManager();
            string dishName = "Pasta";
            string allergyInfo = "Gluten";
            menuManager.AddDish(dishName, "Alice");
            menuManager.AddAllergy(dishName, allergyInfo);

            var allergies = menuManager.GetAllergies();

            Assert.Equal(allergyInfo, allergies[dishName]);
        }
    }
}