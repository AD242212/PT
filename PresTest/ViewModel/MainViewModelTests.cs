using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implementation;
using Logic.API;
using Logic.Implementation;


namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void MainViewModelTest()
        {
            DataHandlerTest logic = new DataHandlerTest();
            MainViewModel model = new MainViewModel(logic);

            model.NewUsername = "Lucas";
            model.NewPassword = "Password";

            model.addUser();


            model.NewUsername = "Artur";
            model.NewPassword = "1234";

            model.addUser();

            Assert.AreEqual(logic.getUserbyName("Lucas").password, "Password");
            Assert.AreEqual(logic.getUserbyName("Artur").password, "1234");
        }
        
        
        [TestMethod]
        public void MainViewModelTest2()
        {
            DataHandlerTest logic = new DataHandlerTest();
            MainViewModel model = new MainViewModel(logic);

            model.NewName = "Redmi";
            model.NewPrice = "100";
            model.NewInStock = "1";

            model.addItem();
            
            Assert.AreEqual(logic.getItembyName("Redmi").nums_in_stock,1);
            
            
            model.NewName = "Xiaomi";
            model.NewPrice = "25";
            model.NewInStock = "1000";
            
            model.addItem();
            
            Assert.AreEqual(logic.getItembyName("Xiaomi").nums_in_stock,1000);
            
        }
        
    }
}