﻿using PT.Data.API;
using PT.Data.Implementation;
using PT.Logic.Implementation;

namespace PT.Logic.API;

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

    bool LogOut();
}