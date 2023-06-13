using Data.Implementation;
using Logic.API;
using Logic.Implementation;

namespace Presentation.Model;

public class ItemModel : IItemModel
{
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }

    private IBusinessLogic logic = new BusinessLogic(new DataHandler());

    public ItemModel(string name, float price, int nums_in_stock)
    {
        this.name = name;
        this.price = price;
        this.nums_in_stock = nums_in_stock;
    }
    public void add_item()
    {
        logic.AddProduct(name, price, nums_in_stock);
    }
}