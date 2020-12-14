using Challenge2Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Claims_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedClaimQueue();
            ClaimList();
        }

        //Claimlist
        private void ClaimList()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // See all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        // Take care of the next claim
                        HandleNextClaim();
                        break;
                    case "3":
                        // Enter a new claim
                        CreateNewClaim();
                        break;
                    case "4":
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

        // Create new claim
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            // ClaimID
            Console.WriteLine("Enter the Claim ID:");
            string stringId = Console.ReadLine();
            newClaim.ClaimID = int.Parse(stringId);

            // ClaimType
            Console.WriteLine("Enter the Claim Type Number: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.ClaimType = (ClaimTypes)typeAsInt;

            // Description
            Console.WriteLine("Enter a description of the claim:");
            newClaim.Description = Console.ReadLine();

            // Claim Amount
            Console.WriteLine("Enter the monetary value of the claim:");
            string stringAmount = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(stringAmount);

            // Date of Incident
            Console.WriteLine("Enter the date of the claim incident in YYYY-MM-DD format:");
            string stringIncident = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(stringIncident);

            // Date of Claim
            Console.WriteLine("Enter the date of the claim in YYYY-MM-DD format:");
            string stringClaim = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(stringClaim);

            // Is Claim Valid?
            int claimDays = (newClaim.DateOfClaim - newClaim.DateOfIncident).Days;
            if (claimDays <= 30)
            {
                newClaim.IsValid = true;
                Console.WriteLine("The claim is valid.");
            }
            else
            {
                newClaim.IsValid = false;
                Console.WriteLine("The claim is not valid");
            }

            _claimRepo.AddClaimToQueue(newClaim);

        }

        // See all claims
        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claim> queueOfClaims = _claimRepo.GetClaims();

            Console.WriteLine($"{"ClaimID",-10}{"Type",-10}{"Description",-25}{"Amount",-12}{"DateOfAccident",-15}{"DateOfClaim",-15}{"IsValid",-10}");

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID,-10}{claim.ClaimType,-10}{claim.Description,-25}{String.Format("{0:C}", Convert.ToInt32(claim.ClaimAmount)),-12}{claim.DateOfIncident.ToShortDateString(),-15}{claim.DateOfClaim.ToShortDateString(),-15}{claim.IsValid,-10}");
            }
        }

        // Take care of next claim
        private void HandleNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.GetClaims();
            Claim tempClaim = queueOfClaims.Peek();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine($"ClaimID: {tempClaim.ClaimID}\n" +
                $"Type: {tempClaim.ClaimType}\n" +
                $"Description: {tempClaim.Description}\n" +
                $"Amount: {String.Format("{0:C}", Convert.ToInt32(tempClaim.ClaimAmount))}\n" +
                $"DateOfAccident: {tempClaim.DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {tempClaim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {tempClaim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string claimResponse = Console.ReadLine().ToLower();
            switch (claimResponse)
            {
                case "y":
                    RemoveNextQueueClaim();
                    break;
                case "n":
                    break;
            }
            Console.Clear();

        }
        public void RemoveNextQueueClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();
            claimQueue.Dequeue();
            Console.WriteLine("The claim has been successfully removed from queue. Press any key to continue...\n");
            Console.ReadKey();
        }

        //Seed Method

        private void SeedClaimQueue()
        {
            Claim claim1 = new Claim(1, ClaimTypes.Car, "Car accident on 465.", 400.00, Convert.ToDateTime("2018/4/27"), Convert.ToDateTime("2018/4/25"), true);
            Claim claim2 = new Claim(2, ClaimTypes.Home, "House fire in kitchen.", 4000.00, Convert.ToDateTime("2018/4/12"), Convert.ToDateTime("2018/4/11"), true);
            Claim claim3 = new Claim(3, ClaimTypes.Theft, "Stolen pancakes.", 4.00, Convert.ToDateTime("2018/6/01"), Convert.ToDateTime("2018/4/27"), false);

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
        }

    }
}
