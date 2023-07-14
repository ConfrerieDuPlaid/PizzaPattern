namespace PizzaPattern;

public class Bill : ISerializable
{
    private Dictionary<StandardPizza, int> OrderRows { get; } = new Dictionary<StandardPizza, int>();
    private Order Order;
    public Bill(Order order)
    {
        this.Order = order;
    }

    public double ComputeTotal()
    {
        double total = 0.0;
        foreach (var pizza in this.Order.GetOrderList())
        {
            total += pizza.Price * pizza.Count;
        }
        return total;
    } 
    
    public string AcceptSerializer(ISerializer serializer)
    {
        return serializer.Serialize(this);
    }

    public List<Pizza> GetOrderRows()
    {
        return this.Order.GetOrderList();
    }
}