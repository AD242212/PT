using PT.Data.API;

namespace PT.Data.Implementation;

public class SellEvent : IEvent
{
    public IItem related_item { get; }
    public IDataHandler context { get; }
    public IUser user { get; }
    public int sell_num { get; }

    public SellEvent(IItem relatedItem, IDataHandler context, IUser user, int sell_num)
    {
        related_item = relatedItem;
        this.context = context;
        this.user = user;
        this.sell_num = sell_num;
    }

    public bool Perform()
    {
        if (context.can_afford(user.id, related_item.price) && context.GetItem(related_item.id).nums_in_stock > 0)
        {
            // todo add user bought items, aswell as cart(?) 
            context.GetItem(related_item.id).nums_in_stock -= sell_num;
            context.getUserByID(user.id).balance -= related_item.price;

            // creates entry in purchase history, which looks like "item: {item_name}, price: {price}, amount: {amount}"
            context.getUserByID(user.id).purchase_history.Add(context.GetSoldString(related_item, sell_num));
            return true;
        }

        throw new Exception("Attempting to buy item with insufficient funds - buisness-logic error");
    }
}

public class SupplyEvent : IEvent
{
    public IItem related_item { get; }
    public IDataHandler context { get; }
    public IUser user { get; }
    public int supply_num { get; }

    public SupplyEvent(IItem relatedItem, IDataHandler context, IUser user, int supply_num)
    {
        related_item = relatedItem;
        this.context = context;
        this.user = user;
        this.supply_num = supply_num;
    }

    public bool Perform()
    {
        if (context.GetItem(related_item.id) != null)
        {
            context.GetItem(related_item.id).nums_in_stock += supply_num;
        }
        else
        {
            if (related_item.nums_in_stock != 0)
            {
                throw new Exception("New items need to have 0 units in stock when created ");
            }

            related_item.nums_in_stock += supply_num;
            context.add_item(related_item);
        }

        return true;
    }
}