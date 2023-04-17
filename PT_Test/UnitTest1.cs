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

            Assert.IsFalse(view.username_available("seller1"));
            Assert.IsTrue(view.username_available("doesnt_exist"));

            Assert.AreEqual(view.get_next_id(), 4);
        }

        [TestMethod]
        public void TestAddingUser()
        {
            Assert.AreEqual(event_handler.UserView.get_next_id(), 4);
            Assert.IsTrue(event_handler.create_new_user("new_user", "password", 1));
            Assert.AreEqual(event_handler.UserView.get_next_id(), 5);

            Assert.AreEqual(event_handler.UserView.getUserByName("new_user").get_name(), "new_user");
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