namespace PT;

public class State
{
    private Dictionary<int, Item> items = new Dictionary<int, Item>();

    private int next_id;

    public State()
    {
        Laptop l1 = new Laptop(0, "ThinkPad1", 200.99f, 1);
        Laptop l2 = new Laptop(1, "ThinkPad2", 250.99f, 2);
        Phone p1 = new Phone(2, "Redmi1", 150.99f, 3);
        Phone p2 = new Phone(3, "Redmi2", 199.99f, 4);

        next_id = 4; 
    
    
        items.Add(l1.GetId(),l1);
        items.Add(l2.GetId(),l2);
        items.Add(p1.GetId(),p1);
        items.Add(p2.GetId(),p2);
        
    }

    public int get_next_id()
    {
        return next_id;
    }

    public void add_item(Item item)
    {
        items[next_id] = item;
        next_id++;
    }
    
    

    public Item GetItem(int id)
    {
        return items[id];
    }

    public int GetItemsNumber()
    {
        return items.Count;
    }

    public Item GetCheapestItem()
    {
        float min = float.MaxValue;
        int id = 0;
        
        if (items.Count == 0)
            return null;
        
        foreach(var item in items)
        {
            if (item.Value.GetPrice() < min)
            {
                min = item.Value.GetPrice();
                id = item.Value.GetId();
            }
        }

        return items[id];
    }
    
    public Item GetMostExpensiveItem()
    {
        float max = 0;
        int id = 0;
        
        if (items.Count == 0)
            return null;
        
        foreach(var item in items)
        {
            if (item.Value.GetPrice() > max)
            {
                max = item.Value.GetPrice();
                id = item.Value.GetId();
            }
        }

        return items[id];
    }
    
    
    public Item GetLeastAvailableItem()
    {
        int min = int.MaxValue;
        int id = 0;
        
        if (items.Count == 0)
            return null;
        
        foreach(var item in items)
        {
            if (item.Value.GetNumsInStock() < min)
            {
                min = item.Value.GetNumsInStock();
                id = item.Value.GetId();
            }
        }

        return items[id];
    }
    
    public Item GetMostAvailableItem()
    {
        int max = 0;
        int id = 0;
        
        if (items.Count == 0)
            return null;
        
        foreach(var item in items)
        {
            if (item.Value.GetNumsInStock() > max)
            {
                max = item.Value.GetNumsInStock();
                id = item.Value.GetId();
            }
        }

        return items[id];
    }

    public int GetItemsInStock()
    {
        int items_num = 0;
        
        foreach(var item in items)
        {
            items_num += item.Value.GetNumsInStock();
        }

        return items_num;
    }
    
}