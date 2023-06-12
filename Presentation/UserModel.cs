using Data.API;

namespace Presentation
{
    public class UserModel : IUser
    {
        public string password { get; set; }
        public string username { get; set; }
        public int id { get; set; }
        public float balance { get; set; }
        


        void add_user()
        {
            
        }
        
    }
}