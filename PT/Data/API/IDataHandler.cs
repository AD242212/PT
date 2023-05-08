using PT.Data.Implementation;

namespace PT.Data.API;

public interface IDataHandler
{
    static IDataHolder create_storage(IDataHolder data)
    {
        return new DataHolder();
    }

// // // // // // // USER METHODS // // // //// // // //
    void add_user(int type, string username, string password, int balance);
    IUser getUserByID(string id);
    IUser getUserByName(string username);
    int validate_user(string username, string password);
    int check_user_type(IUser usr);
    public bool username_available(string username);
    public bool email_available(string mail);
    public bool add_funds(string id, float funds);
    public bool can_afford(string user_id, float price);


// // // // // // // ITEM METHODS // // // //// // // //

    void add_item(IItem item);
    void remove_item(string user_id, int id);
    IItem GetItem(int id);
    void edit_item(string user_id, int id, string name, float price, int num);
    int GetNumOfDistinctItemsInStock();
    IItem GetCheapestItem();
    IItem GetMostExpensiveItem();
    IItem GetLeastAvailableItem();
    IItem GetMostAvailableItem();

    String GetSoldString(IItem item, int ammount);
    
// // // // // // // EVENTS // // // //// // // //

    void NewAddFundsEvent(IUser user, float amount);
    void NewSellEvent(IItem relatedItem, IUser user, int sell_num);
    void NewSupplyEvent(IItem relatedItem, IUser user, int supply_num);
    void NewRemoveProductEvent(int id, IUser user);
    void NewEditProductEvent(int id, IUser user, string name, float price, int num);

}