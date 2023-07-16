namespace PizzaPattern.history;

public interface IOriginator
{
    public OrderSnapshot CreateSnapshot();

    public void Restore(OrderSnapshot snapshot);

    public static abstract Order Of(OrderSnapshot snapshot);
}