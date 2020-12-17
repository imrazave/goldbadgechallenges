using Challenge2Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2Claims_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        private ClaimRepository _repo;
        private Claim _claim;
        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, ClaimTypes.Car, "car crash", 299.00, Convert.ToDateTime("2018/04/01"), Convert.ToDateTime("2017/04/01"), false);

            _repo.AddClaimToQueue(_claim);
        }

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
