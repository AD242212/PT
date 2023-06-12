using Data.Implementation;

namespace PT_Test;

[TestClass]
public class EventTest
{
    private DataHandler test_handler = new DataHandler();

    [TestInitialize]
    public void Setup()
    {
        test_handler.add_user(1,true, "seller1", "seller_password", 0);
        test_handler.add_user(2,false, "customer1", "customer_password", 10000);
        test_handler.add_user(3,true, "admin1", "admin_password", 0);
        test_handler.add_user(4,false, "customer2", "customer_password2", 10);

        test_handler.add_item(new Item(0, "ThinkPad1", 200.99f, 1));
        test_handler.add_item(new Item(1, "ThinkPad2", 250.99f, 2));
        test_handler.add_item(new Item(2, "Redmi1", 150.99f, 3));
        test_handler.add_item(new Item(3, "Redmi2", 199.99f, 4));
    }

    [TestMethod]
    public void AddFundsEvent()
    {
        test_handler.NewAddFundsEvent(test_handler.getUserByName("customer1"), 1);
        Assert.AreEqual(10001, test_handler.getUserByName("customer1").balance);
    }
    
    [TestMethod]
    public void SellEvent()
    {
        test_handler.NewSellEvent(test_handler.GetItem(0), test_handler.getUserByName("customer1"),1);
        Assert.AreEqual(test_handler.GetItem(0).nums_in_stock, 0);
        Assert.AreEqual(test_handler.getUserByName("customer1").balance, 10000 - test_handler.GetItem(0).price);
        
        Assert.ThrowsException<Exception>(() => test_handler.NewSellEvent(test_handler.GetItem(0), test_handler.getUserByName("customer1"),1));

        Assert.ThrowsException<Exception>(() => test_handler.NewSellEvent(test_handler.GetItem(2), test_handler.getUserByName("customer2"),1));
    }

    [TestMethod]
    public void SupplyEvent()
    {
        test_handler.NewSupplyEvent(new Item(213, "Laptop", 200f, 0), test_handler.getUserByName("seller1"), 10);
        Assert.AreEqual(test_handler.GetItem(213).nums_in_stock, 10);
        
        test_handler.NewSupplyEvent(test_handler.GetItem(1), test_handler.getUserByName("seller1"),3);
        Assert.AreEqual(test_handler.GetItem(1).nums_in_stock, 5);
    }
    
    [TestMethod]
    public void RemoveProductEvent()
    {
        test_handler.NewRemoveProductEvent(0, test_handler.getUserByName("seller1"));
        Assert.IsNull(test_handler.GetItem(0));
    }
    
    [TestMethod]
    public void EditProductsEvent()
    {
        test_handler.NewEditProductEvent(1, test_handler.getUserByName("seller1"), "new_item_name", 299.99f, 100);
        Assert.AreEqual("new_item_name", test_handler.GetItem(1).name);
        Assert.AreEqual(299.99f, test_handler.GetItem(1).price);
        Assert.AreEqual(100, test_handler.GetItem(1).nums_in_stock);
    }
}
