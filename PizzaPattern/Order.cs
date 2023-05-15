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

            switch (rowElements[1])
            {
                case "Regina": pizza = Pizza.Regina();
                    break;
                case "4Seasons": pizza = Pizza.FourSeasons();
                    break;
                case "Vegetarian": pizza = Pizza.Vegetarian();
                    break;
                default:
                    throw new Exception("This pizza is not in the menu !");
            }

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

    public Dictionary<string, int> GetOrderList()
    {
        return this._orderList;
    } 
}