using PT;
using PT.Data.API;
using PT.Data.Implementation;

namespace PT_Test
{
    [TestClass]
    public class ItemsUnitTest
    {
        [TestMethod]
        public void LaptopTest()
        {
            Item l1 = new Item(0, "ThinkPad1", 200.99f, 24);
            
            Assert.AreEqual(0, l1.id);
            Assert.AreEqual("ThinkPad1", l1.name);
            Assert.AreEqual(200.99f, l1.price);
            Assert.AreEqual(24, l1.nums_in_stock);
        }
        
        [TestMethod]
        public void PhoneTest()
        {
            Item p1 = new Item(3, "Redmi1", 150.99f, 45);
            
            Assert.AreEqual(3, p1.id);
            Assert.AreEqual("Redmi1", p1.name);
            Assert.AreEqual(150.99f, p1.price);
            Assert.AreEqual(45, p1.nums_in_stock);
        }
        
    }
}