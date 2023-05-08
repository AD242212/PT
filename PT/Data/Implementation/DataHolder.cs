using PT.Data.API;

namespace PT.Data.Implementation;

public class DataHolder: IDataHolder
{
    public List<IUser> users { get; set; }
    public List<IItem> items { get; set; }

    public List<IEvent> events { get; set; }

    public DataHolder()
    {
        this.users = new List<IUser>();

        this.items = new List<IItem>();
        
        this.events = new List<IEvent>();
    }
}