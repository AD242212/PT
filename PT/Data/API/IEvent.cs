namespace PT.Data.API;

public interface IEvent
{

    IItem related_item { get; }
    
    IDataHandler context { get; }

    IUser user { get; }
    
    bool Perform();
}