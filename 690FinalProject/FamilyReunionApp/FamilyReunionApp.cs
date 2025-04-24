using System;
using System.Collections.Generic;
using System.IO; 
using FamilyReunionAppNamespace; 

// This program is a simple console application to manage a family reception.
// It allows users to manage guest lists, menu items, allergies, venue information, and budget.
// The program is structured with a main menu and submenus for each functionality.

// Use cases
// UC1: Manage guest list
// the user navigates to the "Guest List" tab
// the user can view the current list of guests on this page
// the ability to add a new guest by selecting the "add" option, entering their name, confirming the addition, and seeing the updated list
// the ability to remove a guest by selecting the "remove" option, entering their name, confirming the removal, and seeing the updated list

// UC2: Manage menu and allergies sub-menu 
// the user should be able to navigate to the menu tab
// The user can view the current menu list on this page
// the ability to add a new dish by selecting the "add" option, entering the dish name, the person bringing it, and any allergy information
// the ability to remove a dish by selecting the "remove" option, entering the dish name, and confirming the removal
// the ability to view the allergies page, which will show all the dishes and their allergy information

// UC3: Manage the venue
// the user should be able to navigate to the venue tab
// ability to view all the information about the venue in the tab
// user should be able to add a note to the venue information which will show up on the main page in a new block of text
// the ability to remove a note by selecting the "remove" option, entering the number of the note, and confirming the removal

// UC4: Manage budget
// the user should be able to navigate to the budget tab
// in here should be a view of the expenses as a table with the description and amount of each expense listed and the remaining budget
// the user will have the ability to set the total budget in this tab, which will be saved in the budget variable
// the user will have the ability to view the remaining budget, which will be calculated by subtracting the total expenses from the total budget
// the ability to add an expense to the budget tracker, which will be added to the list of expenses and the remaining budget will be updated accordingly
// the ability to view all expenses in a table format, with the description and amount of each expense listed

// new features: ability to save the budget report to a file using the FileSaver class

namespace FamilyReunionAppNamespace
{
    public class FamilyReunionApp
    {
        // Class implementation
    }
}

class GuestManager
{
    private List<string> guests = new List<string>();

    public void ManageGuestList()
    {
        int selectedIndex = 0;
        string[] menuOptions = {
            "1. Add Guest",
            "2. Remove Guest",
            "3. Back"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Guest List:");
            foreach (var guest in guests)
            {
                Console.WriteLine("- " + guest);
            }
            Console.WriteLine("\n-------------------");

            // Display the menu with the selected option highlighted
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected option
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            // Read user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length; // Move up
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % menuOptions.Length; // Move down
            }
            else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= '3')
            {
                int choice = keyInfo.Key == ConsoleKey.Enter ? selectedIndex + 1 : keyInfo.KeyChar - '0';

                if (choice == 1)
                {
                    Console.Write("Enter guest name: ");
                    string name = Console.ReadLine() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        guests.Add(name);
                        Console.WriteLine($"{name} has been added to the guest list.");
                    }
                    else
                    {
                        Console.WriteLine("Guest name cannot be empty. Please try again.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    if (guests.Count == 0)
                    {
                        Console.WriteLine("There are no names to remove from the list.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    while (true)
                    {
                        Console.Write("Enter guest name to remove (or type 'cancel' to go back): ");
                        string name = Console.ReadLine() ?? string.Empty;

                        if (name.ToLower() == "cancel")
                        {
                            Console.WriteLine("Operation canceled.");
                            break;
                        }

                        if (guests.Remove(name))
                        {
                            Console.WriteLine($"{name} has been removed from the guest list.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{name} not found in the guest list. Please try again.");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    break; // Exit the guest list menu
                }
            }
        }
    }
}

class MenuManager
{
    private Dictionary<string, string> menu = new Dictionary<string, string>();
    private Dictionary<string, string> allergies = new Dictionary<string, string>();

    public void ManageMenuAndAllergies()
    {
        int selectedIndex = 0;
        string[] menuOptions = {
            "1. Add Dish",
            "2. View Allergies",
            "3. Back"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu and Allergies:");
            foreach (var item in menu)
            {
                string allergens = allergies.GetValueOrDefault(item.Key, "None");
                Console.WriteLine($"{item.Key} - {item.Value} (Allergies: {allergens})");
            }
            Console.WriteLine("\n-------------------");

            // Display the menu with the selected option highlighted
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected option
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            // Read user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length; // Move up
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % menuOptions.Length; // Move down
            }
            else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= '3')
            {
                int choice = keyInfo.Key == ConsoleKey.Enter ? selectedIndex + 1 : keyInfo.KeyChar - '0';

                if (choice == 1)
                {
                    Console.Write("Enter dish name: ");
                    string dish = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter who is bringing the dish: ");
                    string person = Console.ReadLine() ?? string.Empty;
                    menu[dish] = person;

                    Console.Write("Enter allergies (or enter \"none\" if no allergens): ");
                    string allergyInfo = Console.ReadLine() ?? string.Empty;

                    if (!string.Equals(allergyInfo, "none", StringComparison.OrdinalIgnoreCase))
                    {
                        allergies[dish] = allergyInfo;
                    }
                    else
                    {
                        allergies.Remove(dish);
                    }
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Allergy Information:");
                    foreach (var item in allergies)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    break; // Exit the menu and allergies menu
                }
            }
        }
    }
}

class VenueManager
{
    private string venue = "Not Set";

