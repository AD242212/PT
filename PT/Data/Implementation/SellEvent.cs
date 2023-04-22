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
        if (context.can_afford(user.id, related_item.price) && context.GetItem(related_item.id).nums_in_stock>0)
        {
            // todo add user bought items, aswell as cart(?) 
            context.GetItem(related_item.id).nums_in_stock -= 1;
            context.getUserByID(user.id).balance -= related_item.price;

            return true;
        }

        return false;
    }
}