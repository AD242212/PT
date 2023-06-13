namespace Presentation.Model;

public interface IItemModel
{
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }

    void add_item();
}