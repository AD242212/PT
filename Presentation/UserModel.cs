using Data.API;
using Data.Implementation;
using Logic.API;
using Logic.Implementation;

namespace Presentation
{
    public class UserModel : IUserModel
    {
        public string password { get; set; }
        public string username { get; set; }
        public int id { get; set; }
        public float balance { get; set; }
        
        private IBusinessLogic logic = new BusinessLogic(new DataHandler());

        public void add_user()
        {
            
        }
    }
}