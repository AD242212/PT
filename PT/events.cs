namespace PT;

public class events
{
    public userView view = new userView();

    public bool create_new_user(string username, string password, int usrType)
    {
        user newusr;
        int nextid = view.get_next_id();

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

            view.add_user(newusr);
            return true;
        }


        return false;
    }
}