using PT;

namespace PT_Test
{
    [TestClass]
    public class ItemsUnitTest
    {
        [TestMethod]
        public void LaptopTest()
        {
            Laptop l1 = new Laptop(0, "ThinkPad1", 200.99f, 24);
            
            Assert.AreEqual(0, l1.GetId());
            Assert.AreEqual("ThinkPad1", l1.GetName());
            Assert.AreEqual(200.99f, l1.GetPrice());
            Assert.AreEqual(24, l1.GetNumsInStock());
        }
        
        [TestMethod]
        public void PhoneTest()
        {
            Phone p1 = new Phone(3, "Redmi1", 150.99f, 45);
            
            Assert.AreEqual(3, p1.GetId());
            Assert.AreEqual("Redmi1", p1.GetName());
            Assert.AreEqual(150.99f, p1.GetPrice());
            Assert.AreEqual(45, p1.GetNumsInStock());
        }
    }
}