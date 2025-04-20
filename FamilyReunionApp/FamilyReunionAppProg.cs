using System;
using System.Collections.Generic;

// This program is a simple console application to manage a family reception.
// It allows users to manage guest lists, menu items, allergies, venue information, and budget.
// The program is structured with a main menu and submenus for each functionality.

// Use cases
// UC1: Manage guest list
// the user navigates to the "Guest List" tab
// the user can view the current list of guests on this page
// the ability to add a new guest by selecting the "add" option, entering their name, confirming the addition, and seeing the updated list

// UC2: Manage menu and allergies sub-menu 
// the user should be able to navigate to the menu tab
// The user can view the current menu list on this page
// the ability to add a new dish by selecting the "add" option, entering the dish name, the person bringing it, and any allergy information
// the ability to view the allergies page, which will show all the dishes and their allergy information

// UC3: Manage the venue
// the user should be able to navigate to the venue tab
// ability to view all the information about the venue in the tab
// user should be able to add a note to the venue information which will show up on the main page in a new block of text

// UC4: Manage budget
// the user should be able to navigate to the budget tab
// in here should be a view of the expenses as a table with the description and amount of each expense listed and the remaining budget
// the user will have the ability to set the total budget in this tab, which will be saved in the budget variable
// the user will have the ability to view the remaining budget, which will be calculated by subtracting the total expenses from the total budget
// the ability to add an expense to the budget tracker, which will be added to the list of expenses and the remaining budget will be updated accordingly
// the ability to view all expenses in a table format, with the description and amount of each expense listed

class FamilyReceptionApp
{
    static List<string> guests = new List<string>();
    static Dictionary<string, string> menu = new Dictionary<string, string>();
    static Dictionary<string, string> allergies = new Dictionary<string, string>();
    static string venue = "Not Set";
    static decimal budget = 0;
    static decimal expenses = 0;
    static List<(string Description, decimal Amount)> expenseList = new List<(string, decimal)>();

    static void Main()
    {
        int selectedTab = 0;
        string[] tabs = { "Guest List", "Menu", "Venue Info", "Budget", "Exit" };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Family Reception Organizer");
            Console.WriteLine();

            // Display tabs
            for (int i = 0; i < tabs.Length; i++)
            {
                if (i == selectedTab)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // Highlight the selected tab
                    Console.Write($"[{tabs[i]}] ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{tabs[i]} ");
                }
            }

            Console.WriteLine("\n\nUse Left/Right Arrow keys to navigate, Enter to select.");

            // Handle user input for navigation
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.RightArrow)
            {
                selectedTab = (selectedTab + 1) % tabs.Length; // Move to the next tab
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                selectedTab = (selectedTab - 1 + tabs.Length) % tabs.Length; // Move to the previous tab
            }
            else if (key == ConsoleKey.Enter)
            {
                // Call the corresponding method based on the selected tab
                switch (selectedTab)
                {
                    case 0:
                        ManageGuestList();
                        break;
                    case 1:
                        ManageMenuAndAllergies();
                        break;
                    case 2:
                        SetVenueInformation();
                        break;
                    case 3:
                        ManageBudget();
                        break;
                    case 4:
                        return; // Exit the application
                }
            }
        }
    }

    static void ManageGuestList()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Guest List:");
            foreach (var guest in guests)
            {
                Console.WriteLine("- " + guest);
            }
            Console.WriteLine("\n1. Add Guest");
            Console.WriteLine("2. Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter guest name: ");
                string name = Console.ReadLine();
                guests.Add(name);
                Console.WriteLine($"{name} has been added to the guest list.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "2")
            {
                break; // Exit the guest list menu
            }
            else
            {
                Console.WriteLine("Invalid selection, please choose 1 or 2");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }

    static void ManageMenuAndAllergies()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu and Allergies:");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key} - {item.Value} (Allergies: {allergies.GetValueOrDefault(item.Key, "None")})");
            }
            Console.WriteLine("\n1. Add Dish");
            Console.WriteLine("2. View Allergies");
            Console.WriteLine("3. Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter dish name: ");
                string dish = Console.ReadLine();
                Console.Write("Enter who is bringing the dish: ");
                string person = Console.ReadLine();
                menu[dish] = person;

                Console.Write("Enter allergies (if any, separate by commas): ");
                string allergyInfo = Console.ReadLine();
                allergies[dish] = allergyInfo;
            }
            else if (choice == "2")
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
            else if (choice == "3")
            {
                break; // Exit the menu and allergies menu
            }
            else
            {
                Console.WriteLine("Invalid selection, please choose 1, 2, or 3");
                Console.ReadKey();
            }
            }
        }

    static void SetVenueInformation()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Venue Information:");
            Console.WriteLine("-------------------");
            Console.WriteLine(venue); // Display the current venue information
            Console.WriteLine("\n1. Set Venue");
            Console.WriteLine("2. Add Note");
            Console.WriteLine("3. Back");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter new venue information: ");
                venue = Console.ReadLine();
                Console.WriteLine("Venue information updated successfully.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (choice == "2")
            {
                Console.Write("Enter a note to add to the venue information (or type 'cancel' to cancel): ");
                string note = Console.ReadLine();
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
            else if (choice == "3")
            {
                break; // Exit the venue information menu
            }
            else
            {
                Console.WriteLine("Invalid selection, please choose 1, 2, or 3");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void ManageBudget()
    {
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

            // Display all expenses in a table format
            foreach (var expense in expenseList)
            {
                Console.WriteLine($"| {expense.Description.PadRight(25)} | ${expense.Amount.ToString("F2").PadLeft(12)} |");
            }
            Console.WriteLine("-------------------------------------------------");

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
                Console.Write("Enter expense description: ");
                string description = Console.ReadLine();
                Console.Write("Enter expense amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                // Add the expense to the list and update total expenses
                expenseList.Add((description, amount));
                expenses += amount;
            }
            else if (choice == "3")
            {
                break; // Exit the budget menu
            }
        }
    }
}

