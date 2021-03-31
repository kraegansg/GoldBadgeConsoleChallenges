using _01_Cafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe.ConsoleApp
{
    class ProgramUI
    {
        private MenuRepository _contentRepo = new MenuRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            // Menu console app should permit adding items, deleting items, and a view all items 
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Cafe Menu Editor");
                Console.WriteLine(
                    "Select Cafe Menu Option: \n" +
                    "1) Add Items To Cafe Menu\n" +
                    "2) View Cafe Menu\n" +
                    "3) Delete Items From Cafe Menu\n" +
                    "4) Exit Menu Editor");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1-4");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void AddMenuItem() // Add Items to Menu
        {
            Console.Clear();
            ViewMenu();
            MenuContent newMenuContent = new MenuContent();

            Console.WriteLine("Please enter the new item information:\n");
            Console.WriteLine("Enter the new menu item number: ");
            string newNumberAsString = Console.ReadLine();
            newMenuContent.Number = int.Parse(newNumberAsString);

            Console.WriteLine("Enter the new menu meal name: ");
            newMenuContent.Meal = Console.ReadLine();

            Console.WriteLine("Enter the new meal description: ");
            newMenuContent.Description = Console.ReadLine();

            Console.WriteLine("Enter the new meal ingredients: ");
            newMenuContent.Ingredients = Console.ReadLine();

            Console.Write("Enter the new meal price: $");
            string newPriceAsString = Console.ReadLine();
            newMenuContent.Price = decimal.Parse(newPriceAsString);


            //verify the new item was added
            Console.WriteLine("\nPress any key to submit new item");
            Console.ReadKey();
            Console.WriteLine("\nNew item succesfully added.");


            _contentRepo.AddMenuContent(newMenuContent);

        }

        private void ViewMenu() // View full menu 
        {
            Console.Clear();
            Console.WriteLine("Here is current the Komodo Cafe Menu:\n ");
            List<MenuContent> listofContent = _contentRepo.GetContentList();

            foreach (MenuContent content in listofContent)
            {
                Console.WriteLine($"Number: {content.Number}\n" +
                    $"Meal: {content.Meal}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price: ${content.Price}\n");
            }

        }

        private void DeleteMenuItem() // Delete item from menu
        {
            ViewMenu();

            Console.WriteLine("Please enter the name of the meal you would like removed:");

            string input = Console.ReadLine();

            bool wasDeleted = _contentRepo.RemoveItemFromMenu(input);

            // confirm if deleted

            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }

        }

        private void SeedContentList()
        {
            MenuContent sconeZone = new MenuContent(1, "The Scone Zone", "3 of our daily made scones. Ask server for today's variety.", "Ingredients vary due to daily scone options", 12m);
            MenuContent oneHotOmelete = new MenuContent(2, "One Hot Omelette", "Fluffy egg omelette, extra spicy.", "Eggs, butter, jalapeno pepper, bell pepper, onion, garlic, pepper, house-made hot sauce.", 14m);
            MenuContent komodoTea = new MenuContent(3, "Komodo Tea", "Organic senna tea sourced from farmers in India's Thar Desert.", " Organic Licorice Root, Organic Bitter Fennel Fruit, Organic Sweet Orange Peel, Organic Cinnamon Bark, Organic Coriander Fruit, Organic Ginger Rhizome, Organic Orange Peel Oil on Gum Arabic.", 3m);
            _contentRepo.AddMenuContent(sconeZone);
            _contentRepo.AddMenuContent(oneHotOmelete);
            _contentRepo.AddMenuContent(komodoTea);
        }

    }
}

