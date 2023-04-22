using PT.Data.API;

namespace PT;

public class SellEvent : IEvent
{
    public IItem related_item { get; }
    public IDataHandler context { get; }
    public IUser user { get; }

    public SellEvent(IItem relatedItem, IDataHandler context, IUser user)
    {
        related_item = relatedItem;
        this.context = context;
        this.user = user;
    }

    public bool Perform()
    {
        if (context.can_afford(user.id, related_item.price) && context.GetItem(related_item.id).nums_in_stock > 0)
        {
            // todo add user bought items, aswell as cart(?) 
            context.GetItem(related_item.id).nums_in_stock -= 1;
            context.getUserByID(user.id).balance -= related_item.price;

            return true;
        }

        return false;
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