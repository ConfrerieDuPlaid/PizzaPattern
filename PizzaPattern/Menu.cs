namespace PizzaPattern;

public class Menu
{
    private List<Pizza> _menu { get; } = new List<Pizza>();

    public Menu()
    {
        this._menu.Add(Pizza.Regina());
        this._menu.Add(Pizza.FourSeasons());
        this._menu.Add(Pizza.Vegetarian());
    }

    public void PrintMenu()
    {
        Console.WriteLine("*** Menu ***");
        foreach (Pizza pizza in _menu)
        {
            Console.WriteLine("- " + pizza.Name);
        }
    }
}