using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using _01_Cafe.Repository;

namespace _01_Cafe.UnitTest
{
    [TestClass]
    public class CafeUnitTest
    {
        private MenuRepository _testRepo = new MenuRepository();

        [TestMethod]
        public void AddItemsToMenuTest() // ADD TO MENU TEST
        {
            //ARRANGE
            SeedContentList();
            string itemToAdd = "Dragon Eggs Benedict";

            MenuContent resultContent;

            //ACT
            resultContent = _testRepo.GetContentByMeal(itemToAdd);
            if (resultContent != null)
            {
                Assert.Fail("Title already exists in repository.");
            }
            else
            {
                _testRepo.AddMenuContent(new MenuContent { Number = 4, Meal = "Dragon Eggs Benedict", Description = "Our Komodo Dragon Egg Benedict served with in-house sauce and side of bacon.", Ingredients = "Eggs, Hollandaise Sauce, Cayenne Pepper, English Muffin, Bacon", Price = 16m });
            }

            resultContent = _testRepo.GetContentByMeal(itemToAdd);

            //ASSERT
            Assert.IsNotNull(resultContent);
        }

        [TestMethod]
        public void GetContentByMealTest() //PULL MEAL BY NAME TEST
        {
            // ARRANGE
            SeedContentList();
            string trueMeal = "The Scone Zone";
            string falseMeal = "Dragon Eggs Benedict";

            MenuContent trueResultContent, falseResultContent;

            // ACT
            trueResultContent = _testRepo.GetContentByMeal(trueMeal);
            falseResultContent = _testRepo.GetContentByMeal(falseMeal);

            // ASSERT
            Assert.IsNotNull(trueResultContent);
            Assert.IsNull(falseResultContent);

        }

        [TestMethod]
        public void ViewAllMenuItemsTest() // VIEW FULL MENU TEST
        {
            //ARRANGE
            SeedContentList();
            List<MenuContent> retrievedList;

            //ACT
            retrievedList = _testRepo.GetContentList();
            int count = retrievedList.Count;

            //ASSERT
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void RemoveMenuItemsTest() // REMOVE FROM MENU TEST
        {
            //ARRANGE
            SeedContentList();
            string mealToDelete = "The Scone Zone";

            MenuContent resultContent;

            //ACT
            resultContent = _testRepo.GetContentByMeal(mealToDelete);
            if (resultContent != null)
            {
                _testRepo.RemoveItemFromMenu(mealToDelete);
            }
            else
            {
                Assert.IsNull("Meal does not exist in menu repository.");
            }

            resultContent = _testRepo.GetContentByMeal(mealToDelete);
            // ASSERT
            Assert.IsNull(resultContent);

        }

        private void SeedContentList() // SEED METHOD LIST
        {
            MenuContent sconeZone = new MenuContent(1, "The Scone Zone", "3 of our daily made scones. Ask server for today's variety.", "Ingredients vary due to daily scone options", 12m);
            MenuContent oneHotOmelete = new MenuContent(2, "One Hot Omelette", "Fluffy egg omelette, extra spicy.", "Eggs, butter, jalapeno pepper, bell pepper, onion, garlic, pepper, house-made hot sauce.", 14m);
            MenuContent komodoTea = new MenuContent(3, "Komodo Tea", "Organic senna tea sourced from farmers in India's Thar Desert.", " Organic Licorice Root, Organic Bitter Fennel Fruit, Organic Sweet Orange Peel, Organic Cinnamon Bark, Organic Coriander Fruit, Organic Ginger Rhizome, Organic Orange Peel Oil on Gum Arabic.", 3m);
            _testRepo.AddMenuContent(sconeZone);
            _testRepo.AddMenuContent(oneHotOmelete);
            _testRepo.AddMenuContent(komodoTea);
        }
    }
}