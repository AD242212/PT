namespace Presentation.Model;

public interface IUserModel
{
    public string password { get; set; }
    public string username { get; set; }
    public float balance { get; set; }

    void add_user();


}