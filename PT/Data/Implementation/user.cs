using PT.Data.API;

namespace PT
{
    public class user : IUser
    {
        public user(string username, string password, float balance)
        {
            id = System.Guid.NewGuid().ToString();
            this.username = username;
            this.password = password;
            this.balance = balance;
            this.purchase_history = new List<string>();
        }


        public string password { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public List<string> purchase_history { get; set; }
        public float balance { get; set; }
    }

    public class seller : user
    {
        public seller(string username, string password, float balance) : base(username, password, balance)
        {
        }
    }

    public class customer : user
    {
        public customer(string username, string password, float balance) : base(username, password, balance)
        {
        }
    }

    public class admin : user
    {
        public admin(string username, string password, float balance) : base(username, password, balance)
        {
        }
    }
}