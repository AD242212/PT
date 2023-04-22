using PT.Data.API;

namespace PT;

public class DataHandler : IDataHandler
{
    private IDataHolder _data;

    public DataHandler()
    {
        _data = new DataHolder();
        // seller s1 = new seller( "seller1", "seller_password");
        // customer s2 = new customer( "customer1", "customer_password");
        // admin s3 = new admin( "admin1", "admin_password");
        //
        //
        // userList.Add(s1);
        // userList.Add(s2);
        // userList.Add(s3);
        // Item  l1 = new Item(0, "ThinkPad1", 200.99f, 1);
        // Item  l2 = new Item(1, "ThinkPad2", 250.99f, 2);
        // Item p1 = new Item(2, "Redmi1", 150.99f, 3);
        // Item p2 = new Item(3, "Redmi2", 199.99f, 4);
    }


    public void add_user(user usr)
    {
        _data.users.Add(usr);
    }

    public user getUserByID(string id)
    {
        foreach (user usr in _data.users)
        {
            if (usr.id == id)
            {
                return usr;
            }
        }

        return null;
    }

    public user getUserByName(string username)
    {
        foreach (user usr in _data.users)
        {
            if (usr.username == username)
            {
                return usr;
            }
        }

        return null;
    }

    // returns 0 for wrong credentials 
    // 1 for customer, 2 for seller and 3 for admin
    public int validate_user(string username, string password)
    {
        foreach (user usr in _data.users)
        {
            if (usr.username == username && usr.password == password)
            {
                return check_user_type(usr);
            }
        }

        return 0;
    }

    public int check_user_type(user usr)
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
        foreach (user usr in _data.users)
        {
            if (usr.username == username)
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