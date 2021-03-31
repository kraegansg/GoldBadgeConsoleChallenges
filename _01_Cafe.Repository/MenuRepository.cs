using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe.Repository
{
    public class MenuRepository
    {
        private List<MenuContent> _listOfContent = new List<MenuContent>();
        //Create
        public void AddMenuContent(MenuContent content)
        {
            _listOfContent.Add(content);
        }

        //Read
        public List<MenuContent> GetContentList()
        {
            return _listOfContent;
        }

        // No Update Required

        // Delete
        public bool RemoveItemFromMenu(string meal)
        {
            MenuContent content = GetContentByMeal(meal);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Helper method 
        public MenuContent GetContentByMeal(string meal)
        {
            foreach (MenuContent content in _listOfContent)
            {
                if (content.Meal.ToLower() == meal.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

    }
}

