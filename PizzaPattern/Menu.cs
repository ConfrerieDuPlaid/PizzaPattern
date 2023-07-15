using PizzaPattern.serializers;

namespace PizzaPattern;

public class Menu
{
    private List<StandardPizza> StandardPizzas { get; } = new List<StandardPizza>();
    private Dictionary<string, ISerializer> Serializers { get; } = new Dictionary<string, ISerializer>();

    public Menu()
    {
        this.StandardPizzas.Add(StandardPizza.Regina());
        this.StandardPizzas.Add(StandardPizza.FourSeasons());
        this.StandardPizzas.Add(StandardPizza.Vegetarian());
        this.Serializers.Add("console", new DefaultSerializer());
        this.Serializers.Add("json", new JsonSerializer());
        this.Serializers.Add("xml", new XmlSerializer());
    }

    public void PrintPizzaMenu()
    {
        Console.WriteLine("*** Menu ***");
        foreach (StandardPizza pizza in StandardPizzas)
        {
            Console.WriteLine("- " + pizza.Name);
        }
        Console.WriteLine("You can add 50 grams of an ingredient with +Ingredient or remove an with -Ingredient for 50 cents / ingredient");
    }

    public void PrintActionsMenu()
    {
        Console.WriteLine("Thank you for your order! Do you want to print the :");
        Console.WriteLine("- bill ");
        Console.WriteLine("- instructions ");
        Console.WriteLine("Or you can exit the order.");
    }

    public void PrintBill(Bill bill, string serializer)
    {
        if (!this.Serializers.ContainsKey(serializer))
            throw new Exception($"Serializer {serializer} not accepted");
        string serialized = bill.AcceptSerializer(this.Serializers[serializer]);
        Console.WriteLine(serializer);
    }
}