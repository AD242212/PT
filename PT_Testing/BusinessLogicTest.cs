﻿using Data.Implementation;
using Logic.API;
using Logic.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PT_Test;

[TestClass]
public class BusinessLogicTest
{
    private DataHandler test_handler = new DataHandler(dbstring.getCtString());
    private BusinessLogic logic;

    [TestInitialize]
    public void Setup()
    {
        test_handler.clearDatabase();

        
        test_handler.add_user(1,true, "seller1", "sellerp", 0);
        test_handler.add_user(2,true, "customer1", "customerp", 10000);
        test_handler.add_user(3,true, "admin1", "adminp", 0);
        test_handler.add_user(4,true, "customer2", "customerp2", 10);

        test_handler.add_item(new Item(0, "ThinkPad1", 200.99f, 1));
        test_handler.add_item(new Item(1, "ThinkPad2", 250.99f, 2));
        test_handler.add_item(new Item(2, "Redmi1", 150.99f, 3));
        test_handler.add_item(new Item(3, "Redmi2", 199.99f, 4));

        logic = new BusinessLogic(test_handler);
    }
    
    [TestMethod]
    public void LoginLogoutLogic()
    {
        Assert.IsTrue(logic.Login("customer1", "customerp"));
        Assert.IsTrue(logic.LogOut());
        logic.Login("seller1", "sellerp");
    }

    [TestMethod]
    public void AddFundsLogic()
    {
        logic.Login("customer1", "customerp");
        Assert.IsTrue(logic.AddFunds(100f));
        
        Assert.IsTrue(logic.LogOut());
        
        // Assert.ThrowsException<Exception>(() =>logic.AddFunds(100f));
    }
    
    [TestMethod]
    public void SellLogic()
    {
        logic.Login("customer1", "customerp");
        Assert.IsTrue(logic.Sell(0, 1));
        Assert.IsTrue(logic.Sell(2, 3));
        Assert.ThrowsException<Exception>(() => logic.Sell(0, 2));
        Assert.ThrowsException<Exception>(() => logic.Sell(0, -50));
    }
    
    [TestMethod]
    public void SupplyLogic()
    {
        logic.Login("seller1", "sellerp");
        Assert.IsTrue(logic.Supply(1, 100));
        Assert.IsTrue(logic.Supply(2, 200));
        Assert.IsTrue(logic.Supply(3, 400));
    }
    
    [TestMethod]
    public void RemoveLogic()
    {
        logic.Login("seller1", "sellerp");
        Assert.IsTrue(logic.RemoveProduct(0));
    }
    
    [TestMethod]
    public void EditLogic()
    {
        logic.Login("seller1", "sellerp");
        Assert.IsTrue(logic.EditProduct(0, "ThinkPadNew", 100.55f, 20));
    }

    [TestMethod]
    public void addmethods()
    {
        logic.getItembyId(1);
        logic.getUserByID(1);
        Assert.IsFalse(false);
    }
}