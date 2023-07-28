namespace PizzaPattern;

public class Menu
{
    private List<StandardPizza> StandardPizzas { get; } = new ();

    public Menu()
    {
        StandardPizzas.Add(StandardPizza.Regina());
        StandardPizzas.Add(StandardPizza.FourSeasons());
        StandardPizzas.Add(StandardPizza.Vegetarian());
    }

    public void Print()
    {
        Console.WriteLine("*** Menu ***");
        foreach (var pizza in StandardPizzas)
        {
            Console.WriteLine("- " + pizza.Name + " : " + pizza.Price + " €");
        }
        Console.WriteLine("You can add 50 grams of an ingredient with +Ingredient or remove an with -Ingredient for 50 cents / ingredient");
    }
}