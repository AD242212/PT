using Data.API;
using Logic.API;
using Presentation.Model;

namespace Presentation.ViewModel.Tests;

internal class User : IUser
{
    public string password { get; set; }
    public string username { get; set; }
    public int id { get; set; }
    public float balance { get; set; }
}

internal class Item : IItem
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }
}

internal class DataHandlerTest : IBusinessLogic
{
    public List<IUser> Users = new List<IUser>();
    public List<IItem> Items = new List<IItem>();


    public bool AddFunds(float funds)
    {
        throw new NotImplementedException();
    }

    public bool Sell(int id, int supply_num)
    {
        throw new NotImplementedException();
    }

    public bool Supply(int id, int supply_num)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProduct(int id)
    {
        throw new NotImplementedException();
    }

    public bool EditProduct(int id, string name, float price, int num)
    {
        throw new NotImplementedException();
    }

    public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public bool Register(string username, string password, int type)
    {
        throw new NotImplementedException();
    }




    public IUser getUserByName(string username)
    {
        throw new NotImplementedException();
    }




    public bool AddUser(string username, string password, int funds)
    {
        Users.Add(new Data.Implementation.User(0, username, password, funds));
        return true;
    }

    public bool LogOut()
    {
        throw new NotImplementedException();
    }

    public bool AddProduct(string name, float price, int num)
    {
        Items.Add(new Data.Implementation.Item(0,name,price,num));
        return true;
    }

    public IItem getItembyId(int id)
    {
        foreach (var usr in Items)
        {
            if (usr.id == id)
            {
                return usr;
            }
        }

        throw new Exception();
        
    }

    public IUser getUserByID(int id)
    {
        foreach (var usr in Users)
        {
            if (usr.id == id)
            {
                return usr;
            }
        }

        throw new Exception();    }

    public IItem getItembyName(string name)
    {
        foreach (var usr in Items)
        {
            if (usr.name == name)
            {
                return usr;
            }
        }

        throw new Exception();
    }

    public IUser getUserbyName(string name)
    {
        foreach (var usr in Users)
        {
            if (usr.username == name)
            {
                return usr;
            }
        }

        throw new Exception();    }

    public List<IItem> get_items()
    {
        return new List<IItem>();
    }

    public List<IUser> get_users()
    {

        return new List<IUser>();
    }
}