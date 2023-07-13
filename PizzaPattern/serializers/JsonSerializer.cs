namespace PizzaPattern.serializers;

public class JsonSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "{";
        Pizza pizza;
        List<string> pizzaList = new List<string>();
        foreach (var row in bill.GetOrderRows())
        {
            pizza = row.Key;
            pizzaList.Add(this.SerializePizza(pizza, row.Value));
        }

        res += string.Join(",", pizzaList) + ",";
        res += $"\"total\": \"{DoubleUtils.toUniversalFormat(bill.ComputeTotal())}€\"}}";
        return res;
    }

    public string SerializePizza(Pizza pizza, int pizzaCount)
    {
        string res = $"\"{pizza.Name}\":{{";
        res += $"\"quantity:\": {pizzaCount}, \"unitPrice\": {DoubleUtils.toUniversalFormat(pizza.Price)},";
        res += "\"ingredients\": [";
        List<string> ingredientsList = new List<string>();
        foreach (var ingredient in pizza.Ingredients)
        {
            ingredientsList.Add(this.SerializeIngredient(ingredient));
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