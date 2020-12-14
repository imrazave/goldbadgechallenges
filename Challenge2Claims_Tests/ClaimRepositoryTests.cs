using Challenge2Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2Claims_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddClaimToQueue_ShouldGetNotNull()
        {
            // Arrange 
            Claim claim = new Claim();
            claim.ClaimID = 1;
            ClaimRepository repository = new ClaimRepository();

            //Act
            repository.AddClaimToQueue(claim);
            Claim claimFromQueue = repository.GetClaimById(1);

            //Assert
            Assert.IsNotNull(claimFromQueue);
        }
    }
}
