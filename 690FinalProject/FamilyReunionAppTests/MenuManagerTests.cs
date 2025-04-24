using System;
using Xunit;
using FamilyReunionApp;

namespace FamilyReunionApp
{
    public class MenuManager
    {
        private Dictionary<string, string> menu = new Dictionary<string, string>();
        private Dictionary<string, string> allergies = new Dictionary<string, string>();

        public void AddDish(string dishName, string person)
        {
            menu[dishName] = person;
        }

        public Dictionary<string, string> GetMenu()
        {
            return new Dictionary<string, string>(menu);
        }

        public void AddAllergy(string dishName, string allergyInfo)
        {
            allergies[dishName] = allergyInfo;
        }

        public Dictionary<string, string> GetAllergies()
        {
            return new Dictionary<string, string>(allergies);
        }
    }
}

namespace FamilyReunionApp
{
    public class MenuManager
    {
        private Dictionary<string, string> menu = new Dictionary<string, string>();
        private Dictionary<string, string> allergies = new Dictionary<string, string>();

        public void AddDish(string dishName, string person)
        {
            menu[dishName] = person;
        }

        public Dictionary<string, string> GetMenu()
        {
            return new Dictionary<string, string>(menu);
        }

        public void AddAllergy(string dishName, string allergyInfo)
        {
            allergies[dishName] = allergyInfo;
        }

        public Dictionary<string, string> GetAllergies()
        {
            return new Dictionary<string, string>(allergies);
        }
    }
}