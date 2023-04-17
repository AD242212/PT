namespace PT
{
    public abstract class Item
    {
        private int id;
        private string name;
        private float price;
        private int nums_in_stock;

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public float GetPrice()
        {
            return price;
        }

        public int GetNumsInStock()
        {
            return nums_in_stock;
        }
        
        public Item(int id, string name, float price, int nums_in_stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.nums_in_stock = nums_in_stock;
        }

    }

    public class Phone : Item
    {
        public Phone(int id, string name, float price, int nums_in_stock): base(id, name, price, nums_in_stock)
        {
        }
    }

    public class Laptop : Item
    {
        public Laptop(int id, string name, float price, int nums_in_stock): base(id, name, price, nums_in_stock)
        {
        }
    }
}
