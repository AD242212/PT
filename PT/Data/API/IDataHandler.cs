namespace PT.Data.API;

public interface IDataHandler
{
    static IDataHolder create_storage(IDataHolder data)
    {
        return new DataHolder();
    }

// // // // // // // USER METHODS // // // //// // // //
    void add_user(user usr);
    IUser getUserByID(string id);
    IUser getUserByName(string username);
    int validate_user(string username, string password);
    int check_user_type(IUser usr);
    public bool username_available(string username);
    public bool email_available(string mail);

    public bool can_afford(string user_id, float price);


// // // // // // // ITEM METHODS // // // //// // // //

    void add_item(IItem item);
    IItem GetItem(int id);
    int GetNumOfDistinctItemsInStock();
    IItem GetCheapestItem();
    IItem GetMostExpensiveItem();
    IItem GetLeastAvailableItem();
    IItem GetMostAvailableItem();
}