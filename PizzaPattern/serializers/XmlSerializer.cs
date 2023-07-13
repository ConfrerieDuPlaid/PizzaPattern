using System.Text.Json.Nodes;
using System.Xml;

namespace PizzaPattern.serializers;

public class XmlSerializer : ISerializer
{
    public string Serialize(Bill bill)
    {
        string res = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
        res += $"<bill total={DoubleUtils.toUniversalFormat(bill.ComputeTotal())} devise=\"EUR\">\n";
        Pizza pizza;
        foreach (var row in bill.GetOrderRows())
        {
            pizza = row.Key;
            res += this.SerializePizza(pizza, row.Value);

        }
        res += "<\\bill>";
        return res;
    }

    public string SerializePizza(Pizza pizza, int pizzaCount)
    {
        string res = $"<pizza name=\"{pizza.Name}\" quantity={pizzaCount} unitPrice={DoubleUtils.toUniversalFormat(pizza.Price)} devise=\"EUR\">\n";
        foreach (var ingredient in pizza.Ingredients)
        {
            res += ingredient.AcceptSerializer(this);
        }
        res += "<\\pizza>\n";
        return res;
    }

    public string SerializeIngredient(Ingredient ingredient)
    {
        return $"\t<ingredient name=\"{ingredient.Name}\" quantity={DoubleUtils.toUniversalFormat(ingredient.Quantity)} unit=\"{ingredient.Unit}\" />\n";
    }
}