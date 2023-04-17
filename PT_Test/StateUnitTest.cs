using PT;

namespace PT_Test
{
    [TestClass]
    public class StateUnitTest


    {
        State stateUnit = new State();


        [TestMethod]
        public void GetItemTest()
        {
            Assert.IsTrue(stateUnit.GetItem(0) != null);
        }

        [TestMethod]
        public void ItemsNumberTest()
        {
            Assert.AreEqual(4, stateUnit.GetItemsNumber());
        }

        [TestMethod]
        public void CheapestItemTest()
        {
            Assert.AreEqual(2, stateUnit.GetCheapestItem().GetId());
        }

        [TestMethod]
        public void MostExpensiveItemTest()
        {
            Assert.AreEqual(1, stateUnit.GetMostExpensiveItem().GetId());
        }

        [TestMethod]
        public void LeastAvailableTest()
        {
            Assert.AreEqual(0, stateUnit.GetLeastAvailableItem().GetId());
        }

        [TestMethod]
        public void MostAvailableTest()
        {
            Assert.AreEqual(3, stateUnit.GetMostAvailableItem().GetId());
        }

        [TestMethod]
        public void ItemsInStockTest()
        {
            Assert.AreEqual(10, stateUnit.GetItemsInStock());
        }

        [TestMethod]
        public void GetNextId()
        {
            Assert.AreEqual(stateUnit.get_next_id(), 4);
        }
    }
}