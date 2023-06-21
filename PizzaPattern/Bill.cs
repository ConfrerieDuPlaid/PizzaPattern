namespace PizzaPattern;

public class Bill : ISerializable
{
    private Dictionary<Pizza, int> OrderRows { get; } = new Dictionary<Pizza, int>();
    public Bill(Order order)
    {
        Dictionary<string, int> orderList = order.GetOrderList();
        foreach (string pizzaName in orderList.Keys)
        {
            Pizza pizza = Pizza.Of(pizzaName);
            this.OrderRows.Add(pizza, orderList[pizzaName]);
        }
    }

    public double ComputeTotal()
    {
        double total = 0.0;
        foreach (var row in this.OrderRows)
        {
            total += row.Value * row.Key.Price;
        }
        return total;
    } 
    
    public void PrintBill()
    {
        Pizza pizza;
        foreach (var row in this.OrderRows)
        {
            pizza = row.Key;
            Console.WriteLine("{0} {1} : {0} * {2}€", row.Value, pizza.Name, pizza.Price);
            foreach (var ingredient in pizza.Ingredients)
            {
                Console.WriteLine("{0} {1} {2}", ingredient.Name, ingredient.Unit, ingredient.Quantity);
            }
        }
        Console.WriteLine("Prix total : {0}€", this.ComputeTotal());
    }

    public string AcceptSerializer(ISerializer serializer)
    {
        return serializer.Serialize(this);
    }

    public Dictionary<Pizza, int> GetOrderRows()
    {
        return this.OrderRows;
    }
}