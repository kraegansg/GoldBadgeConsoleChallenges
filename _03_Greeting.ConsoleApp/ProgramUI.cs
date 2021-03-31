using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_Greeting.Repository;

namespace _03_Greeting.ConsoleApp
{
    class ProgramUI
    {
        private GreetingRepository _contentRepo = new GreetingRepository();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance email greeting system\n");
                Console.WriteLine("Select a menu option:\n" +
                    "1) Create new customer entry\n" +
                    "2) View full customer greeting list in alphabetical order\n" +
                    "3) Search a customer profile by name\n" +
                    "4) Update customer profile\n" +
                    "5) Delete customer from greeting list\n" +
                    "6) Prepare an email\n" +
                    "7) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewContent();
                        break;
                    case "2":
                        ViewAllContent();
                        break;
                    case "3":
                        ViewContentByName();
                        break;
                    case "4":
                        UpdateCustomerContent();
                        break;
                    case "5":
                        DeleteCustomerContent();
                        break;
                    case "6":
                        PrepareEmailMenu();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 - 6");
                        break;
                }

                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewContent() // CREATE NEW CUSTOMER CONTENT
        {
            Console.Clear();
            CustomerContent newContent = new CustomerContent();

            Console.WriteLine("Enter customer first name:");
            newContent.FirstName = Console.ReadLine();
            Console.WriteLine("Enter customer last name:");
            newContent.LastName = Console.ReadLine();
            Console.WriteLine("Enter customer type (1-3):\n" +
                "1) Current\n" +
                "2) Past\n" +
                "3) Potential");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newContent.TypeOfCustomer = (CustomerType)typeAsInt;

            Console.WriteLine("\nEmail text for this customer:");
            if (typeAsInt == 1)
            {
                Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                newContent.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }
            else if (typeAsInt == 2)
            {
                Console.WriteLine("It's been a long time since we've heard from you, we want you back.");
                newContent.Email = "It's been a long time since we've heard from you, we want you back.";
            }
            else if (typeAsInt == 3)
            {
                Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                newContent.Email = "We currently have the lowest rates on Helicopter Insurance!";
            }
            else
            {
                Console.WriteLine("Could not generate email text due to input error.");
            }

            _contentRepo.AddContentToList(newContent);

            bool wasAdded = _contentRepo.AddContentToList(newContent);

            if (wasAdded)
            {
                Console.WriteLine("\nCustomer profile successfully added.");
            }
            else
            {
                Console.WriteLine("\nCould not add customer profile.");

            }

        }

        private void ViewAllContent()  // VIEW ALL CONTENT IN ALPHABETICAL ORDER
        {
            Console.Clear();
            List<CustomerContent> listOfContent = _contentRepo.GetContentList().OrderBy(order => order.LastName).ToList();

            Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", "FirstName", "LastName", "Type", "Email");

            foreach (CustomerContent content in listOfContent)
            {
                Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", $"{content.FirstName}", $"{content.LastName}", $"{content.TypeOfCustomer}", $"{content.Email}");
            }

        }

        private void ViewContentByName() // SEARCH CUSTOMER BY NAME
        {
            Console.Clear();
            Console.WriteLine("\nEnter the full name of the customer to access their profile:");

            string fullName = Console.ReadLine().ToLower();

            CustomerContent content = _contentRepo.GetCustomerByName(fullName);

            if (content != null)
            {
                Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", "FirstName", "LastName", "Type", "Email");
                Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", $"{content.FirstName}", $"{content.LastName}", $"{content.TypeOfCustomer}", $"{content.Email}");
            }
            else
            {
                Console.WriteLine("No customer by that name.");
            }

        }

