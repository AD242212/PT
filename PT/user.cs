namespace PT
{
    
    abstract class user
    {
        private int id;
        private string username;
        private string password;

        public user()
        {
        }

        public user(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }

    class seller : user
    {
    }

    class customer : user
    {
    }

    class admin : user
    {
    }
}