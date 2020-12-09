using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe_Repository
{
    // Plain Old C# Object
    public class Menu
    {
        public string ItemName { get; set; }
        public int MealNumber { get; set; }
        public string ItemDescription { get; set; }
        public double MealPrice { get; set; }
        public string MealIngredients { get; set; }

        public Menu() {}

        public Menu(string itemName, int mealNumber, string itemDescription, double mealPrice, string mealIngredients)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            MealPrice = mealPrice;
            MealIngredients = mealIngredients;
            
        }

    }
}
