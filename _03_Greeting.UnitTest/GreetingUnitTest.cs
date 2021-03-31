using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_Greeting.Repository;
using System.Collections.Generic;
using System;

namespace _03_Greeting.UnitTest
{
    [TestClass]
    public class GreetingUnitTest
    {
        private GreetingRepository _testRepo = new GreetingRepository();

        [TestMethod]
        public void AddCustomerContentTest() // ADD CUSTOMER TO EMAIL LIST TEST
        {
            //ARRANGE
            CustomerContent content = new CustomerContent();
            GreetingRepository repo = new GreetingRepository();
            List<CustomerContent> localList = repo.GetContentList();

            // ACT
            int beforeCount = localList.Count;
            repo.AddContentToList(content);
            int actual = localList.Count;
            int expected = beforeCount + 1;

            //Assert
            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod]
        public void GetContentByNameTest() // SEARCH CUSTOMER BY NAME TEST
        {
            // ARRANGE
            SeedContentList();
            string trueName = "Jane Smith";
            string falseName = "Tom Bombadill";

            CustomerContent trueResultContent, falseResultContent;

            // ACT
            trueResultContent = _testRepo.GetCustomerByName(trueName);
            falseResultContent = _testRepo.GetCustomerByName(falseName);

            // ASSERT
            Assert.IsNotNull(trueResultContent);
            Assert.IsNull(falseResultContent);

        }


        [TestMethod]
        public void UpdateCustomerContentTest() // EDIT CUSTOMER CONTENT TEST
        {
            // ARRANGE
            GreetingRepository repo = new GreetingRepository();

            CustomerContent oldContent = new CustomerContent("Gandalf", "Thegrey", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!", "Gandalf Thegrey");
           
            repo.AddContentToList(oldContent);
           
            CustomerContent updatedcontent = new CustomerContent("Tom", "Bombadill", CustomerType.Past, "It's been a long time since we've heard from you, we want you back.", "Tom Bombadill");
            
            string name = "gandalf thegrey";

            //ACT
            bool result = repo.UpdateCustomerContent(name, updatedcontent);

            //ASSERT
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ViewAllCustomerContentTest() // VIEW ALL CUSTOMERS TEST
        {
            //ARRANGE
            SeedContentList();
            List<CustomerContent> retrievedList;

            //ACT
            retrievedList = _testRepo.GetContentList();
            int count = retrievedList.Count;

            //ASSERT
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void DeleteCustomerContentTest() // REMOVE CUSTOMER TEST
        {
            //ARRANGE
            SeedContentList();
            string customerToDelete = "James Smith";

            CustomerContent resultContent;

            //ACT
            resultContent = _testRepo.GetCustomerByName(customerToDelete);
            if (resultContent != null)
            {
                _testRepo.RemoveGreetingContent(customerToDelete);
            }
            else
            {
                Assert.IsNull("Customer does not exist in email list.");
            }

            resultContent = _testRepo.GetCustomerByName(customerToDelete);
            // ASSERT
            Assert.IsNull(resultContent);
        }

        private void SeedContentList()
        {
            CustomerContent jakeSmith = new CustomerContent("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!", "Jake Smith");
            CustomerContent jamesSmith = new CustomerContent("James", "Smith", CustomerType.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.", "James Smith");
            CustomerContent janeSmith = new CustomerContent("Jane", "Smith", CustomerType.Past, "It's been a long time since we've heard from you, we want you back.", "Jane Smith");
            _testRepo.AddContentToList(jakeSmith);
            _testRepo.AddContentToList(jamesSmith);
            _testRepo.AddContentToList(janeSmith);
        }
    }
}

