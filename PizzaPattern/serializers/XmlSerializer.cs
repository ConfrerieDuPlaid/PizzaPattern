namespace PizzaPattern.serializers;

public class XmlSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
        res += $"<bill total={DoubleUtils.ToUniversalFormat(bill.ComputeTotal())} devise=\"EUR\">\n";
        foreach (var pizza in bill.GetOrderRows())
        {
            res += pizza.AcceptSerializer(this);

        }
        res += "<\\bill>";
        return res;
    }

    public string SerializePizza(Pizza pizza)
    {
        string res = $"<pizza name=\"{pizza.Name}\" quantity={pizza.Count} unitPrice={DoubleUtils.ToUniversalFormat(pizza.Price)} devise=\"EUR\">\n";
        foreach (var ingredient in pizza.Ingredients)
        {
            res += ingredient.AcceptSerializer(this);
        }
        res += "<\\pizza>\n";
        return res;
    }

    public string SerializeIngredient(Ingredient ingredient)
    {
        return $"\t<ingredient name=\"{ingredient.Name}\" quantity={DoubleUtils.ToUniversalFormat(ingredient.Quantity)} unit=\"{ingredient.Unit}\" />\n";
    }
}