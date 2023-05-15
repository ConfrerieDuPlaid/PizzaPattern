namespace PizzaPattern;

public class Pizza
{
    public string Name { get; set; }
    private List<Ingredient> Ingredients { get; set; }
    private double Price { get; set; }
    
    
    public Pizza(string name, List<Ingredient> ingredients, double price)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
    }

    public static Pizza Regina()
    {
        var ingredients = new List<Ingredient>();
        return new Pizza("Regina", ingredients, 8.0);
    }

    public static Pizza FourSeasons()
    {
        var ingredients = new List<Ingredient>();
        return new Pizza("4Seasons", ingredients, 9.0);
    }

    public static Pizza Vegetarian()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 150, Unit.Grams),
            new Ingredient("Mozzarella", 100, Unit.Grams)
        };
        return new Pizza("Vegetarian", ingredients, 7.5);
    }
}