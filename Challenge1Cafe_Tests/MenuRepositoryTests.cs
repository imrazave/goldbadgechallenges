using Challenge1Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1Cafe_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _item = new Menu("Hamburger", 1, "Beef patty on a bun", 2.99, "Beef, wheat, water, spices");

            _repo.AddItemToMenu(_item);
        }

        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            Menu item = new Menu();
            item.ItemName = "Hamburger";
            MenuRepository repository = new MenuRepository();

            // Act --> Get/run the code we want to test
            repository.AddItemToMenu(item);
            Menu itemFromMenu = repository.GetItemByName("Hamburger");

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(itemFromMenu);
        }

        // Update
        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            Menu newItem = new Menu("Cheeseburger", 1, "Beef patty with cheese on a bun", 3.49, "Beef, cheese, wheat, water, spices");

            //Act
            bool updateResult = _repo.UpdateExistingItem("Hamburger", newItem);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Hamburger", true)]
        [DataRow("Salami", false)]
        public void UpdateExistingItem_ShouldMatchGivenBool(string originalItem, bool shouldUpdate)
        {
            // Arrange
            // TestInitialize
            Menu newItem = new Menu("Cheeseburger", 1, "Beef patty with cheese on a bun", 3.49, "Beef, cheese, wheat, water, spices");

            //Act
            bool updateResult = _repo.UpdateExistingItem(originalItem, newItem);

            // Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteItem = _repo.RemoveItemFromMenu(_item.ItemName);

            // Assert
            Assert.IsTrue(deleteItem);
        }

    }
}
