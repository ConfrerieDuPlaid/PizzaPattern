namespace PizzaPattern;

public class Pizza
{
    public string Name { get; }
    public List<Ingredient> Ingredients { get; }
    public double Price { get; }
    
    
    public Pizza(string name, List<Ingredient> ingredients, double price)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
    }

    public static Pizza Regina()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 150, Unit.Grams),
            new Ingredient("Mozzarella", 125, Unit.Grams),
            new Ingredient("Grated cheese", 100, Unit.Grams),
            new Ingredient("Ham", 2, Unit.Slices),
            new Ingredient("Mushrooms", 4, Unit.Pieces),
            new Ingredient("Olive oil", 2, Unit.Tablespoons)
        };
        return new Pizza("Regina", ingredients, 8.0);
    }

    public static Pizza FourSeasons()
    {
        var ingredients = new List<Ingredient>()
        {
            new Ingredient("Tomato", 150, Unit.Grams),
            new Ingredient("Mozzarella", 125, Unit.Grams),
            new Ingredient("Ham", 2, Unit.Slices),
            new Ingredient("Mushrooms", 100, Unit.Grams),
            new Ingredient("Peppers", 0.5, Unit.Pieces),
            new Ingredient("Olives", 1, Unit.Handful)
        };
        return new Pizza("4Seasons", ingredients, 9.0);
    }

    public static Pizza Vegetarian()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 150, Unit.Grams),
            new Ingredient("Mozzarella", 100, Unit.Grams),
            new Ingredient("Zucchini", 0.5, Unit.Pieces),
            new Ingredient("Peppers", 1, Unit.Pieces),
            new Ingredient("Cherry tomatoes", 6, Unit.Pieces),
            new Ingredient("Olives", 1, Unit.Handful)
        };
        return new Pizza("Vegetarian", ingredients, 7.5);
    }
}