namespace PT.Data.API;

public interface IUser
{
    string password { get; set; }
    string username { get; set; }
    string email { get; set; }
    public string id { get; set; }
}