namespace PT.Data.API;

public interface IDataHolder
{
    public List<IUser> users {get; set;}
    public List<IItem> items {get; set;}


}