using Data.API;

namespace Data.Implementation;

public class Item : IItem
{
    public Item(int id, string name, float price, int nums_in_stock)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.nums_in_stock = nums_in_stock;

    }

    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }

}