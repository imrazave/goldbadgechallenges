using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Badges_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();

        // Create
        public void AddBadgeToDictionary(Badge newbadge)
        {
            _badgeDictionary.Add(newbadge.BadgeID, newbadge);
        }

        public bool AddDoorToBadge(int badgeId, string doorName)
        {
            //Find the badge
            Badge badge = GetBadgeByID(badgeId);

            if (badge == null)
            {
                return false;
            }

            int doorCount = badge.DoorName.Count;

            //Add the door to the badge
            badge.DoorName.Add(doorName);
            
            if (doorCount < badge.DoorName.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDictionary;
        }

        //Update
        public bool UpdateExistingBadge(int existingBadgeId, Badge updatedBadge)
        {
            //Find the badge
            Badge existingBadge = GetBadgeByID(existingBadgeId);

            //Update the badge
            if (existingBadge != null)
            {
                existingBadge.DoorName = updatedBadge.DoorName;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveAllDoorsFromBadge(int existingBadgeId)
        {
            Badge badge = GetBadgeByID(existingBadgeId);

            if(badge == null)
            {
                return false;
            }

            int doorCount = badge.DoorName.Count;

            badge.DoorName.Clear();

            if (doorCount > badge.DoorName.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveOneDoorFromBadge(int existingBadgeId, string doorName)
        {
            Badge badge = GetBadgeByID(existingBadgeId);

            if (badge == null)
            {
                return false;
            }

            int doorCount = badge.DoorName.Count;

            badge.DoorName.Remove(doorName);

            if (doorCount > badge.DoorName.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper Method
        public Badge GetBadgeByID(int badgeId)
        {
            foreach (KeyValuePair<int, Badge> entry in _badgeDictionary)
            {
                if (entry.Key == badgeId)
                {
                    return entry.Value;
                }
            }

            return null;
        }
    }
}
