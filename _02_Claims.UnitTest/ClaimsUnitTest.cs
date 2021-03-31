using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_Claims.Repository;
using System.Collections.Generic;

namespace _02_Claims.UnitTest
{
    [TestClass]
    public class ClaimsUnitTest
    {
        private ClaimsRepository _testRepo = new ClaimsRepository();

        [TestMethod]
        public void ViewAllClaimsTest() // VIEW CLAIMS TEST
        {
            //ARRANGE
            SeedContentList();
            Queue<ClaimsContent> retrievedQueue;

            //ACT
            retrievedQueue = _testRepo.GetClaimsContent();
            int count = retrievedQueue.Count;

            //ASSERT
            Assert.AreEqual(3, count);

        }

        [TestMethod]
        public void AddContentToQueueTest() //ADD NEW CLAIM TEST
        {
            //ARRANGE
            SeedContentList();
            int claimToAdd = 4;

            ClaimsContent resultContent;

            //ACT
            resultContent = _testRepo.GetContentByID(claimToAdd);
            if (resultContent != null)
            {
                Assert.Fail("Claim ID already in use.");
            }
            else
            {
                _testRepo.AddContentToQueue(new ClaimsContent { ClaimID = 4, TypeOfClaim = ClaimType.Home, Description = "Chimney fell off", ClaimAmount = 1200.00m, DateOfClaim = DateTime.Parse("12/25/20"), DateOfIncident = DateTime.Parse("01/04/20"), IsValid = true });
            }

            resultContent = _testRepo.GetContentByID(claimToAdd);

            //ASSERT
            Assert.IsNotNull(resultContent);



        }

        [TestMethod]
        public void RemoveClaimfromQueueTest() //REMOVE CLAIM TEST
        {
            //ARRANGE
            SeedContentList();
            int claimToDelete = 1;

            ClaimsContent resultContent;

            //ACT
            resultContent = _testRepo.GetContentByID(claimToDelete);
            if (resultContent != null)
            {
                _testRepo.RemoveClaim(claimToDelete);
            }
            else
            {
                Assert.IsNull("Claim does not exist in queue.");
            }

            resultContent = _testRepo.GetContentByID(claimToDelete);
            // ASSERT
            Assert.IsNull(resultContent);

        }


        private void SeedContentList() // SEED METHOD LIST
        {
            ClaimsContent firstClaim = new ClaimsContent(1, ClaimType.Auto, "Car accident on 465.", 400.00m, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"), true);
            ClaimsContent secondClaim = new ClaimsContent(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            ClaimsContent thirdClaim = new ClaimsContent(3, ClaimType.Theft, "Stolen pancakes", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            _testRepo.AddContentToQueue(firstClaim);
            _testRepo.AddContentToQueue(secondClaim);
            _testRepo.AddContentToQueue(thirdClaim);
        }
    }
}