    public void ManageVenueInformation()
    {
        int selectedIndex = 0;
        string[] menuOptions = {
            "1. Set Venue",
            "2. Add Note",
            "3. Back"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Venue Information:");
            Console.WriteLine("-------------------");
            Console.WriteLine(venue);
            Console.WriteLine("\n-------------------");

            // Display the menu with the selected option highlighted
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected option
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            // Read user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length; // Move up
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % menuOptions.Length; // Move down
            }
            else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= '3')
            {
                int choice = keyInfo.Key == ConsoleKey.Enter ? selectedIndex + 1 : keyInfo.KeyChar - '0';

                if (choice == 1)
                {
                    Console.Write("Enter new venue information: ");
                    venue = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Venue information updated successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter a note to add to the venue information (or type 'cancel' to cancel): ");
                    string note = Console.ReadLine() ?? string.Empty;
                    if (note.ToLower() == "cancel")
                    {
                        Console.WriteLine("Note addition canceled.");
                    }
                    else
                    {
                        venue += $"\n- {note}";
                        Console.WriteLine("Note added successfully.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    break; // Exit the venue information menu
                }
            }
        }
    }
}

class BudgetManager
{
    private decimal budget = 0;
    private decimal expenses = 0;
    private List<(string Description, decimal Amount)> expenseList = new List<(string, decimal)>();
    private const string BudgetFilePath = "budget_report.txt";

    public void ManageBudget()
    {
        LoadBudgetFromFile();

        int selectedIndex = 0;
        string[] menuOptions = {
            "1. Set Budget",
            "2. Add Expense",
            "3. Back"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Total Budget: ${budget}");
            Console.WriteLine($"Expenses: ${expenses}");
            Console.WriteLine($"Remaining Budget: ${budget - expenses}");
            Console.WriteLine("\nExpense List:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Description                 | Amount         |");
            Console.WriteLine("-------------------------------------------------");

            foreach (var expense in expenseList)
            {
                Console.WriteLine($"| {expense.Description.PadRight(25)} | ${expense.Amount.ToString("F2").PadLeft(12)} |");
            }
            Console.WriteLine("-------------------------------------------------");

            // Display the menu with the selected option highlighted
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected option
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            // Read user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length; // Move up
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % menuOptions.Length; // Move down
            }
            else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= '3')
            {
                int choice = keyInfo.Key == ConsoleKey.Enter ? selectedIndex + 1 : keyInfo.KeyChar - '0';

                if (choice == 1)
                {
                    Console.Write("Enter total budget: ");
                    string? input = Console.ReadLine();
                    if (!decimal.TryParse(input, out decimal totalBudget))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    budget = totalBudget;
                    Console.WriteLine("Total budget updated successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter expense description: ");
                    string description = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter expense amount: ");
                    string? input = Console.ReadLine();
                    if (!decimal.TryParse(input, out decimal amount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    expenseList.Add((description, amount));
                    expenses += amount;
                    Console.WriteLine("Expense added successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    SaveBudgetToFile();
                    Console.WriteLine("Budget saved successfully. Exiting...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break; // Exit the budget menu
                }
            }
        }
    }

    private void SaveBudgetToFile()
    {
        using (StreamWriter writer = new StreamWriter(BudgetFilePath))
        {
            writer.WriteLine($"Total Budget: {budget}");
            writer.WriteLine($"Expenses: {expenses}");
            writer.WriteLine($"Remaining Budget: {budget - expenses}");
            writer.WriteLine("\nExpense List:");
            foreach (var expense in expenseList)
            {
                writer.WriteLine($"{expense.Description}: ${expense.Amount}");
            }
        }
    }

    private void LoadBudgetFromFile()
    {
        if (File.Exists(BudgetFilePath))
        {
            string[] lines = File.ReadAllLines(BudgetFilePath);
            if (lines.Length > 0)
            {
                decimal.TryParse(lines[0].Split(':')[1].Trim(), out budget);
                decimal.TryParse(lines[1].Split(':')[1].Trim(), out expenses);

                expenseList.Clear();
                for (int i = 4; i < lines.Length; i++) // Skip header lines
                {
                    string[] parts = lines[i].Split(':');
                    if (parts.Length == 2 && decimal.TryParse(parts[1].Trim().TrimStart('$'), out decimal amount))
                    {
                        expenseList.Add((parts[0].Trim(), amount));
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Create instances of managers
        var guestManager = new GuestManager();
        var menuManager = new MenuManager();
        var venueManager = new VenueManager();
        var budgetManager = new BudgetManager();

        int selectedIndex = 0; // Tracks the currently selected menu option
        string[] menuOptions = {
            "1. Manage Guest List",
            "2. Manage Menu and Allergies",
            "3. Manage Venue Information",
            "4. Manage Budget",
            "5. Exit"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Family Reunion App");
            Console.WriteLine("-------------------");

            // Display the menu with the selected option highlighted
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight selected option
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            // Read user input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length; // Move up
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % menuOptions.Length; // Move down
            }
            else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.KeyChar >= '1' && keyInfo.KeyChar <= '5')
            {
                // Handle selection
                int choice = keyInfo.Key == ConsoleKey.Enter ? selectedIndex + 1 : keyInfo.KeyChar - '0';

                if (choice == 1)
                {
                    guestManager.ManageGuestList();
                }
                else if (choice == 2)
                {
                    menuManager.ManageMenuAndAllergies();
                }
                else if (choice == 3)
                {
                    venueManager.ManageVenueInformation();
                }
                else if (choice == 4)
                {
                    budgetManager.ManageBudget();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                }
            }
        }
    }
}
