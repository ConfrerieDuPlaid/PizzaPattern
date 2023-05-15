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
            pizza = Pizza.Of(pizzaName);
        
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