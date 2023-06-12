using Logic.API;
using Data.API;
using Data.Implementation;

namespace Logic.Implementation;

public class BusinessLogic : IBusinessLogic
{
    private IDataHandler dataHandler;
    private IUser currentUser;
    private bool loggedIn = true;

    public BusinessLogic(IDataHandler dataHandler)
    {
        this.dataHandler = dataHandler;
    }

    public bool AddFunds(float funds)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");
        
        dataHandler.NewAddFundsEvent(currentUser, funds);

        return true;
    }

    public bool Sell(int id, int num_to_buy)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");

        if (dataHandler.check_user_type(currentUser) == 1
            && dataHandler.GetItem(id).nums_in_stock >= num_to_buy
            && dataHandler.getUserByID(currentUser.id).balance >= dataHandler.GetItem(id).price * num_to_buy)
        {
            dataHandler.NewSellEvent(dataHandler.GetItem(id), currentUser, num_to_buy);
        }
        else
        {
            throw new Exception("Insufficient balance or not enough items in stock!");
        }
        
        return true;
    }

    public bool Supply(int id, int supply_num)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");

        if (dataHandler.check_user_type(currentUser) == 1)
        {
            dataHandler.NewSupplyEvent(dataHandler.GetItem(id), currentUser, supply_num);
        }
        else
        {
            throw new Exception("Not admin!");
        }

        return true;
    }

    public bool RemoveProduct(int id)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");

        dataHandler.NewRemoveProductEvent(id, currentUser);
        
        return true;
    }

    public bool EditProduct(int id, string name, float price, int num)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");
        
        dataHandler.NewEditProductEvent(id, currentUser, name, price, num);
        
        return true;
    }
    
    public bool AddProduct(string name, float price, int num)
    {
        
        dataHandler.add_item(new Item(dataHandler.get_next_usr_id(), name, price, num));
        
        return true;
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
                    dataHandler.add_user(1,false, username, password, 0);
                    break;
                case 2:
                    dataHandler.add_user(2,true, username, password, 0);
                    break;
            }

            return true;
        }

        return false;
    }

    public bool LogOut()
    {
        loggedIn = false;
        dataHandler.getUserByID(currentUser.id).balance = currentUser.balance;

        return true;
    }
}