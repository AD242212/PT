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

    public bool AddFunds(float funds)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");
        
        AddFundsEvent evt = new AddFundsEvent(dataHandler, currentUser, funds);
        evt.Perform();

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
            SellEvent evt = new SellEvent(dataHandler.GetItem(id), dataHandler, currentUser, num_to_buy);
            evt.Perform();
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

        if (dataHandler.check_user_type(currentUser) == 2)
        {
            SupplyEvent evt = new SupplyEvent(dataHandler.GetItem(id), dataHandler, currentUser, supply_num);
            evt.Perform();
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

        RemoveProductEvent evt = new RemoveProductEvent(id, dataHandler, currentUser);
        evt.Perform();
        
        return true;
    }

    public bool EditProduct(int id, string name, float price, int num)
    {
        if (!loggedIn)
            throw new Exception("Not logged in!");
        
        EditProductEvent evt = new EditProductEvent(id, dataHandler, currentUser, name, price, num);
        evt.Perform();
        
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

    public bool LogOut()
    {
        loggedIn = false;
        dataHandler.getUserByID(currentUser.id).balance = currentUser.balance;

        return true;
    }
}