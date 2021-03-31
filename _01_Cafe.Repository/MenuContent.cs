using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe.Repository
{
    public class MenuContent
    {

        public int Number { get; set; }
        public string Meal { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }


        public MenuContent() { }
        public MenuContent(int number, string meal, string description, string ingredients, decimal price)
        {
            Number = number;
            Meal = meal;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
