using PT;

namespace PT_Test
{
    [TestClass]
    public class StateUnitTest
    {
        [TestMethod]
        public void GetItemTest()
        {
            State stateUnit = new State();
            
            Assert.IsTrue(stateUnit.GetItem(0) != null);
        }
        
        [TestMethod]
        public void ItemsNumberTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(4, stateUnit.GetItemsNumber());
        }
        
        [TestMethod]
        public void CheapestItemTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(2, stateUnit.GetCheapestItem().GetId());
        }
        
        [TestMethod]
        public void MostExpensiveItemTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(1, stateUnit.GetMostExpensiveItem().GetId());
        }
        
        [TestMethod]
        public void LeastAvailableTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(0, stateUnit.GetLeastAvailableItem().GetId());
        }
        
        [TestMethod]
        public void MostAvailableTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(3, stateUnit.GetMostAvailableItem().GetId());
        }
        
        [TestMethod]
        public void ItemsInStockTest()
        {
            State stateUnit = new State();
            
            Assert.AreEqual(10, stateUnit.GetItemsInStock());
        }
        
    }
}