namespace Presentation;
using Data.API;

public class ItemModel: IItem
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }
    
    void add_item(){}
    
}