using System;
using System.Collections.Generic;

// This program is a simple console application to manage a family reception.
// It allows users to manage guest lists, menu items, allergies, venue information, and budget.
// The program is structured with a main menu and submenus for each functionality.


class FamilyReceptionApp
{
    static List<string> guests = new List<string>();
    static Dictionary<string, string> menu = new Dictionary<string, string>();
    static Dictionary<string, string> allergies = new Dictionary<string, string>();
    static string venue = "Not Set";
    static decimal budget = 0;
    static decimal expenses = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Family Reception Organizer");
            Console.WriteLine("1. Manage Guest List");
            Console.WriteLine("2. Manage Menu and Allergies");
            Console.WriteLine("3. Set Venue Information");
            Console.WriteLine("4. Manage Budget");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageGuestList();
                    break;
                case "2":
                    ManageMenuAndAllergies();
                    break;
                case "3":
                    SetVenueInformation();
                    break;
                case "4":
                    ManageBudget();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageGuestList()
    {
        Console.Clear();
        Console.WriteLine("Guest List:");
        foreach (var guest in guests)
        {
            Console.WriteLine("- " + guest);
        }
        Console.WriteLine("\n1. Add Guest");
        Console.WriteLine("2. Remove Guest");
        Console.WriteLine("3. Back");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter guest name: ");
            string name = Console.ReadLine();
            guests.Add(name);
        }
        else if (choice == "2")
        {
            Console.Write("Enter guest name to remove: ");
            string name = Console.ReadLine();
            guests.Remove(name);
        }
    }

    static void ManageMenuAndAllergies()
    {
        Console.Clear();
        Console.WriteLine("Menu and Allergies:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key} - {item.Value} (Allergies: {allergies.GetValueOrDefault(item.Key, "None")})");
        }
        Console.WriteLine("\n1. Add Dish");
        Console.WriteLine("2. Remove Dish");
        Console.WriteLine("3. Back");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter dish name: ");
            string dish = Console.ReadLine();
            Console.Write("Enter who is bringing it: ");
            string person = Console.ReadLine();
            menu[dish] = person;

            Console.Write("Enter allergies (if any, separate by commas): ");
            string allergyInfo = Console.ReadLine();
            allergies[dish] = allergyInfo;
        }
        else if (choice == "2")
        {
            Console.Write("Enter dish name to remove: ");
            string dish = Console.ReadLine();
            menu.Remove(dish);
            allergies.Remove(dish);
        }
    }

    static void SetVenueInformation()
    {
        Console.Clear();
        Console.WriteLine($"Current Venue: {venue}");
        Console.Write("Enter new venue: ");
        venue = Console.ReadLine();
    }

    static void ManageBudget()
    {
        Console.Clear();
        Console.WriteLine($"Total Budget: ${budget}");
        Console.WriteLine($"Expenses: ${expenses}");
        Console.WriteLine($"Remaining Budget: ${budget - expenses}");
        Console.WriteLine("\n1. Set Budget");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Back");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter total budget: ");
            budget = decimal.Parse(Console.ReadLine());
        }
        else if (choice == "2")
        {
            Console.Write("Enter expense amount: ");
            expenses += decimal.Parse(Console.ReadLine());
        }
    }
}

