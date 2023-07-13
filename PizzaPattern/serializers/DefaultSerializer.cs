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
            res += this.SerializePizza(pizza, row.Value);
        }

        res += $"Prix total : {DoubleUtils.toUniversalFormat(bill.ComputeTotal())}€";
        return res;
    }

    public string SerializePizza(Pizza pizza, int pizzaCount)
    {
        string res = $"{pizzaCount} {pizza.Name} : {pizzaCount} * {DoubleUtils.toUniversalFormat(pizza.Price)}€\n";
        foreach (var ingredient in pizza.Ingredients)
        {
            res += ingredient.AcceptSerializer(this);
        }

        return res;
    }

    public string SerializeIngredient(Ingredient ingredient)
    {
        return $"- {ingredient.Name} {ingredient.Unit} {DoubleUtils.toUniversalFormat(ingredient.Quantity)}\n";
    }
}