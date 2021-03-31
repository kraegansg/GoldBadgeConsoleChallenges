using _02_Claims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.ConsoleApp
{
    public class ProgramUI
    {
        private ClaimsRepository _contentRepo = new ClaimsRepository();

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
                Console.WriteLine("Komodo Claims Dept - Claim Menu");
                Console.WriteLine("Select a menu option:\n" +
                    "1) See all claims\n" +
                    "2) Take care of next claim\n" +
                    "3) Enter a new claim\n" +
                    "4) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("\nGoodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        // View all claims
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<ClaimsContent> queueOfContent = _contentRepo.GetClaimsContent();

            Console.WriteLine("{0,-8} {1, -10} {2, -25} {3, -10} {4, -20} {5, -20}", "ClaimID", "Type", "Description", "Amount", "Incident Date", "Claim Date");

            foreach (ClaimsContent content in queueOfContent)
            {

                Console.WriteLine("{0,-8} {1, -10} {2, -25} {3, -10} {4, -20} {5, -20}", $"{content.ClaimID}", $"{content.TypeOfClaim}", $"{content.Description}", $"${content.ClaimAmount}", $"{content.DateOfIncident.ToString("dd/MM/yyyy")}", $"{content.DateOfClaim.ToString("dd/MM/yyyy")}");

            }
        }
        // Take care of next claim
        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled: ");


            Queue<ClaimsContent> newList = _contentRepo.GetClaimsContent();
            ClaimsContent claimsQueue = newList.Peek();

            Console.WriteLine($"Claim ID: {claimsQueue.ClaimID}\n" +
                $" Type of Claim: {claimsQueue.TypeOfClaim}\n" +
                $" Description: {claimsQueue.Description}\n" +
                $" Claim Amount: ${claimsQueue.ClaimAmount}\n" +
                $" Date of Incident: {claimsQueue.DateOfIncident.ToString("dd/MM/yyyy")}\n" +
                $" Date of Claim: {claimsQueue.DateOfClaim.ToString("dd/MM/yyyy")}\n" +
                $" isValid: {claimsQueue.IsValid}");

            Console.WriteLine("\n\nDo you want to deal with this claim now(y/n)?");

            string userInput = Console.ReadLine();
            if (userInput.StartsWith("y"))
            {
                newList.Dequeue();
                Console.WriteLine("\nClaim pulled successfully");
            }

            else if (userInput.StartsWith("n"))
            {
                Console.WriteLine("Claim returned to queue");
            }
            else
            {
                Console.WriteLine("Please enter either y or n");
            }


        }
        // Add new claim
        private void AddNewClaim()
        {
            Console.Clear();
            ClaimsContent newClaimsContent = new ClaimsContent();

            Console.WriteLine("Please enter new claim data:\n");
            Console.WriteLine("Enter the new claim id: ");
            string newIdAsString = Console.ReadLine();
            newClaimsContent.ClaimID = int.Parse(newIdAsString);

            Console.WriteLine("Enter the claim type number (1-3):\n" +
               "1) Auto\n" +
               "2) Home\n" +
               "3) Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaimsContent.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Enter a claim description: ");
            newClaimsContent.Description = Console.ReadLine();

            Console.Write("Amount of damage: $");
            string dmgAmountAsString = Console.ReadLine();
            newClaimsContent.ClaimAmount = decimal.Parse(dmgAmountAsString);

            Console.WriteLine("Date of Incident (dd/mm/yyyy): ");
            string incidentDateAsString = Console.ReadLine();
            newClaimsContent.DateOfIncident = DateTime.Parse(incidentDateAsString);

            Console.WriteLine("Date of Claim (dd/mm/yyyy): ");
            string claimDateAsString = Console.ReadLine();
            newClaimsContent.DateOfClaim = DateTime.Parse(claimDateAsString);

            DateTime incidentDate = newClaimsContent.DateOfIncident;
            DateTime claimDate = newClaimsContent.DateOfClaim;
            TimeSpan timeSpan = claimDate - incidentDate;

            if (timeSpan.Days <= 30)
            {
                Console.WriteLine("\nThis claim is valid");
            }
            else
            {
                Console.WriteLine("\nThis claim is not valid due to being placed after 30 days from incident date.");
            }

            _contentRepo.AddContentToQueue(newClaimsContent);

        }

        //Seed method
        private void SeedContentList()
        {
            ClaimsContent firstClaim = new ClaimsContent(1, ClaimType.Auto, "Car accident on 465.", 400.00m, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"), true);
            ClaimsContent secondClaim = new ClaimsContent(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            ClaimsContent thirdClaim = new ClaimsContent(3, ClaimType.Theft, "Stolen pancakes", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            _contentRepo.AddContentToQueue(firstClaim);
            _contentRepo.AddContentToQueue(secondClaim);
            _contentRepo.AddContentToQueue(thirdClaim);
        }



    }


}
