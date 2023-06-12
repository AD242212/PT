namespace Presentation;

public interface IItemModel
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }

    void add_item();
}