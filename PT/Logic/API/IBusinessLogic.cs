using PT.Data.API;
using PT.Data.Implementation;
using PT.Logic.Implementation;

namespace PT.Logic.API;

public interface IBusinessLogic
{
    static IBusinessLogic LogicEntry(IDataHandler dataHandler)
    {
        return new BusinessLogic(dataHandler);
    }

    void AddFunds(float funds);

    void Buy(int id, int supply_num);

    void Supply(int id, string name, float price, int num, int supply_num);

    void RemoveProduct(int id);

    void EditProduct(int id, string name, float price, int num);

    bool Login(string username, string password);

    bool Register(string username, string password, int type);

    void LogOut();
}