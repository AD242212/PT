namespace PT_Test;

public class dbstring
{
    public static String getCtString()
    {
        string RPath = @"Shop.mdf";
        string RootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string DatabasePath = Path.Combine(RootPath, RPath);
        string d = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DatabasePath};Integrated Security = True;";
        
        return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DatabasePath};Integrated Security = True;";
    }
}