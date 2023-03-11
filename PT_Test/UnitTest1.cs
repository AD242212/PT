using PT;

namespace PT_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AdditionTest()
        {
            Calculator cal = new Calculator();

            int a = 1;
            int b = 4;

            Assert.AreEqual(5, cal.Add(a, b));
        }
    }
}