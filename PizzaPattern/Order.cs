namespace PizzaPattern;

public class Order
{
    public Order(string order)
    {
        Dictionary<string, int> orderList = new Dictionary<string, int>();

        string[] orderRows = order.Split(",");

        foreach (string orderRow in orderRows)
        {
            var trimmedRow = orderRow.Trim();
            string[] rowElements = trimmedRow.Split(" ");
            if (rowElements.Length > 2)
            {
                throw new Exception("Invalid order format !");
            }

            int numberOfPizza = int.Parse(rowElements[0]);
            if (numberOfPizza < 1)
            {
                throw new Exception("Invalid row format for row : " + trimmedRow);
            }

            Pizza pizza;
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

            if (orderList.ContainsKey(pizza.Name))
            {
                orderList[pizza.Name] += numberOfPizza;
            }
            else
            {
                orderList.Add(pizza.Name, numberOfPizza);
            }
        }

        foreach (var pair in orderList.Keys)
        {
            Console.WriteLine(pair + " " + orderList[pair]);
        }
    }
}