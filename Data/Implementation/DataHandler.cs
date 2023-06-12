using AutoMapper;
using Data.API;
using Data.Database;

namespace Data.Implementation;

public class DataHandler : IDataHandler
{
    private DataClasses1DataContext db;




    private Data.Database.Items convertToDbItem(IItem s)
    {
        Data.Database.Items itm = new Items();
        itm.num_in_stock = s.nums_in_stock;
        itm.name = s.name;
        itm.price = s.price;
        itm.Id = s.id;

        return itm;
    }

    private Data.Database.Users convertToDbUser(IUser s)
    {
        Data.Database.Users usr = new Users();
        usr.username = s.username;
        usr.balance = s.balance;
        usr.password = s.password;
        
        //todo change this
        usr.type = true;

        return usr;

    }

    private Data.Database.Events convertToDbEvent(IEvent s)
    {
        Data.Database.Events e = new Events();

        return e;

    }

    private IItem DbItemToItem(Items result)
    {
        if (result != null)
        {
            return new Item(result.Id, result.name,(float) result.price, result.num_in_stock);

        }

        return null;
    }
    
    private IUser DbUserToUser(Data.Database.Users result)
    {
        return new User(result.Id, result.username, result.password,(float) result.balance);
    }
    
    

    public DataHandler()
    {
        db = new DataClasses1DataContext(
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lucas\\source\\repos\\PT\\Data\\Database\\Shop.mdf;Integrated Security=True");
    }

    public void clearDatabase()
    {
        using (DataClasses1DataContext db = new DataClasses1DataContext(
                   "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lucas\\source\\repos\\PT\\Data\\Database\\Shop.mdf;Integrated Security=True"))
        {
            db.ExecuteCommand("DELETE FROM Users");
            db.ExecuteCommand("DELETE FROM Items");
            db.ExecuteCommand("DELETE FROM Events");

            db.SubmitChanges();
        }
    }


    //USER METHODS
    public void add_user(int id, bool type, string username, string password, int balance)
    {
        Data.Database.Users usr = new Users();
        usr.Id = id;
        usr.username = username;
        usr.type = type;
        usr.password = password;
        usr.balance = balance;
        db.Users.InsertOnSubmit(usr);
        db.SubmitChanges();
    }


    public IUser getUserByID(int id)
    {
        var result = (from t in db.Users
            where t.Id == id
            select t).FirstOrDefault();
        return DbUserToUser(result);
    }

    public IUser getUserByName(string username)
    {
        var result = (from t in db.Users
            where t.username == username
            select t).FirstOrDefault();
        return DbUserToUser(result);
    }

    // returns 0 for wrong credentials 
    // 1 for customer, 2 for admin
    public int validate_user(string username, string password)
    {
        var result = (from t in db.Users
            where (t.username == username && t.password == password)
            select t).FirstOrDefault();

        return 1;
    }

    public int check_user_type(IUser usr)
    {
        //todo
        return 1;

    }

    public bool username_available(string username)
    {
        var result = (from t in db.Users
            where (t.username == username)
            select t);


        if (result.Any())
        {
            return false;
        }

        return true;
    }

    //todo add test and implementation 
    public bool email_available(string mail)
    {
        return false;
    }

    public bool add_funds(int id, float funds)
    {
        var query = from ord in db.Users
            where ord.Id == id
            select ord;

        foreach (var row in query)
        {
            row.balance += funds;
            db.SubmitChanges();
            return true;
        }

        return false;
    }

    public bool can_afford(int id, float cost)
    {
        var query = from ord in db.Users
            where ord.Id == id
            select ord;

        foreach (var row in query)
        {
            return row.balance > cost;
        }

        throw new Exception();
    }
    
    
    public int get_next_usr_id()
    {
        var query = from ord in db.Users
            orderby ord.Id descending 
            select ord;


        return query.First().Id+1;
    }

    //ITEM METHODS

    public int get_next_item_id()
    {
        var query = from ord in db.Items
            orderby ord.Id descending 
            select ord;


        return query.First().Id+1;
    }

    public void add_item(IItem item)
    {
        db.Items.InsertOnSubmit(convertToDbItem(item));
        db.SubmitChanges();
    }

    public void remove_item(string user_id, int id)
    {
        throw new NotImplementedException();
    }

    public void remove_item(int user_id, int id)
    {

        var query = from ord in db.Items where ord.Id == id select ord;

        foreach (var row in query)
        {
            db.Items.DeleteOnSubmit(row);
            db.SubmitChanges();
            return;
        }

        throw new Exception("Can not remove the item!");
    }

    public IItem GetItem(int id)
    {
        var result = (from t in db.Items
            where t.Id == id
            select t).FirstOrDefault();
        return DbItemToItem(result);
    }

    public void edit_item(int user_id, int id, string name, float price, int num)
    {
        //todo validation
        var result = (from t in db.Items
            where t.Id == id
            select t);

        foreach (var row in result)
        {
            row.name = name;
            row.price = price;
            row.num_in_stock = num;

            return;
        }

        throw new Exception("Can not edit the item!");
    }

    public int GetNumOfDistinctItemsInStock()
    {
        var result = (from t in db.Items
            select t);

        return result.Count();
    }

    public IItem GetCheapestItem()
    {
        var result = (from t in db.Items
            orderby t.price ascending
            select t).FirstOrDefault();


        return new Item(result.Id, result.name,(float) result.price, result.num_in_stock);

    }

    public IItem GetMostExpensiveItem()
    {
        var result = (from t in db.Items
            orderby t.price descending
            select t).FirstOrDefault();

        return DbItemToItem(result);
    }

    public IItem GetLeastAvailableItem()
    {
        var result = (from t in db.Items
            orderby t.num_in_stock ascending
            select t).FirstOrDefault();

        return DbItemToItem(result);
    }

    public IItem GetMostAvailableItem()
    {
        var result = (from t in db.Items
            orderby t.num_in_stock descending
            select t).FirstOrDefault();

        return DbItemToItem(result);
    }

    public string GetSoldString(IItem item, int ammount)
    {
        return string.Format("item: {0}, price: {1}, amount: {2}", item.name, item.price, ammount);
    }

//EVENT METHODS

    public void NewAddFundsEvent(IUser user, float amount)
    {
        AddFundsEvent evt = new AddFundsEvent(user, amount);
        evt.Perform(this);
    }

    public void NewSellEvent(IItem relatedItem, IUser user, int sell_num)
    {
        SellEvent evt = new SellEvent(relatedItem, user, sell_num);
        evt.Perform(this);
    }

    public void NewSupplyEvent(IItem relatedItem, IUser user, int supply_num)
    {
        SupplyEvent evt = new SupplyEvent(relatedItem, user, supply_num);
        evt.Perform(this);
    }

    public void NewRemoveProductEvent(int id, IUser user)
    {
        RemoveProductEvent evt = new RemoveProductEvent(id, user);
        evt.Perform(this);
    }

    public void NewEditProductEvent(int id, IUser user, string name, float price, int num)
    {
        EditProductEvent evt = new EditProductEvent(id, user, name, price, num);
        evt.Perform(this);
    }
}