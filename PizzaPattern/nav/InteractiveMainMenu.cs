using PizzaPattern.serializers;

namespace PizzaPattern.nav;

public class InteractiveMainMenu : InteractiveNavigation
{
    protected override List<Option> Options { get; set; }
    protected override string MenuHeader { get; set; }

    protected override void SetOptions()
    {
        Options = new List<Option>
        {
            new Option("Place an order", this.PlaceOrder),
            new Option("Exit", () => Environment.Exit(0)),
        };
        this.SetMenuHeader(null);
    }
    protected override void SetMenuHeader(string? input)
    {
        this.MenuHeader = "Welcome to Pizza Pattern!";
    }

    private void PlaceOrder()
    {
        Console.Clear();
        new InteractiveOrderMenu().ReadOrder();
        Console.Clear();
        WriteMenu(this.Options, this.Options.First());
    }

}