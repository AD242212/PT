using PT.Logic.API;
using PT.Data.API;
using PT.Data.Implementation;

namespace PT.Logic.Implementation;

public class BusinessLogic : IBusinessLogic
{
    private IDataHandler dataHandler;
    private IUser currentUser;
    private bool loggedIn = false;
    public BusinessLogic(IDataHandler dataHandler)
    {
        this.dataHandler = dataHandler;
    }

    public void AddFunds(float funds)
    {
        if (!loggedIn)
            return;
        dataHandler.add_funds(currentUser.id, funds);
    }

    public void Buy(int id)
    {
        if (!loggedIn)
            return;
        
        if (dataHandler.check_user_type(currentUser) == 1
            && dataHandler.GetItem(id).nums_in_stock > 0 
            && dataHandler.getUserByID(currentUser.id).balance > dataHandler.GetItem(id).price)
        {
            dataHandler.getUserByID(currentUser.id).balance -= dataHandler.GetItem(id).price;
            dataHandler.GetItem(id).nums_in_stock--;
        }
    }

    public void Supply(int id,string name, float price, int num)
    {
        if (!loggedIn)
            return;

        if (dataHandler.check_user_type(currentUser) == 2
            )
        {
            dataHandler.add_item(new Item(id, name, price, num));
        }
    }

    public void RemoveProduct(int id)
    {
        if (!loggedIn)
            return;

        if (dataHandler.check_user_type(currentUser) == 2)
        {
            dataHandler.remove_item(id);
        }
    }

    public void EditProduct(int id, string name, float price, int num)
    {
        if (!loggedIn)
            return;

        if (dataHandler.check_user_type(currentUser) == 2)
        {
            dataHandler.edit_item(id, name, price, num);
        }
    }
    
    //returns true if successful
    public bool Login(string username, string password)
    {
        if (dataHandler.validate_user(username, password) > 0)
        {
            currentUser = dataHandler.getUserByName(username);
            loggedIn = true;
            return true;
        }

        return false;
    }
    
    //returns true if successful
    public bool Register(string username, string password, int type)
    {
        if (dataHandler.username_available(username) 
            && username.Length < 15 
            && username.Length > 3
            && password.Length < 15 
            && password.Length > 3)
        {
            switch (type)
            {
                case 1:
                    dataHandler.add_user(new customer(username, password, 0));
                    break;
                case 2:
                    dataHandler.add_user(new admin(username, password, 0));
                    break;
            }

            return true;
        }

        return false;
    }

    public void LogOut()
    {
        loggedIn = false;
    }
}