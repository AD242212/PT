namespace Data.API;

public interface IUser
{
    string password { get; set; }
    string username { get; set; }
    public int id { get; set; }
    public float balance { get; set; }
}