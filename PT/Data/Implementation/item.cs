using PT.Data.API;

namespace PT
{
    public class Item : IItem
    {
        public Item(int id, string name, float price, int nums_in_stock,
            Dictionary<string, string>? additional_properties = null)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.nums_in_stock = nums_in_stock;
            if (additional_properties != null)
            {
                this.additonal_properties = additional_properties;
            }
        }

        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int nums_in_stock { get; set; }

        public Dictionary<string, string> additonal_properties { get;}
    }
}