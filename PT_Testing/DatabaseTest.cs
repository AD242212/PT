using AutoMapper;
using Data.API;
using Data.Database;
using Data.Implementation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUser = Data.API.IUser;

namespace PT_Testing
{
    [TestClass]
    public class DatabaseTest
    {
        

        

        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IItem, Data.Database.Items>();
            cfg.CreateMap<IUser, Data.Database.Users>();
            cfg.CreateMap<IEvent, Data.Database.Events>();

        });

        public List<Item> itms = new List<Item>();

        [TestMethod]
        public void ConnectionTest()
        {

            using (DataClasses1DataContext db = new DataClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lucas\\source\\repos\\PT\\Data\\Database\\Shop.mdf;Integrated Security=True"))
            {
                Assert.IsTrue(true);
                db.ExecuteCommand("DELETE FROM Users");
                db.ExecuteCommand("DELETE FROM Items");
                db.ExecuteCommand("DELETE FROM Events");


            }
            
        }






    }
}
