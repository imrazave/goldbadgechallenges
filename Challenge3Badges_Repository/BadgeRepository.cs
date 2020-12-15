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
        public void AddBadgeToDictionary(int badgeId, Badge newbadge)
        {
            _badgeDictionary.Add(badgeId, newbadge);
        }

        //Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _badgeDictionary;
        }

        //Update
        public bool UpdateExistingBadge()
        {
            
        }

        //Delete
        public bool RemoveAllDoorsFromBadge()
        {

        }


    }
}
