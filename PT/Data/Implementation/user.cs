using PT.Data.API;

namespace PT
{
    public class user : IUser
    {
        public user(string username, string password)
        {
            id = System.Guid.NewGuid().ToString();
            this.username = username;
            this.password = password;
        }


        public string password { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string id { get; set; }
    }

    public class seller : user
    {
        public seller(string username, string password) : base(username, password)
        {
        }
    }

    public class customer : user
    {
        public customer(string username, string password) : base(username, password) { }
    }

    public class admin : user
    {
        public admin(string username, string password) : base( username, password) { }
    }
}