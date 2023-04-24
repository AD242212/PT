using PT;
using PT.Data.Implementation;
using PT.Logic.API;
using PT.Logic.Implementation;

namespace PT_Test;

[TestClass]
public class BusinessLogicTest
{
    private DataHandler test_handler = new DataHandler();
    private BusinessLogic logic;

    [TestInitialize]
    public void Setup()
    {
        test_handler.add_user(new admin("seller1", "seller_password", 0));
        test_handler.add_user(new customer("customer1", "customer_password", 10000));
        test_handler.add_user(new admin("admin1", "admin_password", 0));
        test_handler.add_user(new customer("customer2", "customer_password2", 10));

        test_handler.add_item(new Item(0, "ThinkPad1", 200.99f, 1));
        test_handler.add_item(new Item(1, "ThinkPad2", 250.99f, 2));
        test_handler.add_item(new Item(2, "Redmi1", 150.99f, 3));
        test_handler.add_item(new Item(3, "Redmi2", 199.99f, 4));

        logic = new BusinessLogic(test_handler);
    }
    
    [TestMethod]
    public void LoginLogoutLogic()
    {
        Assert.IsTrue(logic.Login("customer1", "customer_password"));
        Assert.IsTrue(logic.LogOut());
        logic.Login("seller1", "seller_password");
    }

    [TestMethod]
    public void AddFundsLogic()
    {
        logic.Login("customer1", "customer_password");
        Assert.IsTrue(logic.AddFunds(100f));
        
        Assert.IsTrue(logic.LogOut());
        
        Assert.ThrowsException<Exception>(() =>logic.AddFunds(100f));
    }
    
    [TestMethod]
    public void SellLogic()
    {
        logic.Login("customer1", "customer_password");
        Assert.IsTrue(logic.Sell(0, 1));
        Assert.IsTrue(logic.Sell(2, 3));
        Assert.ThrowsException<Exception>(() => logic.Sell(0, 2));
        Assert.ThrowsException<Exception>(() => logic.Sell(0, -50));
    }
    
    [TestMethod]
    public void SupplyLogic()
    {
        logic.Login("seller1", "seller_password");
        Assert.IsTrue(logic.Supply(0, 100));
        Assert.IsTrue(logic.Supply(1, 200));
        Assert.IsTrue(logic.Supply(2, 400));
    }
    
    [TestMethod]
    public void RemoveLogic()
    {
        logic.Login("seller1", "seller_password");
        Assert.IsTrue(logic.RemoveProduct(0));
        Assert.ThrowsException<Exception>(() => logic.RemoveProduct(-1));
    }
    
    [TestMethod]
    public void EditLogic()
    {
        logic.Login("seller1", "seller_password");
        Assert.IsTrue(logic.EditProduct(0, "ThinkPadNew", 100.55f, 20));
    }
}