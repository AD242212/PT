using AutoMapper;
using Data.API;
using Data.Database;
using Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_Testing
{
    [TestClass]
    public class DatabaseTest
    {

        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IItem, Data.Database.Items>();
        });

        public List<Item> itms = new List<Item>();

        [TestMethod]
        public void ConnectionTest()
        {

            using (DataClasses1DataContext db = new DataClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lucas\\source\\repos\\PT\\Data\\Database\\Shop.mdf;Integrated Security=True"))
            {
                IMapper mapper = configuration.CreateMapper();


                Item p1 = new Item(3, "Redmi1", 150.99f, 45);
                Data.Database.Items item = mapper.Map<Data.Database.Items>(p1);

                db.Items.InsertOnSubmit(item);
                db.SubmitChanges();



            }

            
            
        }

    }
}
