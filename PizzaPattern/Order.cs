namespace PizzaPattern;

public class Order
{
    private readonly Dictionary<string, int> _orderList = new Dictionary<string, int>();
    
    public Order(string order)
    {
        string[] orderRows = order.Split(",");

        Pizza pizza;
        int numberOfPizza = 0;
        foreach (string orderRow in orderRows)
        {
            string[] rowElements = orderRow.Trim().Split(" ");
            if (rowElements.Length > 2)
            {
                throw new Exception("Invalid order format !");
            }

            numberOfPizza = int.Parse(rowElements[0]);
            if (numberOfPizza < 1)
            {
                throw new Exception("Invalid row format for row : " + orderRow);
            }

            pizza = Pizza.Of(rowElements[1]);
            if (_orderList.ContainsKey(pizza.Name))
            {
                _orderList[pizza.Name] += numberOfPizza;
            }
            else
            {
                _orderList.Add(pizza.Name, numberOfPizza);
            }
        }
    }

    public void PrintAllInstructions()
    {
        Pizza pizza;
        foreach (string pizzaName in _orderList.Keys)
        {
            pizza = Pizza.Of(pizzaName);
            pizza.PrintInstructions();
        }
    }

    public Dictionary<string, int> GetOrderList()
    {
        return this._orderList;
    } 
}