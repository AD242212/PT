using System.Collections;

namespace PT
{
    public class userView
    {
        private List<user> userList = new List<user>();

        public userView()
        {
            seller s1 = new seller(1, "1", "nie");
            customer s2 = new customer(2, "2", "nie");
            admin s3 = new admin(3, "3", "nie");

            userList.Add(s1);
            userList.Add(s2);
            userList.Add(s3);
        }

        public user getUserByID(int id)
        {
            foreach (user usr in userList)
            {
                if (usr.get_id() == id)
                {
                    return usr;
                }
            }

            return null;
        }

        public user getUserByName(string username)
        {
            foreach (user usr in userList)
            {
                if (usr.get_name() == username)
                {
                    return usr;
                }
            }

            return null;
        }


        // returns 0 if wrong credentials 
        public int validate_user(string username, string password)
        {
            foreach (user usr in userList)
            {
                if (usr.get_name() == username && usr.get_password() == password)
                {
                    
                    
                }
                
            }

            return 0;
        }

        public int check_user_type(user usr)
        {
            if (usr.GetType() == typeof(seller))
            {
                return 1;
            }

            return 0;
        }
        
        
    }
}