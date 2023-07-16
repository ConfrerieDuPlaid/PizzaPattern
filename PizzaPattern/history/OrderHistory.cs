namespace PizzaPattern.history;

public class OrderHistory
{
    private readonly List<OrderSnapshot> _orderSnapshots = new List<OrderSnapshot>();

    private OrderHistory() {}

    public void Add(OrderSnapshot order)
    {
        _orderSnapshots.Add(order);
    }

    public void Export()
    {
        _orderSnapshots.Clear();
        throw new NotImplementedException();
    }

    public void Print()
    {
        Console.WriteLine("History of orders :");
        foreach (var snapshot in _orderSnapshots)
        {
            Console.WriteLine("> " + snapshot.State());
        }
    }

    private static OrderHistory? _instance = null;

    public static OrderHistory GetInstance()
    {
        return _instance ??= new OrderHistory();
    }
}