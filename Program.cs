using System;
using System.Collections.Generic;

class Program
{
    private static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Food Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintFoodItems();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void AddFoodItem()
    {
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();

        Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
        string category = Console.ReadLine();

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Press Enter to return to the menu.");
            Console.ReadLine();
            return;
        }

        Console.Write("Enter expiration date (MM/DD/YYYY): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
        {
            Console.WriteLine("Invalid date format. Press Enter to return to the menu.");
            Console.ReadLine();
            return;
        }

        inventory.Add(new FoodItem(name, category, quantity, expirationDate));
        Console.WriteLine("Food item added successfully! Press Enter to return to the menu.");
        Console.ReadLine();
    }

    private static void DeleteFoodItem()
    {
        PrintFoodItems();

        Console.Write("Enter the number of the food item to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > inventory.Count)
        {
            Console.WriteLine("Invalid selection. Press Enter to return to the menu.");
            Console.ReadLine();
            return;
        }

        inventory.RemoveAt(index - 1);
        Console.WriteLine("Food item deleted successfully! Press Enter to return to the menu.");
        Console.ReadLine();
    }

    private static void PrintFoodItems()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
        }
        else
        {
            Console.WriteLine("Current Food Items:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }
        }
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}
