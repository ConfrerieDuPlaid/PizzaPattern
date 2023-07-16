namespace PizzaPattern.history;

public class OrderSnapshot : IMemento
{
    private readonly string _orderInput;

    public OrderSnapshot(string orderInput)
    {
        this._orderInput = orderInput;
    }

    public string State()
    {
        return _orderInput;
    }
}