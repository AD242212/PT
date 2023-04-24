using PT;
using PT.Data.Implementation;

namespace PT_Test
{
    [TestClass]
    public class ItemTest
    {
        DataHandler test_handler = new DataHandler();

        [TestInitialize]
        public void Setup()
        {
            test_handler.add_user(new admin("seller1", "seller_password",0));
            test_handler.add_user(new customer("customer1", "customer_password",0));
            test_handler.add_user(new admin("admin1", "admin_password",0));

            test_handler.add_item(new Item(0, "ThinkPad1", 200.99f, 1));
            test_handler.add_item(new Item(1, "ThinkPad2", 250.99f, 2));
            test_handler.add_item(new Item(2, "Redmi1", 150.99f, 3));
            test_handler.add_item(new Item(3, "Redmi2", 199.99f, 4));
        }

        [TestMethod]
        public void GetItemTest()
        {
            Assert.IsTrue(test_handler.GetItem(0) != null);
            Assert.IsNull(test_handler.GetItem(213));

        }

        [TestMethod]
        public void ItemsNumberTest()
        {
            Assert.AreEqual(4, test_handler.GetNumOfDistinctItemsInStock());
        }

        [TestMethod]
        public void CheapestItemTest()
        {
            Assert.AreEqual(2, test_handler.GetCheapestItem().id);
        }

        [TestMethod]
        public void MostExpensiveItemTest()
        {
            Assert.AreEqual(1, test_handler.GetMostExpensiveItem().id);
        }

        [TestMethod]
        public void LeastAvailableTest()
        {
            Assert.AreEqual(0, test_handler.GetLeastAvailableItem().id);
        }

        [TestMethod]
        public void MostAvailableTest()
        {
            Assert.AreEqual(3, test_handler.GetMostAvailableItem().id);
        }
        
        [TestMethod]
        public void GetNextId()
        {
            Assert.AreEqual(test_handler.get_next_item_id(), 4);
        }

        [TestMethod]
        public void CheckUserType()
        {
            Assert.AreEqual(test_handler.check_user_type(test_handler.getUserByName("admin1")), 2);
            Assert.AreEqual(test_handler.check_user_type(test_handler.getUserByName("customer1")), 1);
        }

        [TestMethod]
        public void UserValidation()
        {
            Assert.AreEqual(test_handler.validate_user("admin1", "admin_password"), 2);
            Assert.AreEqual(test_handler.validate_user("customer1", "customer_password"), 1);
        }

        [TestMethod]
        public void UserAvialable()
        {
            Assert.IsFalse(test_handler.username_available("admin1"));
            Assert.IsTrue(test_handler.username_available("doesnt_exist"));
        }
    }
}