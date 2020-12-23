using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4Outings_Repository
{

    public enum OutingTypes
    {
        Golf = 1,
        Bowling,
        Amusement_Park,
        Concert
    }

    // Plain Old C# Object
    public class Outing
    {
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public decimal PerPersonCost { get; set; }
        public decimal TotalEventCost { get; set; }

        public OutingTypes EventType { get; set; }

        public Outing() { }
        public Outing(int numberOfPeople, DateTime date, decimal perPersonCost, decimal totalEventCost, OutingTypes eventType)
        {
            NumberOfPeople = numberOfPeople;
            Date = date;
            PerPersonCost = perPersonCost;
            TotalEventCost = totalEventCost;
            EventType = eventType;
        }
    }
}
