namespace Data.API;

public interface IItem
{
    int id { get; set; }
    string name { get; set; }
    float price { get; set; }
    int nums_in_stock { get; set; }

}