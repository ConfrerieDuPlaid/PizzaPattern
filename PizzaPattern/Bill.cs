using PizzaPattern.serializers;

namespace PizzaPattern;

public class Bill : ISerializable
{
    private readonly Order _order;
    public Bill(Order order)
    {
        _order = order;
    }

    public double ComputeTotal()
    {
        return _order.GetOrderList().Sum(pizza => pizza.Price * pizza.Count);
    } 
    
    public string AcceptSerializer(ISerializer serializer)
    {
        return serializer.Serialize(this);
    }

    public List<Pizza> GetOrderRows()
    {
        return _order.GetOrderList();
    }
}