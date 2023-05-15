namespace PizzaPattern;

public class Bill
{
    public static void PrintBill(Order order)
    {
        Pizza pizza;
        double totalPrice = 0.0;
        Dictionary<string, int> orderList = order.GetOrderList();
        foreach (string pizzaName in orderList.Keys)
        {
            switch (pizzaName)
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
        
            Console.WriteLine("{0} {1} : {0} * {2}€", orderList[pizzaName], pizzaName, pizza.Price);
            totalPrice += orderList[pizzaName] * pizza.Price;

            foreach (var ingredient in pizza.Ingredients)
            {
                Console.WriteLine("{0} {1} {2}", ingredient.Name, ingredient.Unit, ingredient.Quantity);
            }
        }
        Console.WriteLine("Prix total : {0}€", totalPrice);
    }
}