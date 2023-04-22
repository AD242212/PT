﻿using System.Collections;

namespace PT
{
    public class userView
    {
        private List<user> userList = new List<user>();


        public void add_user(user usr)
        {
            userList.Add(usr);
        }

        public userView()
        {
            seller s1 = new seller( "seller1", "seller_password");
            customer s2 = new customer( "customer1", "customer_password");
            admin s3 = new admin( "admin1", "admin_password");


            userList.Add(s1);
            userList.Add(s2);
            userList.Add(s3);
            

        }
        

        public user getUserByID(string id)
        {
            foreach (user usr in userList)
            {
                if (usr.id == id)
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
                if (usr.username == username)
                {
                    return usr;
                }
            }

            return null;
        }


        // returns 0 for wrong credentials 
        // 1 for customer, 2 for seller and 3 for admin
        public int validate_user(string username, string password)
        {
            foreach (user usr in userList)
            {
                if (usr.username == username && usr.password == password)
                {
                    return check_user_type(usr);
                }
            }

            return 0;
        }

        public int check_user_type(user usr)
        {
            if (usr.GetType() == typeof(customer))
            {
                return 1;
            }
            else if (usr.GetType() == typeof(seller))
            {
                return 2;
            }
            else if (usr.GetType() == typeof(admin))
            {
                return 3;
            }
            else
            {
                throw new InvalidDataException("Incorrect user type");
            }
        }

        public bool username_available(string username)
        {
            foreach (user usr in userList)
            {
                if (usr.username == username)
                    return false;
            }

            return true;
            
        }
        
    }
}