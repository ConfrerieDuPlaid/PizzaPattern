namespace PizzaPattern.serializers;

public class DefaultSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "";
        foreach (var pizza in bill.GetOrderRows())
        {
            res += pizza.AcceptSerializer(this);
        }

        res += $"Prix total : {DoubleUtils.ToUniversalFormat(bill.ComputeTotal())}€";
        return res;
    }

    public string SerializePizza(Pizza pizza)
    {
        string res = $"{pizza.Count} {pizza.Name} : {pizza.Count} * {DoubleUtils.ToUniversalFormat(pizza.Price)}€\n";
        foreach (var ingredient in pizza.Ingredients)
        {
            res += ingredient.AcceptSerializer(this);
        }

        return res;
    }

    public string SerializeIngredient(Ingredient ingredient)
    {
        return $"- {ingredient.Name} {ingredient.Unit} {DoubleUtils.ToUniversalFormat(ingredient.Quantity)}\n";
    }
}