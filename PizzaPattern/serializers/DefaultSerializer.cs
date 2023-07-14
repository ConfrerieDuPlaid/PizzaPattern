namespace PizzaPattern.serializers;

public class DefaultSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "";
        foreach (var pizza in bill.GetOrderRows())
        {
            res += this.SerializePizza(pizza);
        }

        res += $"Prix total : {DoubleUtils.toUniversalFormat(bill.ComputeTotal())}€";
        return res;
    }

    public string SerializePizza(Pizza pizza)
    {
        string res = $"{pizza.Count} {pizza.Name} : {pizza.Count} * {DoubleUtils.toUniversalFormat(pizza.Price)}€\n";
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