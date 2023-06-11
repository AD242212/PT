using Data.API;

namespace Data.API;

public interface IEvent
{
    IUser user { get; }
    
    bool Perform(IDataHandler context);
}