        private void UpdateCustomerContent() // UPDATE CUSTOMER INFO 
        {
            Console.Clear();
            ViewAllContent();

            Console.WriteLine("\nEnter the full name of the customer to edit their profile:");

            string oldName = Console.ReadLine().ToLower();

            CustomerContent newContent = new CustomerContent();

            Console.WriteLine("Enter customer first name:");
            newContent.FirstName = Console.ReadLine();
            Console.WriteLine("Enter customer last name:");
            newContent.LastName = Console.ReadLine();
            Console.WriteLine("Enter customer type (1-3):\n" +
                "1) Current\n" +
                "2) Past\n" +
                "3) Potential");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newContent.TypeOfCustomer = (CustomerType)typeAsInt;

            Console.WriteLine("\nEmail text for this customer:");
            if (typeAsInt == 1)
            {
                Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                newContent.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }
            else if (typeAsInt == 2)
            {
                Console.WriteLine("It's been a long time since we've heard from you, we want you back.");
                newContent.Email = "It's been a long time since we've heard from you, we want you back.";
            }
            else if (typeAsInt == 3)
            {
                Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                newContent.Email = "We currently have the lowest rates on Helicopter Insurance!";
            }
            else
            {
                Console.WriteLine("Could not generate email text due to input error.");
            }

            _contentRepo.AddContentToList(newContent);

            bool wasUpdated = _contentRepo.UpdateCustomerContent(oldName, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("\nCustomer profile successfully updated.");
            }
            else
            {
                Console.WriteLine("\nCould not update customer profile.");

            }

        }

        private void DeleteCustomerContent()  // DELETE CUSTOMER INFORMATION 
        {
            Console.Clear();
            ViewAllContent();

            Console.WriteLine("\nEnter the full name of the customer to delete their profile:");

            string input = Console.ReadLine().ToLower();

            bool wasDeleted = _contentRepo.RemoveGreetingContent(input);

            if (wasDeleted)
            {
                Console.WriteLine("The customer profile was successfully deleted");
            }
            else
            {
                Console.WriteLine("The customer profile could not be deleted.");
            }
        }

        private void PrepareEmailMenu() // CREATE EMAIL MENU
        {
            Console.Clear();
            bool emailConstruct = true;
            while (emailConstruct)
            {
                Console.WriteLine("What kind of email would you like to send:\n" +
                    "1) Email all customers\n" +
                    "2) Email single customer\n" +
                    "3) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateMassEmail();
                        break;
                    case "2":
                        CreateSingleEmail();
                        break;
                    case "3":
                        Console.WriteLine("Returning to Main Menu");
                        emailConstruct = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 -3");
                        break;
                }

            }

        }

        private void CreateMassEmail()
        {
            Console.Clear();
            Console.WriteLine("\nPress any key to send an email to every customer type...");
            Console.ReadKey();
            Console.WriteLine("\nError 482 - Komodo Insurance lacks the infrastructure to email customers as this time.");
        }

        private void CreateSingleEmail()
        {
            Console.Clear();
            ViewAllContent();
            Console.WriteLine("\nEnter the full name of the customer you wish to email:");

            string fullName = Console.ReadLine().ToLower();

            CustomerContent content = _contentRepo.GetCustomerByName(fullName);
            if (content != null)
            {
                Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", "FirstName", "LastName", "Type", "Email");
                Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -20}", $"{content.FirstName}", $"{content.LastName}", $"{content.TypeOfCustomer}", $"{content.Email}");
            }
            else
            {
                Console.WriteLine("No customer by that name.");
            }

            Console.WriteLine("\nPress any key to send an email to the above customer...");
            Console.ReadKey();
            Console.WriteLine("\nError 482 - Komodo Insurance lacks the infrastructure to email customers as this time.");
        }


        private void SeedContentList()
        {
            CustomerContent jakeSmith = new CustomerContent("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!", "Jake Smith");
            CustomerContent jamesSmith = new CustomerContent("James", "Smith", CustomerType.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.", "James Smith");
            CustomerContent janeSmith = new CustomerContent("Jane", "Smith", CustomerType.Past, "It's been a long time since we've heard from you, we want you back.", "Jane Smith");
            _contentRepo.AddContentToList(jakeSmith);
            _contentRepo.AddContentToList(jamesSmith);
            _contentRepo.AddContentToList(janeSmith);
        }

    }
}