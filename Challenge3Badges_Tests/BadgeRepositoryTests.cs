using Challenge3Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3Badges_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo;
        private Badge _badge;
        private List<string> _list;

        [TestInitialize]
        public void Arrange()
        {
            _list = new List<string> { "A5", "A4" };
            _repo = new BadgeRepository();
            _badge = new Badge(11,_list);

            _repo.AddBadgeToDictionary(_badge);
        }

        [TestMethod]
        public void AddBadge_ShouldNotGetNull()
        {
            // Arrange
            Badge badge = new Badge();
            badge.BadgeID = 123455;
            badge.DoorName.Add("A10");
            BadgeRepository repository = new BadgeRepository();
            
            // Act
            repository.AddBadgeToDictionary(badge);
            Badge badgeFromRepository = repository.GetBadgeByID(badge.BadgeID);

            // Assert
            Assert.IsNotNull(badgeFromRepository);
        }

        [TestMethod]
        public void AddDoor_ShouldReturnTrue()
        {
            // Arrange
            // Test Initialize
            string newDoorId = "A3";

            //Act
            bool addResult = _repo.AddDoorToBadge(_badge.BadgeID, newDoorId);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            // Arrange
            // Test Initialize

            // Act
            bool updateBadge = _repo.UpdateExistingBadge(_badge.BadgeID, _badge);

            // Assert
            Assert.IsTrue(updateBadge);
        }

        [TestMethod]
        public void RemoveAllDoors_ShouldReturnTrue()
        {
            // Arrange
            // Test Initialize

            // Act
            bool removeAllDoors = _repo.RemoveAllDoorsFromBadge(_badge.BadgeID);

            // Assert
            Assert.IsTrue(removeAllDoors);
        }

        [TestMethod]
        public void RemoveOneDoor_ShouldReturnTrue()
        {
            // Arrange
            // Test Initialize
            string existingDoorId = "A5";

            // Act
            bool updateBadge = _repo.RemoveOneDoorFromBadge(_badge.BadgeID, existingDoorId);

            // Assert
            Assert.IsTrue(updateBadge);
        }

        [TestMethod]
        public void GetBadgeById_ShouldReturnBadge()
        {
            // Arrange
            //Test Initialize

            // Act
            Badge gotBadge = _repo.GetBadgeByID(_badge.BadgeID);

            // Assert
            Assert.AreEqual(gotBadge, _badge);
        }
    }
}
