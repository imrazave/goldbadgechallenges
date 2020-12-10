using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        //Create
        public void  AddItemToMenu(Menu item)
        {
            _listOfMenuItems.Add(item);
        }

        //Read
        public List<Menu> GetMenu()
        {
            return _listOfMenuItems;
        }
        //Update
        public bool UpdateExistingItem(string oldItemName, Menu newItem)
        {
            //Find the content
            Menu oldItem = GetItemByName(oldItemName);

            //Update the content
            if (oldItem != null)
            {
                oldItem.ItemName = newItem.ItemName;
                oldItem.ItemDescription = newItem.ItemDescription;
                oldItem.MealIngredients = newItem.MealIngredients;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealPrice = newItem.MealPrice;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveItemFromMenu(string itemName)
        {
            Menu item = GetItemByName(itemName);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper method
        public Menu GetItemByName(string itemName)
        {
            foreach (Menu item in _listOfMenuItems)
            {
                if (item.ItemName.ToLower() == itemName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }
    }
}
