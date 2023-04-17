namespace PT
{
    abstract public class user
    {
        private int id;
        private string username;
        private string password;


        public user(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public int get_id()
        {
            return this.id;
        }

        public string get_name()
        {
            return this.username;
        }

        public string get_password()
        {
            return this.password;
        }
    }

    public class seller : user
    {
        public seller(int id, string username, string password) : base(id, username, password)
        {
        }
    }

    public class customer : user
    {
        public customer(int id, string username, string password) : base(id, username, password)
        {
        }
    }

    public class admin : user
    {
        public admin(int id, string username, string password) : base(id, username, password)
        {
        }
    }
}