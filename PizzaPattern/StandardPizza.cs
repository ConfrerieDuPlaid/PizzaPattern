namespace PizzaPattern;

public class StandardPizza : IPizza
{
    public string Name { get; }
    public List<Ingredient> Ingredients { get; }
    public double Price { get; }

    private StandardPizza(string name, List<Ingredient> ingredients, double price)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
    }

    private bool Equals(StandardPizza other)
    {
        return Name == other.Name && Ingredients.Equals(other.Ingredients) && Price.Equals(other.Price);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((StandardPizza)obj);
    }

    private static List<string> InitInstructions(List<Ingredient> ingredients)
    {
        var instructions = new List<string>()
        {
            "Prepare the dough"
        };
        foreach (var ingredient in ingredients)
        {
            instructions.Add("Add the " + ingredient.Name);
        }
        instructions.Add("Bake the pizza");
        return instructions;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Ingredients, Price);
    }

    public static StandardPizza Regina()
    {
        var ingredients = new List<Ingredient>
        {
            new("Tomato", 150, Unit.Grams),
            new("Mozzarella", 125, Unit.Grams),
            new("Grated cheese", 100, Unit.Grams),
            new("Ham", 2, Unit.Slices),
            new("Mushrooms", 4, Unit.Pieces),
            new("Olive oil", 2, Unit.Tablespoons)
        };
        return new StandardPizza("Regina", ingredients, 8.0);
    }

    public static StandardPizza FourSeasons()
    {
        var ingredients = new List<Ingredient>
        {
            new("Tomato", 150, Unit.Grams),
            new("Mozzarella", 125, Unit.Grams),
            new("Ham", 2, Unit.Slices),
            new("Mushrooms", 100, Unit.Grams),
            new("Peppers", 0.5, Unit.Pieces),
            new("Olives", 1, Unit.Handful)
        };
        return new StandardPizza("4Seasons", ingredients, 9.0);
    }

    public static StandardPizza Vegetarian()
    {
        var ingredients = new List<Ingredient>
        {
            new("Tomato", 150, Unit.Grams),
            new("Mozzarella", 100, Unit.Grams),
            new("Zucchini", 0.5, Unit.Pieces),
            new("Peppers", 1, Unit.Pieces),
            new("Cherry tomatoes", 6, Unit.Pieces),
            new("Olives", 1, Unit.Handful)
        };
        return new StandardPizza("Vegetarian", ingredients, 7.5);
    }

    public static StandardPizza Of (string pizzaName)
    {
        switch (pizzaName)
        {
            case "Regina":
                return Regina();
            case "4Seasons":
                return FourSeasons();
            case "Vegetarian":
                return Vegetarian();
            default:
                throw new Exception("This pizza is not in the menu !");
        }
    }
    
    
}