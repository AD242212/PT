using Data.Database;

namespace Data.API;

public interface IDataHolder
{


    public List<IUser> users {get; set;}
    public List<IItem> items {get; set;}
    public List<IEvent> events {get; set;}

}