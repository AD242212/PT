namespace PT.Data.API;

public interface IUser
{
    string password { get; set; }
    string username { get; set; }
    public string id { get; set; }

    public List<string> purchase_history { get; set; }
    public float balance { get; set; }
}