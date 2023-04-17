namespace PT;

public class events
{
    public userView UserView = new userView();
    public State ItemView = new State();

    public bool create_new_user(string username, string password, int usrType)
    {
        user newusr;
        int nextid = UserView.get_next_id();

        if (username.Length > 0 && username.Length < 15 && password.Length > 0 && password.Length < 25)
        {
            switch (usrType)
            {
                case 1:
                    newusr = new customer(nextid, username, password);
                    break;
                case 2:
                    newusr = new seller(nextid, username, password);
                    break;
                case 3:
                    newusr = new admin(nextid, username, password);
                    break;
                default:
                    throw new InvalidDataException("Unknown user type");
            }

            UserView.add_user(newusr);
            return true;
        }


        return false;
    }

    public bool create_new_item(string name, float price, int num_of_items, string item_type)
    {
        int id = ItemView.get_next_id();
        Item item;
        if (name.Length > 0 && name.Length < 25 && price > 0 && num_of_items >= 0)
        {
            switch (item_type)
            {
                case "Laptop":
                    item = new Laptop(id, name, price, num_of_items);
                    break;
                case "Phone":
                    item = new Phone(id, name, price, num_of_items);
                    break;
                default:
                    throw new InvalidDataException("Unknown user type");       
                
            }
            
            ItemView.add_item(item);
            return true;
        }

        return false;


    }
    
}