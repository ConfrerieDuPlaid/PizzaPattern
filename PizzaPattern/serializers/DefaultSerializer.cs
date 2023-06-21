namespace PizzaPattern.serializers;

public class DefaultSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "";
        Pizza pizza;
        foreach (var row in bill.GetOrderRows())
        {
            pizza = row.Key;
            res += $"{row.Value} {pizza.Name} : {row.Value} * {pizza.Price}€\n";
            foreach (var ingredient in pizza.Ingredients)
            {
                res += $"{ingredient.Name} {ingredient.Unit} {ingredient.Quantity}\n";
            }
        }

        res += $"Prix total : {bill.ComputeTotal()}€";
        return res;
    }
}