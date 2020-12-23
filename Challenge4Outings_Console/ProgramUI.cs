using Challenge4Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4Outings_Console
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedOutingsList();
            Menu();
        }

        // Menu

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Menu:\t\n" +
                    "1. Display a list of all outings.\n" +
                    "2. Add individual outings to the list.\n" +
                    "3. Display the combined cost for all outings.\n" +
                    "4. Display outing costs by outing type. \n" +
                    "5. Exit");

                // Collect the user's input
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Display a list of all outings
                        DisplayAllOutings();
                        break;
                    case "2":
                        // Add individual outings to the list
                        AddOutingToList();
                        break;
                    case "3":
                        // Display the combined cost for all outings
                        DisplayCostForAllOutings();
                        break;
                    case "4":
                        // Display outing costs by outing type
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Display a list of all outings 
        private void DisplayAllOutings()
        {
            Console.Clear();

            SortedList<DateTime, Outing> listOfOutings = _outingsRepo.GetOutings();

            Console.WriteLine("Date     Outing");
            foreach (var outingEntry in listOfOutings)
            {
                Console.WriteLine($"{outingEntry.Value.Date}\t{outingEntry.Value.EventType}");
            }
        }
        
        // Add individual outings to the list
        private void AddOutingToList()
        {
            Console.Clear();
            Outing outing = new Outing();

            // Get the Event Type
            Console.WriteLine("Enter the Event Number: \n" +
            "1. Golf \n" +
            "2. Bowling \n" +
            "3. Amusement Park \n" +
            "4. Concert");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            outing.EventType = (OutingTypes)typeAsInt;

            // Get the number of people who attended
            Console.WriteLine("Enter the number of people who attended the event");
            string numStringPeople = Console.ReadLine();
            outing.NumberOfPeople = int.Parse(numStringPeople);

            // Get the date of the event
            Console.WriteLine("Enter the date of the event");
            string stringEvent = Console.ReadLine();
            outing.Date = DateTime.Parse(stringEvent);

            // Cost Per Person
            Console.WriteLine("Enter the cost per person for the event (do not enter a dollar sign)");
            string PPCost = Console.ReadLine();
            outing.PerPersonCost = decimal.Parse(PPCost);

            //Event Cost
            outing.TotalEventCost = (outing.PerPersonCost * outing.NumberOfPeople);

            _outingsRepo.AddOutingToList(outing);

        }

        // Display the combined cost for all outings

        private void DisplayCostForAllOutings()
        {
            Console.WriteLine($"{"The total cost for all outings is: $"}{_outingsRepo.GetTotalCost()}");
        }
        
        // Display outing costs by outing type

        private void DisplayCostByOutingType()
        {
            Console.WriteLine("What type of outing would you like to see the total cost for?");
        }

        
    }
}
