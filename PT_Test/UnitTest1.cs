using System.Collections;
using PT;

namespace PT_Test
{
    [TestClass]
    public class UnitTest1
    {
        private userView view = new userView();
        private events event_handler = new events();
        

        [TestMethod]
        public void UserViewTests()
        {


            Assert.AreEqual(view.check_user_type(view.getUserByName("seller1")), 2);
            Assert.AreEqual(view.check_user_type(view.getUserByName("customer1")), 1);
            Assert.AreEqual(view.check_user_type(view.getUserByName("admin1")), 3);


            Assert.AreEqual(view.validate_user("seller1", "seller_password"), 2); // seller
            Assert.AreEqual(view.validate_user("customer1", "customer_password"), 1); // customer
            Assert.AreEqual(view.validate_user("admin1", "admin_password"), 3); // customer
            Assert.AreEqual(view.validate_user("doesnt_exist", ""), 0); // customer

            Assert.IsFalse(view.username_available("seller1"));
            Assert.IsTrue(view.username_available("doesnt_exist"));

        }

        [TestMethod]
        public void TestAddingUser()
        {
            Assert.IsTrue(event_handler.create_new_user("new_user", "password", 1));

            Assert.AreEqual(event_handler.UserView.getUserByName("new_user").username, "new_user");
        }

        [TestMethod]
        public void TestAddingItem()
        {
            Assert.AreEqual(event_handler.ItemView.get_next_id(), 4);
            Assert.IsTrue(event_handler.create_new_item("Asus Rog", 1000f, 10, "Laptop"));
            Assert.AreEqual(event_handler.ItemView.get_next_id(), 5);
            Assert.AreEqual(event_handler.ItemView.GetItem(4).GetName(),"Asus Rog");
        }
    }
}