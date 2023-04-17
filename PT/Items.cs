namespace PT
{
    abstract class Item
    {
        private int id;
        private string name;
        private float price;
        private int nums_in_stock;

        public Item(int id, string name, float price, int nums_in_stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.nums_in_stock = nums_in_stock;
        }

        public Item()
        {

        }

    }

    class Phone : Item
    {

    }

    class Laptop : Item
    {

    }
}
