namespace PizzaPattern.serializers;

public class JsonSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "{";
        List<string> pizzaList = new List<string>();
        foreach (var pizza in bill.GetOrderRows())
        {
            pizzaList.Add(this.SerializePizza(pizza));
        }

        res += string.Join(",", pizzaList) + ",";
        res += $"\"total\": \"{DoubleUtils.toUniversalFormat(bill.ComputeTotal())}€\"}}";
        return res;
    }

    public string SerializePizza(Pizza pizza)
    {
        string res = $"\"{pizza.Name}\":{{";
        res += $"\"quantity:\": {pizza.Count}, \"unitPrice\": {DoubleUtils.toUniversalFormat(pizza.Price)},";
        res += "\"ingredients\": [";
        List<string> ingredientsList = new List<string>();
        foreach (var ingredient in pizza.Ingredients)
        {
            ingredientsList.Add(ingredient.AcceptSerializer(this));
        }

        res += string.Join(",", ingredientsList);
        res += "]}";
        return res;
    }

    public string SerializeIngredient(Ingredient ingredient)
    {
        return $"{{\"name\": \"{ingredient.Name}\", \"unit\": \"{ingredient.Unit}\", \"quantity\": {DoubleUtils.toUniversalFormat(ingredient.Quantity)}}}";
    }
}