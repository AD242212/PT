
using Data.Database;
using Data.Implementation;

namespace Data.API;

public interface IDataHandler
{

    

// // // // // // // USER METHODS // // // //// // // //
    void add_user(int id, bool type, string username, string password, int balance);
    IUser getUserByID(int id);
    IUser getUserByName(string username);
    int validate_user(string username, string password);
    int check_user_type(IUser usr);
    public bool username_available(string username);
    public bool email_available(string mail);
    public bool add_funds(int id, float funds);
    public bool can_afford(int id, float price);


// // // // // // // ITEM METHODS // // // //// // // //

    void add_item(IItem item);
    void remove_item(int user_id, int id);
    IItem GetItem(int id);
    void edit_item(int user_id, int id, string name, float price, int num);
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