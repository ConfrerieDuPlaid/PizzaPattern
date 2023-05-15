namespace PizzaPattern;

public class Pizza
{
    public string Name { get; }
    public List<Ingredient> Ingredients { get; }
    public double Price { get; }
    
    public List<string> Instructions { get; }
    
    public Pizza(string name, List<Ingredient> ingredients, double price, List<string> instructions)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
        Instructions = instructions;
    }

    public void PrintInstructions()
    {
        Console.WriteLine(Name);
        foreach (var instruction in Instructions)
        {
            Console.WriteLine(instruction);
        }
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
        var instructions = InitInstructions(ingredients);
        return new Pizza("Regina", ingredients, 8.0, instructions);
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
        var instructions = InitInstructions(ingredients);
        return new Pizza("4Seasons", ingredients, 9.0, instructions);
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
        var instructions = InitInstructions(ingredients);
        return new Pizza("Vegetarian", ingredients, 7.5, instructions);
    }
}