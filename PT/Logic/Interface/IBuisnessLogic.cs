using PT.Data.API;
using PT.Logic.Implementation;

namespace PT.Logic.Interface;

public interface IBuisnessLogic
{
    static IBuisnessLogic LogicEntry(IDataHandler dataHandler)
    {
        return new BuisnessLogic();
    }

    void Buy();

    void Login();

    void Register();

    void LogOut();
    void RemoveProduct();

    void EditProduct();
    void Supply();


}