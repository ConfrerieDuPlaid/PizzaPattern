namespace PizzaPattern;

public class Menu
{
    private List<StandardPizza> _menu { get; } = new List<StandardPizza>();

    public Menu()
    {
        this._menu.Add(StandardPizza.Regina());
        this._menu.Add(StandardPizza.FourSeasons());
        this._menu.Add(StandardPizza.Vegetarian());
    }

    public void PrintMenu()
    {
        Console.WriteLine("*** Menu ***");
        foreach (StandardPizza pizza in _menu)
        {
            Console.WriteLine("- " + pizza.Name);
        }
        Console.WriteLine("You can add 50 grams of an ingredient with +Ingredient or remove an with -Ingredient for 50 cents / ingredient");
    }
}