namespace PizzaPattern.nav;

public class InteractiveMainMenu : InteractiveNavigation
{
    protected override List<Option> Options { get; set; }
    protected override string MenuHeader { get; set; }

    protected override void SetOptions()
    {
        Options = new List<Option>
        {
            new ("Place an order", PlaceOrder),
            new ("Exit", () => Environment.Exit(0)),
        };
        SetMenuHeader(null);
    }
    protected override void SetMenuHeader(string? input)
    {
        MenuHeader = "Welcome to Pizza Pattern!";
    }

    private void PlaceOrder()
    {
        Console.Clear();
        new InteractiveOrderMenu().ReadOrder();
        Console.Clear();
        WriteMenu(Options, Options.First());
    }

}