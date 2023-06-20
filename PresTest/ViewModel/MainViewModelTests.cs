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
using Presentation.Commands;


namespace Presentation.ViewModel.Tests
{
    [TestClass]
    public class PresTest
    {
        
        [TestMethod]
        public void TestMockUser()
        { 
            
            MainViewModel model = new MainViewModel(new DataHandlerTest());
            
            model.NewUsername = "Lucas";
            model.NewPassword = "Password";

            Assert.AreEqual(model.NewUsername, "Lucas");
            Assert.AreEqual(model.NewPassword, "Password");

            model.NewUsername = "Rafal";
            Assert.AreEqual(model.NewUsername, "Rafal");
            
        } 
                
        [TestMethod]
        public void TestMockItem()
        { 
            
            MainViewModel model = new MainViewModel(new DataHandlerTest());
            
            model.NewName = "Item";
            model.NewPrice = "11";
            model.NewInStock = "0";

            Assert.AreEqual(model.NewName, "Item");
            Assert.AreEqual(model.NewPrice, "11");
            Assert.AreEqual(model.NewInStock, "0");


            
        }  
        
        
        
    }

    
}