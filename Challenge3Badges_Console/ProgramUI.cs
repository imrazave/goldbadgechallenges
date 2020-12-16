using Challenge3Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Badges_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Menu\t\n" +
                    "Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all badges.\n" +
                    "4. Exit");

                // Collect the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input
                switch (input)
                {
                    case "1":
                        // Add A Badge
                        AddABadge();
                        break;
                    case "2":
                        // Edit A Badge
                        EditABadge();
                        break;
                    case "3":
                        // List All Badges
                        ListAllBadges();
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

        // Create a new badge
        private void AddABadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            // Get the number of the badge
            Console.WriteLine("What is the number (only integers) on the badge:"); 
            string stringBadgeId = Console.ReadLine();
            newBadge.BadgeID = int.Parse(stringBadgeId);

            // Get the door number that they want to add access for
            Console.WriteLine("List a door that it needs access to:"); 
            string doorId = Console.ReadLine();
            newBadge.DoorName.Add(doorId);
            
            //_badgeRepo.AddDoorToBadge(newBadge.BadgeID, doorId);

            // See if the user wants to add another door to the badge
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Any other doors (y/n)?"); string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "y":
                        Console.WriteLine("List a door that it needs access to:"); string newDoorId = Console.ReadLine();
                        newBadge.DoorName.Add(newDoorId);
                        //_badgeRepo.AddDoorToBadge(newBadge.BadgeID, newDoorId);
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            }

            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        // Edit a badge
        private void EditABadge()
        {
            //Ask for the ID of the badge we want to update / Capture the badge ID

            Console.WriteLine("What is the badge number (only integers) to update?"); string stringBadgeId = Console.ReadLine();
            int badgeId = int.Parse(stringBadgeId);

            Badge badge = _badgeRepo.GetBadgeByID(badgeId);
            if (badge != null)
            {
                Console.WriteLine($"{badge.BadgeID}{" has access to door(s) "}{string.Join(" & ", badge.DoorName)}");

                Console.WriteLine($"What would you like to do? \n" +
                    $"1. Remove a door \n" +
                    $"2. Add a door \n" +
                    $"3. Remove all doors from the badge");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Remove a door
                        Console.WriteLine("Which door would you like to remove?"); string doorRemoveId = Console.ReadLine();
                        bool doorRemoved = _badgeRepo.RemoveOneDoorFromBadge(badgeId, doorRemoveId);
                        if (doorRemoved == true)
                        {
                            Console.WriteLine("Door removed.");
                        }
                        else
                        {
                            Console.WriteLine("Door not successfully removed");
                        }
                        break;
                    case "2":
                        // Add a door
                        Console.WriteLine("Which door would you like to add?"); string doorAddId = Console.ReadLine();
                        bool doorAdd = _badgeRepo.AddDoorToBadge(badge.BadgeID, doorAddId);
                        if (doorAdd == true)
                        {
                            Console.WriteLine($"Door added. \n\n" +
                                $"{badge.BadgeID},{" has access to door "}{string.Join(", ", badge.DoorName)}");
                        }
                        else
                        {
                            Console.WriteLine("Door not successfully added");
                        }
                        break;
                    case "3":
                        // Remove all doors from a badge
                        if (badge.DoorName.Count <= 0)
                        {
                            Console.WriteLine("There are no doors to remove from this badge");
                        }
                        else
                        {
                            _badgeRepo.RemoveAllDoorsFromBadge(badgeId);
                            Console.WriteLine($"All doors have been removed from badge {badgeId}.");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("The badge entered does not currently exist in the application");
            }
        }

        // List all badges

        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> dictionaryOfBadges = _badgeRepo.GetBadges();

            Console.WriteLine("Badge #    Door Access");
            foreach( var badgeEntry in dictionaryOfBadges)
            {
                Console.WriteLine($"{badgeEntry.Value.BadgeID}\t{string.Join(" ", badgeEntry.Value.DoorName)}");
            }
        }

        private void SeedBadgeDictionary()
        {
            List<string> doorstring1 = new List<string> {"A7"};
            Badge badge1 = new Badge(12345, doorstring1);
            List<string> doorstring2 = new List<string> {"A1","A4","B1","B2"};
            Badge badge2 = new Badge(22345, doorstring2);
            List<string> doorstring3 = new List<string> {"A4","A5"};
            Badge badge3 = new Badge(32345, doorstring3);

            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);
        }
    }
}
