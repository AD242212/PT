using PT.Logic.Interface;

namespace PT.Logic.Implementation;

public class BuisnessLogic : IBuisnessLogic
{
    public void Buy()
    {
        // only can buy when item in stock and sufficient funds
        throw new NotImplementedException();
    }

    public void Supply()
    {
        // only can supply as a seller 
        throw new NotImplementedException();
    }

    public void RemoveProduct()
    {
        // need event, only can as seller
        throw new NotImplementedException();
    }

    public void EditProduct()
    {
        // need event, only can as seller
        throw new NotImplementedException();
    }

    
    // not sure about those, do we need them ( ? ), probably yes
    // but in implemented very simple way 
    // probably make implementation in different class, and let BuisnessLogic
    // store _authentication_ object to handle logic of it. 
    public void Login()
    {
        throw new NotImplementedException();
    }

    public void Register()
    {
        throw new NotImplementedException();
    }

    public void LogOut()
    {
        throw new NotImplementedException();
    }
}