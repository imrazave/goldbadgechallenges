using Challenge1Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe_Console
{
    class ProgramUI
    {
        private MenuRepository _itemRepo = new MenuRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedItemList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option: \n" +
                    "1. Create New Item\n" +
                    "2. Display All Menu Items\n" +
                    "3. View Menu Items By Name\n" +
                    "4. Update Item\n" +
                    "5. Delete Item\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create New Item
                        CreateNewItem();
                        break;
                    case "2":
                        // View All Menu Items
                        DisplayAllItems();
                        break;
                    case "3":
                        // View Item By Name
                        ViewItemByName();
                        break;
                    case "4":
                        // Update Item
                        UpdateItem();
                        break;
                    case "5":
                        // Delete Item
                        DeleteItem();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new item
        private void CreateNewItem()
        {
            Menu newItem = new Menu();

            //Item Name
            Console.WriteLine("Enter the item name:");
            newItem.ItemName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the description of the item:");
            newItem.ItemDescription = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price of the item:");
            string priceAsString = Console.ReadLine();
            newItem.MealPrice = double.Parse(priceAsString);

            //Ingredients
            Console.WriteLine("Enter the ingredients of the item separated by commas (i.e: pickles, mustard, etc.)");
            newItem.MealIngredients = Console.ReadLine();

            //Meal Number
            Console.WriteLine("Enter the meal number you would like associated with the item");
            string stringMealNumber = Console.ReadLine();
            newItem.MealNumber = int.Parse(stringMealNumber);

            _itemRepo.AddItemToMenu(newItem);
        }

        // View all menu items
        private void DisplayAllItems()
        {
            Console.Clear();

            List<Menu> listofItems = _itemRepo.GetMenu();

            foreach(Menu item in listofItems)
            {
                Console.WriteLine($"Item Name: {item.ItemName}\n" +
                    $"Item Description: {item.ItemDescription}");
            }
        }

        // View item by name
        private void ViewItemByName()
        {
            Console.Clear();

            // Prompt user to provide an item name
            Console.WriteLine("Enter the name of the item you would like to see:");

            // Get the user's input
            string name = Console.ReadLine();

            // Find the content by that title
            Menu item = _itemRepo.GetItemByName(name);

            // Display said content if it isn't null
            if(item != null)
            {
                Console.WriteLine($"Item Name: {item.ItemName}\n" +
                    $"Item Description: {item.ItemDescription}\n" +
                    $"Item Price: {item.MealPrice}\n" +
                    $"Meal Number of Item: {item.MealNumber}\n" +
                    $"Ingredients in the Item: {item.MealIngredients}");
            } 
            else
            {
                Console.WriteLine("No item by that name exists");
            }


        }

        // Update item
        private void UpdateItem()
        {

        }

        // Delete item
        private void DeleteItem()
        {

        }

        //Seed method
        private void SeedItemList()
        {
            Menu hamburger = new Menu("Hamburger",1, "Beef patty on a bun", 2.99, "Beef, salt, wheat, water, pickles, onion, pepper, mustard, yeast");
            Menu cocacola = new Menu("Coca-Cola",2, "12oz can of coke", 0.99, "Water, High-Fructose Corn Syrup, Carbon Dioxide, Phosphoric Acid, Flavoring");
            Menu fries = new Menu("French Fries",3, "4oz serving of fries", 1.99, "Potatoes, Vegetable Oil, Salt");

            _itemRepo.AddItemToMenu(hamburger);
            _itemRepo.AddItemToMenu(cocacola);
            _itemRepo.AddItemToMenu(fries);
        }
    }
}
