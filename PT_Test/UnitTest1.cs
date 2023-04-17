using System.Collections;
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

        [TestMethod]
        public void UsersTest()
        {

            userView view = new userView();
            
            Assert.AreEqual(view.getUserByID(1).get_id(),1);
            Assert.AreEqual(view.getUserByID(2).get_id(),2);
            Assert.AreEqual(view.getUserByID(10),null);
            
            Assert.AreEqual(view.check_user_type(view.getUserByID(1)),1);



        }
    }
}