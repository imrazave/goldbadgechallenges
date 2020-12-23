using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4Outings_Repository
{
    public class OutingsRepository
    {
        public SortedList<DateTime, Outing> _listOfOutings = new SortedList<DateTime, Outing>();
        
        // Create
        public void AddOutingToList(Outing outing)
        {
            _listOfOutings.Add(outing.Date, outing);
        }

        // Read
        public SortedList<DateTime, Outing> GetOutings()
        {
            return _listOfOutings;
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (KeyValuePair<DateTime, Outing> entry in _listOfOutings)
            {
                totalCost += entry.Value.TotalEventCost;
            }
            return totalCost;
        }

        public decimal GetTotalCostByType(OutingTypes type)
        {
            decimal totalTypeCost = 0;
            foreach (KeyValuePair<DateTime, Outing> entry in _listOfOutings)
            {
                if (entry.Value.EventType == type)
                {
                    totalTypeCost += entry.Value.TotalEventCost;
                }
            }
            return totalTypeCost;
        }

        
    }
}
