namespace PT.Data.API;

public interface IEvent
{
    IDataHandler context { get; }

    IUser user { get; }
    
    bool Perform();
}