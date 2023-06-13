using Data.Implementation;
using Logic.API;
using Logic.Implementation;

namespace Presentation.Model
{
    public class UserModel : IUserModel
    {
        public string password { get; set; }
        public string username { get; set; }
        
        public float balance { get; set; }

        private IBusinessLogic logic = new BusinessLogic(new DataHandler());

        public UserModel(string username, string password, float balance)
        {
            this.username = username;
            this.password = password;
            this.balance = balance;
        }

        public void add_user()
        {
            logic.AddUser(username, password, 0);
        }
    }
}