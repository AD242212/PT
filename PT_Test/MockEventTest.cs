using PT;

namespace PT_Test;

[TestClass]
public class MockEventTest
{
    DataHandler test_handler = new DataHandler();

    [TestInitialize]
    public void Setup()
    {
        test_handler.add_user(new seller("seller1", "seller_password",0));
        test_handler.add_user(new customer("customer1", "customer_password",10000));
        test_handler.add_user(new admin("admin1", "admin_password",0));
        test_handler.add_user(new customer("customer2", "customer_password2",10));


        test_handler.add_item(new Item(0, "ThinkPad1", 200.99f, 1));
        test_handler.add_item(new Item(1, "ThinkPad2", 250.99f, 2));
        test_handler.add_item(new Item(2, "Redmi1", 150.99f, 3));
        test_handler.add_item(new Item(3, "Redmi2", 199.99f, 4));
    }

    [TestMethod]
    public void TestEvents()
    {
        SellEvent evt = new SellEvent(test_handler.GetItem(0), test_handler, test_handler.getUserByName("customer1"));
        evt.Perform();
        Assert.AreEqual(test_handler.GetItem(0).nums_in_stock, 0);
        Assert.AreEqual(test_handler.getUserByName("customer1").balance, 10000 - test_handler.GetItem(0).price);
        
        SellEvent evt2 = new SellEvent(test_handler.GetItem(0), test_handler, test_handler.getUserByName("customer1"));
        Assert.IsFalse(evt2.Perform());
        
        SellEvent evt3 = new SellEvent(test_handler.GetItem(2), test_handler, test_handler.getUserByName("customer2"));
        Assert.IsFalse(evt3.Perform());

    }


}