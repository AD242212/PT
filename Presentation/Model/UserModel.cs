using Logic.API;

namespace Presentation.Model
{
    public class UserModel : IUserModel
    {
        public string password { get; set; }
        public string username { get; set; }
        
        public float balance { get; set; }

        private IBusinessLogic logic;

        public UserModel(IBusinessLogic logic, string username, string password, float balance)
        {
            this.logic = logic;
            this.username = username;
            this.password = password;
            this.balance = balance;
        }

        public void add_user()
        {
            logic.AddUser(username, password, (int) balance);
        }
    }
}