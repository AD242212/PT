using Data.Implementation;
using Logic.API;
using Logic.Implementation;

namespace Presentation;

public class ItemModel: IItemModel
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int nums_in_stock { get; set; }

    private IBusinessLogic logic = new BusinessLogic(new DataHandler());
    public void add_item()
    {
        logic.AddProduct(name, price, nums_in_stock);
    }
}