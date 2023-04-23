using PT.Data.API;

namespace PT.Data.Implementation;

public class DataHandler : IDataHandler
{
    private IDataHolder _data;

    public DataHandler()
    {
        _data = new DataHolder();
    }


    public void add_user(User usr)
    {
        _data.users.Add(usr);
    }

    public IUser getUserByID(string id)
    {
        return _data.users.Find(x => x.id == id);
    }

    public IUser getUserByName(string username)
    {
        return _data.users.Find(x => x.username == username);
    }

    // returns 0 for wrong credentials 
    // 1 for customer, 2 for admin
    public int validate_user(string username, string password)
    {
        IUser usr = _data.users.Find(x => x.username == username && x.password == password);

        if (usr != null)
        {
            return check_user_type(usr);
        }

        return 0;
    }

    public int check_user_type(IUser usr)
    {
        if (usr.GetType() == typeof(customer))
        {
            return 1;
        }
        else if (usr.GetType() == typeof(admin))
        {
            return 2;
        }
        else
        {
            throw new InvalidDataException("Incorrect user type");
        }
    }

    public bool username_available(string username)
    {
        if (_data.users.Find(x => x.username == username) != null)
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

    public bool add_funds(string id, float funds)
    {
        if (_data.users.Find(x => x.id == id) != null)
        {
            _data.users.Find(x => x.id == id).balance += funds;
            return true;
        }

        return false;
    }

    //todo add test  
    public bool can_afford(string user_id, float cost)
    {
        return getUserByID(user_id).balance >= cost;
    }

    // ITEM IMPLEMENTATIONS //
    //todo tests for all methods below
    public int get_next_item_id()
    {
        return _data.items.Last().id + 1;
    }

    public void add_item(IItem item)
    {
        _data.items.Add(item);
    }

    public void remove_item(int id)
    {
        if (_data.items.Find(x => x.id == id).nums_in_stock > 0)
        {
            _data.items.Find(x => x.id == id).nums_in_stock--;
        }
    }

    public IItem GetItem(int id)
    {

        return _data.items.Find(x => x.id == id);
    }

    public void edit_item(int id, string name, float price, int num)
    {
        _data.items.Find(x => x.id == id).name = name;
        _data.items.Find(x => x.id == id).price = price;
        _data.items.Find(x => x.id == id).nums_in_stock = num;
    }

    public int GetNumOfDistinctItemsInStock()
    {
        return _data.items.Count;
    }

    public IItem GetCheapestItem()
    {
        return _data.items.OrderByDescending(x => x.price).Last();
    }

    public IItem GetMostExpensiveItem()
    {
        return _data.items.OrderByDescending(x => x.price).First();
    }

    public IItem GetLeastAvailableItem()
    {
        return _data.items.OrderByDescending(x => x.nums_in_stock).Last();
    }

    public IItem GetMostAvailableItem()
    {
        return _data.items.OrderByDescending(x => x.nums_in_stock).First();
    }

    public string GetSoldString(IItem item, int ammount)
    {
        return string.Format("item: {0}, price: {1}, amount: {2}", item.name, item.price, ammount);
    }
}