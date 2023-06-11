using Data.API;

namespace Data.Implementation;

public class DataHandler : IDataHandler
{
    private IDataHolder _data;

    public DataHandler()
    {
        _data = new DataHolder();
    }
    
    //USER METHODS
    public void add_user(int type, string username, string password, int balance)
    {
        if (type == 1)
        {
            _data.users.Add(new customer(username, password, balance));
        }
        else if(type == 2)
        {
            _data.users.Add(new admin(username, password, balance));
        }
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
    
    public bool can_afford(string user_id, float cost)
    {
        return getUserByID(user_id).balance >= cost;
    }

    //ITEM METHODS
    public int get_next_item_id()
    {
        return _data.items.Last().id + 1;
    }

    public void add_item(IItem item)
    {
        _data.items.Add(item);
    }

    public void remove_item(string user_id, int id)
    {
        if (check_user_type(getUserByID(user_id)) == 2)
        {
            _data.items.Remove(_data.items.Find(x => x.id == id));
            return;
        }

        throw new Exception("Can not remove the item!");
    }

    public IItem GetItem(int id)
    {
        return _data.items.Find(x => x.id == id);
    }

    public void edit_item(string user_id, int id, string name, float price, int num)
    {
        if (check_user_type(getUserByID(user_id)) == 2)
        {
            _data.items.Find(x => x.id == id).name = name;
            _data.items.Find(x => x.id == id).price = price;
            _data.items.Find(x => x.id == id).nums_in_stock = num;
            
            return;
        }
        
        throw new Exception("Can not edit the item!");
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

    //EVENT METHODS
    
    public void NewAddFundsEvent(IUser user, float amount)
    {
        AddFundsEvent evt = new AddFundsEvent(user, amount);
        evt.Perform(this);
        _data.events.Add(evt);
    }

    public void NewSellEvent(IItem relatedItem, IUser user, int sell_num)
    {
        SellEvent evt = new SellEvent(relatedItem, user, sell_num);
        evt.Perform(this);
        _data.events.Add(evt);
    }

    public void NewSupplyEvent(IItem relatedItem, IUser user, int supply_num)
    {
        SupplyEvent evt = new SupplyEvent(relatedItem, user, supply_num);
        evt.Perform(this);
        _data.events.Add(evt);
    }

    public void NewRemoveProductEvent(int id, IUser user)
    {
        RemoveProductEvent evt = new RemoveProductEvent(id, user);
        evt.Perform(this);
        _data.events.Add(evt);
    }

    public void NewEditProductEvent(int id, IUser user, string name, float price, int num)
    {
        EditProductEvent evt = new EditProductEvent(id, user, name, price, num);
        evt.Perform(this);
        _data.events.Add(evt);
    }
}