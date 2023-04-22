using PT.Data.API;

namespace PT;

public class DataHandler : IDataHandler
{
    private IDataHolder _data;

    public DataHandler()
    {
        _data = new DataHolder();

    }


    public void add_user(user usr)
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
    // 1 for customer, 2 for seller and 3 for admin
    public int validate_user(string username, string password)
    {
        IUser usr = _data.users.Find(x => x.username == username && x.password == password);

        if (usr!=null)
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
        else if (usr.GetType() == typeof(seller))
        {
            return 2;
        }
        else if (usr.GetType() == typeof(admin))
        {
            return 3;
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

    public bool email_available(string mail)
    {
        return false;
    }

    // ITEM IMPLEMENTATIONS //

    public int get_next_item_id()
    {
        return _data.items.Last().id + 1;
    }

    public void add_item(IItem item)
    {
        _data.items.Add(item);
    }

    public IItem GetItem(int id)
    {
        IItem? usr = _data.items.Find(x => x.id == id);
        if (usr is not null)
        {
            return usr;
        }

        throw new Exception("Item with specified id doesn't exist");
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
}