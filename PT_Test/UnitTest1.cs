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

            Assert.AreEqual(view.getUserByID(1).get_id(), 1);
            Assert.AreEqual(view.getUserByID(2).get_id(), 2);
            Assert.AreEqual(view.getUserByID(10), null);

            Assert.AreEqual(view.check_user_type(view.getUserByID(1)), 2);
            Assert.AreEqual(view.check_user_type(view.getUserByID(2)), 1);
            Assert.AreEqual(view.check_user_type(view.getUserByID(3)), 3);


            Assert.AreEqual(view.validate_user("seller1", "seller_password"), 2); // seller
            Assert.AreEqual(view.validate_user("customer1", "customer_password"), 1); // customer
            Assert.AreEqual(view.validate_user("admin1", "admin_password"), 3); // customer
            Assert.AreEqual(view.validate_user("doesnt_exist", ""), 0); // customer
        }
    }
}