using PizzaPattern.history;

namespace PizzaPattern;

public class Order : IOriginator
{
    private readonly List<Pizza> _orderList = new ();

    private readonly string _input;
    public Order(string order)
    {
        string[] orderRows = order.Split(",");
        Pizza pizza;
        int numberOfPizza = 0;
        string basePizzaName = "";
        foreach (string orderRow in orderRows)
        {
            string[] rowElements = orderRow.Trim().Split(" ");

            numberOfPizza = int.Parse(rowElements[0]);
            if (numberOfPizza < 1)
            {
                throw new Exception("Invalid row format for row : " + orderRow);
            }

            basePizzaName = rowElements[1];
            string[] updateIngredients = Array.Empty<string>();
            if (rowElements.Length > 2) updateIngredients = rowElements.Skip(2).ToArray();
            pizza = new Pizza(basePizzaName, numberOfPizza, updateIngredients);
            int index = _orderList.IndexOf(pizza);
            if (index != -1)
            {
                _orderList[index].Count += numberOfPizza;
            }
            else
            {
                _orderList.Add(pizza);
            }
        }

        _input = order;
    }

    public void PrintAllInstructions()
    {
        foreach (var pizza in _orderList)
        {
            new Instructions(pizza).Print();
        }
    }

    public List<Pizza> GetOrderList()
    {
        return _orderList;
    }

    public OrderSnapshot CreateSnapshot()
    {
        return new OrderSnapshot(_input);
    }

    public void Restore(OrderSnapshot snapshot)
    {
        _orderList.Clear();
        _orderList.AddRange(new Order(snapshot.State())._orderList);
    }

    public static Order Of(OrderSnapshot snapshot)
    {
        return new Order(snapshot.State());
    }
}