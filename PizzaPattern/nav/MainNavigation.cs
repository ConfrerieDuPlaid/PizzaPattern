using PizzaPattern.history;

namespace PizzaPattern.nav;

public class MainNavigation : InteractiveNavigation
{
    protected override List<Option> Options { get; set; } = new();
    protected override string MenuHeader { get; set; } = "";

    protected override void SetOptions()
    {
        Options = new List<Option>
        {
            new ("Place an order", PlaceOrder),
            new ("History of orders", PrintHistory),
            new ("Export history to file", ExportHistory),
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
        new OrderNavigation().ReadOrder();
        Console.Clear();
        WriteMenu(Options, Options.First());
    }

    private void PrintHistory()
    {
        Console.Clear();
        OrderHistory.GetInstance().Print();
        ExitPrint();
    }

    private void ExportHistory()
    {
        Console.Clear();
        OrderHistory.GetInstance().Export();
        Console.WriteLine("Exporté !");
        ExitPrint();
    }
}