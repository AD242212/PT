using Data.API;

namespace Data.Implementation;

public class AddFundsEvent : IEvent
{
    public IUser user { get; }
    public float amount { get; }

    public AddFundsEvent(IUser user, float amount)
    {
        this.user = user;
        this.amount = amount;
    }

    public bool Perform(IDataHandler context)
    {
        try
        {
            context.add_funds(user.id, amount);
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Cant add funds");
        }
        
    }
}

public class SellEvent : IEvent
{
    public IItem related_item { get; }
    public IUser user { get; }
    public int sell_num { get; }

    public SellEvent(IItem relatedItem, IUser user, int sell_num)
    {
        related_item = relatedItem;
        this.user = user;
        this.sell_num = sell_num;
    }

    public bool Perform(IDataHandler context)
    {
        if (context.can_afford(user.id, related_item.price * sell_num) && context.GetItem(related_item.id).nums_in_stock >= sell_num && sell_num > 0)
        {
            
            context.edit_item(1,related_item.id,related_item.name,related_item.price,related_item.nums_in_stock-sell_num);
            context.add_funds(user.id, -related_item.price);
            context.getUserByID(user.id).balance -= related_item.price;

            // creates entry in purchase history, which looks like "item: {item_name}, price: {price}, amount: {amount}"
            // context.getUserByID(user.id).purchase_history.Add(context.GetSoldString(related_item, sell_num));
            return true;
        }

        throw new Exception("Attempting to buy item with insufficient funds or out of stock - buisness-logic error");
    }
}

public class SupplyEvent : IEvent
{
    public IItem related_item { get; }
    public IUser user { get; }
    public int supply_num { get; }

    public SupplyEvent(IItem relatedItem, IUser user, int supply_num)
    {
        related_item = relatedItem;
        this.user = user;
        this.supply_num = supply_num;
    }

    public bool Perform(IDataHandler context)
    {
        context.edit_item(1,related_item.id,related_item.name,related_item.price,related_item.nums_in_stock+supply_num);
        return true;
    }
}

public class RemoveProductEvent : IEvent
{
    public int id { get; }
    public IUser user { get; }

    public RemoveProductEvent(int id, IUser user)
    {
        id = id;
        this.user = user;
    }

    public bool Perform(IDataHandler context)
    {
        if (context.GetItem(id) == null)
        {
            throw new Exception("Item doesnt exist!");
        }
        try
        {
            context.remove_item(user.id, id);
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Cant remove the item");
        }
        
    }
}

public class EditProductEvent : IEvent
{
    public int id { get; }
    public IUser user { get; }

    public string name { get; }
    
    public float price { get; }
    
    public int num { get; }
    
    public EditProductEvent(int id, IUser user, string name, float price, int num)
    {
        this.id = id;
        this.user = user;
        this.name = name;
        this.price = price;
        this.num = num;
    }

    public bool Perform(IDataHandler context)
    {
        try
        {
            context.edit_item(user.id, id, name, price, num);
            return true;
        }
        catch (Exception)
        {
            throw new Exception("Cant edit this item!");
        }
    }
}