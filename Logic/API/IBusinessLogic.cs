using Data.API;
using Logic.Implementation;

namespace Logic.API;

public interface IBusinessLogic
{
    static IBusinessLogic LogicEntry(IDataHandler dataHandler)
    {
        return new BusinessLogic(dataHandler);
    }

    bool AddFunds(float funds);

    bool Sell(int id, int supply_num);

    bool Supply(int id, int supply_num);

    bool RemoveProduct(int id);

    bool EditProduct(int id, string name, float price, int num);

    bool Login(string username, string password);

    bool Register(string username, string password, int type);

    bool AddUser(string username, string password, int funds);

    bool LogOut();

    public bool AddProduct(string name, float price, int num);

    public IItem getItembyId(int id);
    public IUser getUserByID(int id);

    public IItem getItembyName(string name);

    public IUser getUserbyName(string name);

}